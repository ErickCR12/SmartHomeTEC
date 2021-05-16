using System.Collections.Generic;
using API_Service.Models;

namespace API_Service.Data
{
    public interface ISmartHomeRepo{

        //Gets all the devices from the database.
        IEnumerable<Device> GetAllDevices();
        //Gets all the devices of a client from the database using the received email in a SELECT script.
        IEnumerable<Device> GetAllDevicesByClient(string client_email);
        //Returns a device with the specified serial number.
        Device GetDevice(int serialNumber);
        //Adds a device to the database with an INSERT script
        void AddDevice(Device device);
        //Adds a device state to the database
        void AddDeviceState(DeviceState deviceState);
        //Updates an existant device
        void UpdateDevice(Device device);
        //Deletes an existant device from the database
        void DeleteDevice(Device device);

        //Gets all the device types from the database.
        IEnumerable<DeviceType> GetAllDeviceTypes();
        //Returns a device type with the specified name.
        DeviceType GetDeviceType(string name);
        //Adds a device type to the database
        void AddDeviceType(DeviceType deviceType);
        //Updates an existant device type
        void UpdateDeviceType(DeviceType deviceType);
        //Deletes an existant  type from the database
        void DeleteDeviceType(DeviceType deviceType);

        //Gets all the clients from the database.
        IEnumerable<Client> GetAllClients();
        //Get the client with the specified email from the database.
        Client GetClient(string email);
        //Updates the client with the specified.
        void UpdateClient(Client client);

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
        
        
        int GetMonthlyUsage(string email);
        List<Report> GetDeviceTypesUsage(string email);
        List<Report> GetDailyUsage(string email);

    }

}