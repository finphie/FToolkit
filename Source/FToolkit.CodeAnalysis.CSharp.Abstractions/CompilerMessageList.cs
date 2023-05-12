using System.Buffers;
using System.Collections;

namespace FToolkit.CodeAnalysis.CSharp;

/// <summary>
/// コンパイラメッセージのリストを表すクラスです。
/// </summary>
/// <param name="Messages">コンパイラメッセージ</param>
public sealed record CompilerMessageList(IReadOnlyList<CompilerMessage> Messages)
    : IReadOnlyList<CompilerMessage>, ISpanFormattable
{
    /// <summary>
    /// 空を表す<see cref="CompilerMessage"/>インスタンスを取得します。
    /// </summary>
    /// <value>
    /// <see cref="CompilerMessage"/>クラスの空配列で初期化したインスタンスを返します。
    /// </value>
    public static CompilerMessageList Empty => EmptyArray.Value;

    /// <inheritdoc/>
    public int Count => Messages.Count;

    /// <inheritdoc/>
    public CompilerMessage this[int index] => Messages[index];

    /// <inheritdoc/>
    public IEnumerator<CompilerMessage> GetEnumerator() => Messages.GetEnumerator();

    /// <inheritdoc/>
    public override string ToString()
    {
        var buffer = ArrayPool<char>.Shared.Rent(1024);
        TryFormat(buffer, out var charsWritten);

        var result = buffer.AsSpan(0, charsWritten).ToString();
        ArrayPool<char>.Shared.Return(buffer);

        return result;
    }

    /// <inheritdoc cref="ISpanFormattable.TryFormat(Span{char}, out int, ReadOnlySpan{char}, IFormatProvider?)"/>
    public bool TryFormat(Span<char> destination, out int charsWritten)
    {
        charsWritten = 0;

        foreach (var message in Messages)
        {
            if (!destination.TryWrite(null, $"{message}\n", out var written))
            {
                return false;
            }

            destination = destination[written..];
            charsWritten += written;
        }

        return true;
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => Messages.GetEnumerator();

    /// <inheritdoc/>
    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
        => ToString();

    /// <inheritdoc/>
    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => TryFormat(destination, out charsWritten);

    static class EmptyArray
    {
        public static readonly CompilerMessageList Value = new(Array.Empty<CompilerMessage>());
    }
}
