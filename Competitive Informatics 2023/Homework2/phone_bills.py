def func(phone_bills, paid_bills):
    for bill in paid_bills:
        if bill in phone_bills:
            phone_bills.remove(bill)
    phone_bills.sort(reverse=True)
    return phone_bills

def func2(s_full, s_paid):
    final = []
    for i in s_full:
        if i in s_paid:
            s_paid.remove(i)
        else:
            final.append(round(float(i), 2))
    final.sort(reverse=True)
    return final


if __name__ == '__main__':
    m, n = tuple(map(int, input().split()))
    phone_bills = list(map(float, input().split()))[:m]
    paid_bills = list(map(float, input().split()))[:n]
    result = func2(phone_bills, paid_bills)
    print(' '. join(map(str, result)))
