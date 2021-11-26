using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tutoria_S6_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnMensaje_Clicked(object sender, EventArgs e)
        {
            var mensaje = "Saludo desde la clase TOAST";
            DependencyService.Get<Mensaje>().LongAlert(mensaje);
        }
    }
}
