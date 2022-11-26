from django.contrib import admin

from CalorieCounterApp.calorie_counter.models import DailyData


@admin.register(DailyData)
class DailyDataAdmin(admin.ModelAdmin):
    list_display = ('user_id', 'date', 'calories_eaten', 'calories_burnt')
    list_display_links = ('user_id',)
    search_fields = ('user_id', 'date')
    ordering = ('date', 'user_id')
    list_filter = ('user_id', 'date')
