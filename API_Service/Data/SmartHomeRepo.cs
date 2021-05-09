
using System;
using System.Collections.Generic;
using System.Linq;
using API_Service.Models;
using Npgsql;

namespace API_Service.Data
{
    public class SmartHomeRepo : ISmartHomeRepo
    {

        private readonly NpgsqlConnection DBconn;

        public SmartHomeRepo() 
        {
            DBconn = new NpgsqlConnection("Host=localhost;Port=5432;Username=smarthome;Password=emerson;Database=smarthome.dev;");
        }

        public IEnumerable<Device> GetAllDevices()
        {
            List<Device> allDevices = new List<Device>();

            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT serial_number, brand, electric_usage, price, device_type_name " +
                "FROM devices " +
                "WHERE client_email IS NULL",
                DBconn
                );

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            while (DBreader.Read())
            {
                Device device = new Device();
                device.serial_number = Int32.Parse(DBreader[0].ToString()); ;
                device.brand = DBreader[1].ToString();
                device.electric_usage = Int32.Parse(DBreader[2].ToString());
                device.price = Int32.Parse(DBreader[3].ToString());
                device.device_type_name = DBreader[4].ToString();
                allDevices.Add(device);
            }
            DBconn.Close();

            return allDevices;
        }

        public IEnumerable<Device> GetAllDevicesByClient(string client_email)
        {
            List<Device> allDevices = new List<Device>();

            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT serial_number, brand, electric_usage, price, device_type_name, client_email " +
                "FROM devices " +
                "WHERE client_email = @pCond",
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("pCond", client_email);

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            while (DBreader.Read())
            {
                Device device = new Device();
                device.serial_number = Int32.Parse(DBreader[0].ToString()); ;
                device.brand = DBreader[1].ToString();
                device.electric_usage = Int32.Parse(DBreader[2].ToString());
                device.price = Int32.Parse(DBreader[3].ToString());
                device.device_type_name = DBreader[4].ToString();
                device.client_email = DBreader[5].ToString();
                allDevices.Add(device);
            }
            DBconn.Close();

            return allDevices;
        }

        public Device GetDevice(int serialNumber)
        {            
            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT serial_number, brand, electric_usage, price, device_type_name, client_email " +
                "FROM devices " + 
                "WHERE serial_number = @pCond", 
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("pCond", serialNumber);

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            if(DBreader.Read())
            {
                Device device = new Device();
                device.serial_number = Int32.Parse(DBreader[0].ToString());;
                device.brand = DBreader[1].ToString();
                device.electric_usage = Int32.Parse(DBreader[2].ToString());
                device.price = Int32.Parse(DBreader[3].ToString());
                device.device_type_name = DBreader[4].ToString();
                device.client_email = DBreader[5].ToString();
                DBconn.Close();
                return device;
            }
            DBconn.Close();

            return null;
        }

        public void AddDevice(Device device)
        {
            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "INSERT INTO devices (serial_number, brand, electric_usage, price, device_type_name) " +
                "VALUES (@p1, @p2, @p3, @p4, @p5)", 
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("p1", device.serial_number);
            sqlCmd.Parameters.AddWithValue("p2", device.brand);
            sqlCmd.Parameters.AddWithValue("p3", device.electric_usage);
            sqlCmd.Parameters.AddWithValue("p4", device.price);
            sqlCmd.Parameters.AddWithValue("p5", device.device_type_name);
            sqlCmd.ExecuteNonQuery();

            DBconn.Close();
        }

        public void UpdateDevice(Device device)
        {
            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "UPDATE devices " +
                "SET brand = @p1, electric_usage = @p2, price = @p3, device_type_name = @p4 " +
                "WHERE serial_number = @cond", 
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("cond", device.serial_number);
            sqlCmd.Parameters.AddWithValue("p1", device.brand);
            sqlCmd.Parameters.AddWithValue("p2", device.electric_usage);
            sqlCmd.Parameters.AddWithValue("p3", device.price);
            sqlCmd.Parameters.AddWithValue("p4", device.device_type_name);
            sqlCmd.ExecuteNonQuery();

            DBconn.Close();
        }

        public void DeleteDevice(Device device)
        {
            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "DELETE FROM devices " +
                "WHERE serial_number = @cond", 
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("cond", device.serial_number);
            sqlCmd.ExecuteNonQuery();

            DBconn.Close();
        }

        private void AddClientToDevice(int device_serial_number, string client_email){
            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "UPDATE devices " +
                "SET client_email = @p1 " +
                "WHERE serial_number = @cond", 
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("cond", device_serial_number);
            sqlCmd.Parameters.AddWithValue("p1", client_email);
            sqlCmd.ExecuteNonQuery();

            DBconn.Close();
        }


        public IEnumerable<DeviceType> GetAllDeviceTypes()
        {
            List<DeviceType> allDeviceTypes = new List<DeviceType>();
            
            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT name, description, warranty_months " +
                "FROM device_types", 
                DBconn
                );

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            while(DBreader.Read())
            {
                DeviceType deviceType = new DeviceType();
                deviceType.name = DBreader[0].ToString();
                deviceType.description = DBreader[1].ToString();
                deviceType.warranty_months = Int32.Parse(DBreader[2].ToString());
                allDeviceTypes.Add(deviceType);
            }
            DBconn.Close();

            return allDeviceTypes;
        }

        public DeviceType GetDeviceType(string name)
        {
            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT name, description, warranty_months " +
                "FROM device_types " + 
                "WHERE name = @pCond", 
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("pCond", name);

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            if(DBreader.Read())
            {
                DeviceType deviceType = new DeviceType();
                deviceType.name = DBreader[0].ToString();
                deviceType.description = DBreader[1].ToString();
                deviceType.warranty_months = Int32.Parse(DBreader[2].ToString());
                DBconn.Close();
                return deviceType;
            }
            DBconn.Close();

            return null;
        }

        public void AddDeviceType(DeviceType deviceType)
        {
            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "INSERT INTO device_types (name, description, warranty_months) " +
                "VALUES (@p1, @p2, @p3)", DBconn
                );

            sqlCmd.Parameters.AddWithValue("p1", deviceType.name);
            sqlCmd.Parameters.AddWithValue("p2", deviceType.description);
            sqlCmd.Parameters.AddWithValue("p3", deviceType.warranty_months);
            sqlCmd.ExecuteNonQuery();
            DBconn.Close();

        }

        public void UpdateDeviceType(DeviceType deviceType)
        {
            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "UPDATE device_types " +
                "SET description = @p1, warranty_months = @p2 " +
                "WHERE name = @cond", 
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("cond", deviceType.name);
            sqlCmd.Parameters.AddWithValue("p1", deviceType.description);
            sqlCmd.Parameters.AddWithValue("p2", deviceType.warranty_months);
            sqlCmd.ExecuteNonQuery();

            DBconn.Close();
        }

        public void DeleteDeviceType(DeviceType deviceType)
        {
            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "DELETE FROM device_types " +
                "WHERE name = @cond", 
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("cond", deviceType.name);
            sqlCmd.ExecuteNonQuery();

            DBconn.Close();
        }

        public IEnumerable<Client> GetAllClients()
        {
            List<Client> allClients = new List<Client>();
            
            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT email, name, password, last_name1, last_name2, country, continent " +
                "FROM clients", 
                DBconn
                );

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            while(DBreader.Read())
            {
                Client client = new Client();
                client.email = DBreader[0].ToString();
                client.name = DBreader[1].ToString();
                client.password = DBreader[2].ToString();
                client.last_name1 = DBreader[3].ToString();
                client.last_name2 = DBreader[4].ToString();
                client.country = DBreader[5].ToString();
                client.continent = DBreader[6].ToString();
                allClients.Add(client);
            }
            DBconn.Close();

            return allClients;
        }

        public Client GetClient(string email)
        {
            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT email, name, password, last_name1, last_name2, country, continent " +
                "FROM clients " + 
                "WHERE email = @pCond", 
                DBconn
                );
            
            sqlCmd.Parameters.AddWithValue("pCond", email);

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            if(DBreader.Read())
            {
                Client client = new Client();
                client.email = DBreader[0].ToString();
                client.name = DBreader[1].ToString();
                client.password = DBreader[2].ToString();
                client.last_name1 = DBreader[3].ToString();
                client.last_name2 = DBreader[4].ToString();
                client.country = DBreader[5].ToString();
                client.continent = DBreader[6].ToString();
                DBconn.Close();
                return client;
            }
            DBconn.Close();
            return null;
        }

        public void AddClient(Client client)
        {
            DBconn.Open();

            var sqlAddClient = new NpgsqlCommand(
                "INSERT INTO clients (email, name, password, last_name1, last_name2, country, continent) " +
                "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", DBconn
                );

            sqlAddClient.Parameters.AddWithValue("p1", client.email);
            sqlAddClient.Parameters.AddWithValue("p2", client.name);
            sqlAddClient.Parameters.AddWithValue("p3", client.password);
            sqlAddClient.Parameters.AddWithValue("p4", client.last_name1);
            sqlAddClient.Parameters.AddWithValue("p5", client.last_name2);
            sqlAddClient.Parameters.AddWithValue("p6", client.country);
            sqlAddClient.Parameters.AddWithValue("p7", client.continent);
            sqlAddClient.ExecuteNonQuery();

            DBconn.Close();

        }

        public void AddDirection(DirectionClient directionClient){
            DBconn.Open();

            var sqlAddDirection = new NpgsqlCommand(
                "INSERT INTO directions_clients (direction, client_email) " +
                "VALUES (@p1, @p2)", DBconn
                );

            sqlAddDirection.Parameters.AddWithValue("p1", directionClient.direction);
            sqlAddDirection.Parameters.AddWithValue("p2", directionClient.client_email);
            sqlAddDirection.ExecuteNonQuery();
            
            DBconn.Close();
        }

        public IEnumerable<Distributor> GetOnlineStore(string continent, string country)
        {
            List<Distributor> onlineStoreByRegion = new List<Distributor>();
            
            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "SELECT legal_card, serial_number, brand, electric_usage, device_type_name " +
                "FROM public.device_distributor, distributors, devices " + 
                "WHERE 	legal_card = distributors_legal_card AND " +
                "serial_number = devices_serial_number AND " +
                "continent = @p1 AND " + 
                "country = @p2", 
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("p1", continent);
            sqlCmd.Parameters.AddWithValue("p2", country);

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            while(DBreader.Read())
            {
                int legal_card = Int32.Parse(DBreader[0].ToString());
                Distributor distributor = onlineStoreByRegion.Find(o => o.legal_card == legal_card);
                if(distributor == null)
                {
                    distributor = new Distributor();
                    distributor.devices_ = new List<Device>();
                    onlineStoreByRegion.Add(distributor);
                }

                distributor.legal_card = legal_card;

                Device device = new Device();
                device.serial_number = Int32.Parse(DBreader[1].ToString());
                device.brand = DBreader[2].ToString();
                device.electric_usage = Int32.Parse(DBreader[3].ToString());
                device.device_type_name = DBreader[4].ToString();

                distributor.devices_.Add(device);                    
            }
            DBconn.Close();

            return onlineStoreByRegion;
        }

        public void AddOnlineStore(IEnumerable<Distributor> distributors)
        {
            DeleteOnlineStore();
            DBconn.Open();
            foreach(Distributor distributor in distributors)
            {
                foreach(Device device in distributor.devices_)
                {
                    var sqlCmd = new NpgsqlCommand(
                        "INSERT INTO device_distributor (devices_serial_number, distributors_legal_card) " +
                        "VALUES (@p1, @p2)", 
                        DBconn
                        );

                    sqlCmd.Parameters.AddWithValue("p1", device.serial_number);
                    sqlCmd.Parameters.AddWithValue("p2", distributor.legal_card);
                    sqlCmd.ExecuteNonQuery();
                    
                }
            }
            DBconn.Close();
        }

        public void DeleteOnlineStore()
        {
            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "DELETE FROM device_distributor", 
                DBconn
                );

            sqlCmd.ExecuteNonQuery();

            DBconn.Close();
        }

        public IEnumerable<Region> GetAllContinents(){
            
            List<Region> allContinents = new List<Region>();

            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT DISTINCT continent " +
                "FROM regions",
                DBconn
                );

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            while (DBreader.Read())
            {
                Region region = new Region();
                region.continent = DBreader[0].ToString();
                allContinents.Add(region);
            }
            DBconn.Close();

            return allContinents;
        }

        public IEnumerable<Region> GetCountriesByContinent(string continent){
            
            List<Region> allCountries = new List<Region>();

            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT country " +
                "FROM regions " +
                "WHERE continent = @cond",
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("cond", continent);

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            while (DBreader.Read())
            {
                Region region = new Region();
                region.continent = continent;
                region.country = DBreader[0].ToString();
                allCountries.Add(region);
            }
            DBconn.Close();

            return allCountries;
        }


        public void AddOrder(Order order)
        {
            DBconn.Open();

            AddClientToDevice(order.device_serial_number, order.client_email);

            int orderConsecutive = GetAmountOrdersByClient(order.client_email) + 1;

            var sqlCmd = new NpgsqlCommand(
                "INSERT INTO orders (consecutive, price, purchase_date, purchase_time, client_email, device_serial_number) " +
                "VALUES (@p1, @p2, @p3, @p4, @p5, @p6) RETURNING bill_number", DBconn
                );

            sqlCmd.Parameters.AddWithValue("p1", orderConsecutive);
            sqlCmd.Parameters.AddWithValue("p2", order.price);
            sqlCmd.Parameters.AddWithValue("p3", order.purchase_date);
            sqlCmd.Parameters.AddWithValue("p4", order.purchase_time);
            sqlCmd.Parameters.AddWithValue("p5", order.client_email);
            sqlCmd.Parameters.AddWithValue("p6", order.device_serial_number);
            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();

            order.consecutive = orderConsecutive;
            DBreader.Read();
            order.bill_number = Int32.Parse(DBreader[0].ToString());
            DBconn.Close();
        }

        private int GetAmountOrdersByClient(string client_email){
            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT COUNT(client_email) " +
                "FROM orders " +
                "WHERE client_email = @cond", 
                DBconn
                );
            
            sqlCmd.Parameters.AddWithValue("cond", client_email);
            
            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            DBreader.Read();
            int amountOrders = Int32.Parse(DBreader[0].ToString());  
            DBreader.Close();
            
            DBconn.Close();          
            
            return amountOrders;
        }

        public LoginProfile CheckCredentials(LoginProfile loginProfile)
        {
            List<Client> clients = (List<Client>)GetAllClients();
            Admin admin = GetAdmin();


            if (admin.username == loginProfile.Username && admin.password == loginProfile.Password)
            {
                loginProfile.UserType = "Admin";
                return loginProfile;
            }
            
            foreach(Client client in clients)
            {
                if (client.email == loginProfile.Username && client.password == loginProfile.Password)
                {
                    loginProfile.UserType = "Client";
                    return loginProfile;
                }
            }
            loginProfile.UserType = "Invalid";
            return loginProfile;
        }

        public Admin GetAdmin()
        {
            Admin admin = new Admin();
            
            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT username, password " +
                "FROM admin", 
                DBconn
                );

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            while(DBreader.Read())
            {
                admin.username = DBreader[0].ToString();
                admin.password = DBreader[1].ToString();
            }
            DBconn.Close();

            return admin;
        }

        public DevicesPerUser GetDevicesPerUser()
        {
            DevicesPerUser devicesPerUser = new DevicesPerUser();

            DBconn.Open();
            var sqlDeviceCount = new NpgsqlCommand(
                "SELECT COUNT(serial_number) " +
                "FROM devices", 
                DBconn
                );

            var sqlClientCount = new NpgsqlCommand(
                "SELECT COUNT(email) " +
                "FROM clients", 
                DBconn
                );
            
            NpgsqlDataReader DBreaderClients = sqlClientCount.ExecuteReader();
            DBreaderClients.Read();
            devicesPerUser.amountClients = Int32.Parse(DBreaderClients[0].ToString());  
            DBreaderClients.Close();
            
            NpgsqlDataReader DBreaderDevices = sqlDeviceCount.ExecuteReader();
            DBreaderDevices.Read();
            devicesPerUser.amountDevices = Int32.Parse(DBreaderDevices[0].ToString());
            DBreaderDevices.Close();

            devicesPerUser.amountDevicesPerUser = Math.Round(devicesPerUser.amountDevices/devicesPerUser.amountClients, 2);
            
            DBconn.Close();          
            
            return devicesPerUser;
        }

        public List<Region> GetDevicesPerRegion()
        {
            List<Region> devicesPerRegion = new List<Region>();

            DBconn.Open();
            var sqlComm = new NpgsqlCommand(
                "SELECT     country, continent, COUNT(country) AS devices_per_region " +
                "FROM	    ((devices JOIN device_distributor ON serial_number = devices_serial_number) " +
			                "JOIN distributors ON distributors_legal_card = legal_card) " +
                "GROUP BY   country, continent",
                DBconn
                );

            NpgsqlDataReader DBreader = sqlComm.ExecuteReader();

            while(DBreader.Read()){
                Region devicePerRegion = new Region();
                devicePerRegion.country = DBreader[0].ToString();
                devicePerRegion.continent = DBreader[1].ToString();
                devicePerRegion.amount = Int32.Parse(DBreader[2].ToString());
                devicesPerRegion.Add(devicePerRegion);
            }

            DBconn.Close();          
            
            return devicesPerRegion;
        }

        public int GetActiveDevices()
        {
            DBconn.Open();
            var sqlComm = new NpgsqlCommand(
                "SELECT COUNT(serial_number) " +
                "FROM devices " +   
                "WHERE client_email IS NOT NULL",
                DBconn
                );

            NpgsqlDataReader DBreader = sqlComm.ExecuteReader();
            DBreader.Read();
            int amountDevices = Int32.Parse(DBreader[0].ToString());
            
            DBconn.Close();          
            
            return amountDevices;
        }
    }
}