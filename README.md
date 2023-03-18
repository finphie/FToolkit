# FToolkit

[![Build(.NET)](https://github.com/finphie/FToolkit/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/FToolkit/actions/workflows/build-dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/FToolkit.Diagnostics?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.Diagnostics/)
[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/18cbb017-6f1d-41eb-b9a5-a6dbf411e3f7/Packages/8efc9e09-0a75-488d-8cd4-22e8d17a8092/Badge)](https://dev.azure.com/finphie/Main/_packaging?_a=package&feed=18cbb017-6f1d-41eb-b9a5-a6dbf411e3f7&package=8efc9e09-0a75-488d-8cd4-22e8d17a8092&preferRelease=true)

各種処理を詰め合わせたライブラリです。

## 説明

FToolkitは、システムやファイル操作などの各種処理を詰め合わせたライブラリです。

## インストール

ライブラリ名|説明
-|-
[FToolkit.Diagnostics.Abstractions](https://www.nuget.org/packages/FToolkit.Diagnostics.Abstractions/)|FToolkit.Diagnosticsの抽象化です。
[FToolkit.Diagnostics](https://www.nuget.org/packages/FToolkit.Diagnostics/)|システム関連処理の詰め合わせです。
[FToolkit.IO.Abstractions](https://www.nuget.org/packages/FToolkit.IO.Abstractions/)|FToolkit.IOの抽象化です。
[FToolkit.IO](https://www.nuget.org/packages/FToolkit.IO/)|IO関連処理の詰め合わせです。

### NuGet（正式リリース版）

```shell
dotnet add package FToolkit.Diagnostics
dotnet add package FToolkit.IO
```

### Azure Artifacts（開発用ビルド）

```shell
dotnet add package FToolkit.Diagnostics -s https://pkgs.dev.azure.com/finphie/Main/_packaging/DotNet/nuget/v3/index.json
dotnet add package FToolkit.IO -s https://pkgs.dev.azure.com/finphie/Main/_packaging/DotNet/nuget/v3/index.json
```

## サポートフレームワーク

- .NET 7
- .NET 6

## 作者

finphie

## ライセンス

MIT

## クレジット

このプロジェクトでは、次のライブラリ等を使用しています。

### ライブラリ

- Microsoft.Extensions.Logging.Abstractions
- [ProcessX](https://github.com/Cysharp/ProcessX)

### テスト

- [FluentAssertions](https://github.com/fluentassertions/fluentassertions)
- [Microsoft.NET.Test.Sdk](https://github.com/microsoft/vstest)
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
- [NuGet.Frameworks](https://github.com/NuGet/NuGet.Client)
- [xunit](https://github.com/xunit/xunit)
- [xunit.runner.visualstudio](https://github.com/xunit/visualstudio.xunit)

### アナライザー

- Microsoft.CodeAnalysis.NetAnalyzers (SDK組み込み)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)

### その他

- [Microsoft.SourceLink.GitHub](https://github.com/dotnet/sourcelink)
