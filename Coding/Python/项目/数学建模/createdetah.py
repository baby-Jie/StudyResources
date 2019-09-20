import pandas as pd
import os
import shutil

def calculateD(sourceFile:str, dstFile:str):
    df = pd.read_csv(sourceFile, low_memory=False)  # 读取csv,设置low_memory=False防止内存不够时报警告

    df['d'] = df.apply(lambda x: ((x['X'] - x['Cell X']) ** 2 + (x['Y'] - x['Cell Y']) ** 2) ** (1 / 2) / 1000, axis=1)
    df['DetaH'] = df.apply(lambda x: x['Height'] + x['Cell Altitude'] - x['Altitude'] - x['Building Height'], axis=1)
    df['degree'] = df.apply(lambda x: x['Electrical Downtilt'] + x['Mechanical Downtilt'], axis=1)

    # 放在这不会报错  但是放在第7行就会报错
    df = df[ ((df['Clutter Index'] == 10) & ( (df['Building Height'] == 0) | (df['Building Height'] > 60))) | 
    ((df['Clutter Index'] == 11) & ( (df['Building Height'] == 0) | ( (df['Building Height'] >= 40) & (df['Building Height'] <= 60) ))) | 
    ((df['Clutter Index'] == 12) & ( (df['Building Height'] == 0) | ( (df['Building Height'] >= 20) & (df['Building Height'] <= 40) ))) | 
    ( ( (df['Clutter Index'] == 13) | (df['Clutter Index'] == 14) ) & ( (df['Building Height'] == 0) | (df['Building Height'] < 20) )) |
    ( (df['Clutter Index'] != 10) & (df['Clutter Index'] != 11) & (df['Clutter Index'] != 12)  & (df['Clutter Index'] != 13) & (df['Clutter Index'] != 14) ) ]

    df.to_csv(dstFile, index=None)
    # df.to_csv(dstFile, columns=['Cell Index','Azimuth','RS Power', 'Clutter Index', 'd', 'DetaH', 'degree'], index=None)

    # df.to_csv('d:\new_person.csv',columns=['id','name','company'],index=0,header=1)

def translate():
    if not os.path.exists("translate"):
        os.mkdir("translate")
    for root, dirs, files in os.walk(os.path.join(os.curdir, "train_set")):
        for fileName in files:
            if ".csv" in fileName:
                calculateD(os.path.join("train_set", fileName), os.path.join("translate", fileName))
                # print(os.path.join("translate", fileName))
    pass

def main():
    translate()

if __name__ == "__main__":
    main()
    print("yes")



