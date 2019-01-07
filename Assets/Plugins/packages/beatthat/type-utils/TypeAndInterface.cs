using System;


namespace BeatThat.TypeUtil
{
    /// <summary>
    /// struct type class for passing around a type/interface pair
    /// </summary>
    public class TypeAndInterface  
	{
		public TypeAndInterface(Type t) :this(t, t)
		{
		}

		public TypeAndInterface(Type t, Type i)
		{
			this.concreteType = t;
			this.interfaceType = i;
		}
		
		public Type concreteType
		{
			get; set;
		}
		
		public Type interfaceType
		{
			get; set;
		}
	}
}

