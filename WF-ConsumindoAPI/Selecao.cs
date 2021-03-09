using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ConsumindoAPI
{
    public class Selecao
    {
        public int Id { get; set; }
        public string NomeSelecao { get; set; }
        public string Continente { get; set; }
        public int NumeroParticipacoes { get; set; }
        public string MelhorResultado { get; set; }
    }
}
