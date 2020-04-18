import matplotlib.pyplot as plt

plt.rcParams['font.sans-serif']=['SimHei']

x = [1, 3, 5, 7]
y = [2, 4, 5, 8]

xticks = [str(i) + "mi" for i in x]

# 绘画
plt.plot(x, y)

plt.xlabel("横坐标") # 中文会报错，要自己设置字体
plt.ylabel("纵坐标")
plt.title("标题")
plt.xticks(x, xticks) # x坐标的刻度显示

# 显示
plt.show()