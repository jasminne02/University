from django import forms
from django.contrib.auth.forms import UserCreationForm, UserChangeForm, AuthenticationForm, UsernameField

from .models import CustomUser


class CustomUserCreationForm(UserCreationForm):

    class Meta:
        model = CustomUser
        fields = ("username", 'gender', "birthday", "height", "weight", "motivations_group")
        labels = {
            'username': 'Username',
            'birthday': 'Date of birth:',
            'gender': 'Gender:',
            'height': 'Height:',
            'weight': 'Weight',
            'motivations_group': 'Join Motivations Group',
            'password1': 'Password:',
            'password2': 'Confirm password:',
        }


class CustomUserChangeForm(UserChangeForm):

    class Meta:
        model = CustomUser
        fields = ("height", "weight", "profile_image")


class CustomUserLoginForm(AuthenticationForm):
    username = UsernameField(
        widget=forms.TextInput(
            attrs={
                'placeholder': 'Username',
            }
        )
    )

    password = forms.PasswordInput(
        attrs={
            'placeholder': 'Password',
        }
    )


class CustomUserEditForm(forms.ModelForm):
    class Meta:
        model = CustomUser
        fields = ("height", "weight", "profile_image")
        exclude = ('password',)
        labels = {
            'height': 'Height:',
            'weight': 'Weight:',
            'profile_image': 'Image URL:',
        }


class CustomUserDeleteForm(forms.ModelForm):
    class Meta:
        model = CustomUser
        fields = '__all__'

    def __init__(self, *args, **kwargs):
        super().__init__(*args, **kwargs)
        self.__set_hidden_fields()

    def __set_hidden_fields(self):
        for field in self.fields.values():
            field.widget = forms.HiddenInput()
