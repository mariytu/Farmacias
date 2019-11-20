using System;
using System.Net;
using System.Net.Http;
using System.Collections.Concurrent;
using System.Configuration;
using FarmaciasAPI.Providers;
using Microsoft.Extensions.Configuration;

public interface IHttpClientFactory
{
    HttpClient GetForHost(Uri uri);
}

public sealed class HttpClientFactory : IHttpClientFactory, IDisposable
{
    private static readonly ConcurrentDictionary<string, HttpClient> HttpClientCache = new ConcurrentDictionary<string, HttpClient>();
    private readonly IConfiguration _configuration;
    private readonly int _connectionLeaseTimeout;

    public HttpClientFactory(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException("configuration");
        _connectionLeaseTimeout = int.Parse(_configuration["httpClientCache:ConnectionLeaseTimeout"]);
    }

    public HttpClient GetForHost(Uri uri)
    {
        var key = $"{uri.Scheme}://{uri.DnsSafeHost}:{uri.Port}";

        return HttpClientCache.GetOrAdd(key, k => {
            var client = new HttpClient(new LoggingHandler(new HttpClientHandler()))
            {
                BaseAddress = uri,
                /* Other setup */
            };

            var sp = ServicePointManager.FindServicePoint(uri);
            sp.ConnectionLeaseTimeout = _connectionLeaseTimeout; // 60000 = 1 minute

            return client;
        });
    }

    public void Dispose()
    {
        HttpClient client = null;
        foreach (var key in HttpClientCache.Keys)
        {
            if (HttpClientCache.TryRemove(key, out client))
            {
                client.Dispose();
            }
        }
    }
}