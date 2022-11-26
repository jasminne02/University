from django.contrib.auth.models import Group
from django.shortcuts import render, redirect
from django.urls import reverse_lazy
from django.views import generic as views

from CalorieCounterApp.core.forms import MotivationsCreateForm
from CalorieCounterApp.core.models import FoodPlan, Motivation
from CalorieCounterApp.calorie_counter.views import get_daily_data, calculate_eaten_carbs, calculate_eaten_protein, \
    calculate_eaten_fats, calculate_eaten_calories
from CalorieCounterApp.accounts.models import CustomUser


def is_user_in_group(request, value):
    try:
        return request.user.groups.get(name=value)
    except Group.DoesNotExist:
        return None


def add_food_to_daily_data(daily_data, food):
    for f in food:
        daily_data.calories_eaten += calculate_eaten_calories(f, 100)
        daily_data.fats_grams_per_day += calculate_eaten_fats(f, 100)
        daily_data.carbs_grams_per_day += calculate_eaten_carbs(f, 100)
        daily_data.proteins_grams_per_day += calculate_eaten_protein(f, 100)


def add_meal_to_daily_data(daily_data, meals):
    for meal in meals:
        daily_data.calories_eaten += calculate_eaten_calories(meal, meal.grams)
        daily_data.fats_grams_per_day += calculate_eaten_fats(meal, meal.grams)
        daily_data.carbs_grams_per_day += calculate_eaten_carbs(meal, meal.grams)
        daily_data.proteins_grams_per_day += calculate_eaten_protein(meal, meal.grams)


def show_homepage(request):
    context = {
        'motivations': Motivation.objects.all()[:3],
        'motivation_group': is_user_in_group(request, 'Motivations'),
        'staff_group': is_user_in_group(request, 'Staff'),
    }
    return render(request, 'core/home.html', context)


def show_about_page(request):
    return render(request, 'core/about.html')


def add_plan_for_the_day(request, pk):
    user = CustomUser.objects.get(username=request.user.username)
    food_plan = FoodPlan.objects.get(pk=pk)
    daily_data = get_daily_data(user)
    food_plan.daily_data_pk.add(daily_data.pk)
    food_plan.save()

    food = food_plan.food.all()
    meals = food_plan.meals.all()
    add_food_to_daily_data(daily_data, food)
    add_meal_to_daily_data(daily_data, meals)
    daily_data.save()

    return redirect('calorie counter')


class FoodPlansView(views.ListView):
    queryset = FoodPlan.objects.all()
    template_name = 'core/food_plans.html'


class FoodPlanDetailsView(views.DetailView):
    model = FoodPlan
    template_name = 'core/food_details.html'

    def get_context_data(self, **kwargs):
        context = super(FoodPlanDetailsView, self).get_context_data(**kwargs)

        context['meals'] = self.object.meals.all()
        context['food'] = self.object.food.all()
        return context


class AddMotivationView(views.CreateView):
    model = Motivation
    form_class = MotivationsCreateForm
    template_name = 'account/add_motivations.html'
    success_url = reverse_lazy('motivations')


class MotivationsView(views.ListView):
    queryset = Motivation.objects.all()
    template_name = 'core/all_motivations.html'
