using System;
using System.Net;
using System.Windows.Input;
using FEMobileVikings.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MobileVikings.BackEnd.Schema.Repositories;
using MobileVikings.BackEnd.Schema.Services;
using Windows.ApplicationModel.Resources;

namespace FEMobileVikings.ViewModel
{
    /// <summary>
    /// View model for the Is mobile viking view
    /// </summary>
    public class IsMobileVikingViewModel : SignedInViewModelBase
    {
        private readonly IMobileNumbers _mobileNumbers;

        /// <summary>
        /// Initializes a new instance of the <see cref="IsMobileVikingViewModel" /> class.
        /// </summary>
        /// <param name="mobileNumbers">The mobile numbers.</param>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resourceLoader">The resource loader.</param>
        /// <param name="navigationService">The navigation service.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public IsMobileVikingViewModel(IMobileNumbers mobileNumbers, IAuthorizationService authorizationService, ResourceLoader resourceLoader, INavigationService navigationService)
            : base(authorizationService, resourceLoader, navigationService)
        {
            if (mobileNumbers == null)
            {
                throw new ArgumentNullException("mobileNumbers");
            }

            _mobileNumbers = mobileNumbers;
            HandleNoInternet();

            Messenger.Default.Register<WebException>(this, (x) =>
                                                               {
                                                                   _internetAvailable = false;
                                                                   IsAViking = null;
                                                                   IsError = false;
                                                                   IsIncorrectNumber = null;
                                                               });

            MobileNumber = "04";

        }

        private bool _internetAvailable;

        private string _mobileNumber;

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set
            {
                _mobileNumber = value;
                RaisePropertyChanged(() => MobileNumber);
            }
        }

        private bool? _isAViking;

        /// <summary>
        /// Gets or sets the is A viking.
        /// </summary>
        /// <value>
        /// The is A viking.
        /// </value>
        public bool? IsAViking
        {
            get { return _isAViking; }
            set
            {
                _isAViking = value;
                RaisePropertyChanged(() => IsAViking);
            }
        }

        private bool? _isIncorrectNumber;

        /// <summary>
        /// Gets or sets the is incorrect number.
        /// </summary>
        /// <value>
        /// The is incorrect number.
        /// </value>
        public bool? IsIncorrectNumber
        {
            get { return _isIncorrectNumber; }
            set
            {
                _isIncorrectNumber = value;
                RaisePropertyChanged(() => IsIncorrectNumber);
            }
        }

        private bool _isError;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is error; otherwise, <c>false</c>.
        /// </value>
        public bool IsError
        {
            get { return _isError; }
            set
            {
                _isError = value;
                RaisePropertyChanged(() => IsError);
            }
        }

        /// <summary>
        /// Gets the check if viking.
        /// </summary>
        /// <value>
        /// The check if viking.
        /// </value>
        public ICommand CheckIfViking
        {
            get
            {
                return new RelayCommand(IsMobileViking);
            }
        }

        private async void IsMobileViking()
        {
            if (!IsLoading)
            {
                IsLoading = true;
                IsError = false;
                _internetAvailable = true;
                try
                {
                    IsAViking = await _mobileNumbers.IsMobileViking(_mobileNumber);
                    if (_internetAvailable)
                    {
                        IsIncorrectNumber = !IsAViking;
                    }
                }
                catch (TimeoutException)
                {
                    IsAViking = null;
                    IsIncorrectNumber = null;
                    IsError = true;
                }
                IsLoading = false;
            }
        }
    }
}
