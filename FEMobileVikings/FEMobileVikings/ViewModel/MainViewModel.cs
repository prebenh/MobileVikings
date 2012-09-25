using System.ComponentModel;
using FEMobileVikings.Services;
using MobileVikings.BackEnd.Schema.Services;
using Windows.ApplicationModel.Resources;

namespace FEMobileVikings.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : SignedInViewModelBase
    {
        private MobileNumbersViewModel _mobileNumbersViewModel;
        private TwitterViewModel _twitterViewModel;
        private BlogViewModel _blogViewModel;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(MobileNumbersViewModel mobileNumbersViewModel, TwitterViewModel twitterViewModel, BlogViewModel blogViewModel, IAuthorizationService authorizationService, INavigationService navigationService, ResourceLoader resourceLoader)
            : base(authorizationService, resourceLoader, navigationService)
        {
            MobileNumbersViewModel = mobileNumbersViewModel;
            TwitterViewModel = twitterViewModel;
            BlogViewModel = blogViewModel;

            MobileNumbersViewModel.PropertyChanged += IsLoadingOnPropertyChanged;
            TwitterViewModel.PropertyChanged += IsLoadingOnPropertyChanged;
            BlogViewModel.PropertyChanged += IsLoadingOnPropertyChanged;

            HandleNoInternet();
        }

        private void IsLoadingOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == "IsLoading")
            {
                RaisePropertyChanged(() => IsLoading);
            }
        }

        public MobileNumbersViewModel MobileNumbersViewModel
        {
            get { return _mobileNumbersViewModel; }
            set
            {
                _mobileNumbersViewModel = value;
                RaisePropertyChanged(() => MobileNumbersViewModel);
            }
        }

        public TwitterViewModel TwitterViewModel
        {
            get { return _twitterViewModel; }
            set
            {
                _twitterViewModel = value;
                RaisePropertyChanged(() => TwitterViewModel);
            }
        }

        public BlogViewModel BlogViewModel
        {
            get { return _blogViewModel; }
            set
            {
                _blogViewModel = value;
                RaisePropertyChanged(() => BlogViewModel);
            }
        }

        public bool IsLoading
        {
            get { return BlogViewModel.IsLoading || MobileNumbersViewModel.IsLoading || TwitterViewModel.IsLoading; }
        }
    }
}