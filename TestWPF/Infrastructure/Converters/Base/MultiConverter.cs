using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace TestWPFApp.Infrastructure.Converters
{
    /// <summary>
    /// Компонует из нескольких свойств (с помощью мультибиндинга) одну сущность
    /// </summary>
    internal  abstract class MultiConverter : IMultiValueConverter
    {
        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);
       

        public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Обратное преобразование не поддерживаться");
        }
    }
}
