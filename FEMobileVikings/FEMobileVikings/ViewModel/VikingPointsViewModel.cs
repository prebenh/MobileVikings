using System;
using System.Globalization;
using FEMobileVikings.Services;
using MobileVikings.BackEnd.Schema.Repositories;
using MobileVikings.BackEnd.Schema.Services;
using Windows.ApplicationModel.Resources;

namespace FEMobileVikings.ViewModel
{
    /// <summary>
    /// View model for the viking points view
    /// </summary>
    public class VikingPointsViewModel : SignedInViewModelBase
    {
        private readonly IVikingPoints _vikingPoints;

        /// <summary>
        /// Initializes a new instance of the <see cref="VikingPointsViewModel" /> class.
        /// </summary>
        /// <param name="vikingPoints">The viking points.</param>
        /// <param name="authorizationService">The authorization service.</param>
        /// <param name="resourceLoader">The resource loader.</param>
        /// <param name="navigationService">The navigation service.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public VikingPointsViewModel(IVikingPoints vikingPoints, IAuthorizationService authorizationService, ResourceLoader resourceLoader, INavigationService navigationService)
            : base(authorizationService, resourceLoader, navigationService)
        {
            if (vikingPoints == null)
            {
                throw new ArgumentNullException("mobileNumbers");
            }

            _vikingPoints = vikingPoints;
            HandleNoInternet();
            LoadVikingPoints();
        }

        private async void LoadVikingPoints()
        {
            IsLoading = true;
            var points = await _vikingPoints.GetVikingPoints();
            if (points != null)
            {
                AvailablePoints = points.AvailablePoints;
                TotalPoints = points.EarnedPoints;
            }

            IsLoading = false;
        }

        private int _availablePoints;

        /// <summary>
        /// Gets or sets the available points.
        /// </summary>
        /// <value>
        /// The available points.
        /// </value>
        public int AvailablePoints
        {
            get { return _availablePoints; }
            set
            {
                _availablePoints = value;
                RaisePropertyChanged(() => AvailablePoints);
                RaisePropertyChanged( () => Description);
            }
        }

        private int _totalPoints;

        /// <summary>
        /// Gets or sets the total points.
        /// </summary>
        /// <value>
        /// The total points.
        /// </value>
        public int TotalPoints
        {
            get { return _totalPoints; }
            set
            {
                _totalPoints = value;
                RaisePropertyChanged(() => TotalPoints);
            }
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get { return string.Format(CultureInfo.InvariantCulture, ResourceLoader.GetString("VikingPointsDescription"), AvailablePoints); }
        }

    }
}
