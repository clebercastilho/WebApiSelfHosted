using System.Collections.Generic;
using System.Linq;

namespace ExceptionContainer
{
    public class Notification
    {
        //Variables
        private NotificationDelimiter _delimiter;
        private List<NotificationItem> _messageList;

        //Constructors
        public Notification()
        {
            _messageList = new List<NotificationItem>();
            _delimiter = NotificationDelimiter.SimpleDelimiter;
        }

        public Notification(NotificationDelimiter delimiter)
        {
            _messageList = new List<NotificationItem>();
            _delimiter = delimiter;
        }

        //Properties
        public bool HasError
        {
            get
            {
                return _messageList.Any(m => m.Type == NotificationType.Error);
            }
        }

        //Public methods
        public void AddError(string message, int code = 0)
        {
            _messageList.Add(new NotificationItem
            {
                Code = code,
                Message = message,
                Type = NotificationType.Error
            });
        }

        public void AddMessage(string message, NotificationType type, int code = 0)
        {
            _messageList.Add(new NotificationItem
            {
                Code = code,
                Message = message,
                Type = type
            });
        }

        public override string ToString()
        {
            return _messageList.Any() ? ToOrderingString() : string.Empty;
        }

        //Private methods
        private string ToOrderingString()
        {
            var delimiter = GetDelimiter();

            return _messageList
                .OrderBy(o => (int)o.Type)
                .Select(i =>
                {
                    return string.Format("{0}: {1}", i.Type.ToString(), i.Message);
                })
                .Aggregate((a, b) => a + delimiter + b);
        }

        private string GetDelimiter()
        {
            switch(_delimiter)
            {
                case NotificationDelimiter.WebDelimiter:
                    return "<br />";
                case NotificationDelimiter.ConsoleDelimiter:
                    return "\n";
                case NotificationDelimiter.SimpleDelimiter:
                    return ", ";
                default:
                    return ";";
            }
        }
    }
}
