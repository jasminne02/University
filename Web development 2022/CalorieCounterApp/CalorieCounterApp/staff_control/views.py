from django.shortcuts import render, redirect

from CalorieCounterApp.core.models import Food, Meal, FoodPlan, Exercise, Motivation
from CalorieCounterApp.staff_control.forms import FoodCreationForm, FoodEditForm, MealEditForm, MealCreationForm, \
    FoodPlanEditForm, FoodPlanCreationForm, ExerciseEditForm, ExerciseCreationForm, MotivationEditForm


def index(request):
    context = {
        'foods': Food.objects.all(),
        'meals': Meal.objects.all(),
        'food_plans': FoodPlan.objects.all(),
        'exercises': Exercise.objects.all(),
        'motivations': Motivation.objects.all(),
    }
    return render(request, 'staff_control/control.html', context)


def add_food(request):
    if request.method == 'POST':
        form = FoodCreationForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('control')
    else:
        form = FoodCreationForm()

    context = {
        'form': form,
    }
    return render(request, 'staff_control/add_food.html', context)


def edit_food(request, pk):
    food = Food.objects.get(pk=pk)

    if request.method == 'POST':
        form = FoodEditForm(request.POST, instance=food)
        if form.is_valid():
            form.save()
            return redirect('control')
    else:
        form = FoodEditForm(instance=food)

    context = {
        'form': form,
        'food': food,
    }
    return render(request, 'staff_control/edit_food.html', context)


def delete_food(request, pk):
    Food.objects.get(pk=pk).delete()
    return redirect('control')


def add_meal(request):
    if request.method == 'POST':
        form = MealCreationForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('control')
    else:
        form = MealCreationForm()

    context = {
        'form': form,
    }
    return render(request, 'staff_control/add_meal.html', context)


def edit_meal(request, pk):
    meal = Meal.objects.get(pk=pk)

    if request.method == 'POST':
        form = MealEditForm(request.POST, instance=meal)
        if form.is_valid():
            form.save()
            return redirect('control')
    else:
        form = MealEditForm(instance=meal)

    context = {
        'form': form,
        'meal': meal,
    }
    return render(request, 'staff_control/edit_meal.html', context)


def delete_meal(request, pk):
    Meal.objects.filter(pk=pk).first().delete()
    return redirect('control')


def add_plan(request):
    if request.method == 'POST':
        form = FoodPlanCreationForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('control')
    else:
        form = FoodPlanCreationForm()

    context = {
        'form': form,
    }
    return render(request, 'staff_control/add_plan.html', context)


def edit_plan(request, pk):
    plan = FoodPlan.objects.get(pk=pk)

    if request.method == 'POST':
        form = FoodPlanEditForm(request.POST, instance=plan)
        if form.is_valid():
            form.save()
            return redirect('control')
    else:
        form = FoodPlanEditForm(instance=plan)

    context = {
        'form': form,
        'plan': plan,
    }
    return render(request, 'staff_control/edit_plan.html', context)


def delete_plan(request, pk):
    plan = FoodPlan.objects.get(pk=pk)
    plan.delete()
    return redirect('control')


def add_exercise(request):
    if request.method == 'POST':
        form = ExerciseCreationForm(request.POST)
        if form.is_valid():
            form.save()
            return redirect('control')
    else:
        form = ExerciseCreationForm()

    context = {
        'form': form,
    }
    return render(request, 'staff_control/add_exercise.html', context)


def edit_exercise(request, pk):
    exercise = Exercise.objects.get(pk=pk)

    if request.method == 'POST':
        form = ExerciseEditForm(request.POST, instance=exercise)
        if form.is_valid():
            form.save()
            return redirect('control')
    else:
        form = ExerciseEditForm(instance=exercise)

    context = {
        'form': form,
        'exercise': exercise,
    }
    return render(request, 'staff_control/edit_exercise.html', context)


def delete_exercise(request, pk):
    plan = Exercise.objects.filter(pk=pk).first()
    plan.delete()
    return redirect('control')


def edit_motivation(request, pk):
    motivation = Motivation.objects.get(pk=pk)

    if request.method == 'POST':
        form = MotivationEditForm(request.POST, instance=motivation)
        if form.is_valid():
            form.save()
            return redirect('control')
    else:
        form = MotivationEditForm(instance=motivation)

    context = {
        'form': form,
    }
    return render(request, 'staff_control/edit_motivation.html', context)


def delete_motivation(request, pk):
    plan = Motivation.objects.filter(pk=pk)
    plan.first().delete()
    return redirect('control')

