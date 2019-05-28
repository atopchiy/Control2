using System;
using System.Text;

namespace Control2
{ 
    abstract class File
    {
        protected string Name { get; set; }
        protected string Extension { get; set; }
        protected string Size { get; set; }
        public abstract File ParseFile(string fileStr);
        public abstract void ShowFile(File file);
    }
    class TextFile:File
    {
        string Content { get; set; }
        public override File ParseFile(string fileStr)
        {
            var name = fileStr.Split(':')[1].Split('(')[0].Trim();
            var contentStr = fileStr.Split('.')[1];
            var extension = contentStr.Split('(')[0];
            var size = contentStr.Split('(')[1].Split(')')[0];
            var content = contentStr.Split(';')[1].Trim();
            return new TextFile { Name = name, Content = content, Size = size, Extension = extension } ;
        }

        public override void ShowFile(File file)
        {
            if(file is TextFile)
            {
                var textFile = (TextFile)file;
                var sb = new StringBuilder();
                sb.AppendFormat("\t{0}\t\n", textFile.Name);
                sb.AppendFormat("\t\tExtension: {0}\n", textFile.Extension);
                sb.AppendFormat("\t\tSize: {0}\n", textFile.Size);
                sb.AppendFormat("\t\tContent: {0}\n", textFile.Content);
                Console.WriteLine(sb.ToString());

            }
        }
    }
    class Movie: File
    {
        string Resolution { get; set; }
        string Length { get; set; }
        public override File ParseFile(string fileStr)
        {
            var name = fileStr.Split(':')[1].Split('(')[0].Trim();
            var contentStr = fileStr.Split('.')[2];
            var extension = contentStr.Split('(')[0];
            var size = contentStr.Split('(')[1].Split(')')[0];
            var resolution = contentStr.Split(';')[1];
            var length = contentStr.Split(';')[2];
            return new Movie { Name = name, Resolution = resolution, Size = size, Extension = extension, Length = length };
        }
        public override void ShowFile(File file)
        {
            if (file is Movie)
            {
                var movie = (Movie)file;
                var sb = new StringBuilder();
                sb.AppendFormat("\t{0}\t\n", movie.Name);
                sb.AppendFormat("\t\tExtension: {0}\n", movie.Extension);
                sb.AppendFormat("\t\tSize: {0}\n", movie.Size);
                sb.AppendFormat("\t\tResolution: {0}\n", movie.Resolution);
                sb.AppendFormat("\t\tLength: {0}\n", movie.Length);
                Console.WriteLine(sb.ToString());

            }
        }
    }
    class Image: File
    {
        string Resolution { get; set; }
        public override File ParseFile(string fileStr)
        {
            var name = fileStr.Split(':')[1].Split('(')[0].Trim();
            var contentStr = fileStr.Split('.')[1];
            var extension = contentStr.Split('(')[0];
            var size = contentStr.Split('(')[1].Split(')')[0];
            var resolution = contentStr.Split(';')[1].Trim();
            return new Image { Name = name, Size = size, Extension = extension, Resolution = resolution };
        }
        public override void ShowFile(File file)
        {
            if (file is Image)
            {
                var image = (Image)file;
                var sb = new StringBuilder();
                sb.AppendFormat("\t{0}\t\n", image.Name);
                sb.AppendFormat("\t\tExtension: {0}\n", image.Extension);
                sb.AppendFormat("\t\tSize: {0}\n", image.Size);
                sb.AppendFormat("\t\tResolution: {0}\n", image.Resolution);
                Console.WriteLine(sb.ToString());

            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string text = @"Text: file.txt(6B); Some string content
            Image: img.bmp(19MB); 1920х1080
            Text:data.txt(12B); Another string
            Text:data1.txt(7B); Yet another string
            Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";
            var lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var files = new File[lines.Length];
            var index = 0;
            foreach (var line in lines)
            {
                if(line.Contains("Text"))
                {
                    File file = new TextFile();
                    file = file.ParseFile(line);
                    files[index] = file;
                    index++;
                    //file.ShowFile(file);
                }
                else if(line.Contains("Image"))
                {
                    File file = new Image();
                    file = file.ParseFile(line);
                    files[index] = file;
                    index++;
                    //file.ShowFile(file);
                }
                else
                {
                    File file = new Movie();
                    file = file.ParseFile(line);
                    files[index] = file;
                    index++;
                    //file.ShowFile(file);
                }
            }
            ShowFiles(files);
        }
        static void ShowFiles(File[] files)
        {
            Console.WriteLine("Text files: \t");
            foreach (var file in files)
            {
               
                if(file is TextFile)
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
    }
}
