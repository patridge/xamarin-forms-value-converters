# [Start of a] Xamarin.Forms IValueConverter collection

## Numbers

### [PluralizationIntegerConverter](https://github.com/patridge/xamarin-forms-value-converters/blob/master/ConverterPlayground/PluralizationIntegerConverter.cs)

Convert a number into a singular or plural word based on whether the source number is 1 or not.

XAML Example:

    <ContentPage
    	xmlns="http://xamarin.com/schemas/2014/forms"
    	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    	x:Class="ConverterPlayground.Sample.MainPageXaml"
    	xmlns:converters="clr-namespace:ConverterPlayground;assembly=ConverterPlayground">
    	<Page.Resources>
    		<ResourceDictionary>
    			<converters:PluralizationIntConverter
    				x:Key="Pluralize" />
    		</ResourceDictionary>
    	</Page.Resources>
    	<ContentPage.Content>
    		<StackLayout
    			Orientation="Horizontal">
    			<Label
    				Text="{Binding ZeroIntValue}" />
    			<Label
    				Text="{Binding ZeroIntValue, Converter={StaticResource Pluralize}, ConverterParameter='Thing,Things'}" />
    		</StackLayout>
    	</ContentPage.Content>
    </ContentPage>

## TODO

* Create C#-based samples
* Add more converters
