import hashlib

from file_operations import save_hash_in_file, read_file


def md5_scan(file_path):
    file_data = read_file(file_path)
    md5_hash = hashlib.md5(file_data.encode()).hexdigest()

    new_file_name = f"{file_path.split('.')[0]}_md5_hash.txt"

    save_hash_in_file(new_file_name, md5_hash)

    return f"MD5 hash saved in {new_file_name}"
