using System;
using System.Collections.Generic;
using System.Globalization;
using MobileVikings.BackEnd.Schema.DTO;
using MobileVikings.BackEnd.Schema.Services;
using NotificationsExtensions.TileContent;
using Windows.UI.Notifications;

namespace MobileVikings.BackEnd.Implementation.Services
{
    /// <summary>
    /// Service to update the Application tile.
    /// </summary>
    public class TileService : ITileService
    {
        private readonly TileUpdater _tileUpdater;

        /// <summary>
        /// Initializes a new instance of the <see cref="TileService" /> class.
        /// </summary>
        /// <param name="tileUpdater">The tile updater.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public TileService(TileUpdater tileUpdater)
        {
            if (tileUpdater == null)
            {
                throw new ArgumentNullException("tileUpdater");
            }


            _tileUpdater = tileUpdater;
            _tileUpdater.EnableNotificationQueue(true);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TileService" /> class.
        /// </summary>
        public TileService()
            : this(TileUpdateManager.CreateTileUpdaterForApplication())
        {
        }

        /// <summary>
        /// Updates the live tiles with the simbalace.
        /// </summary>
        /// <param name="simBalance">The sim balance.</param>
        public void UpdateLiveTile(Dictionary<string,SimBalance> simBalance)
        {
            if(simBalance == null)
            {
                throw new ArgumentNullException("simBalance");
            }

            _tileUpdater.Clear();

            foreach (var balance in simBalance)
            {
                UpdateLiveTile(balance.Key, balance.Value);
            }
        }

        /// <summary>
        /// Updates the live tile.
        /// </summary>
        /// <param name="mobileNumber">The mobile number.</param>
        /// <param name="simBalance">The sim balance.</param>
        private void UpdateLiveTile(string mobileNumber, SimBalance simBalance)
        {
            var tileContent = TileContentFactory.CreateTileWideSmallImageAndText02();
            tileContent.TextHeading.Text = simBalance.Credit.ToString("0.00 €", CultureInfo.InvariantCulture);
            tileContent.TextBody1.Text = simBalance.Data.ToString("0.00 MB", CultureInfo.InvariantCulture);
            tileContent.TextBody2.Text = simBalance.SmsCount.ToString("0 SMS", CultureInfo.InvariantCulture);
            tileContent.TextBody3.Text = simBalance.MobileVikingsSmsCount.ToString("0 MV SMS", CultureInfo.InvariantCulture);
            tileContent.Image.Src = "ms-appx:///Assets/Logo.png";
            tileContent.Branding = TileBranding.Name;

            var squareTile = TileContentFactory.CreateTileSquareText01();
            squareTile.TextHeading.Text = simBalance.Credit.ToString("0.00 €", CultureInfo.InvariantCulture);
            squareTile.TextBody1.Text = simBalance.Data.ToString("0.00 MB", CultureInfo.InvariantCulture);
            squareTile.TextBody2.Text = simBalance.SmsCount.ToString("0 SMS", CultureInfo.InvariantCulture);
            squareTile.TextBody3.Text = simBalance.MobileVikingsSmsCount.ToString("0 MV SMS", CultureInfo.InvariantCulture);
            tileContent.SquareContent = squareTile;

            var notification = tileContent.CreateNotification();
            notification.Tag = mobileNumber;

            _tileUpdater.Update(notification);
        }

    }
}
