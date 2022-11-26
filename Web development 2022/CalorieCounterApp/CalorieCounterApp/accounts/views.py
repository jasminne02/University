from django.shortcuts import redirect
from django.urls import reverse_lazy
from django.views import generic as views
from django.contrib.auth import views as auth_views
from django.contrib.auth.models import Group

from CalorieCounterApp.accounts.forms import CustomUserCreationForm, CustomUserLoginForm, CustomUserEditForm, \
    CustomUserDeleteForm
from CalorieCounterApp.accounts.models import CustomUser


def set_user_info(user):
    set_user_calories_per_day(user)
    set_user_fats_per_day(user)
    set_user_protein_per_day(user)
    set_user_carbs_per_day(user)
    user.save(update_fields=('calories_per_day', 'fats_grams_per_day', 'proteins_grams_per_day', 'carbs_grams_per_day'))


def set_user_calories_per_day(user):
    """ Revised Harris-Benedict Equation """
    if user.gender == 'Male':
        """ 66.47 + (13.75 x weight in kg) + (5.003 x height in cm) - (6.755 x age in years) """
        user.calories_per_day = 66.47 + (13.75 * user.weight) + (5.003 * user.height) - (6.755 * user.age)
    elif user.gender == 'Female':
        """ 655.1 + (9.563 x weight in kg) + (1.850 x height in cm) - (4.676 x age in years) """
        user.calories_per_day = 655.1 + (9.563 * user.weight) + (1.850 * user.height) - (4.676 * user.age)


def set_user_fats_per_day(user):
    """ 30% of total calorie intake should come from fats. Each gram of fat is 'worth' 9 calories """
    user.fats_grams_per_day = user.calories_per_day * 0.30 / 9


def set_user_protein_per_day(user):
    """ Around 20% of total calorie intake should come from proteins. Protein has four calories per gram """
    user.proteins_grams_per_day = user.calories_per_day * 0.20 / 4


def set_user_carbs_per_day(user):
    """ Around 50% of total calorie intake should come from carbs. Carbohydrates have four calories per gram """
    user.carbs_grams_per_day = user.calories_per_day * 0.5 / 4


class UserRegisterView(views.CreateView):
    model = CustomUser
    form_class = CustomUserCreationForm
    template_name = 'account/register.html'
    success_url = reverse_lazy('login')

    def form_valid(self, form):
        usr = form.save()
        user = CustomUser.objects.get(username=usr.username)
        set_user_info(user)
        if user.motivations_group:
            group = Group.objects.get(name='Motivations')
            group.user_set.add(user)
        return super().form_valid(form)


class UserLoginView(auth_views.LoginView):
    form_class = CustomUserLoginForm
    template_name = 'account/login.html'

    def get_success_url(self):
        user = CustomUser.objects.get(username=self.request.user.username)
        set_user_info(user)
        return reverse_lazy('home')


class UserLogoutView(auth_views.LogoutView):
    next_page = reverse_lazy('home')


class UserDetailsView(views.DetailView):
    model = CustomUser
    template_name = 'account/profile.html'

    def get_object(self, queryset=None):
        return self.request.user


class UserEditView(views.UpdateView):
    model = CustomUser
    form_class = CustomUserEditForm
    template_name = 'account/profile_edit.html'

    def get_object(self, queryset=None):
        return self.request.user

    def get_success_url(self, *args, **kwargs):
        user = CustomUser.objects.get(username=self.request.user.username)
        set_user_info(user)
        return reverse_lazy('profile details', kwargs={'username': self.object.username})


class UserDeleteView(views.DeleteView):
    model = CustomUser
    form_class = CustomUserDeleteForm
    template_name = 'account/profile_delete.html'

    def get_object(self, queryset=None):
        return self.request.user

    def post(self, request, *args, **kwargs):
        self.request.user.delete()
        return redirect('home')
