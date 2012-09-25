using System;
using FEMobileVikings.Services;
using FEMobileVikings.Views;
using GalaSoft.MvvmLight.Ioc;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace FEMobileVikings
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public INavigationService NavigationService;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            // Do not repeat app initialization when already running, just ensure that
            // the window is active
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                Window.Current.Activate();
                return;
            }

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                //TODO: Load state from previously suspended application
            }

            // Create a Frame to act navigation context and navigate to the first page
            var rootFrame = new Frame();
            SimpleIoc.Default.Register<INavigationService>(() => new NavigationService(rootFrame));

            if (!ApplicationData.Current.LocalSettings.Values.ContainsKey("SimBalanceBackgroundTask"))
            {
                //Register background worker
                var backgroundTaskManager = new BackgroundTaskBuilder
                                                {
                                                    TaskEntryPoint =
                                                        "MobileVikings.FrontEnd.BackgroundTasks.SimBalanceBackgroundTask",
                                                    Name = "SimBalanceBackgroundTask"
                                                };

                backgroundTaskManager.SetTrigger(new MaintenanceTrigger(15, false));
                backgroundTaskManager.AddCondition(new SystemCondition(SystemConditionType.InternetAvailable));
                var registration = backgroundTaskManager.Register();
                ApplicationData.Current.LocalSettings.Values["SimBalanceBackgroundTask"] = true;
            }

            if (ApplicationData.Current.RoamingSettings.Values["AuthorizationInfo"] == null)
            {
                if (!rootFrame.Navigate(typeof(LoginView)))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            else
            {
                if (!rootFrame.Navigate(typeof(MainView)))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            

            // Place the frame in the current Window and ensure that it is active
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
