from django.contrib import admin
from django.contrib.auth.admin import UserAdmin

from .forms import CustomUserCreationForm, CustomUserChangeForm
from .models import CustomUser


@admin.register(CustomUser)
class CustomUserAdmin(UserAdmin):
    add_form = CustomUserCreationForm
    form = CustomUserChangeForm
    model = CustomUser
    list_display = ('username', 'gender', 'birthday', 'motivations_group')
    list_display_links = ('username',)
    ordering = ('username',)
    date_hierarchy = 'date_joined'

    fieldsets = (
        (None, {'fields': ('username', 'password', 'gender', 'birthday', 'height', 'weight', 'calories_per_day',
                           'fats_grams_per_day', 'proteins_grams_per_day', 'carbs_grams_per_day')}),
        ('Permissions', {'fields': ('is_active', 'is_staff', 'is_superuser',
                                    'groups', 'user_permissions')}),
        ('Important dates', {'fields': ('last_login', 'date_joined')}),
    )

    add_fieldsets = (
        (None, {
            'classes': ('wide',),
            'fields': ('username', 'password1', 'password2', 'gender', 'birthday', 'height', 'weight')}
         ),
    )
