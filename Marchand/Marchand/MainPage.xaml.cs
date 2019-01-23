using Marchand.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Marchand
{
    public partial class MainPage : ContentPage
    {
        #region Resource
       private string MError = Resource.Resource.MessageError;
        string Ok = Resource.Resource.Okay;
        #endregion End Resource
        public MainPage()
        {
            InitializeComponent();
        }

      
        private void btnlogin_btn(object sender, EventArgs e)
        {
            try
            {
             
                Navigation.PushModalAsync(new Dashboard());
            }
            catch (Exception ex)
            {
                var Error = ex.ToString();
                DisplayAlert(MError, Error, Ok);
            }
        }
    }
}
