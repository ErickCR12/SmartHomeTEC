
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

        private readonly SmartHomeDbContext _db;
        public SmartHomeRepo(SmartHomeDbContext db) 
        {
            _db = db;
            DBconn = new NpgsqlConnection("Host=localhost;Port=5432;Username=smarthome;Password=emerson;Database=smarthome.dev;");
        }

        public IEnumerable<Device> GetAllDevices()
        {
            // return _db.devices.ToList();
            List<Device> allDevices = new List<Device>();
            
            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT serial_number, brand, electric_usage, device_type_name, client_email " +
                "FROM devices", 
                DBconn
                );

            NpgsqlDataReader DBreader = sqlCmd.ExecuteReader();
            while(DBreader.Read())
            {
                Device device = new Device();
                device.serial_number = Int32.Parse(DBreader[0].ToString());;
                device.brand = DBreader[1].ToString();
                device.electric_usage = Int32.Parse(DBreader[2].ToString());
                device.device_type_name = DBreader[3].ToString();
                device.client_email = DBreader[4].ToString();
                allDevices.Add(device);
            }
            DBconn.Close();

            return allDevices;
        }

        public Device GetDevice(int serialNumber)
        {
            //return _db.devices.Find(serialNumber);
            
            DBconn.Open();
            var sqlCmd = new NpgsqlCommand(
                "SELECT serial_number, brand, electric_usage, device_type_name, client_email " +
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
                device.device_type_name = DBreader[3].ToString();
                device.client_email = DBreader[4].ToString();
                DBconn.Close();
                return device;
            }
            DBconn.Close();

            return null;
        }

        public void AddDevice(Device device)
        {

            // _db.Add(device);
            // _db.SaveChanges();

            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "INSERT INTO devices (serial_number, brand, electric_usage, device_type_name) " +
                "VALUES (@p1, @p2, @p3, @p4)", 
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("p1", device.serial_number);
            sqlCmd.Parameters.AddWithValue("p2", device.brand);
            sqlCmd.Parameters.AddWithValue("p3", device.electric_usage);
            sqlCmd.Parameters.AddWithValue("p4", device.device_type_name);
            sqlCmd.ExecuteNonQuery();

            DBconn.Close();
        }

        public void UpdateDevice(Device device)
        {
            // _db.Update(device);
            // _db.SaveChanges();
            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "UPDATE devices " +
                "SET brand = @p1, electric_usage = @p2, device_type_name = @p3 " +
                "WHERE serial_number = @cond", 
                DBconn
                );

            sqlCmd.Parameters.AddWithValue("cond", device.serial_number);
            sqlCmd.Parameters.AddWithValue("p1", device.brand);
            sqlCmd.Parameters.AddWithValue("p2", device.electric_usage);
            sqlCmd.Parameters.AddWithValue("p3", device.device_type_name);
            sqlCmd.ExecuteNonQuery();

            DBconn.Close();
        }

        public void DeleteDevice(Device device)
        {
            // _db.Remove(device);
            // _db.SaveChanges();

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


        public IEnumerable<DeviceType> GetAllDeviceTypes()
        {
            //return _db.device_types.ToList();

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
            // return _db.device_types.Find(name);

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
            // _db.Add(deviceType);
            //_db.SaveChanges();

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
            // _db.Update(deviceType);
            // _db.SaveChanges();
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
            // _db.Remove(deviceType);
            // _db.SaveChanges();

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
            // return _db.clients.ToList();

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
            // return _db.clients.Find(email);
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
            // _db.Add(client);
            // _db.SaveChanges();

            DBconn.Open();

            var sqlCmd = new NpgsqlCommand(
                "INSERT INTO clients (email, name, password, last_name1, last_name2, country, continent) " +
                "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", DBconn
                );

            sqlCmd.Parameters.AddWithValue("p1", client.email);
            sqlCmd.Parameters.AddWithValue("p2", client.name);
            sqlCmd.Parameters.AddWithValue("p3", client.password);
            sqlCmd.Parameters.AddWithValue("p4", client.last_name1);
            sqlCmd.Parameters.AddWithValue("p5", client.last_name2);
            sqlCmd.Parameters.AddWithValue("p6", client.country);
            sqlCmd.Parameters.AddWithValue("p7", client.continent);
            sqlCmd.ExecuteNonQuery();
            DBconn.Close();
        }
    }
}