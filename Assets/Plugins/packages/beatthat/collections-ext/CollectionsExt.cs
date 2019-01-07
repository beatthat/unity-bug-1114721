using System;
using System.Collections.Generic;


namespace BeatThat.CollectionsExt
{
    public delegate ToType MapFunc<FromType, ToType>(FromType from);
    public static class Ext
	{
		/// <summary>
		/// Enable <c>ICollection.AddRange<T></c> which is normally only available on <c>IList<T></c>
		/// </summary>
		/// <param name="toC">To c.</param>
		/// <param name="fromC">From c.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static void AddRange<T>(this ICollection<T> toC, ICollection<T> fromC)
		{
			var asList = toC as List<T>;
			if(asList != null) {
				asList.AddRange(fromC);
				return;
			}

			foreach(var o in fromC) {
				toC.Add(o);
			}
		}

		public static bool AddIfMissing<T>(this ICollection<T> c, T elem)
		{
			if (c.Contains (elem)) {
				return false;
			}
			c.Add (elem);
			return true;
		}

        public static ToType[] Map<FromType,ToType>(this FromType[] a, MapFunc<FromType, ToType> mapFunc)
        {
            if(a == null) {
                return null;
            }

            var result = new ToType[a.Length];
            for (var i = 0; i < a.Length; i++) {
                result[i] = mapFunc(a[i]);
            }

            return result;
        }

        /// <summary>
        /// No-allocation method to pull a 'best' item from a collection,
        /// e.g. min or max by item value).
        /// 
        /// returns the item that would be first 
        /// if you sorted the given collection by the passed-in comparer.
        /// The result will be empty only if the passed in collection is empty
        /// </summary>
        public static bool FirstBy<T>(this IEnumerable<T> c, out T result, Comparison<T> comp)
        {
            result = default(T);

            var anySet = false;
            foreach(var x in c) {
                if(!anySet) {
                    result = x;
                    anySet = true;
                    continue;
                }

                if(comp(x, result) < 0) {
                    result = x;
                }
            }

            return anySet;
        }
	}
}



