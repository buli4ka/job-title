﻿using System.Globalization;

namespace Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message){}
    public NotFoundException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args)){}
}