using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private EventManagerDBContext context = new EventManagerDBContext();
        private GenericRepository<Event> eventRepository;
        private GenericRepository<Team> teamRepository;
        private GenericRepository<Player> playerRepository;

        public GenericRepository<Event> EventRepository
        {
            get
            {

                if (this.eventRepository == null)
                {
                    this.eventRepository = new GenericRepository<Event>(context);
                }
                return eventRepository;
            }
        }
        public GenericRepository<Team> TeamRepository
        {
            get
            {

                if (this.teamRepository == null)
                {
                    this.teamRepository = new GenericRepository<Team>(context);
                }
                return teamRepository;
            }
        }
        public GenericRepository<Player> PlayerRepository
        {
            get
            {

                if (this.playerRepository == null)
                {
                    this.playerRepository = new GenericRepository<Player>(context);
                }
                return playerRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
