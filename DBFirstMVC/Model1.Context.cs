﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBFirstMVC
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class team16Entities : DbContext
    {
        public team16Entities()
            : base("name=team16Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<AllocatedRoom> AllocatedRooms { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Dept> Depts { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<FacilityRequest> FacilityRequests { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleDegree> ModuleDegrees { get; set; }
        public DbSet<ModuleLecturer> ModuleLecturers { get; set; }
        public DbSet<Park> Parks { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestToRoom> RequestToRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        public DbSet<RoomRequest> RoomRequests { get; set; }
        public DbSet<RoundAndSemester> RoundAndSemesters { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Week> Weeks { get; set; }
    }
}
