from django.urls import path

from CalorieCounterApp.calorie_counter import views


urlpatterns = [
    path('', views.show_calorie_counter, name='calorie counter'),
    path('add-activity/<int:pk>/', views.add_activity, name='add activity'),
    path('add-food/<str:name>/', views.add_food, name='add food'),
    path('today-details/', views.today_details, name='today details')
]
