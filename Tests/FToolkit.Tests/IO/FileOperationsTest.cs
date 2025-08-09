using System.Text;
using FToolkit.IO;
using FToolkit.Objects;
using Microsoft.Extensions.Logging.Abstractions;
using Shouldly;
using Xunit;

namespace FToolkit.Tests.IO;

public sealed class FileOperationsTest : IDisposable
{
    static readonly ReadOnlyMemory<char> TestContent = "abc".AsMemory();
    static readonly byte[] TestContentBytes = Encoding.UTF8.GetBytes(TestContent.ToArray());

    readonly FilePath _path;

    public FileOperationsTest()
    {
        _path = new(Path.Join(Path.GetTempPath(), Path.GetRandomFileName()));
        File.Exists(_path.AsPrimitive()).ShouldBeFalse();
    }

    public void Dispose()
        => File.Delete(_path.AsPrimitive());

    [Fact]
    public async Task Exists_ファイルが存在する_trueを返す()
    {
        await CreateTestFileAsync();

        var fileOperations = CreateFileOperations();
        fileOperations.Exists(_path).ShouldBeTrue();
    }

    [Fact]
    public void Exists_ファイルが存在しない_falseを返す()
    {
        var fileOperations = CreateFileOperations();
        fileOperations.Exists(_path).ShouldBeFalse();
    }

    [Fact]
    public async Task CreateAsync_バイト列でファイル作成_ファイルが作成され内容が一致()
    {
        var fileOperations = CreateFileOperations();
        await fileOperations.CreateAsync(_path, TestContentBytes, TestContext.Current.CancellationToken);

        await AssertFileContentAsync();
    }

    [Fact]
    public async Task CreateAsync_文字列でファイル作成_ファイルが作成され内容が一致()
    {
        var fileOperations = CreateFileOperations();
        await fileOperations.CreateAsync(_path, TestContent, TestContext.Current.CancellationToken);

        await AssertFileContentAsync();
    }

    [Fact]
    public async Task CreateAsync_既存ファイルがある場合_IOException()
    {
        await CreateTestFileAsync();

        var fileOperations = CreateFileOperations();
        await Should.ThrowAsync<IOException>(async () =>
            await fileOperations.CreateAsync(_path, TestContentBytes, TestContext.Current.CancellationToken));
    }

    [Fact]
    public async Task SaveAsync_バイト列_新規作成で内容が一致()
    {
        var fileOperations = CreateFileOperations();
        await fileOperations.SaveAsync(_path, TestContentBytes, TestContext.Current.CancellationToken);

        await AssertFileContentAsync();
    }

    [Fact]
    public async Task SaveAsync_バイト列_上書きで内容が更新()
    {
        await CreateTestFileAsync();

        var fileOperations = CreateFileOperations();
        await fileOperations.SaveAsync(_path, TestContentBytes, TestContext.Current.CancellationToken);

        await AssertFileContentAsync();
    }

    [Fact]
    public async Task SaveAsync_文字列_新規作成で内容が一致()
    {
        var fileOperations = CreateFileOperations();
        await fileOperations.SaveAsync(_path, TestContent, TestContext.Current.CancellationToken);

        await AssertFileContentAsync();
    }

    [Fact]
    public async Task SaveAsync_文字列_上書きで内容が更新()
    {
        await CreateTestFileAsync();

        var fileOperations = CreateFileOperations();
        await fileOperations.SaveAsync(_path, TestContent, TestContext.Current.CancellationToken);

        await AssertFileContentAsync();
    }

    [Fact]
    public async Task Delete_ファイルあり_ファイルが削除される()
    {
        await CreateTestFileAsync();
        DeleteAndAssertFileDeleted();
    }

    [Fact]
    public void Delete_ファイルなし_例外が発生しない()
        => DeleteAndAssertFileDeleted();

    static FileOperations CreateFileOperations() => new(NullLogger<FileOperations>.Instance);

    async Task CreateTestFileAsync()
    {
        await File.WriteAllBytesAsync(_path.AsPrimitive(), TestContentBytes, TestContext.Current.CancellationToken);
        File.Exists(_path.AsPrimitive()).ShouldBeTrue();
    }

    async Task AssertFileContentAsync()
    {
        var bytes = await File.ReadAllBytesAsync(_path.AsPrimitive(), TestContext.Current.CancellationToken);
        bytes.ShouldBe(TestContentBytes);
    }

    void DeleteAndAssertFileDeleted()
    {
        var fileOperations = CreateFileOperations();
        fileOperations.Delete(_path);

        File.Exists(_path.AsPrimitive()).ShouldBeFalse();
    }
}
