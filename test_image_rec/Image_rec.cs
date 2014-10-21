using System.Collections.Generic;
using System.Drawing;

namespace test_image_rec
{
    class ImageRec
    {
        public ImageRec(Bitmap imageSourseBitmap, List<int> red, List<int> green, List<int> blue)
        {
            ImageSourseBitmap = imageSourseBitmap;
            Red = red;
            Green = green;
            Blue = blue;
        }

        public Bitmap ImageSourseBitmap { get; set; }

        public List<int> Red { get; set; }

        public List<int> Green { get; set; }

        public List<int> Blue { get; set; }
    }
}
