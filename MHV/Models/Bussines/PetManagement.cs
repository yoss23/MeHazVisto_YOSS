using System;
using System.Collections.Generic;
using System.Drawing;//imagenes
using System.Drawing.Drawing2D;//imagenes
using System.IO;
using System.Linq;
using System.Web;

namespace MHV.Models.Bussines
{
    public class PetManagement
    {

        public static void CreateThumbNail(string fileName, string filePath, int thumbWi, int thumbHi, bool maintainAspect)
        {

            var originalFile = Path.Combine(filePath, fileName);//la variable originalFile Donde sera el nombre de la ruta y el nombre de la imagen
            var source = Image.FromFile(originalFile); // source sera la imagen
            if (source.Width <= thumbWi &&
                source.Height <= thumbHi)
                return;

            Bitmap thumbnail;
            try
            {

                int wi = thumbWi;
                int hi = thumbHi;
                if (maintainAspect)
                {
                    //mantener el aspecto de los parametros de la vista previa
                    wi = thumbWi;
                    hi = (int)(source.Height *
                        ((decimal)thumbWi / source.Width));
                }

                else
                {
                    hi = thumbHi;
                    wi = (int)(source.Width *
                        ((decimal)thumbHi / source.Height));
                }
                thumbnail = new Bitmap(wi, hi);
                using (Graphics g = Graphics.FromImage(thumbnail))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.FillRectangle(Brushes.Transparent,
                        0, 0,
                        wi, hi);
                    g.DrawImage(source, 0, 0, wi, hi);

                    var thumbnailName = Path.Combine(filePath,
                       "thumbnail_" + fileName);
                    thumbnail.Save(thumbnailName);

                }


            }

            catch
            {

            }

        }
    
    }

}