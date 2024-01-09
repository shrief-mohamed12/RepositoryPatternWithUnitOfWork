using RepositoryPatternWithUOW.Core.Interface;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core
{
    public  interface IUnitOfWork :IDisposable
    {
        IBookRepository Books { get; }
        IBaseRepository <Author> Authors { get; }
        int Complete();
    }
}
