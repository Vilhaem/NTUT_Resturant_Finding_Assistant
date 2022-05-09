using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookStore.Infrastructure.Data
{
    public class AuthorSqlRepository : IAuthorRepository
    {
        private readonly ISqlDataAccess _sqliteData;
        private readonly ILogger<AuthorSqlRepository> _logger;
        private readonly IConfiguration _config;
        private readonly string connectionString = "sqlite";

        public AuthorSqlRepository(ISqlDataAccess sqliteData,
            ILogger<AuthorSqlRepository> logger,
            IConfiguration config)
        {
            _sqliteData = sqliteData;
            _logger = logger;
            _config = config;
        }

        public async Task<bool> Create(Author entity)
        {
            string sql = "INSERT INTO Authors (Name, Style, Distance, Address, Rating) VALUES (@Name, @Style, @Distance, @Address, @Rating);";

            try
            {
                var author = new
                {
                    entity.Name,
                    entity.Style,
                    entity.Distance,
                    entity.Address,
                    entity.Rating
                };

                await _sqliteData.SaveData(sql, author, connectionString);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return false;
            }
        }

        public async Task<bool> Delete(Author entity)
        {
            string sql = "DELETE FROM Authors WHERE Id = @Id";

            try
            {
                await _sqliteData.SaveData(sql, new
                {
                    entity.Id
                }, connectionString);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return false;
            }
        }

        public async Task<IList<Author>> FindAll()
        {
            string sql = "SELECT Id, Name, Style, Address, Rating FROM Authors;";

            try
            {
                using (var connection = new SqliteConnection(_config
                    .GetConnectionString(connectionString)))
                {
                    using(var multi = await connection.QueryMultipleAsync(sql))
                    {
                        var authors = multi.Read<Author>().ToList();
                        
                        return authors;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return null;
            }

        }

        public async Task<IList<Author>> FindBySearch(string search)
        {
            string sql = "SELECT Id, Name, Style, Address, Rating FROM Authors WHERE Name LIKE @Search;";
            try
            {
                var results = await _sqliteData.LoadData<Author, dynamic>(sql, 
                    new
                    {
                        Search = "%" + search + "%"
                    }, connectionString);

                return results.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return null;
            }
        }

        public async Task<Author> FindById(int id)
        {
            string sql = "SELECT Id, Name, Style, Address, Rating FROM Authors WHERE Id = @Id;";
                        
            try
            {
                using (var connection = new SqliteConnection(_config
                    .GetConnectionString(connectionString)))
                {
                    using (var multi = await connection.QueryMultipleAsync(sql,
                        new
                        {
                            @Id = id
                        }))
                    {
                        var author = multi.Read<Author>().SingleOrDefault();

                        return author;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return null;
            }
        }

        public async Task<bool> Update(Author entity)
        {
            string sql = @"UPDATE Authors SET Name = @Name, Style = @Style, Address = @Address, Rating = @Rating WHERE Id = @Id";

            try
            {
                await _sqliteData.SaveData(sql, entity, connectionString);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} - {ex.InnerException}");

                return false;
            }
        }

        public async Task<bool> IsExists(int id)
        {
            string sql = "SELECT CASE WHEN EXISTS (SELECT Id FROM Authors WHERE Id = @Id)" +
                         "THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS Result";

            try
            {
                using (var connection = new SqliteConnection(_config.GetConnectionString(connectionString)))
                {
                    var isExists = await connection.QueryFirstAsync<bool>(sql, new
                    {
                        @Id = id
                    });

                    return isExists;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return false;
            }
        }
    }
}