from django.core import validators
from django.db import models

from CalorieCounterApp.accounts.models import CustomUser
from CalorieCounterApp.calorie_counter.models import DailyData


class Exercise(models.Model):
    name = models.CharField(
        max_length=100,
    )

    metabolic_equivalent = models.FloatField(
        validators=(validators.MinValueValidator(0),),
    )

    daily_data_pk = models.ManyToManyField(
        DailyData,
        blank=True,
    )

    def __str__(self):
        return self.name

    class Meta:
        ordering = ('name',)


class Food(models.Model):
    name = models.CharField(
        max_length=100,
    )

    calories_per_100g = models.FloatField(
        validators=(validators.MinValueValidator(0),),
    )

    fats_per_100g = models.FloatField(
        validators=(validators.MinValueValidator(0),),
    )

    protein_per_100g = models.FloatField(
        validators=(validators.MinValueValidator(0),),
    )

    carbs_per_100g = models.FloatField(
        validators=(validators.MinValueValidator(0),),
    )

    daily_data_pk = models.ManyToManyField(
        DailyData,
        blank=True,
    )

    @property
    def calories(self):
        return self.calories_per_100g

    @property
    def grams(self):
        return 100

    @property
    def fats_grams(self):
        return self.fats_per_100g

    @property
    def protein_grams(self):
        return self.protein_per_100g

    @property
    def carbs_grams(self):
        return self.carbs_per_100g

    def __str__(self):
        return self.name

    class Meta:
        ordering = ('name',)


class Meal(models.Model):
    name = models.CharField(
        max_length=100,
    )

    calories = models.FloatField(
        validators=(validators.MinValueValidator(1),),
    )

    grams = models.PositiveIntegerField()

    fats_grams = models.FloatField(
        validators=(validators.MinValueValidator(1),),
    )

    protein_grams = models.FloatField(
        validators=(validators.MinValueValidator(1),),
    )

    carbs_grams = models.FloatField(
        validators=(validators.MinValueValidator(1),),
    )

    daily_data_pk = models.ManyToManyField(
        DailyData,
        blank=True,
    )

    def __str__(self):
        return self.name

    class Meta:
        ordering = ('name',)


class FoodPlan(models.Model):
    name = models.CharField(
        max_length=150,
    )

    details = models.TextField(
        blank=True,
        null=True,
    )

    meals = models.ManyToManyField(Meal)

    food = models.ManyToManyField(Food, blank=True)

    image_url = models.URLField()

    daily_data_pk = models.ManyToManyField(
        DailyData,
        blank=True,
    )

    @property
    def calories(self):
        calories = 0
        for meal in self.meals.all():
            calories += meal.calories
        for f in self.food.all():
            calories += f.calories_per_100g
        return calories

    @property
    def grams(self):
        grams = 0
        for meal in self.meals.all():
            grams += meal.grams
        grams += self.food.count() * 100
        return grams

    @property
    def fats_grams(self):
        fats = 0
        for meal in self.meals.all():
            fats += meal.fats_grams
        for f in self.food.all():
            fats += f.fats_per_100g
        return fats

    @property
    def protein_grams(self):
        protein = 0
        for meal in self.meals.all():
            protein += meal.protein_grams
        for f in self.food.all():
            protein += f.protein_per_100g
        return str(protein)

    @property
    def carbs_grams(self):
        carbs = 0
        for meal in self.meals.all():
            carbs += meal.carbs_grams
        for f in self.food.all():
            carbs += f.carbs_per_100g
        return str(carbs)

    def __str__(self):
        return self.name

    class Meta:
        ordering = ('pk',)


class Motivation(models.Model):
    quote = models.CharField(
        max_length=450,
    )

    description = models.TextField()

    def __str__(self):
        return self.quote

    class Meta:
        ordering = ('pk',)
