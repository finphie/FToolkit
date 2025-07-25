﻿using FToolkit.IO;
using Shouldly;
using Xunit;

namespace FToolkit.Tests.IO;

public sealed class PathGetUniqueTempFileNameTest
{
    [Fact]
    public void 拡張子指定なし_ファイル名を返す()
    {
        const string Extension = ".tmp";
        var fileName = Path.GetUniqueTempFileName().AsPrimitive();

        fileName.ShouldEndWith(Extension);
        Guid.TryParse(fileName[..^Extension.Length], out _).ShouldBeTrue();
    }

    [Theory]
    [InlineData(".a")]
    [InlineData(".abc")]
    public void 有効な拡張子_ファイル名を返す(string extension)
    {
        var fileName = Path.GetUniqueTempFileName(extension).AsPrimitive();

        fileName.ShouldEndWith(extension);
        Guid.TryParse(fileName[..^extension.Length], out _).ShouldBeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(".")]
    [InlineData("a")]
    public void 不正な拡張子_Error(string? extension)
        => Should.Throw<ArgumentException>(() => Path.GetUniqueTempFileName(extension));
}
