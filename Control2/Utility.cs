using System;
using System.Collections.Generic;
using System.Text;

namespace Control2
{
    static class Utility
    {
        public static void ShowFiles(File[] files)
        {
            Console.WriteLine("Text files: \t");
            foreach (var file in files)
            {

                if (file is TextFile)
                {
                    var textFile = (TextFile)file;
                    textFile.ShowFile(textFile);
                }
            }
            Console.WriteLine("Movies:");
            foreach (var file in files)
            {

                if (file is Movie)
                {
                    var movie = (Movie)file;
                    movie.ShowFile(movie);

                }
            }
            Console.WriteLine("Images: \t");
            foreach (var file in files)
            {

                if (file is Image)
                {
                    var image = (Image)file;
                    image.ShowFile(image);

                }
            }
        }
        public static File[] SortFiles(File [] files)
        {
            File temp;
            for (int i = 0; i < files.Length - 1; i++)
            {
                bool f = false;
                for (int j = 0; j < files.Length - i - 1; j++)
                {
                    if (files[j + 1].GetNumberSize() > files[j].GetNumberSize())
                    {
                        f = true;
                        temp = files[j + 1];
                        files[j + 1] = files[j];
                        files[j]= temp;
                    }
                }
                if (!f) break;
            }
            return files;
        }
    }
}
