using System.Buffers;
using System.Runtime.CompilerServices;

namespace FToolkit.Diagnostics.Extensions;

/// <summary>
/// <see cref="IBufferWriter{T}"/>を実装オブジェクト関連の拡張メソッド集です。
/// </summary>
static class BufferWriterExtensions
{
    /// <summary>
    /// <paramref name="bufferWriter"/>に<paramref name="value"/>と改行を書き込みます。
    /// </summary>
    /// <param name="bufferWriter"><see cref="char"/>データを書き込むことができる出力シンク</param>
    /// <param name="value"><paramref name="value"/>に書き込む値</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteLine(this IBufferWriter<char> bufferWriter, string value)
    {
        bufferWriter.Write(value);
        bufferWriter.Write("\n");
    }
}
