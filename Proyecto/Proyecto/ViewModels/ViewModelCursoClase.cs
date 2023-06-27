using Proyecto.Models;
using Proyecto.ViewModels;
using Proyecto.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Proyecto.ViewModels
{

   public class ViewModelCursoClase : INotifyPropertyChanged
    {
       
        public ViewModelCursoClase(string NombreUser)
        {
            this.nombreUser = NombreUser;
            cargarCursoClase();

            SelectCursoClase = new Command(async () => {

                var pagina = new ViewOpciones();
                var viewModelPagina = new ViewModelOpciones(CursoClaseSeleccionada.id_detalle_curso, nombreUser, CursoClaseSeleccionada.horario);
                pagina.BindingContext = viewModelPagina;
                await Application.Current.MainPage.Navigation.PushAsync(pagina);

            });
            
        }
        public ViewModelCursoClase()
        {

        }

        public async void cargarCursoClase()
        {
            
            ConsumoService service = new ConsumoService("https://apex.oracle.com/pls/apex/examendaw2/api/cursosclases/" + NombreUser);
            GetCursoClaseResponse responseCursoClase = await service.Get<GetCursoClaseResponse>();

            foreach (ItemCursoClase x in responseCursoClase.items)
            {

                GetCursoClase crcl = new GetCursoClase()
                {
                    id_detalle_curso = x.id_detalle_curso,
                    nombre_clase = x.nombre_clase,
                    nombre_curso = x.nombre_curso,
                    horario = x.horario,

                };

                listaCursoClase.Add(crcl);

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



        GetCursoClase cursoclaseSeleccionada;
        public GetCursoClase CursoClaseSeleccionada
        {
            get { return cursoclaseSeleccionada; }
            set
            {
                cursoclaseSeleccionada = value;
                var args = new PropertyChangedEventArgs(nameof(CursoClaseSeleccionada));
                PropertyChanged?.Invoke(this, args);

            }
        }


        public ObservableCollection<GetCursoClase> listaCursoClase { get; set; } = new ObservableCollection<GetCursoClase>();
        public Command SelectCursoClase { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

    }
}