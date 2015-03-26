using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBFirstMVC.Models
{
    //class to link all of the appropriate tables when creating a request
    public class CreateNewRequest
    {
        public Request Request { get; set; }
        public IEnumerable<FacilityRequest> FacilityRequests { get; set; }
        public IEnumerable<Facility> Facilities { get; set; } //IEnumerable as there are multiple facilities
        public IEnumerable<Room> Rooms { get; set; } //IEnumerable as there are multiple rooms
        public IEnumerable<Park> Parks { get; set; }
        public IEnumerable<Building> Buildings { get; set; }
        public IEnumerable<RequestToRoom> RequestToRooms { get; set; }
        public IEnumerable<RoomRequest> RoomRequests { get; set; }
    }
}