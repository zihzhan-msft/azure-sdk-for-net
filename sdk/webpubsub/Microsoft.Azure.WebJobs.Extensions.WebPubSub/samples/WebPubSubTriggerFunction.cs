﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.WebJobs.Extensions.WebPubSub;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Samples
{
    #region Snippet:WebPubSubTriggerFunction
    public static class WebPubSubTriggerFunction
    {
        [FunctionName("WebPubSubTriggerFunction")]
        public static void Run(
            ILogger logger,
            [WebPubSubTrigger("hub", WebPubSubEventType.User, "message")] UserEventRequest request,
            string message,
            MessageDataType dataType)
        {
            logger.LogInformation("Request from: {user}, message: {message}, dataType: {dataType}",
                request.ConnectionContext.UserId, message, dataType);
        }
    }
    #endregion
}
