// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Compute;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> The operation to create or update the run command. </summary>
    public partial class VirtualMachineRunCommandCreateOrUpdateOperation : Operation<VirtualMachineRunCommandVirtualMachine>, IOperationSource<VirtualMachineRunCommandVirtualMachine>
    {
        private readonly OperationInternals<VirtualMachineRunCommandVirtualMachine> _operation;

        private readonly ArmResource _operationBase;

        /// <summary> Initializes a new instance of VirtualMachineRunCommandCreateOrUpdateOperation for mocking. </summary>
        protected VirtualMachineRunCommandCreateOrUpdateOperation()
        {
        }

        internal VirtualMachineRunCommandCreateOrUpdateOperation(ArmResource operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<VirtualMachineRunCommandVirtualMachine>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachineRunCommandCreateOrUpdateOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override VirtualMachineRunCommandVirtualMachine Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<VirtualMachineRunCommandVirtualMachine>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<VirtualMachineRunCommandVirtualMachine>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        VirtualMachineRunCommandVirtualMachine IOperationSource<VirtualMachineRunCommandVirtualMachine>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return new VirtualMachineRunCommandVirtualMachine(_operationBase, VirtualMachineRunCommandData.DeserializeVirtualMachineRunCommandData(document.RootElement));
        }

        async ValueTask<VirtualMachineRunCommandVirtualMachine> IOperationSource<VirtualMachineRunCommandVirtualMachine>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return new VirtualMachineRunCommandVirtualMachine(_operationBase, VirtualMachineRunCommandData.DeserializeVirtualMachineRunCommandData(document.RootElement));
        }
    }
}
