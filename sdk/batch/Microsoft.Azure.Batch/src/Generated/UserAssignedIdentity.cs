// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

//
// This file was autogenerated by a tool.
// Do not modify it.
//

namespace Microsoft.Azure.Batch
{
    using Models = Microsoft.Azure.Batch.Protocol.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The reference to a user assigned identity associated with the Batch pool which a compute node will use.
    /// </summary>
    public partial class UserAssignedIdentity : ITransportObjectProvider<Models.UserAssignedIdentity>, IPropertyMetadata
    {
        private class PropertyContainer : PropertyCollection
        {
            public readonly PropertyAccessor<string> ClientIdProperty;
            public readonly PropertyAccessor<string> PrincipalIdProperty;
            public readonly PropertyAccessor<string> ResourceIdProperty;

            public PropertyContainer() : base(BindingState.Unbound)
            {
                this.ClientIdProperty = this.CreatePropertyAccessor<string>(nameof(ClientId), BindingAccess.Read);
                this.PrincipalIdProperty = this.CreatePropertyAccessor<string>(nameof(PrincipalId), BindingAccess.Read);
                this.ResourceIdProperty = this.CreatePropertyAccessor<string>(nameof(ResourceId), BindingAccess.Read | BindingAccess.Write);
            }

            public PropertyContainer(Models.UserAssignedIdentity protocolObject) : base(BindingState.Bound)
            {
                this.ClientIdProperty = this.CreatePropertyAccessor(
                    protocolObject.ClientId,
                    nameof(ClientId),
                    BindingAccess.Read);
                this.PrincipalIdProperty = this.CreatePropertyAccessor(
                    protocolObject.PrincipalId,
                    nameof(PrincipalId),
                    BindingAccess.Read);
                this.ResourceIdProperty = this.CreatePropertyAccessor(
                    protocolObject.ResourceId,
                    nameof(ResourceId),
                    BindingAccess.Read);
            }
        }

        private readonly PropertyContainer propertyContainer;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAssignedIdentity"/> class.
        /// </summary>
        /// <param name='resourceId'>The ARM resource id of the user assigned identity</param>
        public UserAssignedIdentity(
            string resourceId)
        {
            this.propertyContainer = new PropertyContainer();
            this.ResourceId = resourceId;
        }

        internal UserAssignedIdentity(Models.UserAssignedIdentity protocolObject)
        {
            this.propertyContainer = new PropertyContainer(protocolObject);
        }

        #endregion Constructors

        #region UserAssignedIdentity

        /// <summary>
        /// Gets the client id of the user assigned identity.
        /// </summary>
        public string ClientId
        {
            get { return this.propertyContainer.ClientIdProperty.Value; }
        }

        /// <summary>
        /// Gets the principal id of the user assigned identity.
        /// </summary>
        public string PrincipalId
        {
            get { return this.propertyContainer.PrincipalIdProperty.Value; }
        }

        /// <summary>
        /// Gets or sets the ARM resource id of the user assigned identity
        /// </summary>
        public string ResourceId
        {
            get { return this.propertyContainer.ResourceIdProperty.Value; }
            set { this.propertyContainer.ResourceIdProperty.Value = value; }
        }

        #endregion // UserAssignedIdentity

        #region IPropertyMetadata

        bool IModifiable.HasBeenModified
        {
            get { return this.propertyContainer.HasBeenModified; }
        }

        bool IReadOnly.IsReadOnly
        {
            get { return this.propertyContainer.IsReadOnly; }
            set { this.propertyContainer.IsReadOnly = value; }
        }

        #endregion //IPropertyMetadata

        #region Internal/private methods
        /// <summary>
        /// Return a protocol object of the requested type.
        /// </summary>
        /// <returns>The protocol object of the requested type.</returns>
        Models.UserAssignedIdentity ITransportObjectProvider<Models.UserAssignedIdentity>.GetTransportObject()
        {
            Models.UserAssignedIdentity result = new Models.UserAssignedIdentity()
            {
                ResourceId = this.ResourceId,
            };

            return result;
        }

        /// <summary>
        /// Converts a collection of protocol layer objects to object layer collection objects.
        /// </summary>
        internal static IList<UserAssignedIdentity> ConvertFromProtocolCollection(IEnumerable<Models.UserAssignedIdentity> protoCollection)
        {
            ConcurrentChangeTrackedModifiableList<UserAssignedIdentity> converted = UtilitiesInternal.CollectionToThreadSafeCollectionIModifiable(
                items: protoCollection,
                objectCreationFunc: o => new UserAssignedIdentity(o));

            return converted;
        }

        /// <summary>
        /// Converts a collection of protocol layer objects to object layer collection objects, in a frozen state.
        /// </summary>
        internal static IList<UserAssignedIdentity> ConvertFromProtocolCollectionAndFreeze(IEnumerable<Models.UserAssignedIdentity> protoCollection)
        {
            ConcurrentChangeTrackedModifiableList<UserAssignedIdentity> converted = UtilitiesInternal.CollectionToThreadSafeCollectionIModifiable(
                items: protoCollection,
                objectCreationFunc: o => new UserAssignedIdentity(o).Freeze());

            converted = UtilitiesInternal.CreateObjectWithNullCheck(converted, o => o.Freeze());

            return converted;
        }

        /// <summary>
        /// Converts a collection of protocol layer objects to object layer collection objects, with each object marked readonly
        /// and returned as a readonly collection.
        /// </summary>
        internal static IReadOnlyList<UserAssignedIdentity> ConvertFromProtocolCollectionReadOnly(IEnumerable<Models.UserAssignedIdentity> protoCollection)
        {
            IReadOnlyList<UserAssignedIdentity> converted =
                UtilitiesInternal.CreateObjectWithNullCheck(
                    UtilitiesInternal.CollectionToNonThreadSafeCollection(
                        items: protoCollection,
                        objectCreationFunc: o => new UserAssignedIdentity(o).Freeze()), o => o.AsReadOnly());

            return converted;
        }

        #endregion // Internal/private methods
    }
}