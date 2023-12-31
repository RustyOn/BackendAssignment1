﻿using System;

public class InvalidLevelException : Exception
{
    public InvalidLevelException()
    {
    }

    public InvalidLevelException(string message)
        : base(message)
    {
    }

    public InvalidLevelException(string message, Exception inner)
        : base(message, inner)
    {
    }
}