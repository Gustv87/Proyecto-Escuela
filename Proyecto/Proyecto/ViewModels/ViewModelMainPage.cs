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
    public class ViewModelMainPage : INotifyPropertyChanged
    {
        public ViewModelMainPage()
        {

            LogIn = new Command(async () =>
            {
                string urlnew = $"https://apex.oracle.com/pls/apex/examendaw2/api/login/{NombreUser}/{Password}";
                ConsumoService service = new ConsumoService(urlnew);

                LogIn log = await service.Get<LogIn>();

                if (log.items.Count == 0)
                {
                    Resultado = " Ingreso Erroneo";

                }
                else
                {

                    if (log.items[0].es_valido == 1 && log.items[0].id_rol == 21)
                    {
                        if (log.items[0].es_valido == 1 && log.items[0].id_rol == 21)
                        {

                              var pagina = new ViewCursoClase();
                              var viewModelPagina = new ViewModelCursoClase(NombreUser);
                              pagina.BindingContext = viewModelPagina;
                              await Application.Current.MainPage.Navigation.PushAsync(pagina);

                        }
                    }
                 
                }



            });

    

        }

        string nombreUser;
        public string NombreUser
        {
            get { return nombreUser; }
            set {                 
                  nombreUser = value;
                var args = new PropertyChangedEventArgs(nameof(NombreUser));
                PropertyChanged?.Invoke(this, args);
            
            }
        }

        string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                var args = new PropertyChangedEventArgs(nameof(Password));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string resultado;
        public string Resultado
        {
            get { return resultado; }
            set
            {
                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);

            }
        }


        public Command RedirigirCrearUsuario { get;}
        public Command SeleccionCursoClase { get; set; }
        public Command LogIn { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}



//  if(log.items[0].es_valido == 1 && log.items[0].id_rol == 2)
//{
//  await Application.Current.MainPage.Navigation.PushAsync(new ViewMainAdmin());
//Resultado = " ";

//}

//  RedirigirCrearUsuario = new Command(() =>
//{
//  var pagina = new CreacionUsuarios();
//Application.Current.MainPage.Navigation.PushAsync(pagina);

//});