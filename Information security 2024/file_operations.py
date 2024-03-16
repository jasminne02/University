def read_file(path):
    with open(path, 'r') as file:
        return file.read()


def save_hash_in_file(file_name, hash_value):
    with open(file_name, 'w') as file:
        file.write(str(hash_value))
