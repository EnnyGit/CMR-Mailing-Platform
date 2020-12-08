﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class UserData : IUserData
    {
        private readonly IDataAccess _db;

        public UserData(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<UserModel>> GetUsers()
        {
            string sql = "SELECT * FROM dbo.Users";

            return _db.LoadData<UserModel, dynamic>(sql, new { });
        }

        public Task InsertUser(UserModel user)
        {
            string sql = @"INSERT INTO dbo.Users(FirstName, LastName, Email, Password)
                           values (@FirstName, @LastName, @Email, @Password);";

            return _db.SaveData(sql, user);
        }
    }
}
