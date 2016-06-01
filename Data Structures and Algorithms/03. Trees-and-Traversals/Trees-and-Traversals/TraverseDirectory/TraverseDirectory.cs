namespace TraverseDirectory
{
    using System;
    using System.IO;
    using System.Linq;

    public class TraverseDirectory
    {
        static void Main()
        {
            DriveInfo drive = new DriveInfo("C:\\");
            DirectoryInfo rootDir = drive.RootDirectory;
            var allDirectoriesInC = rootDir.GetDirectories();
            var windowsDir = rootDir.GetDirectories("Windows").FirstOrDefault();

            // Task 2.Write a program to traverse the directory C:\WINDOWS and all
            // its subdirectories recursively and to display all files matching the mask
            // *.exe. Use the class System.IO.Directory.
            
            //FindExeFilesInAllSubFoldersOf(windowsDir);

            // Task 3.Define classes File { string name, int size } and Folder 
            // { string name, File[] files, Folder[] childFolders } and using them build
            // a tree keeping all files and folders on the hard drive starting from 
            // C:\WINDOWS. Implement a method that calculates the sum of the file sizes 
            // in given subtree of the tree and test it accordingly. Use recursive DFS traversal.
            var windowsTree = CreateTreeByTraversingDirectory(windowsDir);
            Console.WriteLine(windowsTree.Name);

            // Note that you may NOT have some type of this folders, for example 
            // I didn`t had the folderContainingOneSubFolder so i made one 
            // for testing purpose 

            var folderContainingOnlyFilesAndNoSubFolders = windowsTree.ChildFolders
                .FirstOrDefault(f => f.ChildFolders.Length == 0 && f.Files.Length > 1);

            //Console.WriteLine(folderContainingOnlyFilesAndNoSubFolders.ToString());

            var folderContainingOnlyFilesSize = CalculateSumOfFilesIn(folderContainingOnlyFilesAndNoSubFolders);
            Console.WriteLine("Size of folder containing only files and no sub folders: {0}", 
                folderContainingOnlyFilesSize);

            var folderContainingOneSubFolderAndAtleastOneFileInEachFolder = windowsTree.ChildFolders
                .FirstOrDefault(f => f.ChildFolders.Length == 1 &&
                    f.Files.Length > 1 &&
                    f.ChildFolders.First().Files.Length >= 1 &&
                    f.ChildFolders.First().Files.First().Size > 0
            );

            //Console.WriteLine(folderContainingOneSubFolderAndAtleastOneFileInEachFolder.ToString());
            //foreach (var file in folderContainingOneSubFolderAndAtleastOneFileInEachFolder.ChildFolders.First().Files)
            //{
            //    Console.WriteLine(file);
            //}

            var folderContainingOneSubFolderSize = CalculateSumOfFilesIn(folderContainingOneSubFolderAndAtleastOneFileInEachFolder);
            Console.WriteLine("Size of folder containg one sub folder and atleast one file in each folder: {0}", 
                folderContainingOneSubFolderSize);

            var folderContainingMoreThanOneSubFolder = windowsTree.ChildFolders
                .FirstOrDefault(f => f.ChildFolders.Length > 1 && f.Files.Length > 1 &&
                    f.ChildFolders.FirstOrDefault().Files.Length > 1
            );

            //Console.WriteLine(folderContainingMoreThanOneSubFolder.ToString());
            //foreach (var subfolder in folderContainingMoreThanOneSubFolder.ChildFolders)
            //{
            //    Console.WriteLine(subfolder.ToString());
            //}

            var folderContainingMoreThanOneSubFolderSize = CalculateSumOfFilesIn(folderContainingMoreThanOneSubFolder);
            Console.WriteLine("Size of folder containing more than one sub folder: {0}",
                folderContainingMoreThanOneSubFolderSize);

            var folderWithNoFiles = windowsTree.ChildFolders
                .FirstOrDefault(f => f.Files.Length == 0 && f.ChildFolders.Length == 0);

            //Console.WriteLine(folderWithNoFiles.ToString());

            var folderWithNoFilesSize = CalculateSumOfFilesIn(folderWithNoFiles);
            Console.WriteLine("Size of folder with no files: {0}", folderWithNoFilesSize);
        }

        public static long CalculateSumOfFilesIn(Folder folder)
        {
            var root = folder;
            long sumOfFileSizes = 0;
            if (root.ChildFolders.Length > 0)
            {
                foreach (var childFolder in root.ChildFolders)
                {
                    var sizeOfCurrentChildFolder = CalculateSumOfFilesIn(childFolder);
                    sumOfFileSizes += sizeOfCurrentChildFolder;
                }
            }

            foreach (var file in root.Files)
            {
                sumOfFileSizes += file.Size;
            }

            return sumOfFileSizes;
        }

        public static Folder CreateTreeByTraversingDirectory(DirectoryInfo directory)
        {
            var directoryFolder = new Folder(directory.Name);
            DirectoryInfo[] subDirectories = directory.GetDirectories();
            FileInfo[] allFiles = directory.GetFiles();

            foreach (var currentFile in allFiles)
            {
                directoryFolder.AddFile(new File(currentFile.Name, currentFile.Length));
            }

            try
            {
                foreach (var subdir in subDirectories)
                {
                    var resultSubDir = CreateTreeByTraversingDirectory(subdir);
                    directoryFolder.AddFolder(resultSubDir);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }

            return directoryFolder;
        }

        public static void FindExeFilesInAllSubFoldersOf(DirectoryInfo directory)
        {
            DirectoryInfo[] subDirectories = directory.GetDirectories();
            FileInfo[] exeFiles = directory.GetFiles("*.exe");

            if (exeFiles.Length > 0)
            {
                foreach (var exe in exeFiles)
                {
                    Console.WriteLine(exe.Name);
                }
            }

            try
            {
                foreach (var subdir in subDirectories)
                {
                    FindExeFilesInAllSubFoldersOf(subdir);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
