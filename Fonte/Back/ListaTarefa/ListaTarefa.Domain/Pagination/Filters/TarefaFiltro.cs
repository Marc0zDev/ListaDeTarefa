using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefa.Domain.Pagination.Filters
{
    public class TarefaFiltro : QueryStringParameter
    {
        public string Titulo { get; set; }
        public string Status { get; set; }
    }
}
