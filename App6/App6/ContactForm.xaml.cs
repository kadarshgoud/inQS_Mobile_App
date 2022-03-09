using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactForm : ContentPage, INotifyPropertyChanged
	{
		public ContactForm ()
		{
			InitializeComponent ();
		}
	}
}