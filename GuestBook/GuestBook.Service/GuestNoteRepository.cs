using System.Collections.Generic;
using System.Linq;
using GuestBook.Data.Model;

namespace GuestBook.Service
{
    public class GuestNoteRepository : Data.Interfaces.IGuestNoteRepository
    {
        private readonly Data.Context.DataContext _dataContext;
        public GuestNoteRepository(Data.Context.DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Delete(int id)
        {
            Data.Model.GuestNote guestNote = Get(id);
            _dataContext.GuestNotes.Remove(guestNote);
            _dataContext.SaveChanges();
        }

        public GuestNote Get(int id)
        {
            return _dataContext.GuestNotes.Find(id);
        }

        public GuestNote Insert(GuestNote guestNote)
        {
            _dataContext.GuestNotes.Add(guestNote);
            _dataContext.SaveChanges();

            return guestNote;
        }

        public List<GuestNote> List()
        {
            return _dataContext.GuestNotes.ToList();
        }

        public GuestNote Update(GuestNote guestNote)
        {
            _dataContext.GuestNotes.Update(guestNote);
            _dataContext.SaveChanges();

            return guestNote;
        }
    }
}
