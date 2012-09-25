using System;
using System.Windows.Input;
using FEMobileVikings.Services;
using FEMobileVikings.Views;
using GalaSoft.MvvmLight.Command;
using MobileVikings.BackEnd.Schema.Services;
using Windows.UI.ApplicationSettings;
using Windows.ApplicationModel.Resources;

namespace FEMobileVikings.ViewModel
{
    /// <summary>
    /// View model base for when the user is signed in.
    /// </summary>
    public abstract class SignedInViewModelBase : MobileVikingsViewModelBase
    {
        private readonly IAuthorizationService _authorizationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignedInViewModelBase" /> class.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resourceLoader">The resource loader.</param>
        /// <param name="navigationService">The navigation service.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        protected SignedInViewModelBase(IAuthorizationService authorizationService, ResourceLoader resourceLoader, INavigationService navigationService)
            : base(navigationService, resourceLoader)
        {
            if (authorizationService == null)
            {
                throw new ArgumentNullException("authorizationService");
            }

            _authorizationService = authorizationService;


            SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
        }



        /// <summary>
        /// Gets the viking points.
        /// </summary>
        /// <value>
        /// The viking points.
        /// </value>
        public ICommand VikingPoints
        {
            get
            {
                return new RelayCommand(NavigateToVikingPoints);
            }
        }

        /// <summary>
        /// Gets the is viking.
        /// </summary>
        /// <value>
        /// The is viking.
        /// </value>
        public ICommand IsViking
        {
            get { return new RelayCommand(NavigateToIsViking); }
        }

        private void NavigateToVikingPoints()
        {
            NavigationService.Navigate<VikingPointsView>();
        }

        private void NavigateToIsViking()
        {
            NavigationService.Navigate<IsMobileVikingView>();
        }


        private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            AddSettingsCommand("SignOut", ResourceLoader.GetString("SignOut"),
                               command =>
                                   {
                                       _authorizationService.SignOut();
                                       NavigationService.Navigate<LoginView>();
                                   }, args);
        }

    }
}