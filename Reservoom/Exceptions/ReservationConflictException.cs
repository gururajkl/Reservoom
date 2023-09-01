using Reservoom.Models;
using System;

namespace Reservoom.Exceptions
{
    public class ReservationConflictException : Exception
    {
        public Reservation ExisitingException { get; }
        public Reservation IncomingException { get; }

        public ReservationConflictException(Reservation exisitingException, Reservation incomingException)
        {
            ExisitingException = exisitingException;
            IncomingException = incomingException;
        }

        public ReservationConflictException(string? message, Reservation exisitingException, Reservation incomingException) : base(message)
        {
            ExisitingException = exisitingException;
            IncomingException = incomingException;
        }

        public ReservationConflictException(string? message, Exception? innerException, Reservation exisitingException, Reservation incomingException) : base(message, innerException)
        {
            ExisitingException = exisitingException;
            IncomingException = incomingException;
        }
    }
}
