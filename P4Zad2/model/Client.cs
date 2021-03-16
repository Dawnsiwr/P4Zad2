using System;
using System.Collections.Generic;
using System.Text;

namespace P4Zad2
{
    class Client
    {
        public string IDklienta { get; set; }
        public string NazwaFirmy { get; set; }
        public string Przedstawiciel { get; set; }
        public string StanowiskoPrzedstawiciela { get; set; }
        public string Adres { get; set; }
        public string Miasto { get; set; }
        public string Region { get; set; }
        public string KodPocztowy { get; set; }
        public string Kraj { get; set; }
        public string Telefon { get; set; }
        public string Faks { get; set; }



        public Client()
        {

        }

        public Client(string clientId, string companyName)
        {
            IDklienta = clientId;
            NazwaFirmy = companyName;
        }


        public Client(string clientId, string companyName, string agent, string agentWorkplace, string adress, string city, string region, string postCode, string country, string phoneNumber, string fax)
        {
            IDklienta = clientId;
            NazwaFirmy = companyName;
            Przedstawiciel = agent;
            StanowiskoPrzedstawiciela = agentWorkplace;
            Adres = adress;
            Miasto = city;
            Region = region;
            KodPocztowy = postCode;
            Kraj = country;
            Telefon = phoneNumber;
            Faks = fax;
        }

        public string ToString()
        {
            return IDklienta + " | " + NazwaFirmy + " | " + Przedstawiciel + " | " + StanowiskoPrzedstawiciela + " | " + Adres + " | " + Kraj + " | " + Region + " | " + KodPocztowy + " | " + Kraj + " | " + Telefon + " | " + Faks;
        }
    }
}
