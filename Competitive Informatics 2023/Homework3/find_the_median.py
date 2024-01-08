import os


def findMedian(arr):
    arr.sort()

    # Find the median index
    median_index = len(arr) // 2

    # Return the median value
    return arr[median_index]


if __name__ == '__main__':
    fptr = open(os.environ['OUTPUT_PATH'], 'w')

    n = int(input().strip())

    arr = list(map(int, input().rstrip().split()))

    result = findMedian(arr)

    fptr.write(str(result) + '\n')

    fptr.close()
