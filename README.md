# Comparision of serilog 2.9.0 vs nlog 4.6.8 vs log4net 2.0.8


``` ini

BenchmarkDotNet=v0.11.5, OS=Windows 10.0.18363
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.100-preview3-014645
  [Host] : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT
  Core   : .NET Core 3.0.0 (CoreCLR 4.700.19.46205, CoreFX 4.700.19.46214), 64bit RyuJIT

Job=Core  Runtime=Core  

```
|                       Method |        Mean |      Error |     StdDev | Ratio | RatioSD |
|----------------------------- |------------:|-----------:|-----------:|------:|--------:|
|                      Log4Net |   963.69 us | 19.1754 us | 32.0377 us | 40.00 |    1.21 |
| Log4NetLockingModelExclusive |    62.26 us |  1.3377 us |  1.2512 us |  2.62 |    0.06 |
|    NLogKeepFileOpenAutoFlush |    28.53 us |  0.2757 us |  0.2579 us |  1.20 |    0.02 |
|                         NLog | 1,032.88 us | 20.5246 us | 40.0317 us | 44.86 |    1.68 |
|                NLogAutoFlush | 1,078.86 us | 16.8555 us | 14.9419 us | 45.32 |    0.96 |
|             NLogKeepFileOpen |    15.75 us |  0.1434 us |  0.1197 us |  0.66 |    0.01 |
|                      Serilog |    23.81 us |  0.2939 us |  0.2606 us |  1.00 |    0.00 |
|              SerilogBuffered |    14.68 us |  0.2353 us |  0.2201 us |  0.62 |    0.01 |
