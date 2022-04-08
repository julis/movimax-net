using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimaxNet.Repositories
{
    public interface IRepositoryService
    {
        IFilmRepository FilmRepository { get; }
        Task SaveChangesAsync();
        void Dispose();
    }
}
