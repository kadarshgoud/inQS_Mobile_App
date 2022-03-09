using App6.Model;
using Xamarin.Forms;

namespace App6.Management
{
    public class BewohnerStatusDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FinishedQETemplate { get; set; }
        public DataTemplate UnfinishedQETemplate { get; set; }
        public DataTemplate FinishedNoQETemplate { get; set; }
        public DataTemplate UnfinishedNoQETemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            //mit QE
            if (((Patient)item).Bogenart == 0)
            {
                if (((Patient)item).isSurveyCompleted == 1)
                {
                    return FinishedQETemplate;
                }
                else
                {
                    return UnfinishedQETemplate;
                }
            }
            //ohne QE
            else
            {
                if (((Patient)item).isSurveyCompleted == 1)
                {
                    return FinishedNoQETemplate;
                }
                else
                {
                    return UnfinishedNoQETemplate;
                }
            }
        }
    }
}
