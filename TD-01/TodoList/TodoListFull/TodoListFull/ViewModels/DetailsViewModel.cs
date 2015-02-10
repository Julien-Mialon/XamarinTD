using System.Collections.Generic;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Navigation;
using Storm.Mvvm.Services;
using TodoListFull.Models;
using TodoListFull.Services;
using TodoListFull.Views;
using Xamarin.Forms;

namespace TodoListFull.ViewModels
{
	public class DetailsViewModel : ViewModelBase
	{
		private TodoItem _item;

		[NavigationParameter]
		public TodoItem Item
		{
			get { return _item; }
			set
			{
				SetProperty<TodoItem>(ref _item, value);
			}
		}

		public ICommand EditCommand
		{
			get { return new Command(EditAction); }
		}

		public ICommand DeleteCommand
		{
			get { return new Command(DeleteAction); }
		}

		private async void DeleteAction()
		{
			bool result = await DependencyService.Get<IDialogService>()
				.DisplayAlertAsync("Confirm delete ?", "Are you sure you want to delete " + Item.Title + " ? ", "Yes", "No");
			if (result)
			{
				DependencyService.Get<ITodoService>().Delete(Item);
				#pragma warning disable 4014
				NavigationService.PopAsync();
				#pragma warning restore 4014
			}
		}

		private void EditAction()
		{
			NavigationService.PushAsync<AddPage>(new Dictionary<string, object>()
			{
				{"Item", Item}
			}, NavigationMode.Modal);
		}
	}
}
