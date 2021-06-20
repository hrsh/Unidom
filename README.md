# Unidom
Simply create a random string

[![.NET](https://github.com/hrsh/Unidom/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hrsh/Unidom/actions/workflows/dotnet.yml)

`dotnet add package Unidom`

```csharp
var t = Uuid.Random(4, 8);
var u = Uuid.Random(8).Flat(4, ":");
// output: lJWq:xcmt
Console.WriteLine(t.Value);
```
#### Random odd number
```csharp
var odd = Uuid.Odd(6);
// output: 567824

var longOdd = Uuid.Odd(17, allowDuplicate: true)
// output: 58723698259024156
```

#### Random even number
```csharp
var even = Uuid.Even(4);
// output: 149723

var longEven = Uuid.Even(12, allowDuplicate: true)
// output: 560247895897
```
