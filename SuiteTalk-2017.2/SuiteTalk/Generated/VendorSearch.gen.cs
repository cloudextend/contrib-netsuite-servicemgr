// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class VendorSearch: ISearch, ISearch<VendorSearchBasic>
    {
        public VendorSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public VendorSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new VendorSearchBasic();
            return this.basic;
        }

        ISearch<VendorSearchBasic> 
            ISearch<VendorSearchBasic>.CreateBasic(Action<VendorSearchBasic> initializer) => this.CreateBasic(initializer);

        public VendorSearch CreateBasic(Action<VendorSearchBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return this;
        }

        SearchRecordBasic ISearch.CreateBasic() => this.CreateBasic();

        public SearchRecordBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRecordBasic => (J)this.GetJoin(joinName);

        public SearchRecordBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRecordBasic => (J)this.CreateJoin(joinName);

        ISearch<VendorSearchBasic> 
            ISearch<VendorSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public VendorSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(VendorSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new VendorSearchBasic();
                    break;

                case "accountJoin":
                    result = target.accountJoin;
                    creator = () => target.accountJoin = new AccountSearchBasic();
                    break;
        
                case "campaignResponseJoin":
                    result = target.campaignResponseJoin;
                    creator = () => target.campaignResponseJoin = new CampaignSearchBasic();
                    break;
        
                case "contactJoin":
                    result = target.contactJoin;
                    creator = () => target.contactJoin = new ContactSearchBasic();
                    break;
        
                case "contactPrimaryJoin":
                    result = target.contactPrimaryJoin;
                    creator = () => target.contactPrimaryJoin = new ContactSearchBasic();
                    break;
        
                case "expAccountJoin":
                    result = target.expAccountJoin;
                    creator = () => target.expAccountJoin = new AccountSearchBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchBasic();
                    break;
        
                case "messagesJoin":
                    result = target.messagesJoin;
                    creator = () => target.messagesJoin = new MessageSearchBasic();
                    break;
        
                case "messagesFromJoin":
                    result = target.messagesFromJoin;
                    creator = () => target.messagesFromJoin = new MessageSearchBasic();
                    break;
        
                case "messagesToJoin":
                    result = target.messagesToJoin;
                    creator = () => target.messagesToJoin = new MessageSearchBasic();
                    break;
        
                case "mseSubsidiaryJoin":
                    result = target.mseSubsidiaryJoin;
                    creator = () => target.mseSubsidiaryJoin = new MseSubsidiarySearchBasic();
                    break;
        
                case "timeApproverJoin":
                    result = target.timeApproverJoin;
                    creator = () => target.timeApproverJoin = new EmployeeSearchBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
        
                case "userNotesJoin":
                    result = target.userNotesJoin;
                    creator = () => target.userNotesJoin = new NoteSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("VendorSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}