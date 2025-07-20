using FToolkit.Extensions;
using Shouldly;
using Xunit;

namespace FToolkit.Tests;

public sealed class PathGetTempFilePathTest
{
    [Fact]
    public void 拡張子指定なし_ファイルパスを返す()
    {
        const string Extension = ".tmp";
        var filePath = Path.GetTempFilePath();

        filePath.ShouldEndWith(Extension);
        Path.IsPathFullyQualified(filePath).ShouldBeTrue();
    }

    [Theory]
    [InlineData(".a")]
    [InlineData(".abc")]
    public void 有効な拡張子_ファイルパスを返す(string extension)
    {
        var filePath = Path.GetTempFilePath(extension);

        filePath.ShouldEndWith(extension);
        Path.IsPathFullyQualified(filePath).ShouldBeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(".")]
    [InlineData("a")]
    public void 不正な拡張子_Error(string? extension)
        => Should.Throw<ArgumentException>(() => Path.GetTempFilePath(extension));
}
