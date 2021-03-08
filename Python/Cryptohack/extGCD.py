
def extGCD(p,q):
    if p == 0:
        return (q, 0, 1)
    else:
        (gcd, u, v) = extGCD(q % p, p)
        return (gcd, v - (q // p) * u, u)

gcd, u, v = extGCD(26513, 32321)


print("crypto{"+ str(u) + "," + str(v) + "}")