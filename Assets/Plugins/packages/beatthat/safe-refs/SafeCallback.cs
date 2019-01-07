using UnityEngine;

namespace BeatThat.SafeRefs
{
    /// <summary>
    /// For the case where you want to use a closure from a Monobehaviour 
    /// without risking a NullRef error on the callback if the monobehaviour gets destroyed, say, by a scene change.
    /// 
    /// Wraps callbacks with a check that the owner is still valid or some other user-defined cancel condition.
    /// </summary>
    public static class SafeCallback 
	{
		/// <summary>
		/// Wrap the specified callback.
		/// Proceeds with callback ONLY if cancelCondition returns TRUE.
		/// If the cancelCondition returns FALSE, cancels the callaback
		/// </summary>
		public static System.Action<T> Wrap<T>(System.Action<T> cb, System.Func<bool> cancelCondition)
		{
			return (T result) => {
				if(!cancelCondition()) {
					return;
				}
				cb(result);
			};
		}

		public static System.Action<T> Wrap<T>(System.Action<T> cb, GameObject owner)
		{
			return Wrap<T>(cb, () => { return (owner != null); });
		}

		public static System.Action<T> Wrap<T>(System.Action<T> cb, Component owner)
		{
			return Wrap<T>(cb, owner.gameObject);
		}

		public static System.Action Wrap(System.Action cb, System.Func<bool> cancelCondition)
		{
			return () => {
				if(!cancelCondition()) {
					return;
				}
				cb();
			};
		}
		
		public static System.Action Wrap(System.Action cb, GameObject owner)
		{
			return Wrap(cb, () => { return (owner != null); });
		}
		
		public static System.Action Wrap(System.Action cb, Component owner)
		{
			return Wrap(cb, owner.gameObject);
		}
	}
}

