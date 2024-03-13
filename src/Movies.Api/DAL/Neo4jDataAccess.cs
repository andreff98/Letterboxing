using Microsoft.Extensions.Options;
using Neo4j.Driver;

namespace Movies.Api.DAL;

public class Neo4jDataAccess : INeo4jDataAccess
{
    private IAsyncSession _session;
    private ILogger<Neo4jDataAccess> _logger;

    public Neo4jDataAccess(IDriver driver, ILogger<Neo4jDataAccess> logger)
    {
        _session = driver.AsyncSession(o => o.WithDatabase("neo4j"));
        _logger = logger;
    }

    /// <summary>
    /// Execute read dictionary as an asynchronous operation.
    /// </summary>
    public async Task<List<Dictionary<string, object>>> ExecuteReadDictionaryAsync(string query, string returnObjectKey, IDictionary<string, object>? parameters = null)
    {
        return await ExecuteReadDictionaryAsync(query, returnObjectKey, parameters);
    }

    /// <summary>
    /// Execute read list as an asynchronous operation.
    /// </summary>
    public async Task<List<string>> ExecuteReadListAsync(string query, string returnObjectKey, IDictionary<string, object>? parameters = null)
    {
        return await ExecuteReadListAsync(query, returnObjectKey, parameters);
    }

    /// <summary>
    /// Execute read scalar as an asynchronous operation.
    /// </summary>
    public async Task<T> ExecuteReadScalarAsync<T>(string query, IDictionary<string, object>? parameters = null)
    {
        try
        {
            parameters = parameters == null ? new Dictionary<string, object>() : parameters;

            var result = await _session.ExecuteReadAsync(async tx =>
            {
                T scalar = default(T);
                var res = await tx.RunAsync(query, parameters);
                scalar = (await res.SingleAsync())[0].As<T>();
                return scalar;
            });

            return result;

        }catch(Exception ex)
        {
            _logger.LogError(ex, "Error executing read scalar");
            throw;
        }
    }

    /// <summary>
    /// Execute write transaction
    /// </summary>
    public async Task<T> ExecuteWriteTransactionAsync<T>(string query, IDictionary<string, object>? parameters = null)
    {
        try
        {
            parameters = parameters == null ? new Dictionary<string, object>() : parameters;

            var result = await _session.ExecuteWriteAsync(async tx =>
            {
                T scalar = default(T);
                var res = await tx.RunAsync(query, parameters);
                scalar = (await res.SingleAsync())[0].As<T>();
                return scalar;
            });

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "There was a problem while executing database query");
            throw;
        }
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or
    /// resetting unmanaged resources asynchronously.
    /// </summary>
    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        await _session.CloseAsync();
    }
}