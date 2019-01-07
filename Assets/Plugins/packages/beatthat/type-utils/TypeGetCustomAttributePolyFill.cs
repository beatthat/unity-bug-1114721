using System;

namespace BeatThat.TypeExts
{
#if !NET_4_6
    public static class TypeGetCustomAttributePolyFill
	{
		public static T GetCustomAttribute<T>(
			this Type t,
			bool inherit = true
		)
			where T : Attribute
		{
			var all = t.GetCustomAttributes (typeof(T), inherit);
			return all != null && all.Length > 0 ? all [0] as T: null;
		}
	}
	#endif
}

