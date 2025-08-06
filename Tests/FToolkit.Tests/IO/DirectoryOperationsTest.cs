using FToolkit.IO;
using FToolkit.Objects;
using Microsoft.Extensions.Logging.Abstractions;
using Shouldly;
using Xunit;

namespace FToolkit.Tests.IO;

public sealed class DirectoryOperationsTest : IDisposable
{
    readonly DirectoryPath _path;

    public DirectoryOperationsTest()
    {
        _path = new(Path.Combine(Path.GetTempPath(), "TestDir_" + Guid.NewGuid()));
        Directory.Exists(_path.AsPrimitive()).ShouldBeFalse();
    }

    public void Dispose()
    {
        var directoryPath = _path.AsPrimitive();

        if (!Directory.Exists(directoryPath))
        {
            return;
        }

        Directory.Delete(directoryPath);
    }

    [Fact]
    public void Exists_ディレクトリが存在する_trueを返す()
    {
        CreateTestDirectory();

        var directoryOperations = CreateDirectoryOperations();
        directoryOperations.Exists(_path).ShouldBeTrue();
    }

    [Fact]
    public void Exists_ディレクトリが存在しない_falseを返す()
    {
        var directoryOperations = CreateDirectoryOperations();
        directoryOperations.Exists(_path).ShouldBeFalse();
    }

    [Fact]
    public void Create_同名ディレクトリなし_ディレクトリが作成される()
        => CreateAndAssertDirectoryCreated();

    [Fact]
    public void Create_同名ディレクトリあり_例外が発生しない()
    {
        CreateTestDirectory();
        CreateAndAssertDirectoryCreated();
    }

    static DirectoryOperations CreateDirectoryOperations() => new(NullLogger<DirectoryOperations>.Instance);

    void CreateTestDirectory()
    {
        Directory.CreateDirectory(_path.AsPrimitive());
        Directory.Exists(_path.AsPrimitive()).ShouldBeTrue();
    }

    void CreateAndAssertDirectoryCreated()
    {
        var directoryOperations = CreateDirectoryOperations();
        directoryOperations.Create(_path);

        Directory.Exists(_path.AsPrimitive()).ShouldBeTrue();
    }
}
