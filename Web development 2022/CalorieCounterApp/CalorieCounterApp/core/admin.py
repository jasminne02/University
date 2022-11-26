from django.contrib import admin

from CalorieCounterApp.core.models import Food, Exercise, FoodPlan, Meal, Motivation


@admin.register(Exercise)
class ExerciseAdmin(admin.ModelAdmin):
    list_display = ('name', 'metabolic_equivalent')
    list_display_links = ('name',)
    ordering = ('name',)
    search_fields = ('name',)
    list_filter = ('metabolic_equivalent',)


@admin.register(Food)
class FoodAdmin(admin.ModelAdmin):
    list_display = ('name', 'calories_per_100g',)
    list_display_links = ('name',)
    search_fields = ('name',)
    ordering = ('name', 'calories_per_100g')
    list_filter = ('calories_per_100g', 'fats_per_100g', 'protein_per_100g', 'carbs_per_100g')


@admin.register(Meal)
class MealAdmin(admin.ModelAdmin):
    list_display = ('name', 'calories', 'grams', 'fats_grams', 'protein_grams', 'carbs_grams')
    list_display_links = ('name',)
    search_fields = ('name',)
    ordering = ('name', 'calories', 'grams')
    list_filter = ('calories', 'grams', 'fats_grams', 'protein_grams', 'carbs_grams')


@admin.register(FoodPlan)
class FoodPlanAdmin(admin.ModelAdmin):
    list_display = ('name', 'details')
    list_display_links = ('name',)
    search_fields = ('name', 'details')
    readonly_fields = ('calories', 'grams',)
    ordering = ('name',)


@admin.register(Motivation)
class MotivationAdmin(admin.ModelAdmin):
    list_display = ('quote',)
    ordering = ('quote',)
    search_fields = ('quote', 'description')
