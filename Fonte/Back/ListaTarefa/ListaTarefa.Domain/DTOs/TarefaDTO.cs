using ListaTarefa.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefa.Domain.DTOs
{
    public class TarefaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusTarefa Status { get; set; }
    }

}
