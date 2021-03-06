﻿using System;
using System.Threading.Tasks;

namespace WpfClientPrism.Services
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(Uri requestUrl);
        Uri CreateRequestUri(string relativePath, string queryString = "");
    }
}