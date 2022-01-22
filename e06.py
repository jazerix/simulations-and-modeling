import matplotlib.pyplot as plt
import statsmodels.api as sm
import numpy as np
from scipy.stats import norm 
from scipy.stats import chisquare
from scipy.optimize import curve_fit


time = []

with open("FortLauderdaleHighway.csv", encoding='utf8') as file:
    for line in file:
        line = line.replace("\n","")
        line = line.replace("\ufeff","")
        split = line.split(':')
        
        
        time.append( int(split[0])*60+ int(split[1]))

interarrival = {}
count=0
print(len(time))
print(time)
for i in range(1, len(time)):
    diff = time[i] - time[i-1]
    count += 1
    if diff in interarrival:
        interarrival[diff] += 1
        continue
    
    interarrival[diff] = 1


for key, value in interarrival.items():
    #interarrival[key] = value / count
    pass
    
print(interarrival.keys(), interarrival.values())
interarrival[10] = 0
# Histogram
interarrival = dict(sorted(interarrival.items()))
keys, values = interarrival.keys(), interarrival.values()

plt.xticks(range(len(values)), keys)
x = np.arange(0, 11, 0.001)
y = norm.pdf(x, 0.85, 1.35)
fig, ax = plt.subplots()
ax.plot(x,y, color='r',)
ax.bar(range(len(values)), values, color='b')
plt.show()

# Quantile-Quantile plot
# freq = []
# seconds = []
# for key,value in interarrival.items():
#     freq.append(value)
#     seconds.append(key)

# npfreq = np.array(freq)
# npseconds = np.array(seconds)
# sm.qqplot(npfreq, line ='45')
# plt.show()

#Chi-Square
# csq = chisquare(npfreq, npfreq, ddof=)
# print(csq)
# print(npfreq, npfreq)