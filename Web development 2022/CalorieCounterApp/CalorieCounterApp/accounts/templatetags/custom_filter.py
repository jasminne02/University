from django import template

register = template.Library()


@register.filter
def placeholder(value, token):
    """ Sets placeholders to form fields """
    value.field.widget.attrs['placeholder'] = token
    return value
