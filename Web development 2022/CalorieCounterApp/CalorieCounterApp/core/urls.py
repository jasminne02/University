from django.urls import path, include

from CalorieCounterApp.core import views

urlpatterns = [
    path('', views.show_homepage, name='home'),
    path('about/', views.show_about_page, name='about'),
    path('food-plans/', views.FoodPlansView.as_view(), name='food plans'),
    path('food-plan-details/<int:pk>', include([
        path('', views.FoodPlanDetailsView.as_view(), name='food plan details'),
        path('add-for-the-day/', views.add_plan_for_the_day, name='add plan for the day'),
    ])),
    path('motivations/', views.MotivationsView.as_view(), name='motivations'),
    path('add-motivation/', views.AddMotivationView.as_view(), name='add motivation'),
]
