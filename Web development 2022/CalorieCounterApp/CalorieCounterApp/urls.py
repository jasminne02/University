from django.contrib import admin
from django.urls import path, include

urlpatterns = [
    path('admin/', admin.site.urls),
    path('', include('CalorieCounterApp.core.urls')),
    path('account/', include('CalorieCounterApp.accounts.urls')),
    path('calorie-counter/', include('CalorieCounterApp.calorie_counter.urls')),
    path('staff-control/', include('CalorieCounterApp.staff_control.urls')),
]
