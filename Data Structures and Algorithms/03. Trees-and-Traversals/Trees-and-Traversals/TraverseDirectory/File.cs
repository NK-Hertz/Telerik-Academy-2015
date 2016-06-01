namespace TraverseDirectory
{
    public class File
    {
        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; private set; }
        public long Size { get; private set; }

        public override string ToString()
        {
            var result = string.Format("Name: {0}, Size: {1}", this.Name, this.Size);
            return result;
        }
    }
}
