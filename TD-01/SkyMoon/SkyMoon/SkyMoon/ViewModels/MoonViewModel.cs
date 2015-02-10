using System.Windows.Input;
using Storm.Mvvm;
using Xamarin.Forms;

namespace SkyMoon.ViewModels
{
	public class MoonViewModel : ViewModelBase
	{
		public ImageSource Image
		{
			get
			{
				var source = ImageSource.FromResource("SkyMoon.Images.lune.jpg");
				return source;
			}
		}

		public ICommand ButtonCommand
		{
			get
			{
				return new Command(() =>
				{
					NavigationService.PopAsync();
				});
			}
		}
	}
}
