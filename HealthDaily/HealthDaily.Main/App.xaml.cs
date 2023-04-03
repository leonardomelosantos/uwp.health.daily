using HealthDaily.Domain.Repositories;
using HealthDaily.Domain.Repositories.Impl;
using HealthDaily.Domain.Services;
using HealthDaily.Domain.Services.Impl;
using HealthDaily.Main.Common;
using Microsoft.Practices.Unity;
using Prism.Unity.Windows;
using Prism.Windows.AppModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace HealthDaily.Main
{
    public sealed partial class App : PrismUnityApplication
    {
		protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
		{
			// TODO lcms Chamar aqui o trecho de código que garante a criação do banco de dados

			NavigationService.Navigate(PageTokens.DashboardPage, null);

			return Task.CompletedTask;
		}

		/// <summary>
		/// Sobrescrevendo a criação do AppShell, porque a intenção é customizar.
		/// </summary>
		/// <param name="rootFrame"></param>
		/// <returns></returns>
		protected override UIElement CreateShell(Frame rootFrame)
		{
			var myAppShell = new AppShell();
			myAppShell.SetFrame(rootFrame);
			return myAppShell;
		}

		protected override void ConfigureContainer()
		{
			base.ConfigureContainer();

			// Esta linha abaixo foi necessária adicionar para que funcione o "IResourceLoader" na injeção de dependência.
			// O "IResourceLoader" é utilizado para obter valores dos arquivos de Resources, em tempo de execução.
			//Container.RegisterInstance(typeof(IResourceLoader), new ResourceLoaderAdapter(new ResourceLoader()), new ContainerControlledLifetimeManager());

			RegisterTypeIfMissing(typeof(IFoodService), typeof(FoodService), true);
			RegisterTypeIfMissing(typeof(IActivityService), typeof(ActivityService), true);
			RegisterTypeIfMissing(typeof(IActivitiesDayRepository), typeof(ActivitiesDayRepository), true);

			RegisterTypeIfMissing(typeof(IActivityEntryRepository), typeof(ActivityEntryRepository), true);
			RegisterTypeIfMissing(typeof(IActivityRepository), typeof(ActivityRepository), true);
			RegisterTypeIfMissing(typeof(IFoodEntryRepository), typeof(FoodEntryRepository), true);


		}
	}
}
