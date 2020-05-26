def gen ():
    i = 0

    while i < 5:
        temp = yield i
        print(temp)
        i += 1

# for val in gen():
#     print(val, end = " ")

g = gen()
val = next(g)

print(val)

val = next(g)

print(val)

# val = g.send(None)
# print(val)

# val = g.send("hello")
# print(val)
