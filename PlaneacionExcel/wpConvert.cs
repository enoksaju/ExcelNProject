using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaneacionExcel
{
	public class WpConverter : System.Windows.Data.IValueConverter
	{
		public object Convert ( object value, Type targetType, object parameter, CultureInfo culture )
		{
			System.Diagnostics.Debug.WriteLine ( value.GetType().ToString() );

			double t = (double)value;
			return (int)(t - 130);
		}

		public object ConvertBack ( object value, Type targetType, object parameter, CultureInfo culture )
		{
			throw new NotImplementedException ( );
		}
	}
}
