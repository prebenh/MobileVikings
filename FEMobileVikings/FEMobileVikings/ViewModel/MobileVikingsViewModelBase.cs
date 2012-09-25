using System;
using System.Linq;
using System.Net;
using FEMobileVikings.Services;
using FEMobileVikings.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Windows.ApplicationModel.Resources;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;

namespace FEMobileVikings.ViewModel
{
    /// <summary>
    /// View model base for the mobile viking application
    /// </summary>
    public abstract class MobileVikingsViewModelBase : ViewModelBase
    {
        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        /// <value>
        /// The navigation service.
        /// </value>
        protected INavigationService NavigationService { get; private set; }

        /// <summary>
        /// Gets the resource loader.
        /// </summary>
        /// <value>
        /// The resource loader.
        /// </value>
        protected ResourceLoader ResourceLoader { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileVikingsViewModelBase" /> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="resourceLoader">The resource loader.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        protected MobileVikingsViewModelBase(INavigationService navigationService, ResourceLoader resourceLoader)
        {
            if (navigationService == null)
            {
                throw new ArgumentNullException("navigationService");
            }
            if(resourceLoader == null)
            {
                throw new ArgumentNullException("resourceLoader");
            }

            NavigationService = navigationService;
            ResourceLoader = resourceLoader;

            SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
        }

        private bool _isLoading;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is loading.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is loading; otherwise, <c>false</c>.
        /// </value>
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }


        /// <summary>
        /// Adds the settings command.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="label">The label.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="args">The <see cref="SettingsPaneCommandsRequestedEventArgs" /> instance containing the event data.</param>
        protected void AddSettingsCommand(string id, string label, UICommandInvokedHandler handler, SettingsPaneCommandsRequestedEventArgs args)
        {
            if (!args.Request.ApplicationCommands.Any(x => x.Id is string && (string) x.Id == id))
            {
                var command = new SettingsCommand(id,label,
                   handler);

                args.Request.ApplicationCommands.Add(command);
            }
        }

        /// <summary>
        /// Handler when there is no internet available.
        /// </summary>
        protected virtual void HandleNoInternet()
        {
            Messenger.Default.Register<WebException>(this, async (x) =>
            {
                try
                {
                    var dialog = new MessageDialog(ResourceLoader.GetString("NoInternet"));
                    await dialog.ShowAsync();
                }
                catch (Exception)
                {
                    //TODO: Fix this
                }

            });
        }

        private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            AddSettingsCommand("PrivacyPolicy", ResourceLoader.GetString("PrivacyPolicyTitle"), 
                command => NavigationService.Navigate<PrivacyPolicyView>(), args);
        }

    }
}
