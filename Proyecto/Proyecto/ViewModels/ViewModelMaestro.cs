using Proyecto.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Proyecto.ViewModels
{
    public class ViewModelMaestro : INotifyPropertyChanged
    {
        public ViewModelMaestro()
        {
            Reporte_Notas = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewReporteNotas());

            });

            Asistencia = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ViewAsistencia());

            });
        }

        public Command Reporte_Notas { get; set; }
        public Command Asistencia { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
    }


}
