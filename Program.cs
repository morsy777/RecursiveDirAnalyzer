namespace RecursionMethods
{
    /*
     * This statement [ new String('-', 3)) ] output = "---" mean a new instance of string class and we
     * pass the char and count in the constructor to print the chars with the passed num.
     * 
     * This statement {new FileInfo(dirPath).Name} for taking an instance from FileInfo Class and (.Name) 
     * is an instance variable in a FileInfo class used to print a short file name. but fileName will
     * return the absolute file path.
     * 
     * To make method chaining like: Console.ReadLine().ToLower.Trim() , the sequence of this method must 
     * have the same return type 
     */ 

    internal class Program
    {
        static void Main()
        {
            PrintDirectoryFileSystemEntries(@"F:\C#\C# Advanced\RecursionMethods", 1); 
            PrintDirectoryFileSystemEntries(@"C:\Users\user\Downloads\Revision", 1);
            Console.WriteLine($"The Directory Size = {CalculateDirectorySize(@"F:\C#\C# Advanced\RecursionMethods")} Byte");
        }

        static void PrintDirectoryFileSystemEntries(string dirPath, int level)
        {
            // fileName = the absolute path of the file like :"F:\C#\C# Advanced\RecursionMethods\Program.cs"
            foreach (var fileName in Directory.GetFiles(dirPath))
                Console.WriteLine($"{new String('-', level)} {new FileInfo(fileName).Name}");

            // dirName = the absolute path of the directory like :"F:\C#\C# Advanced\RecursionMethods"
            foreach (var dirName in Directory.GetDirectories(dirPath))
            {
                // We call the function again and pass a dirName that contain the abs path of the current dir
                // to print the all files that exist in that dir and also print the each subDir that exist in
                // that dir with its own files(subDir) and continue untill print the all subDirs with its own files
                // after that will back into the first calling operation to continuo in the second foreach. 

                // Level represent the dir level EX: if first dir containt dir, the internal dir will have level = 2. 
                Console.WriteLine($"{new String('-', level)} {new DirectoryInfo(dirName).Name}");
                PrintDirectoryFileSystemEntries(dirName, level + 1);
            } 
        }
         



        // static long CalculateDirectorySize(string dirPath) :
        // The dir itself doesn't have a size, but we calculate the dir size upon its
        // subDirs with it's own files.
        // In this function we calculate the size of all files that exist in specific dir
        // and also calculate the size of all files that exist in the internal subDirs that
        // exist in that main dir. (specific dir)  
        static long CalculateDirectorySize(string dirPath)
        {
            long size = 0;
            foreach (var fileName in Directory.GetFiles(dirPath))
                size += new FileInfo(fileName).Length;

            foreach(var dirName in Directory.GetDirectories(dirPath))
            {
                size += CalculateDirectorySize(dirName);
            }
            return size;
        }

         

    }
}
