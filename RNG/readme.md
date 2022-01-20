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