def countingValleys(steps, path):
    # Write your code here
    valley_count = 0
    down_counter = 0
    up_counter = 0
    is_valley = False

    for value in path:
        if up_counter == 0 and down_counter == 0 and value == 'D':
            is_valley = True

        if value == 'U':
            up_counter += 1
        elif value == 'D':
            down_counter += 1

        if down_counter == up_counter and is_valley:
            valley_count += 1
            down_counter = 0
            up_counter = 0
            is_valley = False
        elif down_counter == up_counter:
            up_counter = 0
            down_counter = 0

    return valley_count


if __name__ == '__main__':
    steps = int(input().strip())

    path = input()

    result = countingValleys(steps, path)
    print(result)
