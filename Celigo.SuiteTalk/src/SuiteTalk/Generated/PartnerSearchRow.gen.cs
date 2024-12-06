// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class PartnerSearchRow: ISearchRow, ISearchRow<PartnerSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public PartnerSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public PartnerSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PartnerSearchRowBasic();
            return this.basic;
        }

        ISearchRow<PartnerSearchRowBasic> 
            ISearchRow<PartnerSearchRowBasic>.CreateBasic(Action<PartnerSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public PartnerSearchRow CreateBasic(Action<PartnerSearchRowBasic> initializer)
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

        ISearchRow<PartnerSearchRowBasic> 
            ISearchRow<PartnerSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public PartnerSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.campaignResponseJoin;
      //      yield return this.contactJoin;
      //      yield return this.contactPrimaryJoin;
      //      yield return this.customerJoin;
      //      yield return this.fileJoin;
      //      yield return this.messagesJoin;
      //      yield return this.messagesFromJoin;
      //      yield return this.messagesToJoin;
      //      yield return this.opportunityJoin;
      //      yield return this.taxRegistrationJoin;
      //      yield return this.transactionJoin;
      //      yield return this.userJoin;
      //      yield return this.userNotesJoin;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(PartnerSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new PartnerSearchRowBasic();
                    break;


                case "campaignResponseJoin":
                    result = target.campaignResponseJoin;
                    creator = () => target.campaignResponseJoin = new CampaignSearchRowBasic();
                    break;
        
                case "contactJoin":
                    result = target.contactJoin;
                    creator = () => target.contactJoin = new ContactSearchRowBasic();
                    break;
        
                case "contactPrimaryJoin":
                    result = target.contactPrimaryJoin;
                    creator = () => target.contactPrimaryJoin = new ContactSearchRowBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchRowBasic();
                    break;
        
                case "messagesJoin":
                    result = target.messagesJoin;
                    creator = () => target.messagesJoin = new MessageSearchRowBasic();
                    break;
        
                case "messagesFromJoin":
                    result = target.messagesFromJoin;
                    creator = () => target.messagesFromJoin = new MessageSearchRowBasic();
                    break;
        
                case "messagesToJoin":
                    result = target.messagesToJoin;
                    creator = () => target.messagesToJoin = new MessageSearchRowBasic();
                    break;
        
                case "opportunityJoin":
                    result = target.opportunityJoin;
                    creator = () => target.opportunityJoin = new OpportunitySearchRowBasic();
                    break;
        
                case "taxRegistrationJoin":
                    result = target.taxRegistrationJoin;
                    creator = () => target.taxRegistrationJoin = new EntityTaxRegistrationSearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "userNotesJoin":
                    result = target.userNotesJoin;
                    creator = () => target.userNotesJoin = new NoteSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("PartnerSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}