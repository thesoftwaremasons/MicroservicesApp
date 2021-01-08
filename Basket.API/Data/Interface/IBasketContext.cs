using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Data.Interface
{
    public interface IBasketContext
    {
        StackExchange.Redis.IDatabase Redis { get; }
    }
}
