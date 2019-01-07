using UnityEngine;

namespace BeatThat.SafeRefs
{
    /// <summary>
    /// Holds a ref and if that ref is to a UnityEngine component, 
    /// returns the value as null if the Component's GameObject has been destroyed.
    /// 
    /// Exists to address the problem of holding references to Unity Component instances,
    /// where the Component's GameObject may be destroyed by some external actor.
    /// When this occurs, there is no way to tell from from a Component reference that it has become invalid.
    /// </summary>
    public struct SafeRef<T> where T : class
	{
		public SafeRef(T c)
		{
			m_value = default(T);
			m_gameObject = null;
			m_valueIsComponent = false;

			this.value = c;
		}

		public bool isValid
		{
			get {
				if(m_value == null) {
					return false;
				}

				if(m_valueIsComponent) {
					return m_gameObject != null;
				}

				return true;
			}
		}

		/// <summary>
		/// Perform an action on the value ONLY if it is valid (non null and not a component attached to a destroyed game object)
		/// </summary>
		/// <param name="a">The alpha component.</param>
		public void IfValid(System.Action<T> a)
		{
			var val = this.value;
			if(val != null) {
				a(val);
			}
		}

		public delegate bool CustomValidityTest(T val);

		/// <summary>
		/// returns TRUE if the ref is valid AND the passed-in function returns TRUE, e.g.
		/// 
		/// mySafeRef.ValidAnd((r) => r.someProperty == 0; });
		/// </summary>
		/// <param name="test">Additional validirty test to apply if reference is valid.</param>
		public bool ValidAnd(CustomValidityTest test)
		{
			var val = this.value;
			return val != null && test(val);
		}

		public T GetValue()
		{
			return this.value;
		}

		public T value
		{
			get {
				return this.isValid ? m_value : default(T);
			}
			set {
				m_value = value;

				var component = value as Component;
				if (component != null) {
					m_gameObject = component.gameObject;
					m_valueIsComponent = true;
				} else {
					m_gameObject = null;
					m_valueIsComponent = false;
				}
			}
		}

		private T m_value;
		private GameObject m_gameObject;
		private bool m_valueIsComponent;
	}
}

