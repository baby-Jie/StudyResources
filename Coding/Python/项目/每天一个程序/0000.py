"""将你的 QQ 头像（或者微博头像）右上角加上红色的数字，类似于微信未读信息数量那种提示效果。 类似于图中效果"""
"""PIL包的使用  安装 pip install pillow"""


from PIL import Image, ImageDraw, ImageFont

def add_num(img):
    draw = ImageDraw.Draw(img)
    # myfont = ImageFont.truetype('C:/windows/fonts/Arial.ttf', size = 40)
    fillcolor = "#ff0000"
    width, height = img.size
    draw.text((width-40, 0), '99',fill=fillcolor)
    img.save('result.jpg', 'jpeg')

    return 0

if __name__ == "__main__":
    imagepath = input("please input the path of image:")
    image = Image.open(imagepath)
    add_num(image)