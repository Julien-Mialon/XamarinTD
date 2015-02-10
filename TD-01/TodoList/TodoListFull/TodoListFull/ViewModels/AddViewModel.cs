using System.Collections.Generic;
using System.Windows.Input;
using Storm.Mvvm;
using Storm.Mvvm.Navigation;
using TodoListFull.Models;
using TodoListFull.Services;
using Xamarin.Forms;

namespace TodoListFull.ViewModels
{
	public class AddViewModel : ViewModelBase
	{
		private bool _isAddingItem;
		private bool _isEditingItem;
		private string _title;
		private string _description;
		private TodoItem _item;

		[NavigationParameter]
		public TodoItem Item
		{
			get { return _item; }
			set { SetProperty<TodoItem>(ref _item, value); }
		}

		public string Description
		{
			get { return _description; }
			set { SetProperty<string>(ref _description, value); }
		}
		
		public string Title
		{
			get { return _title; }
			set { SetProperty<string>(ref _title, value); }
		}
		
		public bool IsEditingItem
		{
			get { return _isEditingItem; }
			set { SetProperty<bool>(ref _isEditingItem, value); }
		}
		
		public bool IsAddingItem
		{
			get { return _isAddingItem; }
			set { SetProperty<bool>(ref _isAddingItem, value); }
		}

		public ICommand SaveCommand
		{
			get
			{
				return new Command(SaveAction);
			}
		}

		public override void Initialize(Dictionary<string, object> navigationParameters)
		{
			base.Initialize(navigationParameters);

			IsEditingItem = Item != null;
			IsAddingItem = !IsEditingItem;

			if (Item != null)
			{
				Title = Item.Title;
				Description = Item.Description;
			}
		}

		private void SaveAction()
		{
			if (IsEditingItem)
			{
				Item.Title = Title;
				Item.Description = Description;
			}
			else
			{
				Item = new TodoItem()
				{
					Title = this.Title,
					Description = this.Description,
				};

				DependencyService.Get<ITodoService>().Add(Item);
			}
			NavigationService.PopAsync();
		}
	}
}
