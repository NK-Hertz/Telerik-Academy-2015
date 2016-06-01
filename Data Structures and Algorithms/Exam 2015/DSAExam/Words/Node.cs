namespace Words
{
    public class Node
    {
        public Node[] Letter { get; set; }
        public Node faillink { get; set; }
        public Node successlink { get; set; }
        public int Index { get; set; }

        public Node()
        {
            this.Letter = new Node[26];
            this.Index = -1;
        }
    }
}
