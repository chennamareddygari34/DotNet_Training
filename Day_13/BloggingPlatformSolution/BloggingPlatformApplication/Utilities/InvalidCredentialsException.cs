﻿namespace BloggingPlatformApplication.Utilities
{
    public class InvalidCredentialsException: Exception
    {
        public override string Message => "Invalid username or password";

    }
}
