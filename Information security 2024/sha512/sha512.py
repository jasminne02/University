import hashlib

from file_operations import save_hash_in_file, read_file


def sha512_scan(file_path):
    file_data = read_file(file_path)
    sha512_hash = hashlib.sha512(file_data.encode()).hexdigest()

    new_file = f"{file_path.split('.')[0]}_sha512_hash.txt"

    save_hash_in_file(new_file, sha512_hash)

    return f"SHA512 hash saved in {new_file}"
