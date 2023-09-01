using Reservoom.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Reservoom.Models
{
    public class ReservationBook
    {
        private readonly List<Reservation> reservations;

        public ReservationBook()
        {
            reservations = new List<Reservation>();
        }

        public IEnumerable<Reservation> GetAllReservation()
        {
            return reservations;
        }

        public void AddReservation(Reservation reservation)
        {
            foreach (var exisitingReservation in reservations)
            {
                if (exisitingReservation.Conflicts(reservation))
                {
                    throw new ReservationConflictException(exisitingReservation, reservation);
                }
            }

            reservations.Add(reservation);
        }
    }
}
