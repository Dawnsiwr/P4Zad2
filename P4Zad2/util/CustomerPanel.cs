using System;
using System.Collections.Generic;
using System.Text;

namespace P4Zad2
{
    class CustomerPanel
    {
        private DataReader DataReader;

        public CustomerPanel()
        {
            DataReader = new DataReader();

        }

        public int Menu()
        {
            int option;


            do
            {
                option = 0;
                Console.Clear();
                Console.WriteLine("Panel klientów: ");
                Console.WriteLine("----------------");
                Console.WriteLine("1. Dodaj nowego klienta");
                Console.WriteLine("2. Znajdź klienta");
                Console.WriteLine("3. Wyświetl klientów");
                Console.WriteLine("4. Aktualizuj klienta");
                Console.WriteLine("5. Usuń klienta");
                Console.WriteLine("6. Zakończ");
                option = DataReader.ReadIntValue();


            } while (option > 7 || option < 1);


            return option;

        }

        public (Client, int) CreateClient()
        {
            Console.Clear();
            Console.WriteLine("Wybierz typ wprowadzania: ");
            Console.WriteLine("1. Dodawanie szybkie");
            Console.WriteLine("2. Dodawanie zwykłe");
            Client client;
            int option = DataReader.ReadIntValueMinMax(1, 2);
            if (option == 1)
            {
                Console.WriteLine("Wprowadź ID klienta");
                string clientId = DataReader.ReadSentence();
                Console.WriteLine("Wprowadź nazwę firmy");
                string companyName = DataReader.ReadSentence();

                client = new Client(clientId, companyName);
                return (client, option);
            }
            else
            {
                Console.WriteLine("Wprowadź ID klienta");
                string clientId = DataReader.ReadSentence();
                Console.WriteLine("Wprowadź nazwę firmy");
                string companyName = DataReader.ReadSentence();
                Console.WriteLine("Wprowadź imię i nazwisko przedstawiciela");
                string agent = DataReader.ReadSentence();
                Console.WriteLine("Wprowadź stanowisko przedstawiciela");
                string agentWorkplace = DataReader.ReadSentence();
                Console.WriteLine("Wprowadź adres firmy");
                string adress = DataReader.ReadSentence();
                Console.WriteLine("Wprowadź misato firmy");
                string city = DataReader.ReadSentence();
                Console.WriteLine("Wprowadź region firmy");
                string region = DataReader.ReadSentence();
                Console.WriteLine("Wprowadź kod pocztowy firmy");
                string postCode = DataReader.ReadSentence();
                Console.WriteLine("Wprowadź kraj firmy");
                string country = DataReader.ReadSentence();
                Console.WriteLine("Wprowadź telefon firmy");
                string phoneNumber = DataReader.ReadSentence();
                Console.WriteLine("Wprowadź fax firmy");
                string fax = DataReader.ReadSentence();

                client = new Client(clientId, companyName, agent, agentWorkplace, adress, city, region, postCode, country, phoneNumber, fax);
                return (client, option);
            }


        }

        public string SelectClient()
        {
            Console.Clear();
            Console.WriteLine("Podaj ID klienta lub nazwę firmy której szukasz");
            string clientIdOrCompanyName = DataReader.ReadSentence();

            return clientIdOrCompanyName;
        }

        public Dictionary<string, string> UpdateClient()
        {
            Console.Clear();
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            Console.WriteLine("Podaj ID klienta lub nazwę firmy na której chcesz dokonać modyfiakcji");
            string clientId = DataReader.ReadSentence();
            parameters.Add("clientId", clientId);

            Console.WriteLine("Wybierz nr kolumny do modyfikacji ");
            Console.WriteLine("1. ID klienta");
            Console.WriteLine("2. Nazwa firmy");
            Console.WriteLine("3. Dane przedstawiciela");
            Console.WriteLine("4. Stanowisko przedstawiciela");
            Console.WriteLine("5. Adres");
            Console.WriteLine("6. Miasto");
            Console.WriteLine("7. Region");
            Console.WriteLine("8. Kod pocztowy");
            Console.WriteLine("9. Kraj");
            Console.WriteLine("10. Telefon");
            Console.WriteLine("11. Faks");
            int option = DataReader.ReadIntValueMinMax(1, 11);

            switch (option)
            {
                case 1: parameters.Add("columnName", "IDklienta"); break;
                case 2: parameters.Add("columnName", "NazwaFirmy"); break;
                case 3: parameters.Add("columnName", "Przedstawiciel"); break;
                case 4: parameters.Add("columnName", "StanowiskoPrzedstawiciela"); break;
                case 5: parameters.Add("columnName", "Adres"); break;
                case 6: parameters.Add("columnName", "Miasto"); break;
                case 7: parameters.Add("columnName", "Region"); break;
                case 8: parameters.Add("columnName", "KodPocztowy"); break;
                case 9: parameters.Add("columnName", "Kraj"); break;
                case 10: parameters.Add("columnName", "Telefon"); break;
                case 11: parameters.Add("columnName", "Faks"); break;
            }

            Console.WriteLine("Wprowadź nowe dane: ");
            string newValue = DataReader.ReadSentence();
            parameters.Add("newValue", newValue);

            return parameters;
        }

        public string DeleteClient()
        {
            Console.Clear();
            Console.WriteLine("Podaj id klienta lub nazwe firmy do usunięcia");
            string clientIdOrCompanyName = DataReader.ReadSentence();

            return clientIdOrCompanyName;

        }




    }
}