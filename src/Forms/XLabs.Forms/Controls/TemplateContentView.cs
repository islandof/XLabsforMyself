﻿using Xamarin.Forms;
using XLabs.Forms.Exceptions;

namespace XLabs.Forms.Controls
{
    public class TemplateContentView<T> : ContentView
    {
        #region Bindable Properties
        /// <summary>
        /// Property definition for the <see cref="TemplateSelector"/> Property
        /// </summary>
        public static readonly BindableProperty TemplateSelectorProperty = BindableProperty.Create<TemplateContentView<T>, TemplateSelector>(x => x.TemplateSelector, default(TemplateSelector));
        /// <summary>
        /// Property definition for the <see cref="ViewModel"/> Property
        /// </summary>
        public static readonly BindableProperty ViewModelProperty = BindableProperty.Create<TemplateContentView<T>, T>(x => x.ViewModel,default(T),BindingMode.OneWay,null,ViewModelChanged);

        /// <summary>
        /// Used to match a type with a datatemplate
        /// <see cref="TemplateSelector"/>
        /// </summary>
        public TemplateSelector TemplateSelector
        {
            get { return (TemplateSelector)GetValue(TemplateSelectorProperty); }
            set { SetValue(TemplateSelectorProperty, value); }
        }

        /// <summary>
        /// There is an argument to use 'object' rather than T
        /// however you can specify T as object.  In addition
        /// T allows the use of marker interfaces to enable
        /// things like Ux Widgets while maintaining 
        /// some typesafety
        /// </summary>
        public T ViewModel
        {
            get { return (T)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty,value);}
        }

        /// <summary>
        /// Call down to the actual controls Implmentation
        /// <see cref="ViewModelChangedImpl"/>
        /// </summary>
        /// <param name="bindable">The TemplateContentView<typeparam name="T"></typeparam></param>
        /// <param name="oldValue">Ignored</param>
        /// <param name="newValue">Passed down to <see cref="ViewModelChangedImpl"/></param>
        /// <exception cref="InvalidBindableException"></exception>Thrown if bindable is not in fact a TemplateContentView<typeparam name="T"></typeparam>
        private static void ViewModelChanged(BindableObject bindable, T oldValue, T newValue)
        {
            var layout = bindable as TemplateContentView<T>;
            if(layout==null)
                throw new InvalidBindableException(bindable,typeof(TemplateContentView<T>));
            layout.ViewModelChangedImpl(newValue);
        }
        #endregion

        /// <summary>
        /// Clears the old Children
        /// Creates the new View and adds it to the Children, and Invalidates the Layout
        /// </summary>
        /// <param name="newvalue"></param>
        private void ViewModelChangedImpl(T newvalue)
        {
            var newchild = TemplateSelector.ViewFor(newvalue);
            //Verify that newchild is a contentview
            Content = newchild;
            InvalidateLayout();
        }
    }
}