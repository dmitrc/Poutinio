using Poutinio.Core.Models;
using Poutinio.Core.Services;
using Poutinio.Views;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace Poutinio.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IDictionary<NavigationKind, Type> _navigationMap = new Dictionary<NavigationKind, Type>()
        {
            { NavigationKind.Login, typeof(LoginPage) },
            { NavigationKind.Explorer, typeof(ExplorerPage) },
            { NavigationKind.Player, typeof(PlayerPage) }
        };

        private Frame _frame;
        private object _lastParamUsed;

        public bool CanGoBack => _frame.CanGoBack;

        public void Init(Frame frame)
        {
            _frame = frame;
        }

        public bool GoBack()
        {
            if (_frame == null || !_frame.CanGoBack) return false;

            _frame.GoBack();
            return true;
        }

        public bool Navigate(NavigationKind kind, object parameter = null)
        {
            if (_frame == null) return false;

            if (_navigationMap.TryGetValue(kind, out var pageType))
            {
                // Don't open the same page multiple times
                if (_frame.Content?.GetType() != pageType || (parameter != null && !parameter.Equals(_lastParamUsed)))
                {
                    var navigationResult = _frame.Navigate(pageType, parameter);
                    if (navigationResult)
                    {
                        _lastParamUsed = parameter;
                    }

                    return navigationResult;
                }
            }

            return false;
        }

        public bool PopHistory()
        {
            var count = _frame?.BackStack?.Count ?? 0;
            if (count > 0)
            {
                _frame.BackStack.RemoveAt(count - 1);
                return true;
            }
            return false;
        }

        public bool HasContent()
        {
            return _frame?.Content != null;
        }
    }
}
