//using System;
//using System.Collections.Generic;

//namespace SuiteTalk
//{
//    public partial class SearchRecord
//    {
//        internal class Meta<T> where T: SearchRecord
//        {
//            protected readonly Dictionary<string, Func<T, SearchRecordBasic>> criteriaGetters;
//            protected readonly Dictionary<string, Action<T, SearchRecordBasic>> criteriaSetters;

//            public Meta()
//            {
//                this.criteriaGetters = new Dictionary<string, Func<T, SearchRecordBasic>>();
//                this.criteriaSetters = new Dictionary<string, Action<T, SearchRecordBasic>>();
//            }

//            public Func<T, SearchRecordBasic> GetCriteriaGetter(string criteriaName)
//            {
//                if (this.criteriaGetters.TryGetValue(criteriaName, out Func<T, SearchRecordBasic> getter))
//                {
//                    return getter;
//                }
//                else
//                {
//                    throw new ArgumentException($"{typeof(T).Name} does not have a join by the name of {criteriaName}");
//                }
//            }

//            public Action<T, SearchRecordBasic> GetCriteriaSetter(string criteriaName)
//            {
//                if (this.criteriaSetters.TryGetValue(criteriaName, out Action<T, SearchRecordBasic> setter))
//                {
//                    return setter;
//                }
//                else
//                {
//                    throw new ArgumentException($"{typeof(T).Name} does not have a join by the name of {criteriaName}");
//                }
//            }

//            protected static void TypeCheckedSetter<CriteriaType>(T source, SearchRecordBasic criteria, Action<T, SearchRecordBasic> setter)
//            {
//                if (criteria == null || criteria is CriteriaType)
//                {
//                    setter(source, criteria);
//                }
//                else
//                {
//                    throw new ArgumentException($"Expected a criteria of {typeof(CriteriaType).Name}. But got {criteria.GetType().Name} instad.");
//                }
//            }
//        }
//    }
//}
