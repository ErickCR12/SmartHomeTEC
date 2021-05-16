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
        //Adds a client to the database
        void AddClient(Client client);
        //Adds a client direction to the database
        void AddDirection(DirectionClient directionClient);
        //Returns a list of distributors with devices that represents the online store
        IEnumerable<Distributor> GetOnlineStore(string continent, string country);
        //Receives a list of distributors with devices that represents the new online store to be stored
        void AddOnlineStore(IEnumerable<Distributor> distributors);
        //Deletes the device store from the database.
        void DeleteOnlineStore();

        //Returns all the exisitng continents in the database
        IEnumerable<Region> GetAllContinents();
        //Returns all countries that are related to the specified continent.
        IEnumerable<Region> GetCountriesByContinent(string continent);

        //Adds a new order representing the purchase of a device.
        void AddOrder(Order order);

        //Checks the received login profile and returns a login profile indicating what kind of user has logged in.
        LoginProfile CheckCredentials(LoginProfile loginProfile);

        //Returns the admin stored in the database.
        Admin GetAdmin();

        //Returns the amount of devices per user.
        DevicesPerUser GetDevicesPerUser();
        //Returns the amount of devices that exist per region
        List<Region> GetDevicesPerRegion();
        //Returns all the active devices.
        int GetActiveDevices();
        
        //Returns the amount of monthly usage of devices from a client.
        int GetMonthlyUsage(string email);
        //Returns the amount of usage per device type devices from a client.
        List<Report> GetDeviceTypesUsage(string email);
        //Returns the amount of daily usage of devices from a client.
        List<Report> GetDailyUsage(string email);

    }

}