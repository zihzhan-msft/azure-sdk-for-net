// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations.Models
{
    /// <summary> The entity extraction result of a LUIS Deepstack project. </summary>
    public partial class DeepstackEntity
    {
        /// <summary> Initializes a new instance of DeepstackEntity. </summary>
        /// <param name="category"> The entity category. </param>
        /// <param name="text"> The predicted entity text. </param>
        /// <param name="offset"> The starting index of this entity in the query. </param>
        /// <param name="length"> The length of the text. </param>
        /// <param name="confidenceScore"> The entity confidence score. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="category"/> or <paramref name="text"/> is null. </exception>
        internal DeepstackEntity(string category, string text, int offset, int length, float confidenceScore)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Category = category;
            Text = text;
            Offset = offset;
            Length = length;
            ConfidenceScore = confidenceScore;
            Resolution = new ChangeTrackingList<DeepStackEntityResolution>();
        }

        /// <summary> Initializes a new instance of DeepstackEntity. </summary>
        /// <param name="category"> The entity category. </param>
        /// <param name="text"> The predicted entity text. </param>
        /// <param name="offset"> The starting index of this entity in the query. </param>
        /// <param name="length"> The length of the text. </param>
        /// <param name="confidenceScore"> The entity confidence score. </param>
        /// <param name="resolution"> A array with extra information about the entity. </param>
        internal DeepstackEntity(string category, string text, int offset, int length, float confidenceScore, IReadOnlyList<DeepStackEntityResolution> resolution)
        {
            Category = category;
            Text = text;
            Offset = offset;
            Length = length;
            ConfidenceScore = confidenceScore;
            Resolution = resolution;
        }

        /// <summary> The entity category. </summary>
        public string Category { get; }
        /// <summary> The predicted entity text. </summary>
        public string Text { get; }
        /// <summary> The starting index of this entity in the query. </summary>
        public int Offset { get; }
        /// <summary> The length of the text. </summary>
        public int Length { get; }
        /// <summary> The entity confidence score. </summary>
        public float ConfidenceScore { get; }
        /// <summary> A array with extra information about the entity. </summary>
        public IReadOnlyList<DeepStackEntityResolution> Resolution { get; }
    }
}
