using System;

namespace SuiteTalk
{
    public partial class VendorSearchRow: SearchRow, SupportsCustomSearchJoin
    {
        public SearchRowBasic GetBasic() => this.basic;

        public SearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new VendorSearchRowBasic();
            return this.basic;
        }

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(VendorSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "accountJoin":
                    result = target.accountJoin;
                    creator = () => target.accountJoin = new AccountSearchRowBasic();
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
        
                case "expAccountJoin":
                    result = target.expAccountJoin;
                    creator = () => target.expAccountJoin = new AccountSearchRowBasic();
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
        
                case "mseSubsidiaryJoin":
                    result = target.mseSubsidiaryJoin;
                    creator = () => target.mseSubsidiaryJoin = new MseSubsidiarySearchRowBasic();
                    break;
        
                case "timeApproverJoin":
                    result = target.timeApproverJoin;
                    creator = () => target.timeApproverJoin = new EmployeeSearchRowBasic();
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
                    throw new ArgumentException("VendorSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}