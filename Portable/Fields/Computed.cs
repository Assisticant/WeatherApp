/**********************************************************************
 * 
 * Update Controls .NET
 * Copyright 2011 Michael L Perry
 * MIT License
 * 
 * This class based on a contribution by David Piepgrass.
 * 
 * http://updatecontrols.net
 * http://www.codeplex.com/updatecontrols/
 * 
 **********************************************************************/

using System;
using System.ComponentModel;

namespace Assisticant.Fields
{
	public class Computed<T> : Computed
	{
		protected internal T _value;
		protected Func<T> _computeValue;

		public Computed(Func<T> compute) : base(null)
		{
			_update = Update;
			_computeValue = compute;
		}
		public Computed(string name, Func<T> compute) : base(null)
		{
			_update = Update;
			_computeValue = compute;
		}

		protected void Update()
		{
			_value = _computeValue();
			// TODO: don't propagate updates when _value did not change.
			//    T oldValue = _value;
			//    _value = _computeValue();
			//    return _value == null ? oldValue != null : !_value.Equals(oldValue);
		}

		public T Value
		{
			get { base.OnGet(); return _value; }
		}
		public static implicit operator T(Computed<T> computed)
		{
			return computed.Value;
		}

        public ComputedSubscription Subscribe(Action<T> whenChanged)
        {
            return new ComputedSubscription(this, () => whenChanged(this));
        }

		[Obsolete, EditorBrowsable(EditorBrowsableState.Never)]
		public Computed ComputedSentry
		{
			get { return this; }
		}
	}
}
