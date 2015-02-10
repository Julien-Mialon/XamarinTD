using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Patterns;
using TodoListFull.Models;
using TodoListFull.Services;
using TodoListFull.Views;
using Xamarin.Forms;

namespace TodoListFull.ViewModels
{
	public class HomeViewModel : ViewModelBase
	{
		private TodoItem _selectedItem;

		public TodoItem SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				if (SetProperty<TodoItem>(ref _selectedItem, value))
				{
					if (value != null)
					{
						OnItemSelected(value);
					}
				}
			}
		}

		public ICommand AddCommand
		{
			get { return new Command(AddAction); }
		}

		public ObservableCollection<TodoItem> Items
		{
			get { return LazySingletonInitializer<ITodoService>.Value.Items; }
		}

		public HomeViewModel()
		{
			foreach (string s in new[] { "alpha", "beta", "delta" })
			{
				Items.Add(new TodoItem() { Description = s, Title = s });
			}
		}

		private void AddAction()
		{
			NavigationService.PushAsync<AddPage>();
		}

		private void OnItemSelected(TodoItem item)
		{
			Task.Run(() =>
			{
				Device.BeginInvokeOnMainThread(() =>
				{
					SelectedItem = null;

					Task.Run(() =>
					{
						Device.BeginInvokeOnMainThread(() =>
						{
							NavigationService.PushAsync<DetailsPage>(new Dictionary<string, object>()
							{
								{"Item", item}
							});
						});
					});
				});
			});
		}
	}
}
