<details>
  <summary>Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores</summary>

``` ini

BenchmarkDotNet=v0.13.5, OS=macOS Ventura 13.1 (22C65) [Darwin 22.2.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD


```
|                         Method |  Count |            Mean |           Error |          StdDev |      Gen0 |     Gen1 |     Gen2 |  Allocated |
|------------------------------- |------- |----------------:|----------------:|----------------:|----------:|---------:|---------:|-----------:|
|              AllNotAwaitSimple |     10 |        379.4 ns |         2.61 ns |         2.32 ns |    0.0634 |        - |        - |      400 B |
|                AllNotAwaitTask |     10 |        347.7 ns |         2.79 ns |         2.47 ns |    0.0634 |        - |        - |      400 B |
|           AllNotAwaitValueTask |     10 |        351.6 ns |         1.43 ns |         1.34 ns |    0.0520 |        - |        - |      328 B |
|                 AllAwaitSimple |     10 |     36,305.6 ns |     1,553.43 ns |     4,580.33 ns |    0.2441 |        - |        - |     1844 B |
|                   AllAwaitTask |     10 |     25,302.4 ns |       999.17 ns |     2,946.07 ns |    0.3052 |        - |        - |     1949 B |
|              AllAwaitValueTask |     10 |     24,384.7 ns |       709.76 ns |     2,070.40 ns |    0.2747 |        - |        - |     1877 B |
|    HalfAwaitHalfNotAwaitSimple |     10 |     28,400.0 ns |     1,657.14 ns |     4,860.11 ns |    0.1831 |        - |        - |     1282 B |
|      HalfAwaitHalfNotAwaitTask |     10 |     15,543.3 ns |       682.59 ns |     2,001.93 ns |    0.2136 |        - |        - |     1386 B |
| HalfAwaitHalfNotAwaitValueTask |     10 |     15,071.1 ns |       555.76 ns |     1,621.19 ns |    0.1984 |        - |        - |     1314 B |
| | | | | | | | | |
|              AllNotAwaitSimple |   1000 |     27,119.5 ns |       288.37 ns |       269.74 ns |    1.3428 |        - |        - |     8608 B |
|                AllNotAwaitTask |   1000 |     25,568.2 ns |       132.02 ns |       123.49 ns |    1.3428 |        - |        - |     8608 B |
|           AllNotAwaitValueTask |   1000 |     25,281.5 ns |       136.80 ns |       127.96 ns |    1.3428 |        - |        - |     8536 B |
|                 AllAwaitSimple |   1000 |    836,353.3 ns |    16,501.14 ns |    27,111.85 ns |   19.5313 |        - |        - |   120992 B |
|                   AllAwaitTask |   1000 |    835,632.7 ns |    18,680.21 ns |    54,785.83 ns |   19.5313 |        - |        - |   121091 B |
|              AllAwaitValueTask |   1000 |    933,602.3 ns |    19,399.95 ns |    56,590.56 ns |   19.5313 |        - |        - |   121009 B |
|    HalfAwaitHalfNotAwaitSimple |   1000 |    505,682.3 ns |    10,110.18 ns |    23,632.22 ns |   10.2539 |        - |        - |    64983 B |
|      HalfAwaitHalfNotAwaitTask |   1000 |    593,817.7 ns |    11,846.84 ns |    26,740.30 ns |    9.7656 |        - |        - |    65073 B |
| HalfAwaitHalfNotAwaitValueTask |   1000 |    491,103.8 ns |     9,513.92 ns |    25,558.53 ns |   10.2539 |        - |        - |    65017 B |
| | | | | | | | | |
|              AllNotAwaitSimple |  10000 |    274,100.6 ns |     4,270.93 ns |     3,786.06 ns |   20.5078 |   1.4648 |        - |   131584 B |
|                AllNotAwaitTask |  10000 |    254,677.4 ns |     2,695.01 ns |     2,520.92 ns |   20.5078 |   1.9531 |        - |   131584 B |
|           AllNotAwaitValueTask |  10000 |    253,878.4 ns |     2,980.49 ns |     2,787.95 ns |   20.5078 |        - |        - |   131512 B |
|                 AllAwaitSimple |  10000 |  6,730,909.2 ns |   295,171.10 ns |   861,027.95 ns |  195.3125 |  39.0625 |        - |  1251978 B |
|                   AllAwaitTask |  10000 |  6,365,460.5 ns |   311,001.98 ns |   902,273.14 ns |  187.5000 |  31.2500 |        - |  1252091 B |
|              AllAwaitValueTask |  10000 |  8,294,054.3 ns |   290,765.52 ns |   857,328.69 ns |  203.1250 |  46.8750 |        - |  1252019 B |
|    HalfAwaitHalfNotAwaitSimple |  10000 |  3,768,552.6 ns |    84,392.65 ns |   243,492.08 ns |  109.3750 |  19.5313 |        - |   691968 B |
|      HalfAwaitHalfNotAwaitTask |  10000 |  4,360,162.4 ns |    86,933.26 ns |   199,743.62 ns |  109.3750 |  23.4375 |        - |   692081 B |
| HalfAwaitHalfNotAwaitValueTask |  10000 |  3,619,258.6 ns |    71,322.75 ns |   126,776.12 ns |  109.3750 |  19.5313 |        - |   692004 B |
| | | | | | | | | |
|              AllNotAwaitSimple | 100000 |  2,830,878.9 ns |    18,101.15 ns |    15,115.28 ns |  285.1563 | 285.1563 | 285.1563 |  1049355 B |
|                AllNotAwaitTask | 100000 |  2,629,061.3 ns |    46,074.07 ns |    43,097.71 ns |  285.1563 | 285.1563 | 285.1563 |  1049355 B |
|           AllNotAwaitValueTask | 100000 |  2,621,061.1 ns |    21,398.59 ns |    20,016.25 ns |  285.1563 | 285.1563 | 285.1563 |  1049283 B |
|                 AllAwaitSimple | 100000 | 56,588,751.7 ns | 2,326,610.54 ns | 6,860,063.68 ns | 1777.7778 | 222.2222 | 222.2222 | 12249893 B |
|                   AllAwaitTask | 100000 | 57,642,334.5 ns | 2,333,217.00 ns | 6,879,542.97 ns | 1800.0000 | 200.0000 | 200.0000 | 12249962 B |
|              AllAwaitValueTask | 100000 | 57,409,275.8 ns | 2,573,997.42 ns | 7,589,489.46 ns | 1750.0000 | 250.0000 | 250.0000 | 12249969 B |
|    HalfAwaitHalfNotAwaitSimple | 100000 | 28,028,002.7 ns | 1,200,622.66 ns | 3,521,218.42 ns |  933.3333 | 333.3333 | 266.6667 |  6649923 B |
|      HalfAwaitHalfNotAwaitTask | 100000 | 31,057,337.3 ns | 1,773,282.68 ns | 5,228,563.98 ns |  968.7500 | 375.0000 | 281.2500 |  6650015 B |
| HalfAwaitHalfNotAwaitValueTask | 100000 | 34,712,046.2 ns | 1,186,687.28 ns | 3,498,974.21 ns |  937.5000 | 312.5000 | 250.0000 |  6649932 B |

</details>

<details>
  <summary>12th Gen Intel Core i5-12600K, 1 CPU, 16 logical and 10 physical cores</summary>

``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1555/22H2/2022Update/SunValley2)
12th Gen Intel Core i5-12600K, 1 CPU, 16 logical and 10 physical cores
.NET SDK=7.0.105
  [Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


```
|                         Method |  Count |            Mean |           Error |          StdDev |      Gen0 |     Gen1 |     Gen2 |  Allocated |
|------------------------------- |------- |----------------:|----------------:|----------------:|----------:|---------:|---------:|-----------:|
|              AllNotAwaitSimple |     10 |        410.2 ns |         5.85 ns |         5.48 ns |    0.0381 |        - |        - |      400 B |
|                AllNotAwaitTask |     10 |        301.3 ns |         6.03 ns |         5.35 ns |    0.0381 |        - |        - |      400 B |
|           AllNotAwaitValueTask |     10 |        300.2 ns |         3.49 ns |         3.26 ns |    0.0310 |        - |        - |      328 B |
|                 AllAwaitSimple |     10 |      6,120.3 ns |        35.56 ns |        31.52 ns |    0.1755 |        - |        - |     1840 B |
|                   AllAwaitTask |     10 |      6,207.0 ns |        23.38 ns |        20.73 ns |    0.1831 |        - |        - |     1944 B |
|              AllAwaitValueTask |     10 |      6,219.3 ns |        31.24 ns |        29.23 ns |    0.1755 |        - |        - |     1872 B |
|    HalfAwaitHalfNotAwaitSimple |     10 |      3,577.2 ns |        35.66 ns |        31.61 ns |    0.1221 |        - |        - |     1280 B |
|      HalfAwaitHalfNotAwaitTask |     10 |      3,608.9 ns |        26.73 ns |        25.01 ns |    0.1297 |        - |        - |     1384 B |
| HalfAwaitHalfNotAwaitValueTask |     10 |      3,671.4 ns |        14.09 ns |        13.18 ns |    0.1259 |        - |        - |     1312 B |
| | | | | | | | | |
|              AllNotAwaitSimple |   1000 |     27,993.4 ns |       158.54 ns |       148.30 ns |    0.7935 |        - |        - |     8608 B |
|                AllNotAwaitTask |   1000 |     22,663.7 ns |       133.71 ns |       118.53 ns |    0.7935 |        - |        - |     8608 B |
|           AllNotAwaitValueTask |   1000 |     22,403.9 ns |        91.13 ns |        85.25 ns |    0.7935 |        - |        - |     8536 B |
|                 AllAwaitSimple |   1000 |    532,131.0 ns |     3,661.16 ns |     3,424.65 ns |   11.7188 |        - |        - |   120993 B |
|                   AllAwaitTask |   1000 |    539,811.6 ns |     2,415.25 ns |     2,259.23 ns |   11.7188 |        - |        - |   121095 B |
|              AllAwaitValueTask |   1000 |    530,162.1 ns |     3,149.51 ns |     2,791.96 ns |   11.7188 |        - |        - |   121025 B |
|    HalfAwaitHalfNotAwaitSimple |   1000 |    304,494.4 ns |     1,182.70 ns |       987.61 ns |    6.3477 |        - |        - |    64992 B |
|      HalfAwaitHalfNotAwaitTask |   1000 |    305,805.0 ns |     1,850.01 ns |     1,730.50 ns |    6.3477 |        - |        - |    65096 B |
| HalfAwaitHalfNotAwaitValueTask |   1000 |    301,357.3 ns |     1,350.77 ns |     1,197.43 ns |    6.3477 |        - |        - |    65024 B |
| | | | | | | | | |
|              AllNotAwaitSimple |  10000 |    285,001.7 ns |     2,176.40 ns |     2,035.81 ns |   12.2070 |   1.9531 |        - |   131584 B |
|                AllNotAwaitTask |  10000 |    227,701.9 ns |     1,666.02 ns |     1,476.89 ns |   12.4512 |   2.4414 |        - |   131584 B |
|           AllNotAwaitValueTask |  10000 |    224,947.5 ns |     1,151.46 ns |     1,077.08 ns |   12.4512 |   2.4414 |        - |   131512 B |
|                 AllAwaitSimple |  10000 |  5,283,877.6 ns |    23,578.05 ns |    22,054.92 ns |  117.1875 |  23.4375 |        - |  1251975 B |
|                   AllAwaitTask |  10000 |  5,250,289.5 ns |    40,860.22 ns |    38,220.68 ns |  117.1875 |  23.4375 |        - |  1252072 B |
|              AllAwaitValueTask |  10000 |  5,258,683.2 ns |    73,859.72 ns |    65,474.72 ns |  117.1875 |  23.4375 |        - |  1252007 B |
|    HalfAwaitHalfNotAwaitSimple |  10000 |  2,911,972.9 ns |    50,658.66 ns |    44,907.58 ns |   66.4063 |  15.6250 |        - |   691971 B |
|      HalfAwaitHalfNotAwaitTask |  10000 |  2,901,879.8 ns |    16,700.42 ns |    15,621.58 ns |   66.4063 |  15.6250 |        - |   692075 B |
| HalfAwaitHalfNotAwaitValueTask |  10000 |  2,829,402.0 ns |    39,358.01 ns |    36,815.51 ns |   66.4063 |  11.7188 |        - |   692007 B |
| | | | | | | | | |
|              AllNotAwaitSimple | 100000 |  3,063,427.7 ns |    23,031.29 ns |    17,981.32 ns |  285.1563 | 285.1563 | 285.1563 |  1049258 B |
|                AllNotAwaitTask | 100000 |  2,511,606.6 ns |    40,290.83 ns |    35,716.77 ns |  285.1563 | 285.1563 | 285.1563 |  1049259 B |
|           AllNotAwaitValueTask | 100000 |  2,526,043.8 ns |    50,011.77 ns |    46,781.04 ns |  285.1563 | 285.1563 | 285.1563 |  1049186 B |
|                 AllAwaitSimple | 100000 | 57,505,984.0 ns | 1,142,433.29 ns | 1,068,632.81 ns | 1100.0000 | 200.0000 | 200.0000 | 12249758 B |
|                   AllAwaitTask | 100000 | 55,337,317.5 ns |   805,294.98 ns |   713,873.03 ns | 1111.1111 | 222.2222 | 222.2222 | 12249867 B |
|              AllAwaitValueTask | 100000 | 55,087,637.9 ns |   594,664.96 ns |   527,155.00 ns | 1100.0000 | 200.0000 | 200.0000 | 12249823 B |
|    HalfAwaitHalfNotAwaitSimple | 100000 | 29,217,898.8 ns |   203,765.55 ns |   170,153.46 ns |  562.5000 | 281.2500 | 281.2500 |  6649747 B |
|      HalfAwaitHalfNotAwaitTask | 100000 | 29,319,951.5 ns |   572,574.26 ns |   535,586.32 ns |  562.5000 | 281.2500 | 281.2500 |  6649851 B |
| HalfAwaitHalfNotAwaitValueTask | 100000 | 28,485,285.4 ns |   356,201.58 ns |   333,191.18 ns |  562.5000 | 281.2500 | 281.2500 |  6649779 B |
</details>
