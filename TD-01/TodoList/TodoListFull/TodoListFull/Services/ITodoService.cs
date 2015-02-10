using System.Collections.ObjectModel;
using TodoListFull.Models;

namespace TodoListFull.Services
{
	public interface ITodoService
	{
		ObservableCollection<TodoItem> Items { get; }

		void Add(TodoItem item);

		void Delete(TodoItem item);

		void Delete(int index);
	}
}
