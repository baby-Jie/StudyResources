import os
from pathlib import Path

base_dir = input().strip()

file = open("File.txt")

try:
    while True:
        text_line = file.readline()
        if text_line:
            fold_path = text_line.strip()
            if len(fold_path) > 0:
                target_fold_path = os.path.join(base_dir, fold_path)
                os.makedirs(target_fold_path)
        else:
            break
except Exception as e:
    print(e)

