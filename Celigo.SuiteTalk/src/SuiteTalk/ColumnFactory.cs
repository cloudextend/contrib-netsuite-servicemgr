using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    abstract class ColumnFactory<T> where T: SearchRowBasic
    {
        private readonly object _builderLock = new object();

        private WeakReference<Dictionary<string, Action<T>>> _columnBuilders;

        protected abstract Dictionary<string, Action<T>> InitializeColumnBuilders();

        protected ColumnFactory()
        {
        }

        public void BuildColumn(T rowBasic, string columnName)
        {
            var builders = this.GetBuilders();
            this.BuildColumn(builders, rowBasic, columnName);
        }

        private Dictionary<string, Action<T>> GetBuilders()
        {
            if (_columnBuilders != null && _columnBuilders.TryGetTarget(out Dictionary<string, Action<T>> builders))
            {
                return builders;
            }
            else
            {
                lock(_builderLock)
                { 
                    if (_columnBuilders == null)
                    {
                        builders = this.InitializeColumnBuilders();
                        _columnBuilders = new WeakReference<Dictionary<string, Action<T>>>(builders);
                    }
                    else if (!_columnBuilders.TryGetTarget(out builders))
                    {
                        builders = this.InitializeColumnBuilders();
                        _columnBuilders.SetTarget(builders);
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
