import re

from convert_number import convert_number


def convert_str_to_number(number):
    try:
        return int(number)
    except ValueError:
        return float(number)


def convert_text(text, base):
    pattern = "([+-]?[0-9]+([.]?[0-9]*))"
    matches = re.findall(pattern, text)

    return [convert_number(convert_str_to_number(match[0]), base) for match in matches]
