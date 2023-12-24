import re
import sys


def func(number):
    factorial = 1
    sys.set_int_max_str_digits(500000)
    for n in range(1, number+1):
        factorial *= n
    return len(re.findall(r'0*$', str(factorial))[0])


if __name__ == '__main__':
    number = 49999
    result = func(number)
    print(result)
