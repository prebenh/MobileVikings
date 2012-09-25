using System;
using System.Collections.Generic;
using System.Linq;
using MobileVikings.BackEnd.Implementation.Repositories;
using MobileVikings.BackEnd.Implementation.Services;
using MobileVikings.BackEnd.Schema.Repositories;
using MobileVikings.BackEnd.Schema.Services;
using DTO = MobileVikings.BackEnd.Schema.DTO;
using Windows.ApplicationModel.Background;

namespace MobileVikings.FrontEnd.BackgroundTasks
{
    /// <summary>
    /// Background task to get the sim balance of all sim cards connected to the signed in user.
    /// Updates the application tile.
    /// </summary>
    public sealed class SimBalanceBackgroundTask : IBackgroundTask
    {
        private volatile bool _cancelRequest;
        private readonly ISimBalance _simBalanceRepository = new SimBalance();
        private readonly IMobileNumbers _mobileNumbersRepository = new MobileNumbers();
        private readonly ITileService _tileService = new TileService();

        /// <summary>
        /// Performs the work of a background task. The system calls this method when the associated background task has been triggered.
        /// </summary>
        /// <param name="taskInstance">An interface to an instance of the background task. The system creates this instance when the task has been triggered to run.</param>
        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            try
            {
                taskInstance.Canceled += TaskInstanceOnCanceled;
                if (!_cancelRequest)
                {
                    var deferral = taskInstance.GetDeferral();
                    var mobileNumbers = await _mobileNumbersRepository.GetAll();
                    if (mobileNumbers != null && mobileNumbers.Any())
                    {
                        var simbalances = new Dictionary<string, DTO.SimBalance>();
                        foreach (var mobileNumber in mobileNumbers)
                        {
                            simbalances.Add(mobileNumber.Number,
                                            await _simBalanceRepository.GetBalance(mobileNumber.Number));
                        }

                        _tileService.UpdateLiveTile(simbalances);
                    }
                    deferral.Complete();
                }
            }
            catch (Exception)
            {
            }

        }

        private void TaskInstanceOnCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            _cancelRequest = true;
        }
    }
}
