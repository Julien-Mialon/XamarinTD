using System.Collections.ObjectModel;
using System.Diagnostics;
using Storm.Mvvm.Services;
using TodoListFull.Models;

namespace TodoListFull.Services
{
	public class TodoService : ITodoService
	{
		private readonly ObservableCollection<TodoItem> _items = new ObservableCollection<TodoItem>();

		public ObservableCollection<TodoItem> Items
		{
			get { return _items; }
		}

		public void Add(TodoItem item)
		{
			_items.Add(item);
		}

		public void Delete(TodoItem item)
		{
			_items.Remove(item);
		}

		public void Delete(int index)
		{
			_items.RemoveAt(index);
		}
	}
}
