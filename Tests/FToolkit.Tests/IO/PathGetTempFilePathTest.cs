using FToolkit.IO.Extensions;
using Shouldly;
using Xunit;

namespace FToolkit.Tests.IO;

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
    [InlineData("x", ".a")]
    [InlineData("xyz", ".abc")]
    [InlineData("a/b/c", ".a")]
    [InlineData("a/b/c/", ".a")]
    [InlineData("/a/b/c", ".a")]
    [InlineData(@"a\b\c", ".a")]
    public void 有効な親ディレクトリ名と拡張子_ファイルパスを返す(string parentDirectoryPath, string extension)
    {
        var filePath = Path.GetTempFilePath(parentDirectoryPath, extension);

        filePath.ShouldEndWith(extension);
        Path.IsPathFullyQualified(filePath).ShouldBeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(".")]
    [InlineData("a")]
    public void 不正な拡張子_ArgumentException(string? extension)
        => Should.Throw<ArgumentException>(() => Path.GetTempFilePath(extension));

    [Theory]
    [InlineData(null, ".a")]
    [InlineData("", ".a")]
    [InlineData("a", null)]
    [InlineData("a", "")]
    [InlineData("a", ".")]
    public void 不正な親ディレクトリ名や拡張子_ArgumentException(string? parentDirectoryPath, string? extension)
        => Should.Throw<ArgumentException>(() => Path.GetTempFilePath(parentDirectoryPath, extension));
}
