namespace FToolkit.CodeAnalysis.CSharp;

/// <summary>
/// コンパイル結果を表すクラスです。
/// </summary>
/// <param name="RawAssembly">アセンブリデータ</param>
/// <param name="Messages">コンパイラのメッセージリスト</param>
public sealed record CompileResult(ReadOnlyMemory<byte> RawAssembly, CompilerMessageList Messages);
