using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Interface;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.Ef.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Ef
{
    public  class UnitOfWork :IUnitOfWork
    {
        public  IBookRepository Books {  get; private set; }
        public  IBaseRepository<Author> Authors {  get; private set; }
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
            Authors = new BaseRepository<Author>(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
