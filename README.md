# Comparision of serilog 2.9.0 vs nlog 4.6.8 vs log4net 2.0.8


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
|                   Log4Net | 1,102.52 us | 24.2902 us | 46.2147 us | 46.67 |    2.79 |
| NLogKeepFileOpenAutoFlush |    28.29 us |  0.5343 us |  0.4736 us |  1.20 |    0.02 |
|                      NLog | 1,057.99 us | 20.9862 us | 24.9826 us | 44.82 |    1.17 |
|             NLogAutoFlush | 1,042.90 us | 26.9321 us | 25.1923 us | 44.24 |    1.08 |
|          NLogKeepFileOpen |    15.77 us |  0.1368 us |  0.1213 us |  0.67 |    0.01 |
|                   Serilog |    23.57 us |  0.1871 us |  0.1751 us |  1.00 |    0.00 |
|           SerilogBuffered |    14.29 us |  0.3100 us |  0.2899 us |  0.61 |    0.01 |
