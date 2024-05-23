﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Data.Models
{
    public class GuestEntity : UserEntity
    {
        public List<BookingEntity> Bookings { get; set; } = [];
       
    }
}
