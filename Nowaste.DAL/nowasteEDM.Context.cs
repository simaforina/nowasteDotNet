﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nowaste.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class nowasteDBEntities : DbContext
    {
        public nowasteDBEntities()
            : base("name=nowasteDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<CityDistricts> CityDistricts { get; set; }
        public virtual DbSet<ClientPersonPhoneNumbbers> ClientPersonPhoneNumbbers { get; set; }
        public virtual DbSet<ClientPersons> ClientPersons { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Emploees> Emploees { get; set; }
        public virtual DbSet<RecycledResourses> RecycledResourses { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<RequestStatuses> RequestStatuses { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
