using FEMobileVikings.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FEMobileVikings.Common
{
    public class GroupDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SimInfoTemplate { get; set; }

        public DataTemplate TopUpHistoryTemplate { get; set; }

        public DataTemplate UsageTemplate { get; set; }

        protected override Windows.UI.Xaml.DataTemplate SelectTemplateCore(object item, Windows.UI.Xaml.DependencyObject container)
        {
            DataTemplate selectedTemplate = null;
            if(item is SimBalanceItem)
            {
                selectedTemplate = SimInfoTemplate;
            }
            else if(item is TopUpHistoryItem)
            {
                selectedTemplate = TopUpHistoryTemplate;
            }
            else if(item is UsageItem)
            {
                selectedTemplate = UsageTemplate;
            }

            return selectedTemplate;
        }
    }
}
