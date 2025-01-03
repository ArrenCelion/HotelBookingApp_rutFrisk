using HotelBookingApp.Controllers;
using HotelBookingApp.Models;
using Spectre.Console;

namespace HotelBookingApp.Utilities
{
    public class DisplayEntities
    {
        public static void ShowGuestTable(List<Guest> guests)
        {
            var guestTable = new Table();
            guestTable.AddColumn("First Name");
            guestTable.AddColumn("Last Name");
            guestTable.AddColumn("Email");
            guestTable.AddColumn("Phone Number");
            guestTable.AddColumn("Date of Birth (yyyy/MM/dd)");

            foreach (Guest guest in guests)
            {
                guestTable.AddRow(
                    guest.FirstName,
                    guest.LastName,
                    guest.Email,
                    guest.PhoneNumber,
                    guest.DateOfBirth.ToShortDateString()
                    );
            }

            AnsiConsole.Write(guestTable);
        }

        public static void ShowRoomTable(List<Room> rooms)
        {
            var roomTable = new Table();
            roomTable.AddColumn("Room Number");
            roomTable.AddColumn("Room Size");
            roomTable.AddColumn("Room type");

            foreach (Room room in rooms)
            {
                string singleRoom = "Single";
                string doubleRoom = "Double";

                if (room.IsSingle)
                {
                    roomTable.AddRow(
                        room.RoomNumber.ToString(),
                        room.RoomSize.ToString(),
                        singleRoom
                        );
                }
                else
                {
                    roomTable.AddRow(
                        room.RoomNumber.ToString(),
                        room.RoomSize.ToString(),
                        doubleRoom
                        );
                }
            }

            AnsiConsole.Write(roomTable);
        }

        public static void ShowReservationTable(List<Reservation> reservations)
        {
            var reservationsTable = new Table();
            reservationsTable.AddColumn("Reservation Number");
            reservationsTable.AddColumn("Guest");
            reservationsTable.AddColumn("Room");
            reservationsTable.AddColumn("Arrival Date");
            reservationsTable.AddColumn("Length of stay (nights)");
            reservationsTable.AddColumn("Wants extra bed");

            foreach (Reservation reservation in reservations)
            {
                reservationsTable.AddRow(
                    reservation.ReservationId.ToString(),
                    reservation.Guest.FirstName + " " + reservation.Guest.LastName,
                    reservation.Room.RoomNumber.ToString(),
                    reservation.ArrivalDate.ToShortDateString(),
                    reservation.LengthOfStay.ToString(),
                    reservation.WantsExtraBed ? "Yes" : "No"
                );
            }

            AnsiConsole.Write(reservationsTable);
        }
    }
}