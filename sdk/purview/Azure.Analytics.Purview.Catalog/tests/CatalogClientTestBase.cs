// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Catalog.Tests
{
    public class CatalogClientTestBase : RecordedTestBase<PurviewCatalogTestEnvironment>
    {
        public CatalogClientTestBase(bool isAsync) : base(isAsync)
        {
        }

        public CatalogClientTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public PurviewCatalogClient GetCatalogClient()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            var options = new PurviewCatalogClientOptions { Transport = new HttpClientTransport(httpHandler) };
            var client = InstrumentClient(
                new PurviewCatalogClient(TestEnvironment.Endpoint, TestEnvironment.Credential, InstrumentClientOptions(options)));
            return client;
        }
    }
}
