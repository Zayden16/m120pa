using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
	}
}
