import requests
import matplotlib
url1 = "https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=EUR&api_key=02932904224a3b791bfe3f5b37d8092672b316cbb4f69d112c6d63d8aca9701a"
url2 = "https://min-api.cryptocompare.com/data/price?fsym=LTC&tsyms=EUR&api_key=02932904224a3b791bfe3f5b37d8092672b316cbb4f69d112c6d63d8aca9701a"
url3 = "https://min-api.cryptocompare.com/data/price?fsym=ZEC&tsyms=EUR&api_key=02932904224a3b791bfe3f5b37d8092672b316cbb4f69d112c6d63d8aca9701a"
BTC = requests.get(url1)
btcData = BTC.json()
print("Bitcoin:",btcData["EUR"],"EUR")
LTC = requests.get(url2)
ltcData = LTC.json()
print("Litecoin:",ltcData["EUR"],"EUR")
ZEC = requests.get(url3)
zecData = ZEC.json()
print("ZCash:",zecData["EUR"],"EUR")
