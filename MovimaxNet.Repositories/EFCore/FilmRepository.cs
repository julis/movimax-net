using Microsoft.EntityFrameworkCore;
using MovimaxNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimaxNet.Repositories.EFCore
{
    internal class FilmRepository : RepositoryBase<Film>, IFilmRepository
    {
        public FilmRepository(DatabaseContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Film>> GetAll()
        {
            try
            {
                return await context.Films.Include(f => f.FilmGenres).ToListAsync();                
            }
            catch (Exception ex)
            {
                return new List<Film>();
            }
        }
    }
}
