﻿using DigitalBooksApp.DatabaseEntity;

namespace TokenAuthentication.Service
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, IEnumerable<string> audience, User user);
    }
}