using System;

namespace Reservoom.Models
{
    public class Reservation
    {
        public RoomID? RoomID { get; }
        public string Username { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public TimeSpan Length => EndTime.Subtract(StartTime);

        public Reservation(RoomID? roomID, DateTime startTime, DateTime endTime, string username)
        {
            RoomID = roomID;
            StartTime = startTime;
            EndTime = endTime;
            Username = username;
        }

        public bool Conflicts(Reservation reservation)
        {
            if (reservation.RoomID! == RoomID!) return true;
            return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
        }
    }
}
