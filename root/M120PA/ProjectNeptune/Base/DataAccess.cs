using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dapper;
using ProjectNeptune.Model;

namespace ProjectNeptune.Base
{
	class DataAccess
    {
        public List<User> GetUsers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
            {
                try
                {
                    var users = connection.Query<User>("SELECT * FROM Users").ToList();
                    return users;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Oops! There was an exception!", MessageBoxButton.OK);
                    throw;
                }
            }
        }

        public User GetUserByNameAndPassword(string username, string password)
        {
            User authorizedUser = new User();
            var parameters = new { UserName = username, Password = password };
            const string sql = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
            {
                try
                {
                    var result = connection.QuerySingle<User>(sql, parameters);
                    authorizedUser.UserId = result.UserId;
                    authorizedUser.UserName = result.UserName;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Incorrect Credentials", "Oops! There was an exception!", MessageBoxButton.OK);
                }
            }
            return authorizedUser;
        }
    }
}
