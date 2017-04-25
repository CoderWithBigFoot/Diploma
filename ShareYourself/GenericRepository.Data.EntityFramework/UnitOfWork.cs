using System;
using System.Data.Entity;

namespace GenericRepository.Data.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DbContext _context;
        private bool _disposed;

        public UnitOfWork(DbContext context)
        {
            _context = context ?? throw new Exception("DbContext is null");
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _context.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}