﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityModel;
using IdentityServer4.Configuration;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using System;
using IdentityServer4.Hosting.Cookies;

namespace IdentityServer4.Hosting
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, AuthenticationHandler handler)
        {
            handler.Init();
            try
            {
                await _next(context);
            }
            finally
            {
                handler.Cleanup();
            }
        }
    }
}