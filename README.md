# FToolkit

[![Build(.NET)](https://github.com/finphie/FToolkit/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/FToolkit/actions/workflows/build-dotnet.yml)
[![NuGet](https://img.shields.io/nuget/v/FToolkit?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit/)
[![FToolkit package in DotNet feed in Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/18cbb017-6f1d-41eb-b9a5-a6dbf411e3f7/Packages/13a33d25-881a-49e3-88a2-3775a2667a9d/Badge)](https://dev.azure.com/finphie/Main/_packaging?_a=package&feed=18cbb017-6f1d-41eb-b9a5-a6dbf411e3f7&package=13a33d25-881a-49e3-88a2-3775a2667a9d&preferRelease=true)

各種処理を詰め合わせたライブラリです。

## 説明

FToolkitは、システムやファイル操作などの各種処理を詰め合わせたライブラリです。

## インストール

### NuGet（正式リリース版）

```console
dotnet add package FToolkit
```

### Azure Artifacts（開発用ビルド）

```console
dotnet add package FToolkit -s https://pkgs.dev.azure.com/finphie/Main/_packaging/DotNet/nuget/v3/index.json
```

## サポートフレームワーク

- .NET 6

## 作者

finphie

## ライセンス

MIT

## クレジット

このプロジェクトでは、次のライブラリ等を使用しています。

### ライブラリ

- [CommunityToolkit.HighPerformance](https://github.com/CommunityToolkit/dotnet)
- [Microsoft.Extensions.Logging.Abstractions](https://github.com/dotnet/runtime)  
- [ProcessX](https://github.com/Cysharp/ProcessX)

### テスト

- [FluentAssertions](https://fluentassertions.com/)
- [Microsoft.NET.Test.Sdk](https://github.com/microsoft/vstest/)
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
