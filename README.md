# Comparison of serilog 2.9.0 vs nlog 4.6.8 vs log4net 2.0.8

``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.100-preview3-014645
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT
  Job-FEGHVT : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT
  Job-ZFSMZI : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT
  Job-NUZNHO : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), X64 RyuJIT
  Job-QWVPNG : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT


```
|  Method |       Runtime |             FileMode |        Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |
|-------- |-------------- |--------------------- |------------:|-------------:|-------------:|------------:|-------:|--------:|
| **Serilog** |    **.NET 4.6.1** |                 **None** |    **35.20 us** |     **1.464 us** |     **4.224 us** |    **34.09 us** |   **1.00** |    **0.00** |
|    NLog |    .NET 4.6.1 |                 None | 8,353.49 us | 1,440.655 us | 1,821.968 us | 7,552.81 us | 221.04 |   50.99 |
| Log4Net |    .NET 4.6.1 |                 None | 8,771.96 us |   171.555 us |   313.698 us | 8,649.53 us | 238.43 |   25.29 |
|         |               |                      |             |              |              |             |        |         |
| Serilog |      .NET 4.8 |                 None |    30.58 us |     0.608 us |     1.515 us |    30.01 us |   1.00 |    0.00 |
|    NLog |      .NET 4.8 |                 None | 8,212.45 us | 1,481.376 us | 3,313.309 us | 7,593.09 us | 267.29 |   98.99 |
| Log4Net |      .NET 4.8 |                 None | 8,713.80 us |   151.857 us |   142.048 us | 8,748.33 us | 284.13 |   14.84 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 2.1 |                 None |    26.42 us |     0.374 us |     0.350 us |    26.35 us |   1.00 |    0.00 |
|    NLog | .NET Core 2.1 |                 None | 1,092.19 us |    21.415 us |    33.341 us | 1,087.53 us |  41.38 |    1.10 |
| Log4Net | .NET Core 2.1 |                 None |   964.92 us |    19.025 us |    33.321 us |   962.60 us |  36.02 |    1.39 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 3.0 |                 None |    23.30 us |     0.287 us |     0.254 us |    23.30 us |   1.00 |    0.00 |
|    NLog | .NET Core 3.0 |                 None |   987.48 us |    24.025 us |    24.672 us |   978.71 us |  42.43 |    1.30 |
| Log4Net | .NET Core 3.0 |                 None |   938.13 us |    19.868 us |    39.678 us |   938.45 us |  38.34 |    1.05 |
|         |               |                      |             |              |              |             |        |         |
| **Serilog** |    **.NET 4.6.1** |         **KeepFileOpen** |    **30.17 us** |     **0.619 us** |     **1.814 us** |    **29.11 us** |   **1.00** |    **0.00** |
|    NLog |    .NET 4.6.1 |         KeepFileOpen |    31.34 us |     0.199 us |     0.166 us |    31.33 us |   1.03 |    0.06 |
| Log4Net |    .NET 4.6.1 |         KeepFileOpen |   350.54 us |     3.692 us |     3.454 us |   349.52 us |  11.64 |    0.69 |
|         |               |                      |             |              |              |             |        |         |
| Serilog |      .NET 4.8 |         KeepFileOpen |    30.08 us |     0.611 us |     1.802 us |    29.15 us |   1.00 |    0.00 |
|    NLog |      .NET 4.8 |         KeepFileOpen |    31.51 us |     0.464 us |     0.411 us |    31.44 us |   1.06 |    0.05 |
| Log4Net |      .NET 4.8 |         KeepFileOpen |   352.12 us |     6.889 us |     7.075 us |   350.61 us |  11.87 |    0.59 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 2.1 |         KeepFileOpen |    25.91 us |     0.187 us |     0.175 us |    25.87 us |   1.00 |    0.00 |
|    NLog | .NET Core 2.1 |         KeepFileOpen |    23.88 us |     0.239 us |     0.224 us |    23.86 us |   0.92 |    0.01 |
| Log4Net | .NET Core 2.1 |         KeepFileOpen |    64.65 us |     0.606 us |     0.537 us |    64.59 us |   2.49 |    0.03 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 3.0 |         KeepFileOpen |    22.35 us |     0.145 us |     0.135 us |    22.37 us |   1.00 |    0.00 |
|    NLog | .NET Core 3.0 |         KeepFileOpen |    23.50 us |     0.219 us |     0.194 us |    23.44 us |   1.05 |    0.01 |
| Log4Net | .NET Core 3.0 |         KeepFileOpen |    60.13 us |     0.763 us |     0.713 us |    59.96 us |   2.69 |    0.04 |
|         |               |                      |             |              |              |             |        |         |
| **Serilog** |    **.NET 4.6.1** | **KeepFileOpenBuffered** |    **21.15 us** |     **0.430 us** |     **1.267 us** |    **21.06 us** |   **1.00** |    **0.00** |
|    NLog |    .NET 4.6.1 | KeepFileOpenBuffered |    17.64 us |     0.106 us |     0.088 us |    17.64 us |   0.84 |    0.06 |
| Log4Net |    .NET 4.6.1 | KeepFileOpenBuffered |   332.96 us |     4.609 us |     4.311 us |   332.11 us |  15.88 |    1.06 |
|         |               |                      |             |              |              |             |        |         |
| Serilog |      .NET 4.8 | KeepFileOpenBuffered |    20.55 us |     0.410 us |     1.202 us |    20.77 us |   1.00 |    0.00 |
|    NLog |      .NET 4.8 | KeepFileOpenBuffered |    17.51 us |     0.161 us |     0.151 us |    17.47 us |   0.85 |    0.06 |
| Log4Net |      .NET 4.8 | KeepFileOpenBuffered |   331.84 us |     6.031 us |     5.641 us |   329.38 us |  16.16 |    1.11 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 2.1 | KeepFileOpenBuffered |    16.34 us |     0.121 us |     0.107 us |    16.33 us |   1.00 |    0.00 |
|    NLog | .NET Core 2.1 | KeepFileOpenBuffered |    13.84 us |     0.126 us |     0.105 us |    13.85 us |   0.85 |    0.01 |
| Log4Net | .NET Core 2.1 | KeepFileOpenBuffered |    53.51 us |     0.423 us |     0.396 us |    53.40 us |   3.28 |    0.03 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 3.0 | KeepFileOpenBuffered |    13.74 us |     0.084 us |     0.074 us |    13.73 us |   1.00 |    0.00 |
|    NLog | .NET Core 3.0 | KeepFileOpenBuffered |    13.08 us |     0.123 us |     0.115 us |    13.10 us |   0.95 |    0.01 |
| Log4Net | .NET Core 3.0 | KeepFileOpenBuffered |    50.93 us |     0.340 us |     0.301 us |    50.89 us |   3.71 |    0.03 |
|         |               |                      |             |              |              |             |        |         |
| **Serilog** |    **.NET 4.6.1** |   **KeepFileOpenShared** |    **36.20 us** |     **0.717 us** |     **1.705 us** |    **35.25 us** |   **1.00** |    **0.00** |
|    NLog |    .NET 4.6.1 |   KeepFileOpenShared |    47.18 us |     0.624 us |     0.521 us |    47.13 us |   1.31 |    0.06 |
| Log4Net |    .NET 4.6.1 |   KeepFileOpenShared |   363.06 us |     7.087 us |     7.278 us |   360.12 us |   9.97 |    0.61 |
|         |               |                      |             |              |              |             |        |         |
| Serilog |      .NET 4.8 |   KeepFileOpenShared |    35.49 us |     1.027 us |     1.009 us |    35.06 us |   1.00 |    0.00 |
|    NLog |      .NET 4.8 |   KeepFileOpenShared |    47.19 us |     0.398 us |     0.353 us |    47.09 us |   1.33 |    0.04 |
| Log4Net |      .NET 4.8 |   KeepFileOpenShared |   362.14 us |     5.149 us |     4.565 us |   362.02 us |  10.21 |    0.35 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 2.1 |   KeepFileOpenShared |    42.43 us |     0.330 us |     0.292 us |    42.49 us |   1.00 |    0.00 |
|    NLog | .NET Core 2.1 |   KeepFileOpenShared |   430.46 us |     8.394 us |     8.244 us |   430.64 us |  10.15 |    0.23 |
| Log4Net | .NET Core 2.1 |   KeepFileOpenShared |    75.14 us |     0.571 us |     0.534 us |    75.19 us |   1.77 |    0.02 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 3.0 |   KeepFileOpenShared |    37.87 us |     0.209 us |     0.195 us |    37.91 us |   1.00 |    0.00 |
|    NLog | .NET Core 3.0 |   KeepFileOpenShared |   491.15 us |     9.292 us |     8.692 us |   491.86 us |  12.97 |    0.24 |
| Log4Net | .NET Core 3.0 |   KeepFileOpenShared |    72.60 us |     1.161 us |     1.086 us |    72.01 us |   1.92 |    0.03 |
