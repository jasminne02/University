from django.urls import path, include
from CalorieCounterApp.staff_control import views
from CalorieCounterApp.core.views import AddMotivationView


urlpatterns = [
    path('', views.index, name='control'),
    path('add-food/', views.add_food, name='add food'),
    path('edit-food/<int:pk>/', views.edit_food, name='edit food'),
    path('delete-food/<int:pk>/', views.delete_food, name='delete food'),
    path('add-meal/', views.add_meal, name='add meal'),
    path('edit-meal/<int:pk>/', views.edit_meal, name='edit meal'),
    path('delete-meal/<int:pk>/', views.delete_meal, name='delete meal'),
    path('add-plan/', views.add_plan, name='add plan'),
    path('edit-plan/<int:pk>/', views.edit_plan, name='edit plan'),
    path('delete-plan/<int:pk>/', views.delete_plan, name='delete plan'),
    path('add-exercise/', views.add_exercise, name='add exercise'),
    path('edit-exercise/<int:pk>/', views.edit_exercise, name='edit exercise'),
    path('delete-exercise/<int:pk>/', views.delete_exercise, name='delete exercise'),
    path('add-motivation/', AddMotivationView.as_view(), name='add motivation'),
    path('edit-motivation/<int:pk>/', views.edit_motivation, name='edit motivation'),
    path('delete-motivation/<int:pk>/', views.delete_motivation, name='delete motivation'),
]
