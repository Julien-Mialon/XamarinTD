using Storm.Mvvm;

namespace TodoListFull.Models
{
	public class TodoItem : NotifierBase
	{
		private string _title;
		private string _description;

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
	}
}
