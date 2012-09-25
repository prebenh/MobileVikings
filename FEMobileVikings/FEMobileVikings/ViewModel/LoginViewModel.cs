using System;
using System.Windows.Input;
using FEMobileVikings.Services;
using FEMobileVikings.Views;
using GalaSoft.MvvmLight.Command;
using MobileVikings.BackEnd.Schema.Services;
using Windows.ApplicationModel.Resources;
using Windows.System;
using Windows.UI.ApplicationSettings;

namespace FEMobileVikings.ViewModel
{
    /// <summary>
    /// View model for the login view
    /// </summary>
    public class LoginViewModel : MobileVikingsViewModelBase
    {
        private readonly IAuthorizationService _authorizationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel" /> class.
        /// </summary>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="resourceLoader">The resource loader.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public LoginViewModel(IAuthorizationService authorizationService, INavigationService navigationService, ResourceLoader resourceLoader)
            : base(navigationService, resourceLoader)
        {
            if (authorizationService == null)
            {
                throw new ArgumentNullException("authorizationService");
            }
            if (resourceLoader == null)
            {
                throw new ArgumentNullException("resourceLoader");
            }

            _authorizationService = authorizationService;
            HandleNoInternet();

            SettingsPane.GetForCurrentView().CommandsRequested += OnCommandsRequested;
        }

        private void OnCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            AddSettingsCommand("GetAccount", ResourceLoader.GetString("GetAccount"),
                command => Launcher.LaunchUriAsync(new Uri("http://mobilevikings.com/referral/ZInLzPvZCfgBJqVeNSsLPLdKMbIUqrTe/", UriKind.Absolute)), args);
        }

        private string _userName;
        private string _password;
        private bool? _signInFailed;

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }


        /// <summary>
        /// Gets or sets the sign in failed.
        /// </summary>
        /// <value>
        /// The sign in failed.
        /// </value>
        public bool? SignInFailed
        {
            get { return _signInFailed; }
            set
            {
                _signInFailed = value;
                RaisePropertyChanged(() => SignInFailed);
            }
        }

        /// <summary>
        /// Gets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        public ICommand Login { get { return new RelayCommand(ExecuteLogin); } }

        private async void ExecuteLogin()
        {
            IsLoading = true;

            try
            {
                SignInFailed = !(await _authorizationService.SignIn(UserName, Password));

                if (!SignInFailed.Value)
                {
                    UserName = string.Empty;
                    Password = string.Empty;

                    NavigationService.Navigate<MainView>();
                }

            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
