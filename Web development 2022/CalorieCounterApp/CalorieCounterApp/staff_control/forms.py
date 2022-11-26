from django import forms

from CalorieCounterApp.core.models import Food, Meal, FoodPlan, Exercise, Motivation


class FoodCreationForm(forms.ModelForm):
    class Meta:
        model = Food
        fields = ("name", "calories_per_100g", "fats_per_100g", "protein_per_100g", "carbs_per_100g")


class FoodEditForm(forms.ModelForm):
    class Meta:
        model = Food
        fields = ("calories_per_100g", "fats_per_100g", "protein_per_100g", "carbs_per_100g")


class MealCreationForm(forms.ModelForm):
    class Meta:
        model = Meal
        fields = ("name", "calories", "grams", "fats_grams", "protein_grams", "carbs_grams")


class MealEditForm(forms.ModelForm):
    class Meta:
        model = Meal
        fields = ("fats_grams", "protein_grams", "carbs_grams")


class FoodPlanCreationForm(forms.ModelForm):
    class Meta:
        model = FoodPlan
        fields = ("name", "image_url", "meals", "food")


class FoodPlanEditForm(forms.ModelForm):
    class Meta:
        model = FoodPlan
        fields = ("image_url", "meals", "food")


class ExerciseCreationForm(forms.ModelForm):
    class Meta:
        model = Exercise
        fields = ("name", "metabolic_equivalent")


class ExerciseEditForm(forms.ModelForm):
    class Meta:
        model = Exercise
        fields = ("metabolic_equivalent",)


class MotivationEditForm(forms.ModelForm):
    class Meta:
        model = Motivation
        fields = ("quote", "description")

