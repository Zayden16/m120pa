using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Dapper;
using ProjectNeptune.Model;

namespace ProjectNeptune.Base
{
    public class DataAccess
    {
        public ObservableCollection<User> GetUsers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
            {
                try
                {
                    var usersList = connection.Query<User>("SELECT * FROM Users").ToList();
                    return new ObservableCollection<User>(usersList);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Oops! There was an exception!", MessageBoxButton.OK);
                    throw;
                }
            }
        }

        public ObservableCollection<Car> GetCars()
        {
            using (IDbConnection connection =
                new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
            {
                try
                {
                    var carsList = connection.Query<Car>("SELECT * FROM Cars").ToList();
                    return new ObservableCollection<Car>(carsList);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Oops! There was an exception!", MessageBoxButton.OK);
                    throw;
                }
            }
        }

        public bool WriteCar(Car inputCar)
        {
            if (inputCar.CarId < 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(inputCar.Kennzeichen))
            {
                return false;
            }
            if (string.IsNullOrEmpty(inputCar.FIN))
            {
                return false;
            }
            if (string.IsNullOrEmpty(inputCar.Marke))
            {
                return false;
            }
            if (string.IsNullOrEmpty(inputCar.Model))
            {
                return false;
            }

            using (IDbConnection connection =
                new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
            {
                try
                {
                    var insertCarQuery = "INSERT INTO Cars (CarID, Marke, Model, FIN, Kennzeichen ) VALUES (@CarID, @Marke, @Model, @FIN, @Kennzeichen)";
                    connection.Execute(insertCarQuery, inputCar);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public bool WriteUser(User inputUser)
        {
            if (string.IsNullOrEmpty(inputUser.UserName))
            {
                return false;
            }

            if (string.IsNullOrEmpty(inputUser.Password))
            {
                return false;
            }

            using (IDbConnection connection =
                new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
            {
                try
                {
                    var insertUserQuery = "INSERT INTO Users (UserName, Password) VALUES (@UserName, @Password)";
                    connection.Execute(insertUserQuery, inputUser);

                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
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
                    var result = connection.QuerySingle<User>(sql, parameters, commandTimeout:5);
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

        public int CountUsers()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
            {
                try
                {
                    int numberOfUsers = connection.QuerySingle<int>("SELECT COUNT(UserID) FROM Users");
                    return numberOfUsers;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Oops! There was an exception!", MessageBoxButton.OK);
                    throw;
                }
            }
        }

        public int CountCars()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
            {
                try
                {
                    int numberOfCars = connection.QuerySingle<int>("SELECT COUNT(CarID) FROM Cars");
                    return numberOfCars;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Oops! There was an exception!", MessageBoxButton.OK);
                    throw;
                }
            }
        }

        public string GetMostPopularMake()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
            {
                try
                {
                    string mostPopularMake= connection.QuerySingle<string>("SELECT TOP(1) Marke FROM Cars GROUP BY Marke ORDER BY COUNT(*) DESC");
                    return mostPopularMake;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Oops! There was an exception!", MessageBoxButton.OK);
                    throw;
                }
            }
        }

        public string GetMostPopularModel()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(DatabaseHelper.CnnVal("NeptuneDB")))
            {
                try
                {
                    string mostPopularModel = connection.QuerySingle<string>("SELECT TOP(1) Model FROM Cars GROUP BY Model ORDER BY COUNT(*) DESC");
                    return mostPopularModel;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Oops! There was an exception!", MessageBoxButton.OK);
                    throw;
                }
            }
        }
    }
}
