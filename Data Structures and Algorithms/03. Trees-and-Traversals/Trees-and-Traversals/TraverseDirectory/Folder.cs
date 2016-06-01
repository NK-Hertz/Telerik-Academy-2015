namespace TraverseDirectory
{
    using System;
    using System.Collections;
    using System.Text;

    public class Folder : IEnumerable
    {
        private readonly int InitialSize = 1;
        private string name;
        private File[] files;
        private int fileIndex;
        private Folder[] childFolders;
        private int folderIndex;

        public Folder(string name)
        {
            this.Name = name;
            this.files = new File[InitialSize];
            this.childFolders = new Folder[InitialSize];
            this.fileIndex = 0;
            this.folderIndex = 0;
        }

        public File[] Files
        {
            get
            {
                var trimmedFiles = new File[this.fileIndex];
                for (int i = 0, len = this.fileIndex; i < len; i++)
                {
                    trimmedFiles[i] = this.files[i];
                }

                return trimmedFiles;
            }
        }

        public Folder[] ChildFolders
        {
            get
            {
                var trimmedChildFolders = new Folder[this.folderIndex];
                for (int i = 0, len = this.folderIndex; i < len; i++)
                {
                    trimmedChildFolders[i] = this.childFolders[i];
                }

                return trimmedChildFolders;
            }
        }

        public string Name {
            get
            {
                return this.name;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name can not be null!");
                }

                this.name = value;
            }
        }

        private void ResizeFileContainer()
        {
            var doubleSize = this.files.Length * 2;
            var doubleSizedFileContainer = new File[doubleSize];
            for (int i = 0, len = this.files.Length; i < len; i++)
            {
                doubleSizedFileContainer[i] = this.files[i];
            }

            this.files = doubleSizedFileContainer;
        }

        public void AddFile(File file)
        {
            if (file == null)
            {
                throw new ArgumentNullException("File can not be null!");
            }

            if (this.files.Length == this.fileIndex)
            {
                ResizeFileContainer();
            }

            this.files[fileIndex] = file;
            this.fileIndex++;
        }

        private void ResizeFolderContainer()
        {
            var doubleSize = this.childFolders.Length * 2;
            var doubleSizedFolderContainer = new Folder[doubleSize];
            for (int i = 0, len = this.childFolders.Length; i < len; i++)
            {
                doubleSizedFolderContainer[i] = this.childFolders[i];
            }

            this.childFolders = doubleSizedFolderContainer;
        }

        public void AddFolder(Folder folder)
        {
            if (folder == null)
            {
                throw new ArgumentNullException("Folder can not be null!");
            }

            if (this.childFolders.Length == this.folderIndex)
            {
                ResizeFolderContainer();
            }

            this.childFolders[folderIndex] = folder;
            this.folderIndex++;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("Name: {0}\n", this.Name);
            if (this.ChildFolders.Length > 0)
            {
                builder.Append("Sub Folders: ");
                for (int i = 0, len = this.ChildFolders.Length; i < len; i++)
                {
                    builder.AppendFormat("{0}, ", this.ChildFolders[i].Name);
                }

                builder.Remove(builder.Length - 2, 2);
                builder.AppendLine();
            }

            if (this.Files.Length > 0)
            {
                builder.Append("Files: ");
                for (int i = 0, len = this.Files.Length; i < len; i++)
                {
                    builder.AppendFormat("{0}, ", this.Files[i].ToString());
                }

                builder.Remove(builder.Length - 2, 2);
            }

            return builder.ToString();
        }

        // ?
        public IEnumerator GetEnumerator()
        {
            yield return this;

            if (this.ChildFolders != null)
            {
                for (int i = 0, len = this.ChildFolders.Length; i < len; i++)
                {
                    yield return this.ChildFolders[i];
                }
            }

            if (this.Files != null)
            {
                for (int i = 0, len = this.Files.Length; i < len; i++)
                {
                    yield return this.Files[i];
                }
            }
        }
    }
}
