using System.Collections.Generic;
using API_Service.Models;

namespace API_Service.Data
{
    public interface ISmartHomeRepo{

        IEnumerable<Device> GetAllDevices();
        Device GetDevice(int serialNumber);
        void AddDevice(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(Device device);

        IEnumerable<DeviceType> GetAllDeviceTypes();
    }

}