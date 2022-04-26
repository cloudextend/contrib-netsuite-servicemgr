
// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class CustomRecordSearchRow: ISearchRow, ISearchRow<CustomRecordSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public CustomRecordSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public CustomRecordSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new CustomRecordSearchRowBasic();
            return this.basic;
        }

        ISearchRow<CustomRecordSearchRowBasic> 
            ISearchRow<CustomRecordSearchRowBasic>.CreateBasic(Action<CustomRecordSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public CustomRecordSearchRow CreateBasic(Action<CustomRecordSearchRowBasic> initializer)
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

        ISearchRow<CustomRecordSearchRowBasic> 
            ISearchRow<CustomRecordSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public CustomRecordSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.fileJoin;
      //      yield return this.messagesJoin;
      //      yield return this.ownerJoin;
      //      yield return this.userJoin;
      //      yield return this.userNotesJoin;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(CustomRecordSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new CustomRecordSearchRowBasic();
                    break;


                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchRowBasic();
                    break;
        
                case "messagesJoin":
                    result = target.messagesJoin;
                    creator = () => target.messagesJoin = new MessageSearchRowBasic();
                    break;
        
                case "ownerJoin":
                    result = target.ownerJoin;
                    creator = () => target.ownerJoin = new EmployeeSearchRowBasic();
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
                    throw new ArgumentException("CustomRecordSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}