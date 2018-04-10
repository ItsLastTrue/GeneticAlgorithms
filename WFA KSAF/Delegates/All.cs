using System;

namespace WFA.KSAF.Delegates
{
    /// <summary>
    /// Осуществление потокобезопасных вызовов элементов управления Windows Forms.
    /// </summary>
    internal delegate void TextReturningVoidDelegate(object o, string text);

    /// <summary>
    /// Осуществление потокобезопасных вызовов элементов управления Windows Forms.
    /// </summary>
    internal delegate void ActionReturningVoidDelegate<out T>(object o, Action<T> a);

    /// <summary>
    /// Осуществление потокобезопасных вызовов элементов управления Windows Forms.
    /// </summary>
    internal delegate void SafeActionDelegate(Action a);
}