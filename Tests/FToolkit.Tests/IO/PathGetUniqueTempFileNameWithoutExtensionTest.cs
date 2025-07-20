using FToolkit.IO.Extensions;
using Shouldly;
using Xunit;

namespace FToolkit.Tests.IO;

public sealed class PathGetUniqueTempFileNameWithoutExtensionTest
{
    [Fact]
    public void ファイル名を返す()
        => Guid.TryParse(Path.GetUniqueTempFileNameWithoutExtension().AsPrimitive(), out _).ShouldBeTrue();
}
