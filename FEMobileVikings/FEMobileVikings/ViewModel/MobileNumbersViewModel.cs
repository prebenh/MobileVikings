using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FEMobileVikings.Services;
using FEMobileVikings.Views;
using GalaSoft.MvvmLight.Command;
using MobileVikings.BackEnd.Schema.DTO;
using MobileVikings.BackEnd.Schema.Repositories;
using Windows.ApplicationModel.Resources;

namespace FEMobileVikings.ViewModel
{
    /// <summary>
    /// View model for the mobile numbers view
    /// </summary>
    public class MobileNumbersViewModel : MobileVikingsViewModelBase
    {
        private readonly IMobileNumbers _mobileNumbers;

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileNumbersViewModel" /> class.
        /// </summary>
        /// <param name="mobileNumbers">The mobile numbers.</param>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="resourceLoader">The resource loader.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public MobileNumbersViewModel(IMobileNumbers mobileNumbers, INavigationService navigationService, ResourceLoader resourceLoader)
            : base(navigationService, resourceLoader)
        {
            if (mobileNumbers == null)
            {
                throw new ArgumentNullException("mobileNumbers");
            }

            _mobileNumbers = mobileNumbers;

            MobileNumbers = new ObservableCollection<MobileNumber>();

            LoadMobileNumbers();
        }

        /// <summary>
        /// Gets or sets the mobile numbers.
        /// </summary>
        /// <value>
        /// The mobile numbers.
        /// </value>
        public ObservableCollection<MobileNumber> MobileNumbers { get; set; }

        /// <summary>
        /// Gets the sim balance.
        /// </summary>
        /// <value>
        /// The sim balance.
        /// </value>
        public ICommand SimBalance
        {
            get
            {
                return new RelayCommand<object>(x => NavigateToSimbalance(x));
            }
        }

        private async void LoadMobileNumbers()
        {
            IsLoading = true;

            var mobileNumbers = await _mobileNumbers.GetAll();

            if (mobileNumbers == null)
            {
                return;
            }

            foreach (var mobileNumber in mobileNumbers)
            {
                MobileNumbers.Add(mobileNumber);
            }

            IsLoading = false;
        }

        private void NavigateToSimbalance(object value)
        {
            var mobileNumber = value as MobileNumber;

            if (mobileNumber != null)
            {
                NavigationService.Navigate<SimBalanceView>(mobileNumber);
            }
        }


    }
}
