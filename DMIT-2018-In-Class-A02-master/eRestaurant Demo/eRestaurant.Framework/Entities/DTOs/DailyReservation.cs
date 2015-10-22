

using eRestaurant.Framework.Entities.POCOs;
using System.Collections.Generic;
namespace eRestaurant.Framework.Entities.DTOs
{
    public class DailyReservation
    {

        public int Month { get; set; }
        public int Day { get; set; }
        public IEnumerable<Booking> Reservations { get; set; }


    }
}
