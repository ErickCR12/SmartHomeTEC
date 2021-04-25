using API_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Service.Data
{
    public class SmartHomeDbContext : DbContext
    {
        public SmartHomeDbContext() { }
        public SmartHomeDbContext(DbContextOptions<SmartHomeDbContext> options) : base(options) { }
        


        public virtual DbSet<Device> devices {get; set;}
        public virtual DbSet<DeviceType> device_types {get; set;}
        public virtual DbSet<Distributor> distributors {get; set;}
        public virtual DbSet<Order> orders {get; set;}
        public virtual DbSet<Client> clients {get; set;}
        public virtual DbSet<Chamber> chambers {get; set;}
        public virtual DbSet<DirectionClient> directions_clients {get; set;}
        public virtual DbSet<Admin> admin {get; set;}

    }
}