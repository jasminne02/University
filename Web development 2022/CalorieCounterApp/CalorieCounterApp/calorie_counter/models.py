from django.db import models

from CalorieCounterApp.accounts.models import CustomUser


class DailyData(models.Model):
    date = models.DateField(
        auto_now_add=True,
    )

    user_id = models.ForeignKey(
        to=CustomUser,
        on_delete=models.CASCADE
    )

    total_calories = models.PositiveIntegerField(
        blank=True,
        null=True,
    )

    calories_eaten = models.PositiveIntegerField(
        blank=True,
        null=True,
    )

    calories_burnt = models.PositiveIntegerField(
        blank=True,
        null=True,
    )

    fats_grams_per_day = models.PositiveIntegerField(
        blank=True,
        null=True,
    )

    proteins_grams_per_day = models.PositiveIntegerField(
        blank=True,
        null=True,
    )

    carbs_grams_per_day = models.PositiveIntegerField(
        blank=True,
        null=True,
    )

    class Meta:
        verbose_name_plural = 'Daily Data'
