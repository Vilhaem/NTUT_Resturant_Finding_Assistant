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
    public class ResturantSqlRepository : IResturantRepository
    {
        private readonly ISqlDataAccess _sqliteData;
        private readonly ILogger<ResturantSqlRepository> _logger;
        private readonly IConfiguration _config;
        private readonly string connectionString = "sqlite";

        public ResturantSqlRepository(ISqlDataAccess sqliteData,
            ILogger<ResturantSqlRepository> logger,
            IConfiguration config)
        {
            _sqliteData = sqliteData;
            _logger = logger;
            _config = config;
        }

        public async Task<bool> Create(Resturant entity)
        {
            string sql = "INSERT INTO Resturants (Name, Style, PriceClass, Distance, Address, Rating) VALUES (@Name, @Style, @PriceClass, @Distance, @Address, @Rating);";

            try
            {
                var resturant = new
                {
                    entity.Name,
                    entity.Style,
                    entity.PriceClass,
                    entity.Distance,
                    entity.Address,
                    entity.Rating
                };

                await _sqliteData.SaveData(sql, resturant, connectionString);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return false;
            }
        }

        public async Task<bool> Delete(Resturant entity)
        {
            string sql = "DELETE FROM Resturants WHERE Id = @Id";

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

        public async Task<IList<Resturant>> FindAll()
        {
            string sql = "SELECT Id, Name, Style, PriceClass, Distance, Address, Rating FROM Resturants;";

            try
            {
                using (var connection = new SqliteConnection(_config
                    .GetConnectionString(connectionString)))
                {
                    using(var multi = await connection.QueryMultipleAsync(sql))
                    {
                        var resturants = multi.Read<Resturant>().ToList();

                        return resturants;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return null;
            }

        }

        public async Task<IList<Resturant>> FindBySearch(string search)
        {
            string sql = "SELECT Id, Name, FROM Resturants WHERE Name LIKE @Search UNION ";
            try
            {
                var results = await _sqliteData.LoadData<Resturant, dynamic>(sql, 
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

        public async Task<Resturant> FindById(int id)
        {
            string sql = "SELECT Id, Name, Style, PriceClass, Distance, Address, Rating FROM Resturants WHERE Id = @Id;";
                        
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
                        var resturant = multi.Read<Resturant>().SingleOrDefault();

                        return resturant;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");

                return null;
            }
        }

        public async Task<bool> Update(Resturant entity)
        {
            string sql = @"UPDATE Resturants SET Name = @Name,  Style = @Style, PriceClass = @PriceClass, Distance = @Distance, Address = @Address, Rating = @Rating WHERE Id = @Id";

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
            string sql = "SELECT CASE WHEN EXISTS (SELECT Id FROM Resturants WHERE Id = @Id)" +
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