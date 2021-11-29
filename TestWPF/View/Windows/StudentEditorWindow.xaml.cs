using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestWPFApp.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для StudentEditorWindow.xaml
    /// </summary>

    

    public partial class StudentEditorWindow : Window
    {
        public static readonly DependencyProperty FirstNameProperty = 
            DependencyProperty.Register(nameof(FirstName),typeof(string), typeof(StudentEditorWindow), new PropertyMetadata(string.Empty));
        public StudentEditorWindow()
        {
            InitializeComponent();
        }

        public string FirstName
        {
            get { return (string)GetValue(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }




        public string  LastName
        {
            get { return (string )GetValue(LastNameProperty); }
            set { SetValue(LastNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastNameProperty =
            DependencyProperty.Register("LastName", typeof(string ), typeof(StudentEditorWindow), new PropertyMetadata(string.Empty));



        public string Patronumic
        {
            get { return (string)GetValue(PatronumicProperty); }
            set { SetValue(PatronumicProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Patronymic.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PatronumicProperty =
            DependencyProperty.Register("Patronumic", typeof(string), typeof(StudentEditorWindow), new PropertyMetadata(string.Empty));



        public double Rating
        {
            get { return (double)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Rating.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register("Rating", typeof(double), typeof(StudentEditorWindow), new PropertyMetadata(0.0));



        public DateTime Birthday
        {
            get { return (DateTime)GetValue(BirthdayProperty); }
            set { SetValue(BirthdayProperty, value); }
        }

        // Using a DependencyProperty as the backing store for dateTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BirthdayProperty =
            DependencyProperty.Register("dateTime", typeof(DateTime), typeof(StudentEditorWindow), new PropertyMetadata(default(DateTime)));







    }
}
