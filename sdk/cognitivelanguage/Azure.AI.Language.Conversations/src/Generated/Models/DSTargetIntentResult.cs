// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.AI.Language.Conversations.Models
{
    /// <summary> A wrap up of LUIS Deepstack response. </summary>
    public partial class DSTargetIntentResult : TargetIntentResult
    {
        /// <summary> Initializes a new instance of DSTargetIntentResult. </summary>
        /// <param name="confidenceScore"> The prediction score and it ranges from 0.0 to 1.0. </param>
        internal DSTargetIntentResult(double confidenceScore) : base(confidenceScore)
        {
            TargetKind = TargetKind.LuisDeepstack;
        }

        /// <summary> Initializes a new instance of DSTargetIntentResult. </summary>
        /// <param name="targetKind"> This discriminator property specifies the type of the target project that returns the response. &apos;luis&apos; means the type is LUIS Generally Available. &apos;luis_deepstack&apos; means LUIS vNext. &apos;question_answering&apos; means Question Answering. </param>
        /// <param name="apiVersion"> The API version used to call a target service. </param>
        /// <param name="confidenceScore"> The prediction score and it ranges from 0.0 to 1.0. </param>
        /// <param name="result"> The actual response from a LUIS Deepstack application. </param>
        internal DSTargetIntentResult(TargetKind targetKind, string apiVersion, double confidenceScore, DeepstackResult result) : base(targetKind, apiVersion, confidenceScore)
        {
            Result = result;
            TargetKind = targetKind;
        }

        /// <summary> The actual response from a LUIS Deepstack application. </summary>
        public DeepstackResult Result { get; }
    }
}
