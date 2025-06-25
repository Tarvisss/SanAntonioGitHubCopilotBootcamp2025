using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using UrlListApp.Models;

namespace UrlListApp.Services
{
    public class UrlListRepository
    {
        private static readonly ConcurrentDictionary<string, UrlList> _lists = new();

        public IEnumerable<UrlList> GetAll() => _lists.Values;
        public UrlList? GetByCustomUrl(string customUrl) => _lists.TryGetValue(customUrl, out var list) ? list : null;
        public UrlList? GetById(Guid id) => _lists.Values.FirstOrDefault(l => l.Id == id);
        public void Add(UrlList list)
        {
            if (list.CustomUrl != null)
                _lists[list.CustomUrl] = list;
        }
        public void Remove(string customUrl)
        {
            _lists.TryRemove(customUrl, out _);
        }
        public bool CustomUrlExists(string customUrl) => _lists.ContainsKey(customUrl);
        public string GenerateUniqueUrl()
        {
            string url;
            do
            {
                url = Guid.NewGuid().ToString().Substring(0, 8);
            } while (_lists.ContainsKey(url));
            return url;
        }
    }
}
