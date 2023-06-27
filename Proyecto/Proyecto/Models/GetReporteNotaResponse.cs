using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{
    public class ItemReporteNota
    {
        public string nombre_completo { get; set; }
        public int primer_parcial { get; set; }
        public int segundo_parcial { get; set; }
        public int tercer_parcial { get; set; }
        public int cuarto_parcial { get; set; }
    }

    public class LinkReporteNotas
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class GetReporteNotaResponse
    {
        public List<ItemReporteNota> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }
}
