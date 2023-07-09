using MontyHall.DataAccess.Interface;
using MontyHall.DataAccess.Models;
using MontyHall.DataAccess.Repository;
using System;

namespace MontyHall.DataAccess
{
    public class DataAdapter : IDisposable
    {
        private bool disposedValue;

        private Context _context = new Context();

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private IGenericRepository<GameData> gameDataGenericRepository;

        public IGenericRepository<GameData> GameDataGenericRepository
        {
            get
            {
                if (this.gameDataGenericRepository == null)
                    this.gameDataGenericRepository = new GenericRepository<GameData>(_context);
                return gameDataGenericRepository;
            }
        }
    }
}