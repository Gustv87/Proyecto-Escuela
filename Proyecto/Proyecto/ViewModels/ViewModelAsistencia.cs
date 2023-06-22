using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Proyecto.ViewModels
{
    public class ViewModelAsistencia : INotifyPropertyChanged
    {
        
        public ViewModelAsistencia(string NombreUser)
        {
            this.nombreUser = NombreUser;
            asistenciaAlumno();
        }

        public ViewModelAsistencia()
        {

        }

        public async void asistenciaAlumno()
        {

            ConsumoService service = new ConsumoService("https://apex.oracle.com/pls/apex/examendaw2/api/asistencia/" + NombreUser);
            GetAsistenciaResponse responseCursoClase = await service.Get<GetAsistenciaResponse>();

            foreach (ItemAsistencia x in responseCursoClase.items)
            {

                GetAsistencia astc = new GetAsistencia()
                {
                    nombre_completo = x.nombre_completo,
                    id_alumno = x.id_alumno

                };

                listaAsistencia.Add(astc);

            }


        }



        string nombreUser;
        public string NombreUser
        {
            get { return nombreUser; }
            set
            {
                nombreUser = value;
                var args = new PropertyChangedEventArgs(nameof(NombreUser));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public ObservableCollection<GetAsistencia> listaAsistencia { get; set; } = new ObservableCollection<GetAsistencia>();
        public event PropertyChangedEventHandler PropertyChanged;
    }


}
