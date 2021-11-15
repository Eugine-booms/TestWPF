using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using System.Xaml;

namespace TestWPFApp.ViewModels.Base
{
    internal abstract class ViewModel : MarkupExtension, INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;



        /// <summary>
        /// Генерирует событие при изменении свойства
        /// </summary>
        /// <param name="PropertyName">[CallerMemberName] Если метод вызывается без параметров
        /// - то компилятор автоматом подставляет имя метода из которого вызвана процедура</param>

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        /// <summary>
        /// Обновляет значение свойства
        /// Разрешает кольцевые изменения свойств 1 обновляет 2 -> 2 обновляет 3-> 3 обновляет 1
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="field"> ссылка на поле в котором свойство хранит свои данные</param>
        /// <param name="value">новое значение </param>
        /// <param name="PropertyName">имя свойства переданного в OnPropertyChanged</param>
        /// <returns></returns>
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;

        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var value_target_service = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var root_object_service = serviceProvider.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;

            OnInitialized(
                value_target_service?.TargetObject,
                value_target_service?.TargetProperty,
                root_object_service?.RootObject);
            return this;
        }

        private WeakReference _tagetRef;
        private WeakReference _rootRef;
        public object TargetObject => _tagetRef.Target;
        public object RootObject => _rootRef.Target;

        protected virtual void OnInitialized(object target, object prop, object root)

        {
            _tagetRef = new WeakReference(target);
            _rootRef = new WeakReference(root);
        }
        //деструктор если он нужен то так
        //~ViewModel()
        //{
        //    Dispose(false);
        //}
        public void Dispose()
        {
            Dispose(true);
        }
        private bool _Disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || _Disposed) return;
            _Disposed = true;
            //освобождение управляемых ресурсов
        }
    }
}
