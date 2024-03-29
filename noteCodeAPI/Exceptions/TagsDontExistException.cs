﻿namespace noteCodeAPI.Exceptions
{
    public class TagsDontExistException: Exception
    {
        private static readonly string defaultMessage = "Tags don't exist, please select existing tags.";

        public TagsDontExistException(string message) : base(message)
        {
        }
        public TagsDontExistException() : base(defaultMessage)
        {
        }
    }
}
