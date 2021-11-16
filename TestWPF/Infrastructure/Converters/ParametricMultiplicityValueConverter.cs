using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace TestWPFApp.Infrastructure.Converters
{
    [ValueConversion(typeof(double), typeof(double))]
    internal class ParametricMultiplicityValueConverter : Freezable, IValueConverter
    {


        public double Value
        {
            get { return (double)GetValue(CoefficientProperty); }
            set { SetValue(CoefficientProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Coefficient.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CoefficientProperty =
            DependencyProperty.Register(nameof(Value), typeof(double), typeof(ParametricMultiplicityValueConverter), new PropertyMetadata(1.0, OnValuePropertyChanged, OnCoerceValue));

        private static object OnCoerceValue(DependencyObject d, object baseValue)
        {
            return baseValue;
        }

        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var val = System.Convert.ToDouble(value, culture);
            return val * Value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var backval = System.Convert.ToDouble(value, culture);
            return backval / Value;
        }

        protected override Freezable CreateInstanceCore()
        {
            return new ParametricMultiplicityValueConverter() { Value = this.Value };
        }
    }
}
