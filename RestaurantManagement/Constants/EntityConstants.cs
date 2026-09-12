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
        /// <summary>Maximum length of a person's name.</summary>
        public const int maxnamelength = 100;
        /// <summary>Maximum length of an email address.</summary>
        public const int maxemaillength = 100;
        /// <summary>Maximum length of a phone number.</summary>
        public const int maxphonenumberlength = 20;
        /// <summary>Maximum length of a dish name.</summary>
        public const int maxdishnamelength = 255;
        /// <summary>Maximum length of an address.</summary>
        public const int maxaddresslength = 255;
        /// <summary>Maximum length of a street name.</summary>
        public const int maxstreetlength = 100;
        /// <summary>Maximum length of a city name.</summary>
        public const int maxcitylength = 50;
        /// <summary>Maximum length of a state name.</summary>
        public const int maxstatelength = 50;
        /// <summary>Maximum length of a postal code.</summary>
        public const int maxpincodelength = 30;
        /// <summary>Minimum length of a street name.</summary>
        public const int minstreetlength = 3;
        /// <summary>Minimum length of a city name.</summary>
        public const int mincitylength = 3;
        /// <summary>Minimum length of a state name.</summary>
        public const int minstatelength = 3;
        /// <summary>Minimum length of a postal code.</summary>
        public const int minpincodelength = 3;
        /// <summary>Minimum length of a dish name.</summary>
        public const int mindishnamelength = 3;
        /// <summary>Minimum length of an address.</summary>
        public const int minaddresslength = 3;
        /// <summary>Maximum length of a password.</summary>
        public const int maxpasswordlength = 16;
        /// <summary>Minimum length of a password.</summary>
        public const int minpasswordlength = 8;
    }
}