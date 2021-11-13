using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WinClient.Common;

namespace WinClient.NTier.Common
{
    public class NotifyErrorInfo : Bindable, INotifyDataErrorInfo
    {
        protected readonly Dictionary<string, List<string>> Errors = new();
        public bool HasErrors => Errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName) =>
            propertyName == null && Errors.ContainsKey(propertyName) ?
            Errors[propertyName] :
            Enumerable.Empty<string>();

        protected void RaiseErrorChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
