// Generator { Name = "BaseRefGenerator", Template = "IReference" }

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    partial class BaseRef
    {
        public abstract string GetInternalId();
        public abstract string GetExternalId();

        public abstract void SetInternalId(string internalId);
        public abstract void SetExternalId(string externalid);
    }


    partial class RecordRef : IReference
    {
        public override string GetInternalId() => this.internalId;
        public override string GetExternalId() => this.externalId;

        public override void SetInternalId(string internalId) => this.internalId = internalId;
        public override void SetExternalId(string externalId) => this.externalId = externalId;
    }

    partial class InitializeAuxRef : IReference
    {
        public override string GetInternalId() => this.internalId;
        public override string GetExternalId() => this.externalId;

        public override void SetInternalId(string internalId) => this.internalId = internalId;
        public override void SetExternalId(string externalId) => this.externalId = externalId;
    }

    partial class InitializeRef : IReference
    {
        public override string GetInternalId() => this.internalId;
        public override string GetExternalId() => this.externalId;

        public override void SetInternalId(string internalId) => this.internalId = internalId;
        public override void SetExternalId(string externalId) => this.externalId = externalId;
    }

    partial class CustomTransactionRef : IReference
    {
        public override string GetInternalId() => this.internalId;
        public override string GetExternalId() => this.externalId;

        public override void SetInternalId(string internalId) => this.internalId = internalId;
        public override void SetExternalId(string externalId) => this.externalId = externalId;
    }

    partial class CustomRecordRef : IReference
    {
        public override string GetInternalId() => this.internalId;
        public override string GetExternalId() => this.externalId;

        public override void SetInternalId(string internalId) => this.internalId = internalId;
        public override void SetExternalId(string externalId) => this.externalId = externalId;
    }
}