﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBFirstMVC.Models
{
    //Information about a room
    public class RoomInfo
    {
        public Room Room { get; set; }
        public IEnumerable<RoomFacility> RoomFacility { get; set; }
    }
}