﻿using Data.Data;
using Data.Repositories.Interfaces;
using Data.Repositories.Realizations;
using Data.UoW.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UoW.Realization
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _dbContext;
        private IBookRepository? _bookRepository;

        public UnitOfWork(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IBookRepository BookRepository
        {
            get
            {
                return _bookRepository = _bookRepository ??= new BookRepository(_dbContext);
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
