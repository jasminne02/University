import struct


def convert_to_binary(number):
    if isinstance(number, int):
        return bin(number)[2:]
    else:
        return ''.join('{:0>8b}'.format(x) for x in struct.pack('!f', number))


def convert_to_hex(number):
    if isinstance(number, int):
        return hex(number)[2:]
    else:
        return float.hex(number)


def convert_to_oct(number):
    if isinstance(number, int):
        return oct(number)[2:]
    else:
        whole, dec = str(number).split(".")
        number = oct(int(whole)).lstrip("0o") + "."

        for x in range(len(dec)):

            def decimal_converter(num):
                while num > 1:
                    num /= 10
                return num

            whole, dec = str((decimal_converter(int(dec))) * 8).split(".")

            dec = int(dec)
            number += whole

        return number


def convert_to_quinary(number):
    result = ""
    while number > 0:
        result = str(number % 5) + result
        number = number // 5
    return result
