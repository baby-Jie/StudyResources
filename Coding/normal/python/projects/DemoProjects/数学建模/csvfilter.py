import pandas as pd

df = pd.read_csv("test.csv")

df = df[ ((df['Clutter Index'] == 10) & ( (df['Building Height'] == 0) | (df['Building Height'] > 60))) | 
    ((df['Clutter Index'] == 11) & ( (df['Building Height'] == 0) | ( (df['Building Height'] >= 40) & (df['Building Height'] <= 60) ))) | 
    ((df['Clutter Index'] == 12) & ( (df['Building Height'] == 0) | ( (df['Building Height'] >= 20) & (df['Building Height'] <= 40) ))) | 
    ( ( (df['Clutter Index'] == 13) | (df['Clutter Index'] == 14) ) & ( (df['Building Height'] == 0) | (df['Building Height'] < 20) ))]


df.to_csv("new.csv")