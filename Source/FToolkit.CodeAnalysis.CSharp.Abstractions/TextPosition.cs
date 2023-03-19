namespace FToolkit.CodeAnalysis.CSharp;

/// <summary>
/// テキストの位置を表します。
/// </summary>
/// <param name="Line">行の位置</param>
/// <param name="Offset">列の位置</param>
public sealed record TextPosition(int Line, int Offset) : ISpanFormattable
{
    const int BufferSize = 16;

    /// <inheritdoc/>
    public override string ToString()
        => string.Create(null, stackalloc char[BufferSize], $"({Line}, {Offset})");

    /// <inheritdoc cref="ISpanFormattable.TryFormat(Span{char}, out int, ReadOnlySpan{char}, IFormatProvider?)"/>
    public bool TryFormat(Span<char> destination, out int charsWritten)
        => destination.TryWrite(null, $"({Line}, {Offset})", out charsWritten);

    /// <inheritdoc/>
    string IFormattable.ToString(string? format, IFormatProvider? formatProvider)
        => ToString();

    /// <inheritdoc/>
    bool ISpanFormattable.TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        => TryFormat(destination, out charsWritten);
}
