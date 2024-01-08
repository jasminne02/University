def decentNumber(n):
    num_fives = n
    while num_fives % 3 != 0:
        num_fives -= 5

    # Check if a decent number is possible
    if num_fives < 0:
        print("-1")
        return

    # Print the decent number
    num_threes = n - num_fives
    decent_number = "5" * num_fives + "3" * num_threes
    print(decent_number)


if __name__ == '__main__':
    t = int(input().strip())

    for t_itr in range(t):
        n = int(input().strip())

        decentNumber(n)
