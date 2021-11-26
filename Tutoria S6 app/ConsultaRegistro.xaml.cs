using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Tutoria_S6_app.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tutoria_S6_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> TablaEstudiante;

        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            get();
        }

        public async void get()
        {
            try
            {
                var resultado = await con.Table<Estudiante>().ToListAsync();
                TablaEstudiante = new ObservableCollection<Estudiante>(resultado);
                ListaUsuarios.ItemsSource = TablaEstudiante;
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alerta", "Error:" + ex.Message, "OK");
            }
        }

        private void ListaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var Obj = (Estudiante)e.SelectedItem;
                var item = Obj.Id.ToString();
                int id = Convert.ToInt32(item);
                Navigation.PushAsync(new Elemento(id));
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", "Error:" + ex.Message, "OK");
            }
        }
    }
}