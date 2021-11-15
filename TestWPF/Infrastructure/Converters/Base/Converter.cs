using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;

namespace TestWPFApp.Infrastructure.Converters
{
    //[MarkupExtensionReturnType(typeof(int[]))]
    abstract class Converter : MarkupExtension, IValueConverter
    {

        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Обратное преобразование не поддерживается");

        }
        public override object ProvideValue(IServiceProvider serviceProvider) => this;
        
    }
}
