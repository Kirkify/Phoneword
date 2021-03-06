﻿using System;
using Xamarin.Forms;

namespace Phoneword
{
	public partial class PhonewordPage : ContentPage
	{
		private string translatedNumber;

		public PhonewordPage()
		{
			InitializeComponent();
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

		async void OnCall(object sender, System.EventArgs e)
		{
			if (await this.DisplayAlert(
				"Dial a Number",
				"Would you like to call " + translatedNumber + "?",
				"Yes",
				"No"))
			{
				var dialer = DependencyService.Get<IDialer>();
				if (dialer != null)
				{
					await dialer.DialAsync(translatedNumber);
				}
			}
		}
	}
}
