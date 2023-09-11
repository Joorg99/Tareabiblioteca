using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaDatos
{
    public abstract class DatabaseConnector
    {
        public string bddip;
        public string bddUser;
        public string bddPassword;
        public string bddDatabaseName;

        public MySqlConnection Connection;
        public MySqlCommand Command;
        public MySqlDataReader Reader;

        public DatabaseConnector()
        {
            this.bddip = "localhost";
            this.bddUser = "root";
            this.bddPassword = "23456";
            this.bddDatabaseName = "libreria";

            this.Connection = new MySqlConnection(
                $"server={this.bddip};" +
                $"user={this.bddUser};" +
                $"password={this.bddPassword};" +
                $"database={this.bddDatabaseName};");

            this.Connection.Open();
            this.Command = new MySqlCommand();
            this.Command.Connection = this.Connection;
        }

    }
}