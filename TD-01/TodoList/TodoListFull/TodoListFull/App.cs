using Storm.Mvvm;
using Storm.Mvvm.Services;
using TodoListFull.Services;
using TodoListFull.Views;
using Xamarin.Forms;

namespace TodoListFull
{
	public class App : MvvmApplication<HomePage>
	{
		public App()
			: base(() =>
			{
				DependencyService.Register<ITodoService, TodoService>();
			})
		{
			DependencyService.Get<ICurrentPageService>().Pop();
			DependencyService.Get<ICurrentPageService>().Push(MainPage);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
