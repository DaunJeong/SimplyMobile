using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace SimplyMobile.Core
{
	public abstract class ViewModel : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation
		/// <summary>
		/// Occurs when property is changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		/// <summary>
		/// Unbind all handlers from property changed event.
		/// </summary>
		public void Unbind()
		{
			this.PropertyChanged = null;
		}

		/// <summary>
		/// Changes the property if the value is different and invokes PropertyChangedEventHandler.
		/// </summary>
		/// <param name="property">Property.</param>
		/// <param name="value">Value.</param>
		/// <param name="propertyName">Property name.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		protected void ChangeAndNotify<T>(ref T property, T value,  [CallerMemberName] string propertyName = "")
		{
			if (!EqualityComparer<T>.Default.Equals(property, value))
			{
				property = value;
				NotifyPropertyChanged (propertyName);
			}
		}

		/// <summary>
		/// Notifies the property changed.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
		protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected string GetMemberName([CallerMemberName] string propertyName = "")
		{
			return propertyName;
		}
	}
}

