using GroundControl.Interview.SeniorDeveloper.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroundControl.Interview.SeniorDeveloper.Api.Data.Context
{
    public class GroundDBContext:DbContext
    {
        public readonly IConfiguration configuration;
        public GroundDBContext(DbContextOptions<GroundDBContext> options, IConfiguration config) : base(options)
        {
            configuration = config;
        }
        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
        public DbSet<BookingType> BookingType { get; set; }
        public DbSet<Booking> Booking { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }

    }
}
