using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{
   
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ItemAsistencia
    {
        public int id_alumno { get; set; }
        public string nombre_completo { get; set; }
    }

    public class LinkAsistencia
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class GetAsistenciaResponse
    {
        public List<ItemAsistencia> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }

}
