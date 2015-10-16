using System;
using System.Linq;
using Xamarin.Forms;

namespace ConverterPlayground {
	// XAML usage example:
	// xmlns:converters="clr-namespace:PatridgeDev.Forms.Converters;assembly=PatridgeDev.Forms"
	// <Page.Resources><ResourceDictionary><converters:PluralizationIntConverter x:Key="Pluralize" /></Page.Resources></ResourceDictionary>
	// <Label Text="{Binding SomeIntegerValue, Converter={StaticResource Pluralize}, ConverterParameter='Thing,Things'}"
	public class PluralizationIntConverter : IValueConverter {
		public object Convert (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			var intValue = (int)value;
			var parameters = ((parameter as string) ?? "").Split(new[] { ',' }, 2);
			var singularValue = parameters.FirstOrDefault();
			var pluralValue = parameters.Skip(1).FirstOrDefault() ?? singularValue;

			return ((intValue != 1) ? pluralValue : singularValue) ?? "";
		}

		public object ConvertBack (object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}