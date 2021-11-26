using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutoria_S6_app.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tutoria_S6_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnAgregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var Registros = new Estudiante { Nombre = txtNombre.Text, Usuario = txtusuario.Text, Contrasenia = txtContrasenia.Text };
                con.InsertAsync(Registros);
                DisplayAlert("Alerta", "Usuario registrado exitosamente...", "OK");
                txtNombre.Text = "";
                txtusuario.Text = "";
                txtContrasenia.Text = "";
                Navigation.PushAsync(new Login());
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", "Error:" + ex.Message, "OK");
            }

        }
    }
}