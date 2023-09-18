using FToolkit.Net.GitHub.Repositories.Entities;
using FToolkit.Repositories;

namespace FToolkit.Net.GitHub.Repositories;

/// <summary>
/// GitHubリポジトリ設定に関する操作を定義するインターフェイスです。
/// </summary>
public interface IGitHubRepositoryRepository : IRepository<Request>
{
    /// <summary>
    /// 指定されたリクエスト情報で更新処理を実行します。
    /// </summary>
    /// <param name="request">リクエスト情報。</param>
    /// <param name="cancellationToken">キャンセル要求を行うためのトークン。</param>
    /// <returns>このメソッドが完了すると、オブジェクトまたは値は返されません。</returns>
    /// <exception cref="ArgumentNullException"><paramref name="request"/>がnullです。</exception>
    Task UpdateAsync(Request request, CancellationToken cancellationToken = default);
}
