
# Function to calculate modular 
# inverse using D.P 
def modularInverse( n, prime) : 
  
    dp =[0]*(n+1) 
    dp[0] = dp[1] = 1
    for i in range( 2, n+1) : 
        dp[i] = dp[prime % i] *(prime - prime // i) % prime  
   
    for i in range( 1, n+1) : 
        print(dp[i] ,end=" ") 
          
   
# Driver code 
n = 3
prime = 13
  
modularInverse(n, prime) 
  