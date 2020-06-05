using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Neptune.Models;

namespace Neptune
{
	class DataAccess
	{
		public List<User> GetUsers()
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
			{
				var users= connection.Query<User>("SELECT * FROM Users").ToList();
				return users;
			}
		}

		public User GetUserByNameAndPassword(string username, string password)
		{
			User authorizedUser = new User();
			var parameters = new { UserName = username, Password = password };
			const string sql = "SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password";
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
			{
				var result = connection.QuerySingle<User>(sql, parameters);
				authorizedUser.UserId = result.UserId;
			}

			return authorizedUser;
		}
	}
}


