using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FEMobileVikings.Services
{
    /// <summary>
    /// Service to navigate to the app in aan MVVM way
    /// </summary>
    public class NavigationService : INavigationService
    {
        private readonly Frame _frame;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService" /> class.
        /// </summary>
        /// <param name="frame">The frame.</param>
        public NavigationService(Frame frame)
        {
            _frame = frame;

            _frame.Loaded += OnLoaded;
        }

        /// <summary>
        /// Go back in the navigation stack.
        /// </summary>
        public void GoBack()
        {
            _frame.GoBack();
        }

        /// <summary>
        /// Go forward in the navigation stack.
        /// </summary>
        public void GoForward()
        {
            _frame.GoForward();
        }

        /// <summary>
        /// Navigates to T
        /// </summary>
        /// <typeparam name="T">The view to navigate to</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public bool Navigate<T>(object parameter = null)
        {
            return Navigate(typeof(T), parameter);
        }

        /// <summary>
        /// Navigates the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public bool Navigate(Type source, object parameter = null)
        {
            _parameter = parameter;
            return _frame.Navigate(source, parameter);
        }


        private void OnLoaded(object sender, RoutedEventArgs args)
        {
            if (Loaded != null)
                Loaded(sender, args);
        }

        public event RoutedEventHandler Loaded;

        private object _parameter;
        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        public object Parameter
        {
            get { return _parameter; }
        }
    }
}
