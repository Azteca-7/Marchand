using Marchand.View;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Marchand
{
    public partial class MainPage : ContentPage
    {
        #region Resource
        private string MError = Resource.Resource.MessageError;
        private string IError = Resource.Resource.ErrorInternet;
        private string Ok = Resource.Resource.Okay;
        private string Evalidation = Resource.Resource.ErrorValidation;
        private string REmail = Resource.Resource.RequiredEmail;
        private string Rpass = Resource.Resource.RequiredPass;
        #endregion End Resource
        public MainPage()
        {
            InitializeComponent();
        }

      
        private async void btnlogin_btn(object sender, EventArgs e)
        {
            try
            {
                //Check network status   
                if (!CrossConnectivity.Current.IsConnected)

                    await DisplayAlert(MError, IError, Ok);
                else

                {
                    if (String.IsNullOrWhiteSpace(Email_Entry.Text))
                    {
                    await DisplayAlert(Evalidation, REmail, Ok);

                    }

                    else
                    {
                        //Valida que el formato del correo sea valido
                        bool isEmail = Regex.IsMatch(Email_Entry.Text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                        if (!isEmail)
                        {
                        await DisplayAlert(Evalidation, "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");

                        }

                        if (String.IsNullOrWhiteSpace(Password_Entry.Text))
                        {
                         await DisplayAlert(Evalidation, Rpass, Ok);
                        }

                        else
                        {

                         await  Navigation.PushModalAsync(new Dashboard());
                        // await Navigation.PushAsync(new Dashboard());
                        }
                    }
                }
                


            }
            catch (Exception ex)
            {
                var Error = ex.ToString();
             await DisplayAlert(MError, Error, Ok);
            }
        }
    }
}
