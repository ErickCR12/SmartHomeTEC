
using System.Collections.Generic;
using System.Linq;
using API_Service.Models;

namespace API_Service.Data
{
    public class SmartHomeRepo : ISmartHomeRepo
    {

        private readonly SmartHomeDbContext _db;
        public SmartHomeRepo(SmartHomeDbContext db) 
        {
            _db = db;
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
        public IEnumerable<DeviceType> GetAllDeviceTypes()
        {
            return _db.device_types.ToList();
        }
    }
}