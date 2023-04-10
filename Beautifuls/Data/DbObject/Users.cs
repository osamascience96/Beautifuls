using Beautifuls.Helper;
using Beautifuls.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Helpers;

namespace Beautifuls.Data.DbObject
{
    public class Users
    {
        private Connection _connection;

        public Users() 
        {
            this._connection= new Connection();
        }
        public User GetUser(int Id)
        {
            User user = null;
            try
            {
                var sqlCon = this._connection.GetSqlInstance();
                string sqlQuery = "select " +
                    "[dbo].[Users].Id, " +
                    "[dbo].[Users].FirstName, " +
                    "[dbo].[Users].LastName, " +
                    "[dbo].[Users].Email, " +
                    "[dbo].[Users].Gender, " +
                    "[dbo].[Users].ProfileUrl, " +
                    "[dbo].[Users].IsActive, " +
                    "[dbo].[Users].CreatedDate, " +
                    "[dbo].[UserTypes].Id as 'UserTypeId', " +
                    "[dbo].[UserTypes].Type " +
                    "from [dbo].[Users] JOIN [dbo].[UserTypes] " +
                    "ON [dbo].[UserTypes].Id = [dbo].[Users].UserType WHERE [dbo].[Users].Id=@Id;";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlCon);
                sqlCommand.Parameters.AddWithValue("@Id", Id);
                this._connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    user = new User();
                    user.Id = reader.GetInt32(0);
                    user.FirstName = reader.GetString(1);
                    user.LastName = reader.GetString(2);
                    user.Email = reader.GetString(3);
                    user.Gender = reader.GetString(4);
                    user.ProfileUrl = reader.GetString(5);
                    user.IsActive = reader.GetBoolean(6);
                    user.UserTypeId = reader.GetInt32(7);
                    user.UserType = new UserType
                    {
                        Id = reader.GetInt32(7),
                        Type = reader.GetString(8)
                    };
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally 
            { 
                this._connection.Close(); 
            }
            return user;
        }
        public User GetUser(string email, string password)
        {
            User user = null;
            try
            {
                var sqlCon = this._connection.GetSqlInstance();
                string sqlQuery = "select " +
                    "[dbo].[Users].Id, " +
                    "[dbo].[Users].FirstName, " +
                    "[dbo].[Users].LastName, " +
                    "[dbo].[Users].Email, " +
                    "[dbo].[Users].Gender, " +
                    "[dbo].[Users].ProfileUrl, " +
                    "[dbo].[Users].IsActive, " +
                    "[dbo].[Users].CreatedDate, " +
                    "[dbo].[UserTypes].Id as 'UserTypeId', " +
                    "[dbo].[UserTypes].Type " +
                    "from [dbo].[Users] JOIN [dbo].[UserTypes] " +
                    "ON [dbo].[UserTypes].Id = [dbo].[Users].UserType WHERE [dbo].[Users].Email=@Email AND [dbo].[Users].Password=@Password;";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlCon);
                sqlCommand.Parameters.AddWithValue("@Email", email);
                sqlCommand.Parameters.AddWithValue("@Password", Utility.GetPasswordHash(password));
                this._connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    user = new User();
                    user.Id = reader.GetInt32(0);
                    user.FirstName = reader.GetString(1);
                    user.LastName = reader.GetString(2);
                    user.Email = reader.GetString(3);
                    user.Gender = reader.GetString(4);
                    user.ProfileUrl = reader.GetString(5);
                    user.IsActive = reader.GetBoolean(6);
                    user.UserTypeId = reader.GetInt32(7);
                    user.UserType = new UserType
                    {
                        Id = reader.GetInt32(7),
                        Type = reader.GetString(8)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this._connection.Close();
            }
            return user;
        }
        public IList<User> GetUsers()
        {
            IList<User> users = new List<User>();
            try
            {
                var sqlCon = this._connection.GetSqlInstance();
                string sqlQuery = "select " +
                    "[dbo].[Users].Id, " +
                    "[dbo].[Users].FirstName, " +
                    "[dbo].[Users].LastName, " +
                    "[dbo].[Users].Email, " +
                    "[dbo].[Users].Gender, " +
                    "[dbo].[Users].ProfileUrl, " +
                    "[dbo].[Users].IsActive, " +
                    "[dbo].[UserTypes].Id as 'UserTypeId', " +
                    "[dbo].[UserTypes].Type " +
                    "from [dbo].[Users] JOIN [dbo].[UserTypes] " +
                    "ON [dbo].[UserTypes].Id = [dbo].[Users].UserType;";
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, sqlCon);
                this._connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        Gender = reader.GetString(4),
                        ProfileUrl = reader.GetString(5),
                        IsActive = reader.GetBoolean(6),
                        UserTypeId = reader.GetInt32(7),
                        UserType = new UserType
                        {
                            Id = reader.GetInt32(7),
                            Type = reader.GetString(8)
                        }
                    });
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally 
            { 
                this._connection.Close(); 
            }
            return users;
        }
        public Boolean Save(User user, bool isUpdate = false)
        {
            var sqlCon = this._connection.GetSqlInstance();
            int rowAffected = 0;
            try
            {
                if (!isUpdate)
                {
                    string query = @"INSERT INTO [dbo].[Users] VALUES (@FirstName, @LastName, @Email, @Password, @Gender, @UserType, @ProfileUrl, @IsActive, @CreatedDate)";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", Utility.GetPasswordHash(user.Password));
                    sqlCommand.Parameters.AddWithValue("@Gender", user.Gender);
                    sqlCommand.Parameters.AddWithValue("@UserType", user.UserTypeId);
                    sqlCommand.Parameters.AddWithValue("@ProfileUrl", user.ProfileUrl);
                    sqlCommand.Parameters.AddWithValue("@IsActive", user.IsActive);
                    sqlCommand.Parameters.AddWithValue("@CreatedDate", user.CreatedDate);
                    this._connection.Open();
                    rowAffected = sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    string query = @"UPDATE [dbo].[Users] 
                            SET [FirstName]=@FirstName,
                            SET [LastName]=@LastName, 
                            SET [Email]=@Email, 
                            SET [Password]=@Password,
                            SET [Gender]=@Gender, 
                            SET [ProfileUrl]=@ProfileUrl,
                            SET [IsActive]=@IsActive,
                            SET [CreatedDate]=@CreatedDate WHERE Id=@Id";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                    sqlCommand.Parameters.AddWithValue("@Id", user.Id);
                    sqlCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", user.LastName);
                    sqlCommand.Parameters.AddWithValue("@Email", user.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", user.Password);
                    sqlCommand.Parameters.AddWithValue("@Gender", user.Gender);
                    sqlCommand.Parameters.AddWithValue("@ProfileUrl", user.ProfileUrl);
                    sqlCommand.Parameters.AddWithValue("@IsActive", user.IsActive);
                    sqlCommand.Parameters.AddWithValue("@CreatedDate", user.CreatedDate);
                    this._connection.Open();
                    rowAffected = sqlCommand.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this._connection.Close();
            }

            return rowAffected > 0;
        }
        public Boolean Delete(int Id)
        {
            int rowsAffected = 0;
            var sqlCon = this._connection.GetSqlInstance();
            try
            {
                string query = @"DELETE FROM [dbo].[Users] WHERE Id=@Id";
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@Id", Id);
                this._connection.Open();
                rowsAffected = sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this._connection.Close();
            }
            return rowsAffected > 0;
        }
    }
}