using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagement.Constants
{
    /// <summary>
    /// Defines validation limits used by restaurant management entities.
    /// </summary>
    public static class EntityConstants
    {
        public const int MaxNameLength = 100;
        public const int MaxEmailLength = 100;
        public const int MaxPhoneNumberLength = 20;
        public const int MaxDishNameLength = 255;
        public const int MaxAddressLength = 255;
        public const int MaxStreetLength = 100;
        public const int MaxCityLength = 50;
        public const int MaxStateLength = 50;
        public const int MaxPinCodeLength = 30;
        public const int MinCityLength = 3;
        public const int MinStateLength = 3;
        public const int MinAddressLength = 3;
    }
}

