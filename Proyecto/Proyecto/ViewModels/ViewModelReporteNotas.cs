using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Proyecto.ViewModels
{
    public class ViewModelReporteNotas : INotifyPropertyChanged
    {
        public ViewModelReporteNotas(string Id_detalle)
        {
            this.id_detalle = Id_detalle;
            cargarReporteNota();
        }

        public ViewModelReporteNotas()
        {

        }


        public async void cargarReporteNota()
        {

            ConsumoService service = new ConsumoService("https://apex.oracle.com/pls/apex/examendaw2/api/notalumno/" + Id_detalle);
            GetReporteNotaResponse responseCursoClase = await service.Get<GetReporteNotaResponse>();

            foreach (ItemReporteNota x in responseCursoClase.items)
            {

                GetReporteNota rptn = new GetReporteNota()
                {
                   nombre_completo = x.nombre_completo,
                   primer_parcial = x.primer_parcial,
                   segundo_parcial = x.segundo_parcial,
                   tercer_parcial = x.tercer_parcial,
                   cuarto_parcial = x.cuarto_parcial                   

                };

                listaReporteNota.Add(rptn);

            }


        }



        string id_detalle;
        public string Id_detalle
        {
            get { return id_detalle; }
            set
            {
                id_detalle = value;
                var args = new PropertyChangedEventArgs(nameof(Id_detalle));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public ObservableCollection<GetReporteNota> listaReporteNota { get; set; } = new ObservableCollection<GetReporteNota>();
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
