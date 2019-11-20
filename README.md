# Comparison of serilog vs nlog vs log4net

``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.100-preview3-014645
  [Host]     : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT
  Job-QOTXSC : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT
  Job-VGAFWK : .NET Framework 4.8 (4.8.4042.0), X64 RyuJIT
  Job-VMFNZL : .NET Core 2.1.13 (CoreCLR 4.6.28008.01, CoreFX 4.6.28008.01), X64 RyuJIT
  Job-CPCTYY : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), X64 RyuJIT

NuGetReferences=log4net 2.0.8,NLog 4.5.11,Serilog 2.9.0  

```
|  Method |       Runtime |             FileMode |        Mean |        Error |       StdDev |      Median |  Ratio | RatioSD |
|-------- |-------------- |--------------------- |------------:|-------------:|-------------:|------------:|-------:|--------:|
| **Serilog** |    **.NET 4.6.1** |                 **None** |    **29.89 us** |     **0.650 us** |     **1.156 us** |    **29.43 us** |   **1.00** |    **0.00** |
|    NLog |    .NET 4.6.1 |                 None | 7,930.54 us |   781.507 us | 1,043.290 us | 7,406.16 us | 265.12 |   37.10 |
| Log4Net |    .NET 4.6.1 |                 None | 8,513.48 us |   165.214 us |   169.663 us | 8,505.44 us | 285.38 |   13.03 |
|         |               |                      |             |              |              |             |        |         |
| Serilog |      .NET 4.8 |                 None |    30.47 us |     0.991 us |     1.018 us |    30.03 us |   1.00 |    0.00 |
|    NLog |      .NET 4.8 |                 None | 8,369.79 us | 1,287.185 us | 1,718.355 us | 7,501.55 us | 289.44 |   66.35 |
| Log4Net |      .NET 4.8 |                 None | 8,502.14 us |   156.214 us |   130.446 us | 8,463.88 us | 278.01 |   10.56 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 2.1 |                 None |    26.17 us |     0.243 us |     0.216 us |    26.14 us |   1.00 |    0.00 |
|    NLog | .NET Core 2.1 |                 None | 1,089.25 us |    21.402 us |    21.019 us | 1,086.83 us |  41.64 |    0.96 |
| Log4Net | .NET Core 2.1 |                 None | 1,014.00 us |    19.864 us |    22.079 us | 1,019.27 us |  38.76 |    0.87 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 3.0 |                 None |    23.22 us |     0.457 us |     0.449 us |    23.07 us |   1.00 |    0.00 |
|    NLog | .NET Core 3.0 |                 None |   963.68 us |    19.068 us |    21.958 us |   963.44 us |  41.52 |    1.07 |
| Log4Net | .NET Core 3.0 |                 None |   877.78 us |    16.987 us |    28.844 us |   875.92 us |  37.22 |    1.41 |
|         |               |                      |             |              |              |             |        |         |
| **Serilog** |    **.NET 4.6.1** |         **KeepFileOpen** |    **29.27 us** |     **0.574 us** |     **0.824 us** |    **28.96 us** |   **1.00** |    **0.00** |
|    NLog |    .NET 4.6.1 |         KeepFileOpen |    31.63 us |     0.286 us |     0.254 us |    31.54 us |   1.08 |    0.04 |
| Log4Net |    .NET 4.6.1 |         KeepFileOpen |   350.88 us |     4.958 us |     4.637 us |   349.54 us |  11.95 |    0.40 |
|         |               |                      |             |              |              |             |        |         |
| Serilog |      .NET 4.8 |         KeepFileOpen |    29.95 us |     0.598 us |     1.299 us |    29.30 us |   1.00 |    0.00 |
|    NLog |      .NET 4.8 |         KeepFileOpen |    31.52 us |     0.223 us |     0.198 us |    31.45 us |   1.05 |    0.05 |
| Log4Net |      .NET 4.8 |         KeepFileOpen |   352.88 us |     6.115 us |     5.720 us |   353.53 us |  11.82 |    0.54 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 2.1 |         KeepFileOpen |    25.88 us |     0.136 us |     0.120 us |    25.87 us |   1.00 |    0.00 |
|    NLog | .NET Core 2.1 |         KeepFileOpen |    23.98 us |     0.180 us |     0.160 us |    23.96 us |   0.93 |    0.01 |
| Log4Net | .NET Core 2.1 |         KeepFileOpen |    65.29 us |     0.652 us |     0.578 us |    65.15 us |   2.52 |    0.03 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 3.0 |         KeepFileOpen |    23.16 us |     0.150 us |     0.140 us |    23.11 us |   1.00 |    0.00 |
|    NLog | .NET Core 3.0 |         KeepFileOpen |    23.22 us |     0.101 us |     0.084 us |    23.21 us |   1.00 |    0.01 |
| Log4Net | .NET Core 3.0 |         KeepFileOpen |    59.78 us |     0.311 us |     0.243 us |    59.78 us |   2.58 |    0.02 |
|         |               |                      |             |              |              |             |        |         |
| **Serilog** |    **.NET 4.6.1** | **KeepFileOpenBuffered** |    **20.97 us** |     **0.419 us** |     **1.187 us** |    **20.38 us** |   **1.00** |    **0.00** |
|    NLog |    .NET 4.6.1 | KeepFileOpenBuffered |    17.62 us |     0.196 us |     0.183 us |    17.61 us |   0.85 |    0.04 |
| Log4Net |    .NET 4.6.1 | KeepFileOpenBuffered |   332.31 us |     3.886 us |     3.635 us |   331.71 us |  15.96 |    0.85 |
|         |               |                      |             |              |              |             |        |         |
| Serilog |      .NET 4.8 | KeepFileOpenBuffered |    20.68 us |     0.423 us |     1.248 us |    20.01 us |   1.00 |    0.00 |
|    NLog |      .NET 4.8 | KeepFileOpenBuffered |    17.82 us |     0.139 us |     0.123 us |    17.80 us |   0.86 |    0.06 |
| Log4Net |      .NET 4.8 | KeepFileOpenBuffered |   333.40 us |     3.162 us |     2.803 us |   333.82 us |  16.00 |    1.11 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 2.1 | KeepFileOpenBuffered |    16.80 us |     0.077 us |     0.072 us |    16.80 us |   1.00 |    0.00 |
|    NLog | .NET Core 2.1 | KeepFileOpenBuffered |    14.16 us |     0.132 us |     0.117 us |    14.14 us |   0.84 |    0.01 |
| Log4Net | .NET Core 2.1 | KeepFileOpenBuffered |    54.40 us |     0.342 us |     0.303 us |    54.38 us |   3.24 |    0.02 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 3.0 | KeepFileOpenBuffered |    13.90 us |     0.107 us |     0.095 us |    13.88 us |   1.00 |    0.00 |
|    NLog | .NET Core 3.0 | KeepFileOpenBuffered |    13.21 us |     0.079 us |     0.070 us |    13.22 us |   0.95 |    0.01 |
| Log4Net | .NET Core 3.0 | KeepFileOpenBuffered |    50.31 us |     0.301 us |     0.267 us |    50.24 us |   3.62 |    0.03 |
|         |               |                      |             |              |              |             |        |         |
| **Serilog** |    **.NET 4.6.1** |   **KeepFileOpenShared** |    **34.96 us** |     **0.421 us** |     **0.329 us** |    **34.93 us** |   **1.00** |    **0.00** |
|    NLog |    .NET 4.6.1 |   KeepFileOpenShared |    46.64 us |     0.321 us |     0.285 us |    46.60 us |   1.33 |    0.01 |
| Log4Net |    .NET 4.6.1 |   KeepFileOpenShared |   362.50 us |     5.159 us |     4.826 us |   361.10 us |  10.39 |    0.17 |
|         |               |                      |             |              |              |             |        |         |
| Serilog |      .NET 4.8 |   KeepFileOpenShared |    35.41 us |     0.282 us |     0.221 us |    35.41 us |   1.00 |    0.00 |
|    NLog |      .NET 4.8 |   KeepFileOpenShared |    47.53 us |     0.477 us |     0.398 us |    47.45 us |   1.34 |    0.02 |
| Log4Net |      .NET 4.8 |   KeepFileOpenShared |   363.86 us |     6.807 us |     6.367 us |   362.68 us |  10.27 |    0.17 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 2.1 |   KeepFileOpenShared |    43.92 us |     0.592 us |     0.495 us |    43.77 us |   1.00 |    0.00 |
|    NLog | .NET Core 2.1 |   KeepFileOpenShared |   441.67 us |     9.230 us |    27.069 us |   432.91 us |  11.07 |    0.39 |
| Log4Net | .NET Core 2.1 |   KeepFileOpenShared |    76.12 us |     0.515 us |     0.456 us |    76.14 us |   1.73 |    0.02 |
|         |               |                      |             |              |              |             |        |         |
| Serilog | .NET Core 3.0 |   KeepFileOpenShared |    39.34 us |     0.382 us |     0.339 us |    39.35 us |   1.00 |    0.00 |
|    NLog | .NET Core 3.0 |   KeepFileOpenShared |   406.35 us |     5.537 us |     4.908 us |   406.13 us |  10.33 |    0.14 |
| Log4Net | .NET Core 3.0 |   KeepFileOpenShared |    70.86 us |     0.358 us |     0.318 us |    70.80 us |   1.80 |    0.02 |
