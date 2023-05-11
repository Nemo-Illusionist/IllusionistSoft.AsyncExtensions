``` ini

BenchmarkDotNet=v0.13.5, OS=macOS Ventura 13.1 (22C65) [Darwin 22.2.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD


```
|                   Method |      Mean |     Error |     StdDev |      Gen0 |     Gen1 |     Gen2 | Allocated |
|------------------------- |----------:|----------:|-----------:|----------:|---------:|---------:|----------:|
|                ToListAll |  2.842 ms | 0.0274 ms |  0.0243 ms |  285.1563 | 285.1563 | 285.1563 |      1 MB |
|          SimpleToListAll |  3.020 ms | 0.0430 ms |  0.0382 ms |  285.1563 | 285.1563 | 285.1563 |      1 MB |
|           ToListAllAwait | 56.103 ms | 6.4856 ms | 19.1230 ms | 2090.9091 | 272.7273 | 272.7273 |  13.21 MB |
|     SimpleToListAllAwait | 93.389 ms | 4.8681 ms | 14.3538 ms | 2000.0000 | 166.6667 | 166.6667 |  13.21 MB |
|       ToListAllHalfAwait | 41.278 ms | 3.1296 ms |  9.2276 ms | 1100.0000 | 300.0000 | 200.0000 |    7.1 MB |
| SimpleToListAllHalfAwait | 41.722 ms | 2.3531 ms |  6.9382 ms | 1090.9091 | 363.6364 | 272.7273 |    7.1 MB |
