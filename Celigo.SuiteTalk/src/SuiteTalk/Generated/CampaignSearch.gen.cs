
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class CampaignSearch: ISearch, ISearch<CampaignSearchBasic>
    {
        public CampaignSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public CampaignSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new CampaignSearchBasic();
            return this.basic;
        }

        ISearch<CampaignSearchBasic> 
            ISearch<CampaignSearchBasic>.CreateBasic(Action<CampaignSearchBasic> initializer) => this.CreateBasic(initializer);

        public CampaignSearch CreateBasic(Action<CampaignSearchBasic> initializer)
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

        ISearch<CampaignSearchBasic> 
            ISearch<CampaignSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public CampaignSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(CampaignSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new CampaignSearchBasic();
                    break;

                case "campaignRecipientJoin":
                    result = target.campaignRecipientJoin;
                    creator = () => target.campaignRecipientJoin = new EntitySearchBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchBasic();
                    break;
        
                case "messagesJoin":
                    result = target.messagesJoin;
                    creator = () => target.messagesJoin = new MessageSearchBasic();
                    break;
        
                case "originatingLeadJoin":
                    result = target.originatingLeadJoin;
                    creator = () => target.originatingLeadJoin = new OriginatingLeadSearchBasic();
                    break;
        
                case "promotionCodeJoin":
                    result = target.promotionCodeJoin;
                    creator = () => target.promotionCodeJoin = new PromotionCodeSearchBasic();
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
                    throw new ArgumentException("CampaignSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}