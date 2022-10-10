using System;

namespace IncidentProject.Exceptions
{
    public class AccountBadNameException: Exception
    {
        public AccountBadNameException()
        {
        }

        public AccountBadNameException(string message): base(message)
        {
        }

        public AccountBadNameException(string message, Exception inner): base(message, inner)
        {
        }
    }
}
