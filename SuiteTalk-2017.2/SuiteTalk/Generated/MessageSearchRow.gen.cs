using System;

namespace SuiteTalk
{
    public partial class MessageSearchRow: SearchRow
    {
        public SearchRowBasic GetBasic() => this.basic;

        public SearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new MessageSearchRowBasic();
            return this.basic;
        }

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        private static SearchRowBasic GetOrCreateJoin(MessageSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

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