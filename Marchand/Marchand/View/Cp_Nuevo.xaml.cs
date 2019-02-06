using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private async void ButtonNex_Clicked(object sender, EventArgs e)
        {
            try
            {
                //Nombre
                if (String.IsNullOrWhiteSpace(NombreEntry.Text))
                {
                    await this.DisplayAlert("Error en validación", "El nombre es obligatorio.", "OK");
                    //return false;
                }
                //Valida que solo se ingresen letras
                else
                if (!NombreEntry.Text.ToCharArray().All(Char.IsLetter))
                {
                    await this.DisplayAlert("Error en validación", "No se acepta números.", "OK");
                   // return false;
                }

                else
                {
                    //Valida si se ingresan caracteres especiales
                    string caractEspecial = @"^[^ ][a-zA-Z ]+[^ ]$";
                    bool resultado = Regex.IsMatch(NombreEntry.Text, caractEspecial, RegexOptions.IgnoreCase);
                    if (!resultado)
                    {
                        await this.DisplayAlert("Error en validación", "No se aceptan caracteres especiales.", "OK");
                       // return false;
                    }
                }

                // Validacion Tipo
                if (String.IsNullOrWhiteSpace(TipoEntry.Text))
                {
                    await this.DisplayAlert("Error en validación", "El campo del Tipo es obligatorio.", "OK");
                   // return false;
                }
                //Valida que solo se ingresen letras
                else 
                if (!TipoEntry.Text.ToCharArray().All(Char.IsLetter))
                {
                    await this.DisplayAlert("Error en validación", "Tu información contiene números.", "OK");
                  //  return false;
                }
                else
                {
                    //Valida si se ingresan caracteres especiales
                    string caractEspecial = @"^[^ ][a-zA-Z ]+[^ ]$";
                    bool resultado = Regex.IsMatch(TipoEntry.Text, caractEspecial, RegexOptions.IgnoreCase);
                    if (!resultado)
                    {
                        await this.DisplayAlert("Error en validación", "No se aceptan caracteres especiales.", "OK");
                       // return false;
                    }
                }

                //Direccion
                if (String.IsNullOrWhiteSpace(DereEntry.Text))
                {
                    await this.DisplayAlert("Error en validación", "El campo de dirección es obligatorio.", "OK");
                   // return false;
                }
                else
                {
                    string caractEspecial = @"^[^ ][a-zA-Z ]+[^ ]$";
                    bool resultado = Regex.IsMatch(DereEntry.Text, caractEspecial, RegexOptions.IgnoreCase);
                    if (!resultado)
                    {
                        await this.DisplayAlert("Error en validación", "No se aceptan caracteres especiales.", "OK");
                        // return false;
                    }
                }

                //Contacto
                if (String.IsNullOrWhiteSpace(contacEntry.Text))
                {
                    await this.DisplayAlert("Error en validación", "El campo Contato es obligatorio.", "OK");
                  //  return false;
                }
               
               

                //Telefono
                if (String.IsNullOrWhiteSpace(teleEntry.Text))
                {
                    await this.DisplayAlert("Error en validación", "El campo Telefono es obligatorio.", "OK");
                    //  return false;
                }
                //Valida si la cantidad de digitos ingresados es menor a 10
                else if (teleEntry.Text.Length != 12)
                {
                    await this.DisplayAlert("Error en validación", "Faltan digitos, favor de ingresar su numero.", "OK");
                    //  return false;
                }
                else
                {
                    //Valida que solo se ingresen numeros
                    if (!teleEntry.Text.ToCharArray().All(Char.IsDigit))
                    {
                        await this.DisplayAlert("Error en validación", "Solo se aceptan numeros.", "OK");
                        //  return false;
                    }
                }

                // return true;


                await Navigation.PushModalAsync(new Cp_Encuesta(),true);
            }
            catch (Exception er)
            {
                var error = er.ToString();
              await  DisplayAlert("Error",error,"Ok");

            }
        }
    }
}