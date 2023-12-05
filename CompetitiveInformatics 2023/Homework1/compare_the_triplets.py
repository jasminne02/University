def compareTriplets(a, b):
    # Write your code here
    alice_points = 0
    bob_points = 0

    for idx in range(0, 3):
        a_value = a[idx]
        b_value = b[idx]

        if a_value > b_value:
            alice_points += 1
        elif a_value < b_value:
            bob_points += 1

    return [alice_points, bob_points]


if __name__ == '__main__':
    a = list(map(int, input().rstrip().split()))
    b = list(map(int, input().rstrip().split()))

    result = compareTriplets(a, b)

    print(' '.join(map(str, result)))
