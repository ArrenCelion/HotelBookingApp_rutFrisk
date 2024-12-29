namespace HotelBookingApp.Services.ServiceInterfaces
{
    public interface IRoomService
    {
        void CreateNewRoom();
        void DeleteRoom();
        void ReadAllRooms();
        void RemoveRoom();
        void UpdateRoom();
    }
}