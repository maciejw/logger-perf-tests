# Comparison of serilog 2.9.0 vs nlog 4.6.8 vs log4net 2.0.8


``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.100-preview3-014645
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT
  Job-LZJFLS : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), X64 RyuJIT
  Job-DECESO : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT


```
|  Method |       Runtime | KeepFileOpen | Buffered |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |
|-------- |-------------- |------------- |--------- |------------:|----------:|----------:|------------:|------:|--------:|
| **Serilog** | **.NET Core 2.1** |        **False** |    **False** |    **27.05 us** |  **0.536 us** |  **1.084 us** |    **26.57 us** |  **1.00** |    **0.00** |
|    NLog | .NET Core 2.1 |        False |    False | 1,186.37 us | 23.376 us | 50.320 us | 1,182.86 us | 43.91 |    2.68 |
| Log4Net | .NET Core 2.1 |        False |    False | 1,153.77 us | 22.977 us | 51.864 us | 1,140.66 us | 42.94 |    2.88 |
|         |               |              |          |             |           |           |             |       |         |
| Serilog | .NET Core 3.0 |        False |    False |    22.95 us |  0.160 us |  0.150 us |    22.94 us |  1.00 |    0.00 |
|    NLog | .NET Core 3.0 |        False |    False | 1,191.76 us | 23.762 us | 35.566 us | 1,196.30 us | 52.30 |    1.63 |
| Log4Net | .NET Core 3.0 |        False |    False | 1,161.39 us | 23.167 us | 53.694 us | 1,152.19 us | 49.70 |    2.66 |
|         |               |              |          |             |           |           |             |       |         |
| **Serilog** | **.NET Core 2.1** |        **False** |     **True** |    **16.84 us** |  **0.189 us** |  **0.177 us** |    **16.78 us** |  **1.00** |    **0.00** |
|    NLog | .NET Core 2.1 |        False |     True | 1,207.56 us | 24.742 us | 56.350 us | 1,199.93 us | 70.87 |    3.44 |
| Log4Net | .NET Core 2.1 |        False |     True |   728.11 us | 14.003 us | 15.565 us |   725.66 us | 43.13 |    1.08 |
|         |               |              |          |             |           |           |             |       |         |
| Serilog | .NET Core 3.0 |        False |     True |    13.90 us |  0.170 us |  0.151 us |    13.89 us |  1.00 |    0.00 |
|    NLog | .NET Core 3.0 |        False |     True | 1,214.41 us | 24.156 us | 53.022 us | 1,215.48 us | 83.85 |    3.35 |
| Log4Net | .NET Core 3.0 |        False |     True |   731.46 us | 10.351 us |  9.683 us |   734.48 us | 52.56 |    0.91 |
|         |               |              |          |             |           |           |             |       |         |
| **Serilog** | **.NET Core 2.1** |         **True** |    **False** |    **26.42 us** |  **0.175 us** |  **0.164 us** |    **26.40 us** |  **1.00** |    **0.00** |
|    NLog | .NET Core 2.1 |         True |    False |    29.89 us |  0.328 us |  0.291 us |    29.75 us |  1.13 |    0.01 |
| Log4Net | .NET Core 2.1 |         True |    False |    66.45 us |  0.475 us |  0.421 us |    66.33 us |  2.52 |    0.02 |
|         |               |              |          |             |           |           |             |       |         |
| Serilog | .NET Core 3.0 |         True |    False |    22.90 us |  0.176 us |  0.165 us |    22.88 us |  1.00 |    0.00 |
|    NLog | .NET Core 3.0 |         True |    False |    26.74 us |  0.161 us |  0.135 us |    26.72 us |  1.17 |    0.01 |
| Log4Net | .NET Core 3.0 |         True |    False |    61.78 us |  0.408 us |  0.341 us |    61.85 us |  2.70 |    0.02 |
|         |               |              |          |             |           |           |             |       |         |
| **Serilog** | **.NET Core 2.1** |         **True** |     **True** |    **16.87 us** |  **0.109 us** |  **0.102 us** |    **16.83 us** |  **1.00** |    **0.00** |
|    NLog | .NET Core 2.1 |         True |     True |    17.86 us |  0.139 us |  0.130 us |    17.86 us |  1.06 |    0.01 |
| Log4Net | .NET Core 2.1 |         True |     True |    54.38 us |  0.461 us |  0.431 us |    54.34 us |  3.22 |    0.04 |
|         |               |              |          |             |           |           |             |       |         |
| Serilog | .NET Core 3.0 |         True |     True |    13.97 us |  0.103 us |  0.091 us |    13.97 us |  1.00 |    0.00 |
|    NLog | .NET Core 3.0 |         True |     True |    15.70 us |  0.114 us |  0.095 us |    15.68 us |  1.12 |    0.01 |
| Log4Net | .NET Core 3.0 |         True |     True |    52.33 us |  0.579 us |  0.542 us |    52.16 us |  3.74 |    0.05 |
