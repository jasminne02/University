from django import forms


class SearchFoodForm(forms.Form):
    name = forms.CharField(
        label='Search Food..',
        max_length=300,
    )


class SearchActivityForm(forms.Form):
    name = forms.CharField(
        label='Search Activity..',
        max_length=300,
    )


class AddActivityForm(forms.Form):
    active_minutes = forms.IntegerField(
        label='Activity duration'
    )

    add_burnt_to_total = forms.BooleanField(
        required=False,
    )


class AddFoodForm(forms.Form):
    grams = forms.IntegerField(
        label='Food quantity in grams'
    )
