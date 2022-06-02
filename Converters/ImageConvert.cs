using MVP_Hotel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace MVP_Hotel.Converters
{
    class ImageConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null)
            {
                int parse;
                if (!int.TryParse(values[0].ToString(), out parse)) parse = 0;
                return new Image()
                {
                    Room_ID = parse,
                    Path = values[1].ToString()
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            //Person pers = value as Person;
            //object[] result = new object[2] { pers.Name, pers.Address };
            //return result;
            throw new NotImplementedException();
        }
    }
}
