﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Mvc.ModelBinding.Binders
{
    /// <summary>
    /// An <see cref="IModelBinderProvider"/> for binding simple data types.
    /// </summary>
    public class SimpleTypeModelBinderProvider : IModelBinderProvider
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;

        public SimpleTypeModelBinderProvider()
        {
        }

        public SimpleTypeModelBinderProvider(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger(GetType());
        }

        /// <inheritdoc />
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!context.Metadata.IsComplexType)
            {
                return new SimpleTypeModelBinder(context.Metadata.ModelType, _loggerFactory);
            }

            return null;
        }
    }
}
