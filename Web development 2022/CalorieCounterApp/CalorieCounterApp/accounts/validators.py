import datetime

from django.core import validators


def validate_age_through_birthday(value):
    age = (datetime.date.today() - value).days / 365
    if age < 18:
        raise validators.ValidationError("You must be at least 18 years old")
