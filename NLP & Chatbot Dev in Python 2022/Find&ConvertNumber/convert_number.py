from convert_to_num_system import convert_to_binary, convert_to_hex, convert_to_oct, convert_to_quinary


def convert_number(number, base):
    if base == 2:
        return convert_to_binary(number)
    elif base == 16:
        return convert_to_hex(number)
    elif base == 8:
        return convert_to_oct(number)
    elif base == 5:
        return convert_to_quinary(number)
    else:
        return str(number)
