using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Pasar_Maya_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pasar_Maya_Api.Data
{
    public class LocalData
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "LocalProducts";

        public LocalData(DataContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public ICollection<Product> GetProducts()
        {
            if (!_cache.TryGetValue(CacheKey, out ICollection<Product> cachedProducts))
            {
                cachedProducts = LoadLocalProducts();
                _cache.Set(CacheKey, cachedProducts, TimeSpan.FromHours(1)); // Cache for 1 Hours
            }

            return cachedProducts;
        }

        private ICollection<Product> LoadLocalProducts()
        {
            return _context.Products
                .Include(p => p.Commodity)
                .Include(p => p.Area)
                .ToList();
        }
    }
}
