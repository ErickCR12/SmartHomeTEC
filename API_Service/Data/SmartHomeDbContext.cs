using API_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Service.Data
{
    public class SmartHomeDbContext : DbContext
    {
        public SmartHomeDbContext() { }
        public SmartHomeDbContext(DbContextOptions<SmartHomeDbContext> options) : base(options) { }
        
        public virtual DbSet<Device> Devices {get; set;}
        public virtual DbSet<DeviceType> DeviceTypes {get; set;}

    }
}