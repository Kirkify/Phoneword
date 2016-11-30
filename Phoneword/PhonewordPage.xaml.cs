using System;
using Xamarin.Forms;

namespace Phoneword
{
	public partial class PhonewordPage : ContentPage
	{
		private string translatedNumber;

		public PhonewordPage()
		{
			InitializeComponent();

			this.Padding = new Thickness(20,
										Device.OnPlatform<double>(40, 20, 20), 
			                             20, 20);
		}

		void OnTranslate(object sender, System.EventArgs e)
		{
			translatedNumber = PhonewordTranslator.ToNumber(EnteredNumber.Text);

			if (translatedNumber != null)
			{
				CallBtn.IsEnabled = true;
				CallBtn.Text = string.Format("Call {0}", translatedNumber);
			}
			else
			{
				DisplayAlert("Phoneword", "The number entered is unsupported, Please re-enter a number", "OK");
				CallBtn.IsEnabled = false;
				EnteredNumber.Text = string.Empty;
				CallBtn.Text = "Call";
				EnteredNumber.Focus();
			}
		}

		void MakeCall(object sender, System.EventArgs e)
		{
			Device.OpenUri(new Uri("tel:" + translatedNumber));
		}
	}
}
