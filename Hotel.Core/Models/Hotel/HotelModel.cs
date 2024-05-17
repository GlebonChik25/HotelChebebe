﻿using Hotel.Core.Models.Common;
using System.ComponentModel.DataAnnotations;


namespace Hotel.Core.Models
{
    public class HotelModel : Model
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        private int stras;
        public int Stars 
        { 
            get
            {
                return stras;
            }
            private set
            {
                if (value > 5)
                {
                    stras = 5;
                    return;
                }
                if (value < 0)
                {
                    stras = 5;
                    return;
                }
                stras = value;
            }
        }
        public List<string> Photos { get; private set; } = [];
        public List<RoomModel> Rooms { get; private set; } = [];
        public HotelModel(Guid id,string name, string description, string address, string phone, int stars, List<string> photos) : base(id)
        {
            Name = name;
            Description = description;
            Address = address;
            Phone = phone;
            Stars = stars;
            Photos = photos;
        }
    }
}