using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES.Observer
{
    public class LanguageNotifier
    {
        private static readonly LanguageNotifier _instance = new LanguageNotifier();
        private readonly List<IObserver> _observers = new List<IObserver>();
        private LanguageNotifier() { }

        public static LanguageNotifier Instance => _instance;

        public void RegisterObserver(IObserver observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}

