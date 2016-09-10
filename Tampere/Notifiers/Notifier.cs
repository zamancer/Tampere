using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tampere.Notifiers
{
    public class Notifier
    {
        public INotificator Notificator { get; set; }
        
        private static Notifier _instance;
        
        public static Notifier Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Notifier();
                }

                return _instance;
            }
        }

        public Queue<string> NotificationQueue { get; private set; }

        private Object _threadLock = new Object();

        private Notifier()
        {
            NotificationQueue = new Queue<string>();
        }

        public void EnqueueNotification(string notification)
        {
            lock (_threadLock)
            {
                NotificationQueue.Enqueue(notification);
            }
        }

        public void Run()
        {
            while(true)
            {
                if(NotificationQueue.Count > 0)
                {
                    Notify();
                }

                Thread.Sleep(250);
            }
        }

        private void Notify()
        {
            lock(_threadLock)
            {
                var notification = NotificationQueue.Dequeue();

                Notificator.ShowNotification(notification);
            }
        }
    }
}
