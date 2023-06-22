using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class PostAsistenciaRequest
        {
             public int id_asistencia { get; }
             public int id_alumno { get; set; }
             public DateTime? fecha { get; set; }
             public string asistio { get; set; }
        }
   

}
