﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRent
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class CarRentalCenterDBEntities : DbContext
    {
        public CarRentalCenterDBEntities()
            : base("name=CarRentalCenterDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<TableCars> TableCars { get; set; }
        public DbSet<TableGroups> TableGroups { get; set; }
        public DbSet<TableMakers> TableMakers { get; set; }
        public DbSet<TableModels> TableModels { get; set; }
        public DbSet<TableOrders> TableOrders { get; set; }
        public DbSet<TablePersons> TablePersons { get; set; }
        public DbSet<TableStatus> TableStatus { get; set; }
        public DbSet<TableUsers> TableUsers { get; set; }
        public DbSet<ViewCars1> ViewCars1 { get; set; }
        public DbSet<ViewCars2> ViewCars2 { get; set; }
        public DbSet<ViewOrders1> ViewOrders1 { get; set; }
        public DbSet<ViewOrders2> ViewOrders2 { get; set; }
        public DbSet<ViewOrders3> ViewOrders3 { get; set; }
        public DbSet<ViewOrders4> ViewOrders4 { get; set; }
        public DbSet<ViewOrders5> ViewOrders5 { get; set; }
    
        [EdmFunction("CarRentalCenterDBEntities", "Cars1")]
        public virtual IQueryable<Cars1_Result> Cars1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Cars1_Result>("[CarRentalCenterDBEntities].[Cars1]()");
        }
    
        [EdmFunction("CarRentalCenterDBEntities", "Cars2")]
        public virtual IQueryable<Cars2_Result> Cars2()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<Cars2_Result>("[CarRentalCenterDBEntities].[Cars2]()");
        }
    
        [EdmFunction("CarRentalCenterDBEntities", "FuncCars")]
        public virtual IQueryable<FuncCars_Result> FuncCars()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FuncCars_Result>("[CarRentalCenterDBEntities].[FuncCars]()");
        }
    
        [EdmFunction("CarRentalCenterDBEntities", "FuncOrders1")]
        public virtual IQueryable<FuncOrders1_Result> FuncOrders1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FuncOrders1_Result>("[CarRentalCenterDBEntities].[FuncOrders1]()");
        }
    
        [EdmFunction("CarRentalCenterDBEntities", "FuncUsers")]
        public virtual IQueryable<FuncUsers_Result> FuncUsers()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FuncUsers_Result>("[CarRentalCenterDBEntities].[FuncUsers]()");
        }
    }
}
