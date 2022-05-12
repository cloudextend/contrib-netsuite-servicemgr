
// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class MessageSearchRow: ISearchRow, ISearchRow<MessageSearchRowBasic>
    {
        public MessageSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public MessageSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new MessageSearchRowBasic();
            return this.basic;
        }

        ISearchRow<MessageSearchRowBasic> 
            ISearchRow<MessageSearchRowBasic>.CreateBasic(Action<MessageSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public MessageSearchRow CreateBasic(Action<MessageSearchRowBasic> initializer)
        {
            var rowBasic = this.CreateBasic();
            initializer(rowBasic);
            return this;
        }

        SearchRowBasic ISearchRow.CreateBasic() => this.CreateBasic();

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRowBasic => (J)this.GetJoin(joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRowBasic => (J)this.CreateJoin(joinName);

        ISearchRow<MessageSearchRowBasic> 
            ISearchRow<MessageSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public MessageSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.attachmentsJoin;
      //      yield return this.authorJoin;
      //      yield return this.campaignJoin;
      //      yield return this.caseJoin;
      //      yield return this.contactJoin;
      //      yield return this.customerJoin;
      //      yield return this.employeeJoin;
      //      yield return this.entityJoin;
      //      yield return this.opportunityJoin;
      //      yield return this.originatingLeadJoin;
      //      yield return this.partnerJoin;
      //      yield return this.recipientJoin;
      //      yield return this.transactionJoin;
      //      yield return this.userJoin;
      //      yield return this.vendorJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(MessageSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new MessageSearchRowBasic();
                    break;


                case "attachmentsJoin":
                    result = target.attachmentsJoin;
                    creator = () => target.attachmentsJoin = new FileSearchRowBasic();
                    break;
        
                case "authorJoin":
                    result = target.authorJoin;
                    creator = () => target.authorJoin = new EntitySearchRowBasic();
                    break;
        
                case "campaignJoin":
                    result = target.campaignJoin;
                    creator = () => target.campaignJoin = new CampaignSearchRowBasic();
                    break;
        
                case "caseJoin":
                    result = target.caseJoin;
                    creator = () => target.caseJoin = new SupportCaseSearchRowBasic();
                    break;
        
                case "contactJoin":
                    result = target.contactJoin;
                    creator = () => target.contactJoin = new ContactSearchRowBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "employeeJoin":
                    result = target.employeeJoin;
                    creator = () => target.employeeJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "entityJoin":
                    result = target.entityJoin;
                    creator = () => target.entityJoin = new EntitySearchRowBasic();
                    break;
        
                case "opportunityJoin":
                    result = target.opportunityJoin;
                    creator = () => target.opportunityJoin = new OpportunitySearchRowBasic();
                    break;
        
                case "originatingLeadJoin":
                    result = target.originatingLeadJoin;
                    creator = () => target.originatingLeadJoin = new OriginatingLeadSearchRowBasic();
                    break;
        
                case "partnerJoin":
                    result = target.partnerJoin;
                    creator = () => target.partnerJoin = new PartnerSearchRowBasic();
                    break;
        
                case "recipientJoin":
                    result = target.recipientJoin;
                    creator = () => target.recipientJoin = new EntitySearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "vendorJoin":
                    result = target.vendorJoin;
                    creator = () => target.vendorJoin = new VendorSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("MessageSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}