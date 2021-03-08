def sumIntervals(li):
    s = []
    li1=li[0]
    li2=li[1]
    li3=li[2]
    for i in range(li1[0],li1[1]):
        s.append(i)
    for i in range(li2[0],li2[1]):
        if i not in s:
            s.append(i)
    for i in range(li3[0],li3[1]):
        if i not in s:
            s.append(i)
    return len(s)
