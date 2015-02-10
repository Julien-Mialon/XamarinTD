using System.Windows.Input;
using SkyMoon.Views;
using Storm.Mvvm;
using Xamarin.Forms;

namespace SkyMoon.ViewModels
{
	public class SkyViewModel : ViewModelBase
	{
		public ImageSource Image
		{
			get
			{
				var source = ImageSource.FromResource("SkyMoon.Images.ciel.jpg");
				return source;
			}
		}

		public ICommand ButtonCommand
		{
			get
			{
				return new Command(() =>
				{
					NavigationService.PushAsync<MoonPage>();
				});
			}
		}

	}
}
