using System;
using System.Collections.ObjectModel;
using FEMobileVikings.Models;
using FEMobileVikings.Services;
using MobileVikings.BackEnd.Schema.Repositories;
using MobileVikings.BackEnd.Schema.Services;
using Windows.ApplicationModel.Resources;
using DTO = MobileVikings.BackEnd.Schema.DTO;
using System.Globalization;

namespace FEMobileVikings.ViewModel
{
    /// <summary>
    /// View model for the sim balance view
    /// </summary>
    public class SimBalanceViewModel : SignedInViewModelBase
    {
        private readonly ISimBalance _simBalanceRepository;
        private readonly ITopUpHistory _topUpHistory;
        private readonly IUsageHistory _usageHistory;
        private readonly DTO.MobileNumber _mobileNumber;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimBalanceViewModel" /> class.
        /// </summary>
        /// <param name="simBalance">The sim balance.</param>
        /// <param name="topUpHistory">The top up history.</param>
        /// <param name="usageHistory">The usage history.</param>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="resourceLoader">The resource loader.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public SimBalanceViewModel(ISimBalance simBalance, ITopUpHistory topUpHistory, IUsageHistory usageHistory, IAuthorizationService authorizationService, INavigationService navigationService, ResourceLoader resourceLoader)
            : base(authorizationService, resourceLoader, navigationService)
        {
            if (simBalance == null)
            {
                throw new ArgumentNullException("simBalance");
            }
            if (topUpHistory == null)
            {
                throw new ArgumentNullException("topUpHistory");
            }
            if (usageHistory == null)
            {
                throw new ArgumentNullException("usageHistory");
            }

            _mobileNumber = (DTO.MobileNumber)NavigationService.Parameter;

            _simBalanceRepository = simBalance;
            _topUpHistory = topUpHistory;
            _usageHistory = usageHistory;

            Groups = new ObservableCollection<Group>();

            HandleNoInternet();
            LoadBalance();

        }

        private async void LoadBalance()
        {
            IsLoading = true;
            var simBalance = await _simBalanceRepository.GetBalance(_mobileNumber.Number);

            if (simBalance == null)
            {
                return;
            }

            var simBalanceGroup = new Group { Title = ResourceLoader.GetString("Balance") };

            simBalanceGroup.Items.Add(new SimBalanceItem { Title = ResourceLoader.GetString("Credit"), Value = simBalance.Credit.ToString("0.00 €") });
            simBalanceGroup.Items.Add(new SimBalanceItem { Title = ResourceLoader.GetString("Data"), Value = simBalance.Data.ToString("0.00 MB") });
            simBalanceGroup.Items.Add(new SimBalanceItem { Title = ResourceLoader.GetString("Sms"), Value = simBalance.SmsCount.ToString() });
            simBalanceGroup.Items.Add(new SimBalanceItem { Title = ResourceLoader.GetString("ValidUntil"), Value = simBalance.ValidUntil.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) });
            simBalanceGroup.Items.Add(new SimBalanceItem { Title = ResourceLoader.GetString("MVCredit"), Value = (simBalance.MobileVikingsCredit / 60).ToString("0.00 Min.") });
            simBalanceGroup.Items.Add(new SimBalanceItem { Title = ResourceLoader.GetString("MVSms"), Value = simBalance.MobileVikingsSmsCount.ToString() });

            Groups.Add(simBalanceGroup);

            LoadTopUpHistory();
        }

        private async void LoadTopUpHistory()
        {
            var history = await _topUpHistory.GetHistory(_mobileNumber.Number);

            var topUpHistoryGroup = new Group { Title = ResourceLoader.GetString("TopUpHistory") };

            if (history == null)
            {
                return;
            }

            foreach (var topUpHistory in history)
            {
                topUpHistoryGroup.Items.Add(new TopUpHistoryItem { Method = topUpHistory.Method, Title = topUpHistory.Amount.ToString("0.00 €"), Received = topUpHistory.Received.ToString("dd/MM/yyyy HH:mm"), Status = topUpHistory.Status });
            }

            Groups.Add(topUpHistoryGroup);

            LoadUsageHistory();
        }


        private async void LoadUsageHistory()
        {
            var history = await _usageHistory.GetUsage(_mobileNumber.Number);

            var usageHistoryGroup = new Group { Title = ResourceLoader.GetString("Usagehistory") };

            if (history == null)
            {
                return;
            }

            foreach (var usage in history)
            {
                usageHistoryGroup.Items.Add(
                    new UsageItem { Duration = usage.Duration, IsData = usage.IsData, IsMms = usage.IsMms, IsSms = usage.IsSms, IsVoice = usage.IsVoice, Title = usage.To, Start = usage.Start.ToString("HH:mm dd/MM/yyyy") });
            }

            Groups.Add(usageHistoryGroup);
            IsLoading = false;
        }

        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        /// <value>
        /// The groups.
        /// </value>
        public ObservableCollection<Group> Groups { get; set; }
    }
}
