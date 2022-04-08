using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovimaxNet.Models
{
    public class FilmGenre
    {
        public int Id { get; set; }

        public int FilmId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Film? Film { get; set; }

        public int GenreId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Genre? Genre { get; set; }        
    }
}
