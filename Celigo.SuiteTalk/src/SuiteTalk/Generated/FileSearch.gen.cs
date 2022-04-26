
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class FileSearch: ISearch, ISearch<FileSearchBasic>
    {
        public FileSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public FileSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new FileSearchBasic();
            return this.basic;
        }

        ISearch<FileSearchBasic> 
            ISearch<FileSearchBasic>.CreateBasic(Action<FileSearchBasic> initializer) => this.CreateBasic(initializer);

        public FileSearch CreateBasic(Action<FileSearchBasic> initializer)
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

        ISearch<FileSearchBasic> 
            ISearch<FileSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public FileSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(FileSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new FileSearchBasic();
                    break;

                case "shopperJoin":
                    result = target.shopperJoin;
                    creator = () => target.shopperJoin = new CustomerSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("FileSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}