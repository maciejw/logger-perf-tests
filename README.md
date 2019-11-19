# Comparison of serilog 2.9.0 vs nlog 4.6.8 vs log4net 2.0.8

``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.100-preview3-014645
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT
  Job-HYPXPK : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), X64 RyuJIT
  Job-SLXJRW : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT


```
|  Method |       Runtime |             FileMode |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |
|-------- |-------------- |--------------------- |----------:|----------:|----------:|----------:|------:|--------:|
| **Serilog** | **.NET Core 2.1** |                 **None** |  **27.22 us** |  **0.436 us** |  **0.408 us** |  **27.18 us** |  **1.00** |    **0.00** |
|    NLog | .NET Core 2.1 |                 None | 963.27 us | 19.888 us | 32.676 us | 962.48 us | 35.35 |    1.35 |
| Log4Net | .NET Core 2.1 |                 None | 939.36 us | 18.481 us | 32.850 us | 937.04 us | 34.16 |    1.44 |
|         |               |                      |           |           |           |           |       |         |
| Serilog | .NET Core 3.0 |                 None |  23.93 us |  0.445 us |  0.457 us |  24.05 us |  1.00 |    0.00 |
|    NLog | .NET Core 3.0 |                 None | 931.09 us | 10.853 us |  8.473 us | 932.99 us | 38.88 |    0.90 |
| Log4Net | .NET Core 3.0 |                 None | 908.96 us | 17.980 us | 27.993 us | 905.80 us | 38.04 |    1.57 |
|         |               |                      |           |           |           |           |       |         |
| **Serilog** | **.NET Core 2.1** |         **KeepFileOpen** |  **26.63 us** |  **0.226 us** |  **0.212 us** |  **26.62 us** |  **1.00** |    **0.00** |
|    NLog | .NET Core 2.1 |         KeepFileOpen |  24.28 us |  0.190 us |  0.169 us |  24.26 us |  0.91 |    0.01 |
| Log4Net | .NET Core 2.1 |         KeepFileOpen |  65.67 us |  0.863 us |  0.765 us |  65.47 us |  2.47 |    0.03 |
|         |               |                      |           |           |           |           |       |         |
| Serilog | .NET Core 3.0 |         KeepFileOpen |  23.02 us |  0.144 us |  0.134 us |  23.02 us |  1.00 |    0.00 |
|    NLog | .NET Core 3.0 |         KeepFileOpen |  22.96 us |  0.191 us |  0.179 us |  22.93 us |  1.00 |    0.01 |
| Log4Net | .NET Core 3.0 |         KeepFileOpen |  60.40 us |  0.989 us |  0.925 us |  60.09 us |  2.62 |    0.04 |
|         |               |                      |           |           |           |           |       |         |
| **Serilog** | **.NET Core 2.1** | **KeepFileOpenBuffered** |  **16.42 us** |  **0.104 us** |  **0.093 us** |  **16.41 us** |  **1.00** |    **0.00** |
|    NLog | .NET Core 2.1 | KeepFileOpenBuffered |  13.61 us |  0.094 us |  0.088 us |  13.60 us |  0.83 |    0.01 |
| Log4Net | .NET Core 2.1 | KeepFileOpenBuffered |  54.15 us |  0.430 us |  0.402 us |  54.09 us |  3.30 |    0.02 |
|         |               |                      |           |           |           |           |       |         |
| Serilog | .NET Core 3.0 | KeepFileOpenBuffered |  14.11 us |  0.102 us |  0.095 us |  14.09 us |  1.00 |    0.00 |
|    NLog | .NET Core 3.0 | KeepFileOpenBuffered |  12.87 us |  0.158 us |  0.148 us |  12.82 us |  0.91 |    0.01 |
| Log4Net | .NET Core 3.0 | KeepFileOpenBuffered |  51.33 us |  0.278 us |  0.247 us |  51.32 us |  3.63 |    0.03 |
|         |               |                      |           |           |           |           |       |         |
| **Serilog** | **.NET Core 2.1** |   **KeepFileOpenShared** |  **42.29 us** |  **0.245 us** |  **0.229 us** |  **42.27 us** |  **1.00** |    **0.00** |
|    NLog | .NET Core 2.1 |   KeepFileOpenShared | 477.29 us | 15.378 us | 45.343 us | 450.63 us | 12.10 |    0.53 |
| Log4Net | .NET Core 2.1 |   KeepFileOpenShared |  74.98 us |  0.469 us |  0.416 us |  74.84 us |  1.77 |    0.02 |
|         |               |                      |           |           |           |           |       |         |
| Serilog | .NET Core 3.0 |   KeepFileOpenShared |  38.60 us |  0.143 us |  0.126 us |  38.61 us |  1.00 |    0.00 |
|    NLog | .NET Core 3.0 |   KeepFileOpenShared | 495.71 us |  9.786 us | 19.543 us | 498.80 us | 12.52 |    0.38 |
| Log4Net | .NET Core 3.0 |   KeepFileOpenShared |  71.01 us |  0.292 us |  0.259 us |  71.08 us |  1.84 |    0.01 |
