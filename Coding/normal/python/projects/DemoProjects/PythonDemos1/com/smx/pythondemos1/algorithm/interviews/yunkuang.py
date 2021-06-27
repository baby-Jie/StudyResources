def get_sum(a: str, b: str):

    ra = a[::-1]
    rb = b[::-1]
    min_len = min(len(a), len(b))

    res = ""
    flag = 0
    for i in range(min_len):

        num1 = int(ra[i])
        num2 = int(rb[i])
        result = num1 + num2 + flag
        flag = result // 10
        result %= 10
        res += str(result)

    index = min_len
    while index < len(ra):
        result = int(ra[index]) + flag
        flag = result // 10
        result %= 10
        res += str(result)
        index += 1

    while index < len(rb):
        result = int(rb[index]) + flag
        flag = result // 10
        result %= 10
        res += str(result)
        index += 1

    if flag > 0:
        res += str(flag)
    return res[::-1]

def get_eight_num(s:str):

    length = len(s)

    rtn_str = ""

    if length == 0:
        return (0, rtn_str)
    elif length <= 8:
        return (int(s), rtn_str)
    else:
        rtn_str = s[:-8]
        return (int(s[-8:]), rtn_str)


def get_sum2(a:str, b:str):

    flag = 0
    li = []
    while len(a) > 0 or len(b) > 0:
        num1, a = get_eight_num(a)
        num2, b = get_eight_num(b)
        result = num1 + num2 + flag
        flag = result // 10**8
        result = result % 10**8
        if len(a) > 0 or len(b) > 0:
            li.append(str(result + 10 ** 8)[1:])
        else:
            li.append(str(result))
    if flag > 0:
        li.append(str(flag))
    li = li[::-1]
    s = "".join(li)

    return s

def get_sub(a:str, b:str):
    is_negative = a < b

    pass

def get_sum3(a:str, b:str):

    if a[0] == '-' or b[0] == '-':
        if a[0] == '-' and b[0] == '-':
            return '-' + get_sum(a, b)
        if a[0] == '-':
            return get_sub(b, a)
        if b[0] == '-':
            return get_sub(a, b)
    return get_sum(a, b)


a = 23452415454521213212112121212454545454546565
b = 454541214542154445454
print(a + b)
s = get_sum2(str(a), str(b))
print(s)
