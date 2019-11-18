# Comparision of serilog 2.9.0 and nlog 4.6.8


``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18363
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.100-preview3-014645
  [Host] : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT
  Core   : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT

Job=Core  Runtime=Core  

```
|                    Method |        Mean |      Error |     StdDev | Ratio | RatioSD |
|-------------------------- |------------:|-----------:|-----------:|------:|--------:|
| NLogKeepFileOpenAutoFlush |    27.42 us |  0.6601 us |  0.5852 us |  1.15 |    0.02 |
|                      NLog | 1,039.33 us | 19.9619 us | 23.7632 us | 43.46 |    1.31 |
|             NLogAutoFlush | 1,040.61 us | 20.4470 us | 35.2701 us | 44.10 |    1.45 |
|          NLogKeepFileOpen |    16.31 us |  0.1163 us |  0.1088 us |  0.68 |    0.01 |
|                   Serilog |    23.82 us |  0.2571 us |  0.2405 us |  1.00 |    0.00 |
|           SerilogBuffered |    14.18 us |  0.2706 us |  0.2399 us |  0.60 |    0.01 |
