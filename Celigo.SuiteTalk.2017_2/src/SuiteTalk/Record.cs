//using System;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Linq.Expressions;
//using System.Reflection;

//namespace SuiteTalk
//{
//    public partial class Record : DynamicObject, IDynamicMetaObjectProvider
//    {
//        private Dictionary<string, Action<object>> _setters { get; }
//        private Dictionary<string, Func<object>> _getters { get; }

//        private readonly object initLock = new object();
//        private bool wasInitialized = false;

//        protected Dictionary<string, Action<object>> Setters {
//            get {
//                if (!wasInitialized) this.Initialize();
//                return this._setters;
//            }
//        }

//        protected Dictionary<string, Func<object>> Getters {
//            get {
//                if (!wasInitialized) this.Initialize();
//                return this._getters;
//            }
//        }

//        public Record()
//        {
//            this._setters = new Dictionary<string, Action<object>>();
//            this._getters = new Dictionary<string, Func<object>>();
//        }

//        protected virtual void Initialize()
//        {
//            lock (initLock)
//            {
//                if (!wasInitialized)
//                {
//                    var recordType = this.GetType();
//                    var publicProperties = recordType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
//                    foreach (var prop in publicProperties)
//                    {
//                        string propName = prop.Name;
//                        if (prop.IsSpecialName || prop.GetIndexParameters().Length > 0)
//                        {
//                            continue;
//                        }

//                        // Create getter if not write-only
//                        if (prop.CanRead)
//                        {
//                            var getter = prop.GetMethod;
//                            var getterExpression = Expression.Lambda<Func<object>>(
//                                            Expression.Convert(
//                                                Expression.Call(Expression.Constant(this), getter),
//                                                typeof(object)
//                                            )).Compile();
//                            this._getters[prop.Name] = getterExpression;
//                        }

//                        // Create setter if not read-only
//                        if (prop.CanWrite)
//                        {
//                            var setter = prop.SetMethod;
//                            var valueParam = Expression.Parameter(typeof(object));

//                            var setterExpression = Expression
//                                        .Lambda<Action<object>>(Expression.Call(Expression.Constant(this), setter, Expression.Convert(valueParam, prop.PropertyType)), valueParam)
//                                        .Compile();
//                            this._setters[prop.Name] = setterExpression;
//                        }

//                    }
//                    wasInitialized = true;
//                }
//            }
//        }

//        public override bool TryGetMember(GetMemberBinder binder, out object result)
//        {
//            return this.TryGetPropertyValue(binder.Name, out result);
//        }

//        protected virtual bool TryGetPropertyValue(string propertyName, out object result)
//        {
//            if (!wasInitialized) this.Initialize();

//            var getters = this.Getters;
//            if (getters.ContainsKey(propertyName))
//            {
//                result = getters[propertyName].Invoke();
//                return true;
//            }
//            else
//            {
//                result = null;
//                return false;
//            }
//        }

//        public override bool TrySetMember(SetMemberBinder binder, object value)
//        {
//            return this.TrySetPropertyValue(binder.Name, value);
//        }

//        protected virtual bool TrySetPropertyValue(string propertyName, object value)
//        {
//            if (!wasInitialized) this.Initialize();

//            var setters = this.Setters;
//            if (setters.ContainsKey(propertyName))
//            {
//                setters[propertyName].Invoke(value);
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        public object this[string propertyName]
//        {
//            get {
//                if (this.TryGetPropertyValue(propertyName, out object result))
//                {
//                    return result;
//                }
//                else
//                {
//                    throw GetInvalidPropertyNameException(propertyName);
//                }
//            }
//            set {
//                if (!this.TrySetPropertyValue(propertyName, value))
//                {
//                    throw GetInvalidPropertyNameException(propertyName);
//                }
//            }
//        }

//        private Exception GetInvalidPropertyNameException(string propertyName)
//        {
//            return new InvalidOperationException($"{this.GetType().Name} does not have a property named {propertyName}");
//        }
//    }
//}
