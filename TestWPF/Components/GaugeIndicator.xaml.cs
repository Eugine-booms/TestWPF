using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestWPFApp.Components
{
    /// <summary>
    /// Логика взаимодействия для GaugeIndicator.xaml
    /// </summary>
    public partial class GaugeIndicator : UserControl
    {


        #region Угол поворота
        //[Category ("Новая категория")]
        //[Description ("Угол поворота")]
   public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value), 
                typeof(double), 
                typeof(GaugeIndicator), 
                new PropertyMetadata(default(double), OnValuePropertyChanged, OnCoerceValue),
                OnValidateValue);

        /// <summary>
        /// Получает новое устанавливаемое значение
        /// </summary>
        /// <param name="value">устанавливаемое значение</param>
        /// <returns>bool возможность установки нового значения в это свойство</returns>
        private static bool OnValidateValue(object value)
        {
            return true;
        }

        /// <summary>
        /// Позволяет скорректировать значение если оно не верное. НАпример >100
        /// </summary>
        /// <param name="d">объект</param>
        /// <param name="baseValue"> значение</param>
        /// <returns>Скорректированное значение</returns>
        private static object OnCoerceValue(DependencyObject d, object baseValue)
        {
            var value = (double)baseValue;
            return Math.Max(0, Math.Min(100, value));
        }
         
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //var gauge_indicator = (GaugeIndicator)d;
            //gauge_indicator.ArrowRotator.Angle = (double)e.NewValue;
        }
   #endregion

        public GaugeIndicator()
        {
            InitializeComponent();
        }
    }
}
