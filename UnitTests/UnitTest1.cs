using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using System;
using BitCoin.Linq;
using BotCoin.Reactive;
using BitCoin.Twetch.Linq;
using BitCoin.BitBus.Linq;
using System.Diagnostics;

namespace BotCoin.Reactive.Test
{
    public class ControllerTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetTransactionS2Text()
        {
            QueryBitBusProvider.Instance.Server = @"https://3007-c7a1d83c-da27-4bb7-8959-f91e7ec4ec5e.ws-us1.gitpod.io";
            QueryBitBusProvider.Instance.Port = 80;
            QueryBitBusProvider.Instance.BusHash = "3219a71977a133f67c1504e9f0ef8c7d0e2319db9540f049e452033f19ac7ee8";
            var comments =
                from txs in QueryBitBusProvider.GetTransactions()
                from tx in txs
                from @out in tx.@out.ToAsyncEnumerable()
                select @out.s2;

            await foreach(var comment in comments)
            {
                TestContext.Progress.WriteLine(comment);
                
            }

            if (await comments.CountAsync() > 0)
                Assert.Pass();
            else
                Assert.Fail();
        }

        [Test]
        public async Task GetTwetchesS2Text()
        {
            QueryBitBusProvider.Instance.Server = @"https://3007-c7a1d83c-da27-4bb7-8959-f91e7ec4ec5e.ws-us1.gitpod.io";
            QueryBitBusProvider.Instance.Port = 80;
            QueryBitBusProvider.Instance.BusHash = "3219a71977a133f67c1504e9f0ef8c7d0e2319db9540f049e452033f19ac7ee8";

            var comments =
                from tx in QueryTwetchProvider.GetTwetches()
                select tx.Text;

            await foreach (var comment in comments)
            {
                TestContext.Progress.WriteLine(comment);
            }

            if (await comments.CountAsync() > 0)
                Assert.Pass();
            else
                Assert.Fail();
        }
    }
}