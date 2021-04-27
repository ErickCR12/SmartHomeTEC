
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
            return _db.devices.ToList();
        }

        public Device GetDevice(int serialNumber)
        {
            return _db.devices.Find(serialNumber);
        }

        public void AddDevice(Device device)
        {
            _db.Add(device);
            _db.SaveChanges();
        }

        public void UpdateDevice(Device device)
        {
            _db.Update(device);
            _db.SaveChanges();
        }

        public void DeleteDevice(Device device)
        {
            _db.Remove(device);
            _db.SaveChanges();
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
            return _db.device_types.Find(name);
        }

        public void AddDeviceType(DeviceType deviceType)
        {
            // _db.Add(deviceType);
            //_db.SaveChanges();

            var sqlCmd = new NpgsqlCommand(
                "INSERT INTO device_types (name, description, warranty_months) " +
                "VALUES (@p1, @p2, @p3)", DBconn
                );

            sqlCmd.Parameters.AddWithValue("p1", deviceType.name);
            sqlCmd.Parameters.AddWithValue("p2", deviceType.description);
            sqlCmd.Parameters.AddWithValue("p3", deviceType.warranty_months);
            sqlCmd.ExecuteNonQuery();
        }

        public void UpdateDeviceType(DeviceType deviceType)
        {
            _db.Update(deviceType);
            _db.SaveChanges();
        }

        public void DeleteDeviceType(DeviceType deviceType)
        {
            _db.Remove(deviceType);
            _db.SaveChanges();
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _db.clients.ToList();
        }

        public Client GetClient(string email)
        {
            return _db.clients.Find(email);
        }

        public void AddClient(Client client)
        {
            _db.Add(client);
            _db.SaveChanges();
        }
    }
}