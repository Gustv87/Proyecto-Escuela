using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Models
{

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class PostAsistenciaRequest
        {
             public int id_asistencia { get; }
             public int ID_ALU { get; set; }
             public string FECH { get; set; }
             public string VINO { get; set; }
        }
   

}
