import os
import yara


def detect_malware(file_path):
    cwd = os.getcwd()

    # Load YARA rules
    rules_path = f"{cwd}{os.sep}yara_rules{os.sep}rules.yara"
    rules = yara.compile(rules_path)

    # Scan the file with loaded rules
    matches = rules.match(file_path)

    # Check if there are any matches
    if matches:
        matched_rules = []
        for match in matches:
            matched_rules.append(match.rule)
        return matched_rules
