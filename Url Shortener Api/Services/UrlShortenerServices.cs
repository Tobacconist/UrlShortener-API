using System;
using System.Collections.Concurrent;
using System.Linq;

namespace UrlShortener.Api.Services
{
    
    public interface IUrlShortenerService
    {
        string ShortenUrl(string originalUrl);
        string GetOriginalUrl(string shortCode);
    }

    public class UrlShortenerService : IUrlShortenerService
    {
        
        private readonly ConcurrentDictionary<string, string> _urlDatabase = new();

        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private readonly Random _random = new();

        public string ShortenUrl(string originalUrl)
        {
            
            var existingRecord = _urlDatabase.FirstOrDefault(x => x.Value == originalUrl);
            if (!string.IsNullOrEmpty(existingRecord.Key))
            {
                return existingRecord.Key;
            }

          
            string shortCode;
            do
            {
                shortCode = GenerateCode(6);
            }
            while (_urlDatabase.ContainsKey(shortCode));

         
            _urlDatabase.TryAdd(shortCode, originalUrl);

            return shortCode;
        }

        public string GetOriginalUrl(string shortCode)
        {
            
            _urlDatabase.TryGetValue(shortCode, out var originalUrl);
            return originalUrl;
        }

       
        private string GenerateCode(int length)
        {
            var codeChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                codeChars[i] = Alphabet[_random.Next(Alphabet.Length)];
            }
            return new string(codeChars);
        }
    }
}