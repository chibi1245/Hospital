using Hospital.Utilites;
using Hospital.ViewModel;

namespace Hospital.Services
{
    public interface IRoomService
    {
        PageResult<RoomViewModel> GetAll(int pageNumber, int pageSize);
        RoomViewModel GetRoomById(int RoomId);
        void UpdateRoom(RoomViewModel Room);
        void InsertRoom(RoomViewModel Room);
        void DeleteRoom(int id);
    }
}
