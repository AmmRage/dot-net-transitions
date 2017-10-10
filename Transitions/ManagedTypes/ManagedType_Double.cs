using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Transitions
{
	/// <summary>
	/// Manages transitions for double properties.
	/// </summary>
	internal class ManagedType_Double : IManagedType
	{
		#region IManagedType Members

		/// <summary>
		///  Returns the type managed by this class.
		/// </summary>
		public Type getManagedType()
		{
			return typeof(double);
		}

		/// <summary>
		/// Returns a copy of the double passed in.
		/// </summary>
		public object copy(object o)
		{
			double d = Convert.ToDouble(o);
            return d;
		}

		/// <summary>
		/// Returns the value between start and end for the percentage passed in.
		/// </summary>
		public object getIntermediateValue(object start, object end, double dPercentage)
		{
		    //Debug.WriteLine(start);
			double dStart = (double)start;
		    //Debug.WriteLine(start);
			double dEnd = Convert.ToDouble(end);
            //double dEnd = (double)end;
			return Utility.interpolate(dStart, dEnd, dPercentage);
		}

		#endregion
	}
}
