using Marchand.Model;
using Marchand.Services;
using Plugin.ExternalMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Marchand.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cp_Mapa : ContentPage
	{
		public Cp_Mapa ()
		{
			InitializeComponent ();
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Red; //color del texto del titulo
            lvClientes.ItemsSource = ClienteService.GetClientes();

        }

        private async void LvClientes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var cliente = e.SelectedItem as Cliente_;
                if (cliente.Nombre != null && cliente.Estado != null && cliente.Zip != null)
                    await PoeEnderecodeNoMapaAsync(cliente);
                else
                    return;
            }
            catch (Exception ex)
            {
                await DisplayAlert($"Error", ex.Message, "OK");
            }
        }

        private async Task PoeEnderecodeNoMapaAsync(Cliente_ cliente)
        {
            string pais = "MX", codigoPais = "52";
            if (cliente == null)
            {
                await DisplayAlert("Error de datos", "Faltan datos obligatorios", "OK");
            }
            else
            {
                try
                {
                    //await CrossExternalMaps.Current.NavigationTo("Space Needle", 47.6204, -122.3491, NavigationType.Driving);
                    await CrossExternalMaps.Current.NavigateTo("Xamarin", "394 pacific ave.", "San Francisco", "CA", "94111", "USA", "USA");
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
	
}