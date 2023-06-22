using Proyecto.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Proyecto.ViewModels
{
    public class ViewModelOpciones : INotifyPropertyChanged
    {
        public ViewModelOpciones(string Id_detalle)
        {
            Reporte_Notas = new Command(async () =>
            {
                var pagina = new ViewReporteNotas();
                var viewModelPagina = new ViewModelReporteNotas(Id_detalle);
                pagina.BindingContext = viewModelPagina;
                await Application.Current.MainPage.Navigation.PushAsync(pagina);

            });

            Asistencia = new Command(async () =>
            {
                var pagina = new ViewAsistencia();
                var viewModelPagina = new ViewModelAsistencia(Id_detalle);
                pagina.BindingContext = viewModelPagina;
                await Application.Current.MainPage.Navigation.PushAsync(pagina);

            });
        }

        public ViewModelOpciones()
        {

        }

        public Command Reporte_Notas { get; set; }
        public Command Asistencia { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
