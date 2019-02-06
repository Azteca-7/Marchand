using Marchand.Services;
using Marchand.Services.Configuration;
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
        private string Ruser = Resource.Resource.RequiredUser;
        #endregion End Resource
        public MainPage()
        {
            InitializeComponent();
        }


        private  void btnlogin_btn(object sender, EventArgs e)
        {
            try
            {
                //Check network status   
                if (!CrossConnectivity.Current.IsConnected)

                     DisplayAlert(MError, IError, Ok);
                else

                {
                    if (String.IsNullOrWhiteSpace(User_Entry.Text))
                    {
                         DisplayAlert(Evalidation, Ruser, Ok);

                    }

                    else
                    {
                        //Valida que el formato de usuario
                        if (String.IsNullOrWhiteSpace(Password_Entry.Text))
                        {
                             this.DisplayAlert(MError, Rpass, Ok);
                            //return false;
                        }
                       

                        else
                        {
                            //optenemos los valores del login
                            string user_ = User_Entry.Text;
                            string pass_ = Password_Entry.Text;

                           // var token = new ServiceActions().DoLogin("user4", "password", false);
                            var token = new ServiceActions().DoLogin(user_, pass_, false);
                           // DisplayAlert("Access Token", token.Access_token, "Ok");

                            if (!string.IsNullOrEmpty(token.Access_token))
                            {
                                var jornada = new ServiceActions().GetJornada(token.Access_token);
                                Navigation.PushModalAsync(new Dashboard());

                            }
                            else
                            {
                                DisplayAlert("Usuario Incorrecto", "Intente de nuevo", Ok);
                            }


                            //ConfigurationManager CM = new ConfigurationManager();
                            //var accesoOk = CM.LoginMainpage(email_,pass_);

                            // Navigation.PushModalAsync(new Dashboard());
                            //// await Navigation.PushAsync(new Dashboard());
                        }
                        
                    }
                }



            }
            catch (Exception ex)
            {
                var Error = ex.ToString();
                 DisplayAlert(MError, Error, Ok);
            }
        }
    }
}
