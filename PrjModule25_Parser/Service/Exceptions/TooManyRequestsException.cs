﻿using System;

namespace PrjModule25_Parser.Service.Exceptions
{
    public class TooManyRequestsException:Exception
    {
        public TooManyRequestsException() : base()
        {

        }
        public TooManyRequestsException(string message) : base(message)
        {

        }
    }
}