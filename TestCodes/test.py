try:
    number=int(input())
    expr=''
    for i in range(0,number):
        n=input()
        expr=expr+n+'\n'
        if i ==number-1:
            index=n.index('=')
            output=n[0:index]
            expr=expr+'print('+output+')'
    exec(expr)
except Exception as e:
    print('NA')