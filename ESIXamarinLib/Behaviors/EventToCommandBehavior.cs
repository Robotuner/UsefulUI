/// <summary>
/// https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/behaviors/reusable/event-to-command-behavior
/// </summary>
namespace ESIXamarinLib.Behaviors
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class EventToCommandBehavior : BindableBehavior<View>
    {
        #region EventName
        public static readonly BindableProperty EventNameProperty = BindableProperty.CreateAttached(
                propertyName: "EventName", returnType: typeof(string), declaringType: typeof(EventToCommandBehavior), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnEventNameChanged);

        private static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            EventToCommandBehavior thisctrl = (EventToCommandBehavior)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (newValue != null)
                {
                    thisctrl.EventName = newValue != null ? (string)newValue : string.Empty;
                }
            }
        }

        public static string GetEventName(BindableObject target)
        {
            if (EventNameProperty != null)
            {
                object result = target.GetValue(EventNameProperty);
                if (result != null) return (string)result;
            }
            return null;
        }

        public static void SetEventName(BindableObject target, string value)
        {
            target.SetValue(EventNameProperty, value);
        }
        #endregion

        #region Command
        public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached(
                propertyName: "Command", returnType: typeof(ICommand), declaringType: typeof(EventToCommandBehavior), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCommandChanged);

        private static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            EventToCommandBehavior thisctrl = (EventToCommandBehavior)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (newValue != null)
                {
                    thisctrl.Command = (ICommand)newValue;
                }
            }
        }

        public static ICommand GetCommand(BindableObject target)
        {
            if (CommandProperty != null)
            {
                object result = target.GetValue(CommandProperty);
                if (result != null) return (ICommand)result;
            }
            return null;
        }

        public static void SetCommand(BindableObject target, ICommand value)
        {
            target.SetValue(CommandProperty, value);
        }
        #endregion

        #region CommandParameter
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.CreateAttached(
                propertyName: "CommandParameter", returnType: typeof(object), declaringType: typeof(EventToCommandBehavior), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnCommandParameterChanged);

        private static void OnCommandParameterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            EventToCommandBehavior thisctrl = (EventToCommandBehavior)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (newValue != null)
                {
                    thisctrl.CommandParameter = newValue != null ? newValue : null;
                }
            }
        }

        public static object GetCommandParameter(BindableObject target)
        {
            if (CommandParameterProperty != null)
            {
                object result = target.GetValue(CommandParameterProperty);
                return result;
            }
            return null;
        }

        public static void SetCommandParameter(BindableObject target, object value)
        {
            target.SetValue(CommandParameterProperty, value);
        }
        #endregion

        #region EventArgsConverter
        public static readonly BindableProperty EventArgsConverterProperty = BindableProperty.CreateAttached(
                propertyName: "EventArgsConverter", returnType: typeof(IValueConverter), declaringType: typeof(EventToCommandBehavior), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnEventArgsConverterChanged);

        private static void OnEventArgsConverterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            EventToCommandBehavior thisctrl = (EventToCommandBehavior)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (newValue != null)
                {
                    thisctrl.EventArgsConverter = newValue != null ? (IValueConverter)newValue : null;
                }
            }
        }

        public static IValueConverter GetEventArgsConverter(BindableObject target)
        {
            if (EventArgsConverterProperty != null)
            {
                object result = target.GetValue(EventArgsConverterProperty);
                if (result != null) return (IValueConverter)result;
            }
            return null;
        }

        public static void SetEventArgsConverter(BindableObject target, IValueConverter value)
        {
            target.SetValue(EventArgsConverterProperty, value);
        }
        #endregion

        #region EventArgsConverterParameter
        public static readonly BindableProperty EventArgsConverterParameterProperty = BindableProperty.CreateAttached(
                propertyName: "EventArgsConverterParameter", returnType: typeof(object), declaringType: typeof(EventToCommandBehavior), defaultValue: null,
                defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnEventArgsConverterParameterChanged);

        private static void OnEventArgsConverterParameterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            EventToCommandBehavior thisctrl = (EventToCommandBehavior)bindable;
            if (thisctrl != null && oldValue != newValue)
            {
                if (newValue != null)
                {
                    thisctrl.EventArgsConverterParameter = newValue != null ? (object)newValue : null;
                }
            }
        }

        public static object GetEventArgsConverterParameter(BindableObject target)
        {
            if (EventArgsConverterParameterProperty != null)
            {
                object result = target.GetValue(EventArgsConverterParameterProperty);
                if (result != null) return (object)result;
            }
            return null;
        }

        public static void SetEventArgsConverterParameter(BindableObject target, object value)
        {
            target.SetValue(EventArgsConverterParameterProperty, value);
        }
        #endregion

        private Delegate _handler;
        private EventInfo _eventInfo;

        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public IValueConverter EventArgsConverter
        {
            get { return (IValueConverter)GetValue(EventArgsConverterProperty); }
            set { SetValue(EventArgsConverterProperty, value); }
        }

        public object EventArgsConverterParameter
        {
            get { return GetValue(EventArgsConverterParameterProperty); }
            set { SetValue(EventArgsConverterParameterProperty, value); }
        }

        protected override void OnAttachedTo(View visualElement)
        {
            base.OnAttachedTo(visualElement);
            if (!string.IsNullOrEmpty(this.EventName))
            {
                var events = AssociatedObject.GetType().GetRuntimeEvents().ToArray();
                if (events.Any())
                {
                    _eventInfo = events.FirstOrDefault(e => e.Name == EventName);
                    if (_eventInfo == null)
                        throw new ArgumentException(String.Format("EventToCommand: Can't find any event named '{0}' on attached type", EventName));

                    AddEventHandler(_eventInfo, AssociatedObject, OnFired);
                }
            }
        }

        protected override void OnDetachingFrom(View view)
        {
            if (_handler != null)
                _eventInfo.RemoveEventHandler(AssociatedObject, _handler);

            base.OnDetachingFrom(view);
        }

        private void AddEventHandler(EventInfo eventInfo, object item, Action<object, EventArgs> action)
        {
            var eventParameters = eventInfo.EventHandlerType
                .GetRuntimeMethods().First(m => m.Name == "Invoke")
                .GetParameters()
                .Select(p => Expression.Parameter(p.ParameterType))
                .ToArray();

            var actionInvoke = action.GetType()
                .GetRuntimeMethods().First(m => m.Name == "Invoke");

            _handler = Expression.Lambda(
                    eventInfo.EventHandlerType,
                    Expression.Call(Expression.Constant(action), actionInvoke, eventParameters[0], eventParameters[1]),
                    eventParameters
                )
                .Compile();

            eventInfo.AddEventHandler(item, _handler);
        }

        private void OnFired(object sender, EventArgs eventArgs)
        {
            if (Command == null)
                return;

            var parameter = CommandParameter;

            if (eventArgs != null && eventArgs != EventArgs.Empty)
            {
                parameter = eventArgs;

                if (EventArgsConverter != null)
                {
                    parameter = EventArgsConverter.Convert(eventArgs, typeof(object), EventArgsConverterParameter, CultureInfo.CurrentUICulture);
                }
            }

            if (Command.CanExecute(parameter))
            {
                Command.Execute(parameter);
            }
        }
    }
}
