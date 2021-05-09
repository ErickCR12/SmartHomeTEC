using System.Collections.Generic;
using API_Service.Models;

namespace API_Service.Data
{
    public interface ISmartHomeRepo{

        IEnumerable<Device> GetAllDevices();
        IEnumerable<Device> GetAllDevicesByClient(string client_email);
        Device GetDevice(int serialNumber);
        void AddDevice(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(Device device);

        IEnumerable<DeviceType> GetAllDeviceTypes();
        DeviceType GetDeviceType(string name);
        void AddDeviceType(DeviceType deviceType);
        void UpdateDeviceType(DeviceType deviceType);
        void DeleteDeviceType(DeviceType deviceType);

        IEnumerable<Client> GetAllClients();
        Client GetClient(string email);
        void AddClient(Client client);
        void AddDirection(DirectionClient directionClient);
        
        IEnumerable<Distributor> GetOnlineStore(string continent, string country);
        void AddOnlineStore(IEnumerable<Distributor> distributors);
        void DeleteOnlineStore();

        IEnumerable<Region> GetAllContinents();
        IEnumerable<Region> GetCountriesByContinent(string continent);

        void AddOrder(Order order);

        LoginProfile CheckCredentials(LoginProfile loginProfile);

        Admin GetAdmin();

        DevicesPerUser GetDevicesPerUser();
        List<Region> GetDevicesPerRegion();
        int GetActiveDevices();

    }

}