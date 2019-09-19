
import csv
import os
import shutil

# 获取RSPower的值
def getRsPower(fileName:str):
    with open(fileName,'r') as csvfile:
        reader = csv.reader(csvfile)
        rows= [row for row in reader]
        return rows[1][8]

def moveFile(sourceName:str, dstName:str):
    shutil.move(sourceName, dstName)

def checkDirectory(directoryName:str):
    if os.path.exists(directoryName):
        pass
    else:
        # 创建文件夹
        os.mkdir(directoryName)

def move(directoryName:str, fileName:str):
    checkDirectory(directoryName)
    moveFile(fileName, os.path.join(directoryName, fileName))

def classifyCSVFiles(directoryPath:str):
    for root, dirs, files in os.walk(directoryPath):  
        # print(root) #当前目录路径  
        # print(dirs) #当前路径下所有子目录  
        # print(files) #当前路径下所有非目录子文件
        for fileName in files:
            if ".csv" in fileName:
                rsPower = getRsPower(fileName)
                move(rsPower, fileName)

def main():
    classifyCSVFiles(".")

if __name__ == "__main__":
    main()





