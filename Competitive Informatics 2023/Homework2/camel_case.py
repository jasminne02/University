import math
import os
import random
import re
import sys

#
# Complete the 'camelcase' function below.
#
# The function is expected to return an INTEGER.
# The function accepts STRING s as parameter.
#

def camelcase(s):
    return len(re.findall('[A-Z][^A-Z]*', s)) + 1


if __name__ == '__main__':
    s = 'saveChangesInTheEditor'
    result = camelcase(s)
    print(result)
