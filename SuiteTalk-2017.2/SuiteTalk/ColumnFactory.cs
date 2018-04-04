using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    abstract class ColumnFactory<T> where T: SearchRowBasic
    {
        private readonly WeakReference<Dictionary<string, Action<T>>> columnBuilders;
        private readonly object builderLock = new object();

        protected abstract Dictionary<string, Action<T>> InitializeColumnBuilders();

        public ColumnFactory()
        {
            var builders = this.InitializeColumnBuilders();
            this.columnBuilders = new WeakReference<Dictionary<string, Action<T>>>(builders);
        }

        public void BuildColumn(T rowBasic, string columnName)
        {
            var builders = this.GetBuilders();
            this.BuildColumn(builders, rowBasic, columnName);
        }

        private Dictionary<string, Action<T>> GetBuilders()
        {
            if (columnBuilders.TryGetTarget(out Dictionary<string, Action<T>> builders))
            {
                return builders;
            }
            else
            {
                lock(builderLock)
                { 
                    if (!columnBuilders.TryGetTarget(out builders))
                    {
                        builders = this.InitializeColumnBuilders();
                        columnBuilders.SetTarget(builders);
                    }
                    return builders;
                }
            }
        }

        private void BuildColumn(Dictionary<string, Action<T>> builders, T rowBasic, string columnName)
        {
            if (builders.TryGetValue(columnName, out Action<T> builder))
            {
                builder(rowBasic);
            }
            else
            {
                throw new ArgumentException($"{typeof(T).Name} does not have a colum named {columnName}");
            }
        }
    }
}
