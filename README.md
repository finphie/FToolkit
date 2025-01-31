# FToolkit

[![Build(.NET)](https://github.com/finphie/FToolkit/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/FToolkit/actions/workflows/build-dotnet.yml)

各種処理を詰め合わせたライブラリです。

## 説明

FToolkitは、システムやファイル操作などの各種処理を詰め合わせたライブラリです。

> [!Important]
> 作者が必要な機能のみ実装しています。

> [!Warning]
> メジャーバージョンアップ以外でも破壊的変更を行うことがあります。

## 一覧

### Frameworks

|ライブラリ名|正式リリース|開発用ビルド|説明|
|-|-|-|-|
|FToolkit.Diagnostics|[![NuGet](https://img.shields.io/nuget/v/FToolkit.Diagnostics?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.Diagnostics/)|[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/8efc9e09-0a75-488d-8cd4-22e8d17a8092/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/FToolkit.Diagnostics?preferRelease=true)|システム関連処理の詰め合わせです。|
|FToolkit.Diagnostics.Abstractions|[![NuGet](https://img.shields.io/nuget/v/FToolkit.Diagnostics.Abstractions?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.Diagnostics.Abstractions/)|[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/cada7c86-a601-44df-b92c-78e81eac481c/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/FToolkit.Diagnostics.Abstractions?preferRelease=true)|FToolkit.Diagnosticsの抽象化です。|
|FToolkit.IO|[![NuGet](https://img.shields.io/nuget/v/FToolkit.IO?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.IO/)|[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/ca91d183-9e94-4295-ba1f-4fef31731cc3/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/FToolkit.IO?preferRelease=true)|IO関連処理の詰め合わせです。|
|FToolkit.IO.Abstractions|[![NuGet](https://img.shields.io/nuget/v/FToolkit.IO.Abstractions?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.IO.Abstractions/)|[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/e4ab5317-d6ad-49ef-a6eb-654c0c166c2e/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/FToolkit.IO.Abstractions?preferRelease=true)|FToolkit.IOの抽象化です。|

### Repositories

|ライブラリ名|正式リリース|開発用ビルド|説明|
|-|-|-|-|
|FToolkit.Repositories.Abstractions|[![NuGet](https://img.shields.io/nuget/v/FToolkit.Repositories.Abstractions?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.Repositories.Abstractions/)|[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/ee1fe309-e173-4d6c-ada5-a12012da6df0/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/FToolkit.Repositories.Abstractions?preferRelease=true)|FToolkit Repositoryの抽象化です。|

## 作者

finphie

## ライセンス

MIT

## クレジット

このプロジェクトでは、次のライブラリ等を使用しています。

### ライブラリ

- [CommunityToolkit.HighPerformance](https://github.com/CommunityToolkit/dotnet)
- Microsoft.Extensions.Logging.Abstractions
- [ProcessX](https://github.com/Cysharp/ProcessX)

### アナライザー

- [DocumentationAnalyzers](https://github.com/DotNetAnalyzers/DocumentationAnalyzers)
- [IDisposableAnalyzers](https://github.com/DotNetAnalyzers/IDisposableAnalyzers)
- [Microsoft.CodeAnalysis.NetAnalyzers](https://github.com/dotnet/roslyn-analyzers)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [Roslynator.Analyzers](https://github.com/dotnet/roslynator)
- [Roslynator.Formatting.Analyzers](https://github.com/dotnet/roslynator)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)

### その他

- [PolySharp](https://github.com/Sergio0694/PolySharp)
