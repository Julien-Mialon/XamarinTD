using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storm.Mvvm;
using Xamarin.Forms;

namespace Seasons
{
	public class SeasonViewModel : ViewModelBase
	{
		private ImageSource _seasonImage;
		private string _seasonName;
		private DateTime _selectedDate;

		public DateTime StartYearDate
		{
			get { return new DateTime(2015, 1, 1); }
		}

		public DateTime EndYearDate
		{
			get { return new DateTime(2015, 12, 31); }
		}

		// Bindé sur la date du DatePicker
		public DateTime SelectedDate
		{
			get { return _selectedDate; }
			set
			{
				// Si la date a été changé, SetProperty renvoie true et donc on déclenche la fonction OnDateChanged
				if (SetProperty<DateTime>(ref _selectedDate, value))
				{
					OnDateChanged();
				}
			}
		}

		// Bindé sur le label de la saison
		public string SeasonName
		{
			get { return _seasonName; }
			set { SetProperty<string>(ref _seasonName, value); }
		}

		// Bindé sur l'image de la saison
		public ImageSource SeasonImage
		{
			get { return _seasonImage; }
			set { SetProperty<ImageSource>(ref _seasonImage, value); }
		}

		public SeasonViewModel()
		{
			// initialiser la date du DatePicker à aujourd'hui
			SelectedDate = DateTime.Now;
		}

		private void OnDateChanged()
		{
			// On définit les dates de passage de chaque saisons
			DateTime spring = new DateTime(2015, 3, 20);
			DateTime summer = new DateTime(2015, 6, 21);
			DateTime automn = new DateTime(2015, 9, 22);
			DateTime winter = new DateTime(2015, 12, 22);

			string season = "";
			if (SelectedDate < spring)
			{
				season = "winter";
			}
			else if (SelectedDate < summer)
			{
				season = "spring";
			}
			else if (SelectedDate < automn)
			{
				season = "summer";
			}
			else if (SelectedDate < winter)
			{
				season = "autumn";
			}
			else
			{
				season = "winter";
			}

			// On construit le chemin de l'image à partir du nom de la saison
			string image = season + ".jpg";

			SeasonName = season;
			// On charge notre images depuis les resources de notre projet
			SeasonImage = ImageSource.FromResource("Seasons.Images." + image);
		}
	}
}
