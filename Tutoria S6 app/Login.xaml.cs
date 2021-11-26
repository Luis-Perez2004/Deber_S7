using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {

            return db.Query<Estudiante>("SELECT * FROM ESTUDIANTE  WHERE Usuario = ? and Contrasenia = ?", usuario, contrasenia);
        }

        private async void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var documentPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(documentPath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, txtUsuario.Text, txtContrasenia.Text);
                if (resultado.Count() > 0)
                {
                    await Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    await DisplayAlert("Alerta", "Usuarion no existe, debe registrarse", "OK");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alerta", "Error:" + ex.Message, "OK");
            }
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}