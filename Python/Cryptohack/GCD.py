def gcd(m,n):
    if m< n: 
        (m,n) = (n,m)
    while (m % n != 0):
        (m, n) = (n, m % n)
    return n

# calling function with parameters and printing it out        

print(gcd(66528,52920))