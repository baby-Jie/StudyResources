"""
应用：文件夹copy器（多进程版）

"""
from multiprocessing import Manager, Pool, Queue
import os

def copy_single_file(source_file_name:str, dest_file_name:str):
    if not os.path.exists(source_file_name):
        return
    if not os.path.isfile(source_file_name):
        return
    try:
        f_rd = open(source_file_name, "rb")
        f_wr = open(dest_file_name, "wb")

        while True:
            content = f_rd.read(1024)

            if content:
                f_wr.write(content)
            else:
                break
        pass
    except Exception as res:
        print(res)
    else:
        pass
    finally:
        if f_rd:
            f_rd.close()
        if f_wr:
            f_wr.close()

def copy_directory(source_directory_name:str, dest_directory_name:str, po:Pool):
    if not os.path.exists(source_directory_name):
        return
    if not os.path.isdir(source_directory_name):
        return

    if not os.path.exists(dest_directory_name):
        os.mkdir(dest_directory_name)
    filenames = os.listdir(source_directory_name)

    for file_name in filenames:
        source_name = os.path.join(source_directory_name, file_name)
        if os.path.isdir(source_name):
            dest_folder_name = os.path.join(dest_directory_name, file_name)
            copy_directory(source_name, dest_folder_name, po)
            pass
        if os.path.isfile(source_name):
            dest_file_name = os.path.join(dest_directory_name, file_name)
            print(dest_file_name)

            po.apply_async(copy_single_file, (source_name, dest_file_name))
            # copy_single_file(source_name, dest_file_name)

def main():
    input_name = input("please input directory name:")
    if not os.path.exists(input_name):
        print("the directory what you input is not exist")
        return

    po = Pool(10)

    # po.apply_async(copy_directory, (input_name, input_name + "_bak", po))

    copy_directory(input_name, input_name + "_bak", po)

    po.close()
    po.join()

    print("copy successfully!")
    pass

if __name__ == "__main__":
    main()