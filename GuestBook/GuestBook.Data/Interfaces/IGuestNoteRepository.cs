
using System.Collections.Generic;

namespace GuestBook.Data.Interfaces
{
    public interface IGuestNoteRepository
    {
        Model.GuestNote Insert(Model.GuestNote guestNote);
        Model.GuestNote Update(Model.GuestNote guestNote);
        void Delete(int id);
        List<Model.GuestNote> List();
        Model.GuestNote Get(int id);
    }
}
