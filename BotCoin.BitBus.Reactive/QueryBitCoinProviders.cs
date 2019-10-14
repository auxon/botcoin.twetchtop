using BitCoin.BitBus;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reactive.Disposables;

using System.Reactive.Linq;

namespace BitCoin.Linq
{
    public class QueryBitcoinProvider : IQueryProvider
    {
        // TODO:  config file source this - or read from bitbus json config ?
        const string bitBusHash = "3a402f82fd42804d10fd169369a18f94a9498f03564bbaac4c2281f753816104";
        const string server = "localhost";
        const int port = 3007;
        static readonly string host = $"http://{server}:{port}";
        static readonly string twetchBitBusUrl = $"{host}/b/{bitBusHash}";

        public static async IAsyncEnumerable<string> GetBlockUrls()
        {
            using var http = new HttpClient();
            var itemsRoot = await http.GetJsonAsync<Index>(twetchBitBusUrl);
            var urls = itemsRoot.Where(item => item.Url.EndsWith(".json")).Select(item => item.Url);
            await foreach (var url in urls)
                yield return url;
        }

        public static async IAsyncEnumerable<IAsyncEnumerable<Transaction>> GetTransactions()
        {
            await foreach(var blockUrl in GetBlockUrls())
            {
                using var http = new HttpClient();
                var transactions = from txs in await http.GetJsonAsync<Transaction[]>(host + blockUrl) select txs;
                yield return transactions.ToAsyncEnumerable();
            }                       
        }

        /// <summary>
        /// Returns all transactions from the BitBus block urls passed in.
        /// </summary>
        /// <returns></returns>
        public static async IAsyncEnumerable<IAsyncEnumerable<Transaction>> GetTransactions(params string[] blockUrls)
        {
            foreach (var blockUrl in blockUrls)
            {
                using var http = new HttpClient();
                var transactions = from txs in await http.GetJsonAsync<Transaction[]>(host + blockUrl) select txs;
                yield return transactions.ToAsyncEnumerable();             
            }
        }

        public static async IAsyncEnumerable<Transaction> GetFlattedTransactions()
        {
            await foreach (var transactions in GetTransactions())
            {
                await foreach (var transaction in transactions)
                {
                    yield return transaction;
                }
            }
        }

        /// <summary>
        /// Gets all the outputs from all the transactions indexed by the current BitBus instance.
        /// </summary>
        /// <returns></returns>
        public static async IAsyncEnumerable<Out> GetOutputs()
        {
            await foreach (var transactions in GetTransactions())
            {
                await foreach (var transaction in transactions)
                {
                    var outputs = transaction.@out;

                    foreach (var output in outputs)
                    {
                        yield return output;
                    }
                }
            }
        }

        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            throw new NotImplementedException();
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }

        public static IObservable<Transaction> ObservableTransactions = 
            Observable.Create<Transaction>(async o =>
            {
                await foreach (var transactions in GetTransactions())
                    await foreach (var transaction in transactions) o.OnNext(transaction);

                o.OnCompleted();
                return Disposable.Empty;
            });

            public virtual string Name { get { return nameof(QueryBitcoinProvider); } }
            public virtual string Version { get { return typeof(QueryBitcoinProvider).Assembly.ImageRuntimeVersion; } }
    }
}

