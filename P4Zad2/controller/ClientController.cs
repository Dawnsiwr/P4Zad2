using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace P4Zad2
{
    class ClientController
    {
        public DataReader DataReader { get; }
        public ClientRepository ClientRepository { get; }
        public CustomerPanel CustomerPanel { get; }
        private SqlConnection connection;
        private IDbConnection _connection;


        public ClientController()
        {
            DataReader = new DataReader();
            ClientRepository = new ClientRepository();
            CustomerPanel = new CustomerPanel();
            _connection = new SqlConnection(@"Data Source=DESKTOP-N5HH4R4\BAZYDANYCHI;Initial Catalog=ZNorthwind;Integrated Security=True");
        }

        public void Run()
        {
            
            int menuOption;
            do
            {
                menuOption = CustomerPanel.Menu();
                switch (menuOption)
                {
                    case 1: CreateClient(); break;
                    case 2: SelectClient(); break;
                    case 3: SelectClients(); break;
                    case 4: UpdateClient(); break;
                    case 5: DeleteClient(); break;
                    case 6: Environment.Exit(0); break;
                }

            } while (menuOption != 6);



            
        }

        public void CreateClient()
        {
            var data = CustomerPanel.CreateClient();
            Client client = data.Item1;
            bool result = false;
            try
            {
                switch (data.Item2)
                {
                    case 1:
                        {
                            result = ClientRepository.SimpleCreateClient(_connection, client);
                        }
                        break;

                    case 2:
                        {

                            result = ClientRepository.CreateClient(_connection, client);
                        }
                        break;
                }
                if (result)
                    Console.WriteLine("Pomyślnie dodano klienta");
                else
                    Console.WriteLine("Wystąpił błąd przy usuwaniu klienta");
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Console.WriteLine("Podane dane istnieją juz w bazie");
            }
            finally
            {
                Console.ReadKey();
            }


        }

        public void SelectClient()
        {
            string clientIdOrCompanyName = CustomerPanel.SelectClient();
            Client client = ClientRepository.GetClientByIdOrCompnayName(_connection, clientIdOrCompanyName);
            if(client!=null)
                Console.WriteLine(client.ToString());
            else
            {
                Console.WriteLine("Nie znaleziono klienta o podanym ID bądź nazwie firmy");
            }

            Console.ReadKey();
        }

        public void SelectClients()
        {
            IEnumerable<Client> clients = ClientRepository.SelectClients(_connection);

            foreach(Client client in clients)
            {
                Console.WriteLine(client.ToString());
            }

            Console.ReadKey();
        }

        public void DeleteClient()
        {
            string clientIdOrCompanyName = CustomerPanel.DeleteClient();
            var result = ClientRepository.DeleteClient(_connection, clientIdOrCompanyName);
            if (result)
                Console.WriteLine("Pomyślnie usunięto klienta");
            else
                Console.WriteLine("Wystąpił błąd przy usuwaniu klienta lub klient został usunięty wcześniej");
            Console.ReadKey();
        }


        public void UpdateClient()
        {
            Dictionary<string, string> parameters = CustomerPanel.UpdateClient();

            var result = ClientRepository.UpdateClient(_connection, parameters["columnName"], parameters["newValue"], parameters["clientId"]);

            if (result)
                Console.WriteLine("Pomyślnie zmodyfikowano klienta");
            else
                Console.WriteLine("Wystąpił błąd przy usuwaniu klienta");
            Console.ReadKey();
        }

    }


}