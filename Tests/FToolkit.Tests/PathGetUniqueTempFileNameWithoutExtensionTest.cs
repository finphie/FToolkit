using FToolkit.Extensions;
using Shouldly;
using Xunit;

namespace FToolkit.Tests;

public sealed class PathGetUniqueTempFileNameWithoutExtensionTest
{
    [Fact]
    public void ファイル名を返す()
        => Guid.TryParse(Path.GetUniqueTempFileNameWithoutExtension(), out _).ShouldBeTrue();
}
