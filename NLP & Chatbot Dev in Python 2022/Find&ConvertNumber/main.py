from convert_text import convert_text


def main():
    text = input("Enter the text: ")
    base = int(input("Enter the base (2, 8, 10, 16, or 5): "))
    print(convert_text(text, base))


if __name__ == "__main__":
    main()
