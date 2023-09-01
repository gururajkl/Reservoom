using System.Collections.Generic;

namespace Reservoom.Models
{
    public class Hotel
    {
        private readonly ReservationBook reservationBook;

        public string Name { get; }

        public Hotel(string name)
        {
            Name = name;
            reservationBook = new ReservationBook();
        }

        public IEnumerable<Reservation> GetAllReservation()
        {
            return reservationBook.GetAllReservation();
        }

        public void MakeReservation(Reservation reservation)
        {
            reservationBook.AddReservation(reservation);
        }
    }
}
