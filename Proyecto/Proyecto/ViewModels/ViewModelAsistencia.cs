using Proyecto.Models;
using Proyecto.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Proyecto.ViewModels
{
    public class ViewModelAsistencia : INotifyPropertyChanged
    {
        
        public ViewModelAsistencia(string NombreUser, string horario)
        {
            this.nombreUser = NombreUser;
            this.horario = horario;
            asistenciaAlumno();

            Alumno_Asistio = new Command(async () => {
                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("yyyy-MM-dd");

                ConsumoService service = new ConsumoService("https://apex.oracle.com/pls/apex/examendaw2/api/asistencia");
                PostAsistenciaRequest request = new PostAsistenciaRequest()
                {
                    ID_ALU = AlumnoSeleccionada.id_alumno,
                    FECH = formattedDate,
                    VINO = "Y"
                };
                ResponseAsistencia response = await service.PostAsync<ResponseAsistencia>(request);
                if (response != null)
                {
                    Application.Current.MainPage.DisplayAlert("Mensaje", response.MENSAJE, "ok");

                }
            });
            Alumno_NoAsistio = new Command(async () => {
                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("yyyy-MM-dd");

                ConsumoService service = new ConsumoService("https://apex.oracle.com/pls/apex/examendaw2/api/asistencia");
                PostAsistenciaRequest request = new PostAsistenciaRequest()
                {
                    ID_ALU = AlumnoSeleccionada.id_alumno,
                    FECH = formattedDate,
                    VINO = "N"
                };
                ResponseAsistencia response = await service.PostAsync<ResponseAsistencia>(request);
                if (response != null)
                {
                    Application.Current.MainPage.DisplayAlert("Mensaje", response.MENSAJE, "ok");

                }
            });
        }

        public ViewModelAsistencia()
        {

        }

        public async void asistenciaAlumno()
        {

            ConsumoService service = new ConsumoService("https://apex.oracle.com/pls/apex/examendaw2/api/asistencia/" + NombreUser);
            GetAsistenciaResponse responseCursoClase = await service.Get<GetAsistenciaResponse>();
            if (horario == "07:00")
            {
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
            else
            {
                Application.Current.MainPage.DisplayAlert("Mensaje", "Lo siento, asistencia ya tomada", "ok");
                Application.Current.MainPage.Navigation.PopAsync();
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

        string horario;
        public string Horario
        {
            get { return horario; }
            set
            {
                horario = value;
                var args = new PropertyChangedEventArgs(nameof(Horario));
                PropertyChanged?.Invoke(this, args);

            }
        }

        GetAsistencia alumnoSeleccionada;
        public GetAsistencia AlumnoSeleccionada
        {
            get { return alumnoSeleccionada; }
            set
            {
                alumnoSeleccionada = value;
                var args = new PropertyChangedEventArgs(nameof(AlumnoSeleccionada));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command Alumno_Asistio { get; set; }
        public Command Alumno_NoAsistio { get; set; }
        public ObservableCollection<GetAsistencia> listaAsistencia { get; set; } = new ObservableCollection<GetAsistencia>();
        public event PropertyChangedEventHandler PropertyChanged;
    }


}
