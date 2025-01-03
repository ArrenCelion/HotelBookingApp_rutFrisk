USE RutsHotel;

SELECT * FROM Guests
ORDER BY Guests.LastName;

SELECT * FROM Rooms
WHERE (RoomSize > 15)