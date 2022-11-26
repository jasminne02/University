from django.urls import path, include

from CalorieCounterApp.accounts import views

urlpatterns = [
    path('register/', views.UserRegisterView.as_view(), name='register'),
    path('login/', views.UserLoginView.as_view(), name='login'),
    path('logout/', views.UserLogoutView.as_view(), name='logout'),
    path('profile/<str:username>/', include([
        path('', views.UserDetailsView.as_view(), name='profile details'),
        path('edit/', views.UserEditView.as_view(), name='profile edit'),
        path('delete/', views.UserDeleteView.as_view(), name='profile delete'),
    ])),
]
