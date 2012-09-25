using System;
using FEMobileVikings.Services;
using FEMobileVikings.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using MobileVikings.BackEnd.Implementation.Repositories;
using MobileVikings.BackEnd.Implementation.Services;
using MobileVikings.BackEnd.Schema.Repositories;
using MobileVikings.BackEnd.Schema.Services;
using Windows.ApplicationModel.Resources;

namespace FEMobileVikings
{
    /// <summary>
    /// Setup the IoC container
    /// Registers all instances.
    /// </summary>
    public class Bootstrapper
    {
        public void RegisterAll()
        {

            Register<ResourceLoader>(() => new ResourceLoader());
           
            Register<IAuthorizationService, AuthorizationService>();
            Register<IMobileNumbers, MobileNumbers>();
            Register<IPricePlans, PricePlans>();
            Register<ISimBalance, SimBalance>();
            Register<IVikingPoints, VikingPoints>();
            Register<ITopUpHistory, TopUpHistory>();
            Register<IUsageHistory, UsageHistory>();
            Register<ITweets, Tweets>();
            Register<IRss,Rss>();


            Register<ITileService>(() => new TileService());

            //View models
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MobileNumbersViewModel>();
            SimpleIoc.Default.Register<TwitterViewModel>();
            SimpleIoc.Default.Register<BlogViewModel>();
            SimpleIoc.Default.Register<SimBalanceViewModel>();
            SimpleIoc.Default.Register<VikingPointsViewModel>();
            SimpleIoc.Default.Register<IsMobileVikingViewModel>();


            Register<MainViewModel>(
                            () => new MainViewModel(
                                SimpleIoc.Default.GetInstance<MobileNumbersViewModel>(),
                                SimpleIoc.Default.GetInstance<TwitterViewModel>(),
                                SimpleIoc.Default.GetInstance<BlogViewModel>(),
                                SimpleIoc.Default.GetInstance<IAuthorizationService>(),
                                SimpleIoc.Default.GetInstance<INavigationService>(),
                                SimpleIoc.Default.GetInstance<ResourceLoader>()));
       
        }

        private void Register<TInterface, TClass>()
            where TInterface : class
            where TClass : class
        {
            if (!SimpleIoc.Default.IsRegistered<TInterface>())
            {
                SimpleIoc.Default.Register<TInterface, TClass>();
            }
        }

        private void Register<TClass>(Func<TClass> factory) where TClass : class
        {
            if (!SimpleIoc.Default.IsRegistered<TClass>())
            {
                SimpleIoc.Default.Register<TClass>(factory);
            }
        }
    }
}
