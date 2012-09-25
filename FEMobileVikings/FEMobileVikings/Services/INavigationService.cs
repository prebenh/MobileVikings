using System;
using Windows.UI.Xaml;

namespace FEMobileVikings.Services
{
    /// <summary>
    /// Interface for the navigation service
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Go back in the navigation stack.
        /// </summary>
        void GoBack();
        /// <summary>
        /// Go forward in the navigation stack.
        /// </summary>
        void GoForward();
        /// <summary>
        /// Navigates to T
        /// </summary>
        /// <typeparam name="T">The view to navigate to</typeparam>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        bool Navigate<T>(object parameter = null);
        /// <summary>
        /// Navigates the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        bool Navigate(Type source, object parameter = null);
        /// <summary>
        /// Occurs when the view is loaded.
        /// </summary>
        event RoutedEventHandler Loaded;
        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        object Parameter { get; }
    }
}