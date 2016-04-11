using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UniversityNews.Helpers
{
    public static class PickerHelpers
    {
#pragma warning disable CS0618 // Тип или член устарел
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty
            .CreateAttached<Picker, IEnumerable>(
                bindable => GetItemsSource(bindable),
                null, /* default value */
                BindingMode.OneWay,
                null,
                OnItemsSourceChanged);
#pragma warning restore CS0618 // Тип или член устарел

        public static IEnumerable GetItemsSource(BindableObject bo)
        {
            return (IEnumerable) bo.GetValue(ItemsSourceProperty);
        }

        public static void SetItemsSource(BindableObject bo, IEnumerable value)
        {
            bo.SetValue(ItemsSourceProperty, value);
        }

        public static void OnItemsSourceChanged(BindableObject bo, IEnumerable oldValue, IEnumerable newValue)
        {
            //Good location to initialize the attached behaviour
            picker = bo as Picker;
            if (picker == null)
            {
                throw new InvalidOperationException(
                    $"Attached property 'ItemSource' is only functional with instances of 'typeof({picker})'");
            }
            var oOld = oldValue as ObservableCollection<object>;
            if (oOld != null)
            {
                oOld.CollectionChanged -= OnCollectionChanged;
            }
            var oNew = newValue as ObservableCollection<object>;
            if (oNew != null)
            {
                oNew.CollectionChanged += OnCollectionChanged;
            }
            if (newValue != null)
            {
                picker.Items.Clear();
                AddItemsToPicker(newValue);
            }
        }

        private static Picker picker;

        private static void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            AddItemsToPicker(args.NewItems);
        }

        private static void AddItemsToPicker(IEnumerable items)
        {
            foreach (var item in items)
            {
                picker.Items.Add(item.ToString());
            }
        }
    }
}
