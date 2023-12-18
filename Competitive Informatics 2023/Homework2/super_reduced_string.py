import math
import os
import random
import re
import sys


#
# Complete the 'superReducedString' function below.
#
# The function is expected to return a STRING.
# The function accepts STRING s as parameter.
#


def superReducedString(s):
    while s:
        string_len = len(s)
        stop = True

        for idx in range(string_len-1):
            if s[idx] == s[idx + 1]:
                s = s[:idx] + s[idx+2:]
                stop = False
                break
        if stop:
            break

    return s if len(s) > 0 else 'Empty String'


if __name__ == '__main__':
    s = 'baab'
    result = superReducedString(s)
    print(result)
