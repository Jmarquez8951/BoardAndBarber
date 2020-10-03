using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardAndBarber.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace BoardAndBarber.Data
{
    public class CustomerRepository
    {
        static List<Customer> _customers = new List<Customer>();

        const string _connectionString = "Server=localhost;Database=BoardAndBarber;Trusted_Connection=True;";
        public void Add(Customer customerToAdd)
        {
            var sql = @"INSERT INTO [dbo].[Customers]
                       ([Name]
                       ,[Birthday]
                       ,[FavoriteBarber]
                       ,[Notes])
                 Output inserted.Id
                 VALUES
                       (@name,@birthday,@favoritebarber,@notes)";

            using var db = new SqlConnection(_connectionString);

            var newId = db.ExecuteScalar<int>(sql, customerToAdd);

            customerToAdd.Id = newId;
        }

        public List<Customer> GetAll()
        {
            using var db = new SqlConnection(_connectionString);

            var customers =  db.Query<Customer>("select * from customers");

            return customers.ToList();
        }

        public Customer GetById(int id)
        {
            using var db = new SqlConnection(_connectionString);

            var query = @$"select *
                          from customers
                          where Id = @Id";

            var parameters = new { Id = id };

            var customer = db.QueryFirstOrDefault<Customer>(query, parameters);

            return customer;
        }

        public Customer Update(int id, Customer customer)
        {
            var sql = @"UPDATE [dbo].[Customers]
                        SET [Name] = @name
                          ,[Birthday] = @birthday
                          ,[FavoriteBarber] = @favoriteBarber
                          ,[Notes] = @notes
                        Output inserted.*
                        WHERE id = @id";

            using var db = new SqlConnection(_connectionString);

            var parameters = new
            {
                customer.Name,
                customer.Birthday,
                customer.FavoriteBarber,
                customer.Notes,
                id
            };

            var updatedCustomer = db.QueryFirstOrDefault(sql, parameters);

            return null;
        }

        public void Remove(int customerId)
        {
            var sql = @"DELETE 
                        FROM [dbo].[Customers]
                        WHERE Id = @Id";

            using var db = new SqlConnection(_connectionString);

            db.Execute(sql, new { Id = customerId});
            
        }

    }
}
