## Calculating if runs test is independent

When running the runs test, you'll get the following output:
```
E(1) = 4166,75, O(1) = 4058, Chi Statistic(1) = 2,838318233635327
E(2) = 1833,1, O(2) = 1880, Chi Statistic(2) = 1,199939992362669
E(3) = 527,65, O(3) = 517, Chi Statistic(3) = 0,21484684515526425
E(4) = 115,04, O(4) = 135, Chi Statistic(4) = 3,4638755179197265
E(5) = 20,33, O(5) = 17, Chi Statistic(5) = 0,5447918692871908
E(6) = 3,03, O(6) = 1, Chi Statistic(6) = 1,3596538693862366
Chi Zero Squared: 9,621426327746416
Observed number of runs: 6608
```

Look at the `Chi Zero Squared` value and check if it's below your P value in the CHI^2 distribution.
This can be done in R: `qchisq(0.05, 5, lower.tail = F)`, where 5 is the degrees of freedom and `0.05` is the significance level (confidence level 95%)


## Analysis

Once you have done thetests, you canlook over and analyze your results. Try to answer the following questions:

- What is the random library function that your compiler supplied for you?
    - Subtractive RNG (does two passes of two previous numbers)
- Summarize the outcomes of the statistical tests for each RNG method.What test(s) did the method "pass"?
    - **Init**: Passed Runs test + Smirnov test
    - **Randu**: Passed Runs test + Smirnov test (except at significance level of 10% or higher)
    - **Subtractive**: Passed Runs test + Smirnov test
- For each method, prior to generating the numbers and running the statistical tests, do you expect it to work well or poorly?
   - We expect it to work well, the randu is expected to perform poorly.
- Looking over some of the generated numbers for each method (but before running the statistical tests), do you think they look sufficiently random? Did the outcome of the statistical test surprise you?
  - It's difficult to say, when you are just glancing over the numbers, they all __look__ random. The outcome was not surprising.
- Discuss whether you think the set of experiments you did for this assignment is sufficient. If so, argue why that is the case. If not, explain what additional test(s) or modification(s) to the methodology you'd perform
  - It's obviously not sufficient as the RANDU technically passes although it isn't strictly random and you can discover a relationship between the numbers if you plot them onto a plane. 