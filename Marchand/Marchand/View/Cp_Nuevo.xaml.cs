using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marchand.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Cp_Nuevo : ContentPage
	{
		public Cp_Nuevo ()
		{
			InitializeComponent ();

            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Red; //color del texto del titulo
         
        }
        private NavigationPage MainPage;
        private void ButtonNex_Clicked(object sender, EventArgs e)
        {
            try
            {

                Navigation.PushModalAsync(new Cp_Encuesta(),true);
            }
            catch (Exception er)
            {
                var error = er.ToString();
                DisplayAlert("Error",error,"Ok");

            }
        }
    }
}