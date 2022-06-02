using MVP_Hotel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;

namespace MVP_Hotel.Converters
{
    class RoomConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null)
            {
                int parse1, parse2;
                if (!int.TryParse(values[0].ToString(), out parse1)) parse1 = 0;
                if (!int.TryParse(values[2].ToString(), out parse2)) parse2 = 0;
                return new Room()
                {
                    Room_ID = parse1,
                    Type = values[1].ToString(),
                    Price = parse2
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
