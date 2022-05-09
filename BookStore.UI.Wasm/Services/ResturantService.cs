using System.Net.Http;
using Blazored.LocalStorage;
using BookStore.UI.Wasm.Contracts;
using BookStore.UI.Wasm.Models;
using Microsoft.Extensions.Logging;

namespace BookStore.UI.Wasm.Services
{
    public class ResturantService : RepositoryService<Resturant>, IResturantRepository
    {
        private readonly HttpClient _client;
        private readonly ILogger<ResturantService> _logger;
        private readonly ILocalStorageService _localStorage;

        public ResturantService(HttpClient client, ILogger<ResturantService> logger, 
        ILocalStorageService localStorage) 
            : base(client, logger, localStorage)
        {
            _logger = logger;
            _client = client;
            _localStorage = localStorage;
        }
    }
}