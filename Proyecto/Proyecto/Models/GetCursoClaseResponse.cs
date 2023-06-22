using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ItemCursoClase
    {
        public int id_detalle_curso { get; set; }
        public string nombre_curso { get; set; }
        public string nombre_clase { get; set; }
    }

    public class LinkCursoClase
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class GetCursoClaseResponse
    {
        public List<ItemCursoClase> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<LinkCursoClase> links { get; set; }
    }


}
