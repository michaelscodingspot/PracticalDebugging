

## Serialize to string, small class



| Method                        |       Mean |     Error |    StdDev |
| ----------------------------- | ---------: | --------: | --------: |
| RunSystemTextJson             |   812.1 ns | 15.414 ns | 15.139 ns |
| RunNewtonsoft                 |   962.1 ns | 16.349 ns | 15.293 ns |
| RunDataContractJsonSerializer | 1,569.5 ns | 30.014 ns | 40.067 ns |
| RunJil                        |   331.8 ns |  6.669 ns |  6.238 ns |
| RunUtf8Json                   |   183.0 ns |  3.596 ns |  3.531 ns |
| RunServiceStack               |   581.9 ns |  6.699 ns |  5.594 ns |



## Serialize to string, big class

|                        Method |     Mean |     Error |    StdDev |   Median |
|------------------------------ |---------:|----------:|----------:|---------:|
|             RunSystemTextJson | 5.201 us | 0.1036 us | 0.2783 us | 5.092 us |
|                 RunNewtonsoft | 5.549 us | 0.1218 us | 0.2134 us | 5.507 us |
| RunDataContractJsonSerializer | 8.857 us | 0.1759 us | 0.2523 us | 8.886 us |
|                        RunJil | 2.707 us | 0.0533 us | 0.0781 us | 2.704 us |
|                   RunUtf8Json | 1.465 us | 0.0293 us | 0.0325 us | 1.462 us |
|               RunServiceStack | 4.575 us | 0.0911 us | 0.1902 us | 4.559 us |



## Serialize to string, List 

| Method                        |     Mean |     Error |    StdDev |
| ----------------------------- | -------: | --------: | --------: |
| RunSystemTextJson             | 702.5 us |  4.087 us |  3.623 us |
| RunNewtonsoft                 | 780.7 us | 15.076 us | 14.102 us |
| RunDataContractJsonSerializer | 858.5 us |  9.548 us |  8.931 us |
| RunJil                        | 219.3 us |  4.374 us |  5.371 us |
| RunUtf8Json                   | 112.6 us |  1.311 us |  1.227 us |
| RunServiceStack               | 537.6 us |  6.789 us |  6.018 us |



## Serialize to string, Array

| Method                        |     Mean |     Error |    StdDev |
| ----------------------------- | -------: | --------: | --------: |
| RunSystemTextJson             | 742.7 us | 14.780 us | 24.694 us |
| RunNewtonsoft                 | 814.3 us | 12.116 us | 11.333 us |
| RunDataContractJsonSerializer | 917.1 us | 18.250 us | 32.439 us |
| RunJil                        | 232.2 us |  3.541 us |  3.139 us |
| RunUtf8Json                   | 116.4 us |  2.257 us |  2.217 us |
| RunServiceStack               | 596.2 us |  8.099 us |  7.180 us |



## Serialize to string, Dictionary



| Method                        |       Mean |     Error |    StdDev |     Median |
| ----------------------------- | ---------: | --------: | --------: | ---------: |
| RunSystemTextJson             |   929.1 us | 10.657 us |  9.969 us |   929.7 us |
| RunNewtonsoft                 |   833.1 us | 16.249 us | 18.060 us |   830.3 us |
| RunDataContractJsonSerializer | 1,488.1 us | 29.941 us | 54.748 us | 1,463.8 us |
| RunJil                        |   320.0 us |  3.530 us |  3.302 us |   319.0 us |
| RunUtf8Json                   |   186.0 us |  3.586 us |  5.367 us |   185.5 us |
| RunServiceStack               |   595.0 us | 11.763 us | 10.427 us |   593.6 us |



## Serialize to Stream, Small class

| Method                        |       Mean |     Error |    StdDev |
| ----------------------------- | ---------: | --------: | --------: |
| RunSystemTextJson             |         NA |        NA |        NA |
| RunNewtonsoft                 |   780.1 ns | 15.400 ns | 16.478 ns |
| RunDataContractJsonSerializer |   938.2 ns | 18.160 ns | 20.185 ns |
| RunJil                        |   184.3 ns |  2.201 ns |  1.951 ns |
| RunUtf8Json                   |   139.8 ns |  3.305 ns |  3.246 ns |
| RunServiceStack               | 1,060.9 ns | 21.880 ns | 34.065 ns |



Serialize to Stream, Big class

| Method                        |     Mean |     Error |    StdDev |
| ----------------------------- | -------: | --------: | --------: |
| RunSystemTextJson             | 5.200 us | 0.1072 us | 0.0951 us |
| RunNewtonsoft                 | 5.124 us | 0.1003 us | 0.1909 us |
| RunDataContractJsonSerializer | 7.236 us | 0.1158 us | 0.0967 us |
| RunJil                        | 1.902 us | 0.0338 us | 0.0316 us |
| RunUtf8Json                   | 1.259 us | 0.0221 us | 0.0207 us |
| RunServiceStack               | 4.838 us | 0.0955 us | 0.1173 us |

Serialize to Stream, List

| Method                        |      Mean |     Error |    StdDev |
| ----------------------------- | --------: | --------: | --------: |
| RunSystemTextJson             | 747.09 us | 15.022 us | 16.071 us |
| RunNewtonsoft                 | 754.59 us | 14.855 us | 14.590 us |
| RunDataContractJsonSerializer | 738.27 us |  8.391 us |  7.438 us |
| RunJil                        | 130.65 us |  2.555 us |  3.824 us |
| RunUtf8Json                   |  83.18 us |  1.596 us |  1.960 us |
| RunServiceStack               | 497.76 us |  8.580 us |  7.606 us |

Serialize to stream, Dictionary

| Method                        |       Mean |     Error |    StdDev |
| ----------------------------- | ---------: | --------: | --------: |
| RunSystemTextJson             |     962 us |  20.10 us | 18.891 us |
| RunNewtonsoft                 |   771.1 us |  8.019 us |  7.501 us |
| RunDataContractJsonSerializer | 1,306.3 us | 14.834 us | 13.876 us |
| RunJil                        |   215.7 us |  2.026 us |  1.895 us |
| RunUtf8Json                   |   192.6 us |  2.889 us |  2.255 us |
| RunServiceStack               |   539.9 us |  5.332 us |  4.453 us |







## Deserialize from string

deserialize from string, small class

| Method          |       Mean |     Error |    StdDev |
| --------------- | ---------: | --------: | --------: |
| SystemTextJson  |   838.8 ns |  9.811 ns |  9.177 ns |
| RunNewtonsoft   | 1,513.9 ns | 15.836 ns | 14.813 ns |
| RunJil          |   272.5 ns |  2.386 ns |  1.863 ns |
| RunUtf8Json     |   355.5 ns |  3.910 ns |  3.466 ns |
| RunServiceStack |   496.3 ns |  2.806 ns |  2.488 ns |

deserialize from string, big class

| Method          |      Mean |     Error |    StdDev |
| --------------- | --------: | --------: | --------: |
| SystemTextJson  |  7.613 us | 0.1444 us | 0.1351 us |
| RunNewtonsoft   | 12.763 us | 0.2465 us | 0.2740 us |
| RunJil          |  4.025 us | 0.0763 us | 0.0676 us |
| RunUtf8Json     |  4.205 us | 0.0799 us | 0.0785 us |
| RunServiceStack |  6.812 us | 0.1345 us | 0.1601 us |

deserialize from string, List

| Method          |       Mean |     Error |    StdDev |
| --------------- | ---------: | --------: | --------: |
| SystemTextJson  | 1,126.9 us | 18.027 us | 16.862 us |
| RunNewtonsoft   | 1,291.1 us | 25.720 us | 26.413 us |
| RunJil          |   309.5 us |  5.989 us |  9.671 us |
| RunUtf8Json     |   327.9 us |  6.899 us |  6.453 us |
| RunServiceStack |   892.6 us | 17.046 us | 19.630 us |

deserialize from string, Dictionary

| Method          |       Mean |     Error |    StdDev |
| --------------- | ---------: | --------: | --------: |
| SystemTextJson  | 1,244.1 us | 20.413 us | 19.094 us |
| RunNewtonsoft   | 1,617.3 us | 32.144 us | 34.394 us |
| RunJil          |   613.0 us | 11.926 us | 18.568 us |
| RunUtf8Json     |   688.6 us |  7.568 us |  6.319 us |
| RunServiceStack | 1,176.3 us | 22.861 us | 29.725 us |



## Deserialize on server



Deserialize 1000 item list of SmallClass - # requests / second :

A>Each test was run several times. The edge cases were dismissed and average taken



**Deserialize 1000 small class list**

  SystemTextJson: 239, 325 339 336

   Newtonsoft: 179, 195 196 199

   Utf8Json: 740 1163 1166 1165



**Serialize 1000 small class list**

   SystemTextJson: 745, 913, 921, 927, 921

   Newtonsoft : 121, 135, 130

​	Utf8Json : 1914, 1905, 1987, 1646, 1940
