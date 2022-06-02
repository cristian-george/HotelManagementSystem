using System;
using System.Collections.Generic;
using System.Text;

namespace MVP_Hotel.Model
{
    public class Image : BasePropertyChanged
    {
        private int? image_id;
        public int? Image_ID
        {
            get
            {
                return image_id;
            }
            set
            {
                image_id = value;
                NotifyPropertyChanged("Image_ID");
            }
        }

        private int? room_id;
        public int? Room_ID
        {
            get
            {
                return room_id;
            }
            set
            {
                room_id = value;
                NotifyPropertyChanged("Room_ID");
            }
        }

        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                NotifyPropertyChanged("Path");
            }
        }
    }
}
