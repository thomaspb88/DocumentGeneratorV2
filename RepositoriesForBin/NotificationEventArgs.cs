using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportItemReader.Interface
{
    public class NotificationEventArgs : EventArgs
    {
        public string Message;
        public NotificationType NotificationType;
    }

    public enum NotificationType
    {
        Null = 0,
        Exception,
        User,
        Connection
    }
}
