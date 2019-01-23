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
	public partial class Cp_Lista : ContentPage
	{
		public Cp_Lista ()
		{
			InitializeComponent ();
          //  ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.Red; //color del texto del titulo
        }
    }
	
}