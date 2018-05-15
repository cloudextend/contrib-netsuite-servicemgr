// Generator { Name = "BaseRefGenerator", Template = "IReference" }

using System;
using System.Collections.Generic;

namespace SuiteTalk
{

    partial class RecordRef : IReference, IEqaulityComparer<RecordRef>
    {
        public virtual string GetInternalId() => this.internalId;
        public virtual string GetExternalId() => this.externalId;

        public virtual void SetInternalId(string internalId) => this.internalId = internalId;
        public virtual void SetExternalId(string externalId) => this.externalId = externalId;
    }

    partial class InitializeAuxRef : IReference, IEqaulityComparer<InitializeAuxRef>
    {
        public virtual string GetInternalId() => this.internalId;
        public virtual string GetExternalId() => this.externalId;

        public virtual void SetInternalId(string internalId) => this.internalId = internalId;
        public virtual void SetExternalId(string externalId) => this.externalId = externalId;
    }

    partial class InitializeRef : IReference, IEqaulityComparer<InitializeRef>
    {
        public virtual string GetInternalId() => this.internalId;
        public virtual string GetExternalId() => this.externalId;

        public virtual void SetInternalId(string internalId) => this.internalId = internalId;
        public virtual void SetExternalId(string externalId) => this.externalId = externalId;
    }

    partial class CustomTransactionRef : IReference, IEqaulityComparer<CustomTransactionRef>
    {
        public virtual string GetInternalId() => this.internalId;
        public virtual string GetExternalId() => this.externalId;

        public virtual void SetInternalId(string internalId) => this.internalId = internalId;
        public virtual void SetExternalId(string externalId) => this.externalId = externalId;
    }

    partial class CustomRecordRef : IReference, IEqaulityComparer<CustomRecordRef>
    {
        public virtual string GetInternalId() => this.internalId;
        public virtual string GetExternalId() => this.externalId;

        public virtual void SetInternalId(string internalId) => this.internalId = internalId;
        public virtual void SetExternalId(string externalId) => this.externalId = externalId;
    }
}