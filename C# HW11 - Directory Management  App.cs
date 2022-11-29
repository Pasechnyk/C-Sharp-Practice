using System;
using System.IO;

namespace Directory
{
    // Task - create Menu app using files an directories classes
    public class AppMenu
    {
        // create file and directory
        const string filePath = @"file.txt";
        const string dirPath = "Directory";

        FileInfo file = new FileInfo(filePath);
        DirectoryInfo dir = new DirectoryInfo(dirPath);

        // menu methods with files
        public void AddFile()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            File.Create(filePath).Close();
            File.WriteAllText(filePath, "New file was created!");
        }

        public void ReadFile()
        {
            Console.WriteLine("File information:" +
                $"Name: {file.Name}\n" +
                $"Creation Time: {file.CreationTime}\n" +
                $"Size (MB): {file.Length / 1024.0 / 1024}\n" +
                $"Last Access: {file.LastAccessTime}");

            Console.WriteLine($"\n{new string('-', 40)}\n");
        }

        // menu methods with directory
        public void MoveToDirectory()
        {
            if (!File.Exists("Directory/file.txt"))
            {
                File.Copy(filePath, "Directory/file.txt");
            }
        }

        // move directory content to given destination
        public void MoveToDestination(string destination)
        {
            var files = new DirectoryInfo(dirPath).GetFiles();

            foreach (FileInfo file in files)
            {
                file.MoveTo(destination + file.Name);
            }
        }

        public void AddDirectory()
        {
            if (dir.Exists)
            {
                Console.WriteLine("Directory already exist!");
            }
            else { dir.Create(); }
        }

        public void ReadDirectory()
        {
            Console.WriteLine("Directory information:" +
                $"Name: {dir.Name}\n" +
                $"Creation Time: {dir.CreationTime}\n" +
                $"Last Access: {file.LastAccessTime}");
        }

        public void DeleteDirectory()
        {
            dir.Delete();
            Console.WriteLine("Directory was deleted!");
        }

        public void ShowContent()
        {
            FileInfo[] files = dir.GetFiles("*.txt", SearchOption.AllDirectories);

            Console.WriteLine("Files:");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"\tfile [{i}] - {files[i].Name}");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // initializing Menu class
            AppMenu app = new AppMenu();

            Console.WriteLine("----------------------- DIRECTORY MENU -----------------------");
            Console.WriteLine($"Choose the option: \n [1] - Add new File \n [2] - Show information about file " +
                $"\n [3] - Add new Directory \n [4] - Move files " +
                $"\n [5] - Show infromation about directory \n [6] - Delete your directory " +
                $"\n [7] - Show directory content \n [8] - Move to destination");
           
            int option;
            option = Console.Read();
            switch(option)
            {
                case 1:
                    app.AddFile();
                    break;
                case 2:
                    app.ReadFile();
                    break;
                case 3:
                    app.AddDirectory();
                    break;
                case 4:
                    app.MoveToDirectory();
                    break;
                case 5:
                    app.ReadDirectory();
                    break;
                case 6:
                    app.DeleteDirectory();
                    break;
                case 7:
                    app.ShowContent();
                    break;
                case 8:
                    {
                        Console.WriteLine("Please enter the directory you want to move the files into:");
                        string destination = Console.ReadLine();
                        app.MoveToDestination(destination);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
