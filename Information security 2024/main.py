import os
import filecmp

from md5.md5 import md5_scan
from sha512.sha512 import sha512_scan
from yara_rules.yara_rules import detect_malware

options = {
    1: detect_malware,
    2: md5_scan,
    3: sha512_scan
}


def validate_option(option):
    try:
        option = int(option)
    except ValueError:
        return False

    return True if 0 <= option <= 4 else False


def choose_option():
    option = None

    print("Scan your PC for Malware")
    print("Choose an option: 0.Exit  1.Yara rules  2.MD5  3.SHA512  4.Compare two files hash")

    while not option:
        option = input("Enter: ")
        option = None if not validate_option(option) else option

        if not option:
            print("Not a valid option!")

    return int(option)


def choose_file():
    file = None

    while not file:
        file = input("Enter the path of the file you want to scan: ")
        file = None if not os.path.isfile(file) else file

        if not file:
            print("This file does not exist!")

    return file


def compare_files(file1, file2):
    result = filecmp.cmp(file1, file2)
    return "The two file are identical" if result else "The two file are not identical"


def main():
    option = None

    while not option:
        option = choose_option()
        if option == 0:
            break

        if option == 4:
            file1 = choose_file()
            file2 = choose_file()
            scan_result = compare_files(file1, file2)
        else:
            file_path = choose_file()
            scan_result = options[option](file_path)

        if scan_result:
            print(f"Scan info: {scan_result}\n")
        else:
            print(f"The file does not contain any malware\n")

        option = None


if __name__ == '__main__':
    main()
