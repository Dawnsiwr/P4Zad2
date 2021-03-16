using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace P4Zad2
{
    class ClientRepository
    {

        public Client GetClientByIdOrCompnayName(IDbConnection connection ,string clientIdOrCompanyName)
        {
            var selectSql = $"SELECT * FROM Klienci WHERE IDklienta = @ClientIdOrCompanyName OR NazwaFirmy = @ClientIdOrCompanyName";

            Client client = connection.QuerySingleOrDefault<Client>(selectSql, new { ClientIdOrCompanyName = clientIdOrCompanyName });
            return client;

        }

        public IEnumerable<Client> SelectClients(IDbConnection connection)
        {
            var selectSql = $"SELECT * FROM Klienci ";
            return connection.Query<Client>(selectSql);

        }





        public bool UpdateClient(IDbConnection connection, string column, string value, string clientId)
        {

            var updateSql = $"UPDATE Klienci SET @Column=@Value WHERE IDklienta = @ClientId ";
            var result = connection.Execute(updateSql, new
            {
                Column = column,
                Value = value,
                ClientId = clientId
            });


            return result==1;
        }

        public bool DeleteClient(IDbConnection connection, string clientIdOrCompanyName)
        {
            var deleteSql = $"DELETE FROM Klienci WHERE IDklienta = @ClientIdOrCompanyName or NazwaFirmy = @ClientIdOrCompanyName";
            var result = connection.Execute(deleteSql, new
            {
                ClientIdOrCompanyName = clientIdOrCompanyName
            });
            return result==1;
        }

        public bool SimpleCreateClient(IDbConnection connection, Client client)
        {
            var createSql = $"INSERT INTO Klienci (IDklienta, NazwaFirmy) VALUES (@IDklienta, @NazwaFirmy)";

            var result = connection.Execute(createSql, new
            {
                IDklienta = client.IDklienta,
                NazwaFirmy = client.NazwaFirmy
            });

            return result==1;
        }

        public bool CreateClient(IDbConnection connection, Client client)
        {
            var createSql = $"INSERT INTO Klienci (IDklienta, NazwaFirmy, Przedstawiciel, StanowiskoPrzedstawiciela, Adres, Miasto, Region, KodPocztowy, Kraj, Telefon, Faks) " +
                $"VALUES (@IDklienta, @NazwaFirmy, @Przedstawiciel, @StanowiskoPrzedstawiciela, @Adres, @Miasto, @Region, @KodPocztowy, @Kraj, @Telefon, @Faks)";

            var result = connection.Execute(createSql, new
            {
                IDklienta = client.IDklienta,
                NazwaFirmy = client.NazwaFirmy,
                Przedstawiciel = client.Przedstawiciel,
                StanowiskoPrzedstawiciela = client.StanowiskoPrzedstawiciela,
                Adres = client.Adres,
                Miasto = client.Miasto,
                Region = client.Region,
                KodPocztowy = client.KodPocztowy,
                Kraj = client.Kraj,
                Telefon = client.Telefon,
                Faks = client.Faks
            });
            
            return result == 1;
        }
    }
}