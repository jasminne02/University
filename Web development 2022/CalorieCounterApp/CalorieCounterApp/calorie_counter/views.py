import datetime

from django.shortcuts import render, redirect

from CalorieCounterApp.accounts.models import CustomUser
from CalorieCounterApp.core.models import Food, Meal, FoodPlan, Exercise
from CalorieCounterApp.calorie_counter.models import DailyData
from CalorieCounterApp.calorie_counter.forms import SearchFoodForm, SearchActivityForm, AddFoodForm, AddActivityForm


def get_weekly_data(user):
    try:
        today = datetime.date.today()
        return DailyData.objects. \
            filter(user_id=user.id,
                   date__lte=today,
                   date__gt=datetime.date(today.year, today.month, today.day - 7)) \
            .order_by('date')
    except DailyData.DoesNotExist:
        return None


def get_daily_data(user):
    try:
        today_min = datetime.datetime.combine(datetime.date.today(), datetime.time.min)
        today_max = datetime.datetime.combine(datetime.date.today(), datetime.time.max)
        return DailyData.objects.get(user_id=user.id, date__range=(today_min, today_max))
    except DailyData.DoesNotExist:
        create_daily_data(user)
        return None


def create_daily_data(user):
    daily_data = DailyData.objects.create(date=datetime.date.today(), user_id=user)
    daily_data.total_calories = user.calories_per_day
    daily_data.calories_eaten = 0
    daily_data.calories_burnt = 0
    daily_data.carbs_grams_per_day = 0
    daily_data.proteins_grams_per_day = 0
    daily_data.fats_grams_per_day = 0
    daily_data.save()


def calculate_left_calories(user, daily_data):
    if daily_data:
        return daily_data.total_calories - daily_data.calories_eaten
    else:
        return user.calories_per_day


def calculate_eaten_calories(food, quantity):
    calories_per_gram = food.calories / food.grams
    return calories_per_gram * quantity


def calculate_eaten_fats(food, quantity):
    fats_per_gram = food.fats_grams / food.grams
    return fats_per_gram * quantity


def calculate_eaten_protein(food, quantity):
    protein_per_gram = food.protein_grams / food.grams
    return protein_per_gram * quantity


def calculate_eaten_carbs(food, quantity):
    carbs_per_gram = food.carbs_grams / food.grams
    return carbs_per_gram * quantity


def calculate_burnt_calories(user: CustomUser, activity: Exercise, active_minutes: int):
    return active_minutes * (activity.metabolic_equivalent * 3.5 * user.weight) / 200


def food_search_query(searched):
    try:
        return Food.objects.get(name=searched)
    except Food.DoesNotExist:
        searched = Meal.objects.filter(name__icontains=searched)
        if searched.count() > 0:
            return searched.first()
        else:
            return 'No search results'


def activity_search_query(searched):
    searched = Exercise.objects.filter(name__icontains=searched)
    if searched.count() > 0:
        return searched.first()
    else:
        return 'No search results'


def show_calorie_counter(request):
    user = CustomUser.objects.get(username=request.user.username)
    daily_data = get_daily_data(user)
    food_search_form = SearchFoodForm()
    activity_search_form = SearchActivityForm()

    food_searched_object = None
    activity_searched_object = None

    if request.method == 'POST':
        if 'search-food' in request.POST:
            food_search_form = SearchFoodForm(request.POST)
            if food_search_form.is_valid():
                searched = food_search_form.cleaned_data['name']
                food_searched_object = food_search_query(searched)
        elif 'search-activity' in request.POST:
            activity_search_form = SearchActivityForm(request.POST)
            if activity_search_form.is_valid():
                searched = activity_search_form.cleaned_data['name']
                activity_searched_object = activity_search_query(searched)

    context = {
        'user': user,
        'left_calories': calculate_left_calories(user, daily_data),
        'daily_data': daily_data,
        'food_search_form': food_search_form,
        'activity_search_form': activity_search_form,
        'food_searched_object': food_searched_object,
        'activity_searched_object': activity_searched_object,
        'weekly_data': get_weekly_data(user),
    }

    return render(request, 'calorie_counter/calorie_counter.html', context)


def add_activity(request, pk):
    user = CustomUser.objects.get(username=request.user.username)
    activity_object = Exercise.objects.get(pk=pk)
    form = AddActivityForm()

    if request.method == 'POST':
        form = AddActivityForm(request.POST)
        if form.is_valid():
            daily_data = get_daily_data(user)
            activity_object.daily_data_pk.add(daily_data.pk)
            activity_object.save()

            active_minutes = form.cleaned_data['active_minutes']
            daily_data.calories_burnt += calculate_burnt_calories(user=user, active_minutes=active_minutes,
                                                                  activity=activity_object)
            if form.cleaned_data['add_burnt_to_total']:
                daily_data.total_calories += daily_data.calories_burnt
            daily_data.save()
            return redirect('calorie counter')

    context = {
        'form': form,
        'activity_name': activity_object.name,
    }

    return render(request, 'calorie_counter/add_activity.html', context)


def add_food(request, name):
    user = CustomUser.objects.get(username=request.user.username)
    food_object = food_search_query(name)
    form = AddFoodForm()

    if request.method == 'POST':
        form = AddFoodForm(request.POST)
        if form.is_valid():
            daily_data = get_daily_data(user)
            food_object.daily_data_pk.add(daily_data.pk)
            food_object.save()

            grams = form.cleaned_data['grams']
            daily_data.calories_eaten += calculate_eaten_calories(food_object, grams)
            daily_data.fats_grams_per_day += calculate_eaten_fats(food_object, grams)
            daily_data.proteins_grams_per_day += calculate_eaten_protein(food_object, grams)
            daily_data.carbs_grams_per_day += calculate_eaten_carbs(food_object, grams)
            daily_data.save()
            return redirect('calorie counter')

    context = {
        'form': form,
        'food_name': food_object.name,
    }

    return render(request, 'calorie_counter/add_food.html', context)


def today_details(request):
    user = CustomUser.objects.get(username=request.user.username)
    daily_data = get_daily_data(user)

    context = {
        'daily_data': daily_data,
        'activities': Exercise.objects.filter(daily_data_pk=daily_data.pk),
        'meals': Meal.objects.filter(daily_data_pk=daily_data.pk),
        'food': Food.objects.filter(daily_data_pk=daily_data.pk),
        'food_plans': FoodPlan.objects.filter(daily_data_pk=daily_data.pk),
    }

    return render(request, 'calorie_counter/today_details.html', context)
