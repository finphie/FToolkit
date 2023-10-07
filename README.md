# FToolkit

[![Build(.NET)](https://github.com/finphie/FToolkit/actions/workflows/build-dotnet.yml/badge.svg)](https://github.com/finphie/FToolkit/actions/workflows/build-dotnet.yml)

各種処理を詰め合わせたライブラリです。

## 説明

FToolkitは、システムやファイル操作などの各種処理を詰め合わせたライブラリです。

## 一覧

ライブラリ名|正式リリース|開発用ビルド|説明
-|-|-|-
FToolkit.CodeAnalysis.CSharp|[![NuGet](https://img.shields.io/nuget/v/FToolkit.CodeAnalysis.CSharp?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.CodeAnalysis.CSharp/)|[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/d0b79bb1-23d8-42ec-9ff2-05b53918e247/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/FToolkit.CodeAnalysis.CSharp?preferRelease=true)|C#コード関連処理の詰め合わせです。
FToolkit.CodeAnalysis.CSharp.Abstractions|[![NuGet](https://img.shields.io/nuget/v/FToolkit.CodeAnalysis.CSharp.Abstractions?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.CodeAnalysis.CSharp.Abstractions/)|[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/eac3836c-6ff5-42db-8d7b-dbd72915021a/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/FToolkit.CodeAnalysis.CSharp.Abstractions?preferRelease=true)|FToolkit.CodeAnalysis.CSharpの抽象化です。
FToolkit.Diagnostics|[![NuGet](https://img.shields.io/nuget/v/FToolkit.Diagnostics?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.Diagnostics/)|[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/18cbb017-6f1d-41eb-b9a5-a6dbf411e3f7/Packages/8efc9e09-0a75-488d-8cd4-22e8d17a8092/Badge)](https://dev.azure.com/finphie/Main/_packaging?_a=package&feed=18cbb017-6f1d-41eb-b9a5-a6dbf411e3f7&package=8efc9e09-0a75-488d-8cd4-22e8d17a8092&preferRelease=true)|システム関連処理の詰め合わせです。
FToolkit.Diagnostics.Abstractions|[![NuGet](https://img.shields.io/nuget/v/FToolkit.Diagnostics.Abstractions?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.Diagnostics.Abstractions/)|[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/cada7c86-a601-44df-b92c-78e81eac481c/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/FToolkit.Diagnostics.Abstractions?preferRelease=true)|FToolkit.Diagnosticsの抽象化です。
FToolkit.IO|[![NuGet](https://img.shields.io/nuget/v/FToolkit.IO?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.IO/)|[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/ca91d183-9e94-4295-ba1f-4fef31731cc3/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/FToolkit.IO?preferRelease=true)|IO関連処理の詰め合わせです。
FToolkit.IO.Abstractions|[![NuGet](https://img.shields.io/nuget/v/FToolkit.IO.Abstractions?color=0078d4&label=NuGet)](https://www.nuget.org/packages/FToolkit.IO.Abstractions/)|[![Azure Artifacts](https://feeds.dev.azure.com/finphie/7af9aa4d-c550-43af-87a5-01539b2d9934/_apis/public/Packaging/Feeds/DotNet/Packages/e4ab5317-d6ad-49ef-a6eb-654c0c166c2e/Badge)](https://dev.azure.com/finphie/Main/_artifacts/feed/DotNet/NuGet/FToolkit.IO.Abstractions?preferRelease=true)|FToolkit.IOの抽象化です。
FToolkit.Net.GitHub.Client|||GitHub APIクライアントです。
FToolkit.Net.GitHub.Client.Abstractions|||FToolkit.Net.GitHub.Clientの抽象化です。
FToolkit.Net.GitHub.Repositories|||GitHub APIを利用して各種処理を行います。
FToolkit.Net.GitHub.Repositories.Abstractions|||FToolkit.Net.GitHub.Repositoriesの抽象化です。
FToolkit.Net.GitHub.Services|||GitHub設定の更新処理を行います。
FToolkit.Net.GitHub.Services.Abstractions|||FToolkit.Net.GitHub.Servicesの抽象化です。
FToolkit.Repositories.Abstractions|||FToolkit Repositoryの抽象化です。

## 作者

finphie

## ライセンス

MIT

## クレジット

このプロジェクトでは、次のライブラリ等を使用しています。

### ライブラリ

- [CommunityToolkit.HighPerformance](https://github.com/CommunityToolkit/dotnet)
- [Microsoft.CodeAnalysis.CSharp](https://github.com/dotnet/roslyn)
- Microsoft.Extensions.Logging.Abstractions
- [ProcessX](https://github.com/Cysharp/ProcessX)

### テスト

- [FluentAssertions](https://github.com/fluentassertions/fluentassertions)
- [Microsoft.NET.Test.Sdk](https://github.com/microsoft/vstest)
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)
- [NuGet.Frameworks](https://github.com/NuGet/NuGet.Client)
- [RichardSzalay.MockHttp](https://github.com/richardszalay/mockhttp)
- [xunit](https://github.com/xunit/xunit)
- [xunit.runner.visualstudio](https://github.com/xunit/visualstudio.xunit)

### アナライザー

- Microsoft.CodeAnalysis.NetAnalyzers (SDK組み込み)
- [Microsoft.VisualStudio.Threading.Analyzers](https://github.com/Microsoft/vs-threading)
- [StyleCop.Analyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers)

### その他

- [Microsoft.SourceLink.GitHub](https://github.com/dotnet/sourcelink)
- [PolySharp](https://github.com/Sergio0694/PolySharp)
