namespace MyLinkListTask
{
    public class ListItem<T>
    {
        public ListItem()
        {
        }

        public ListItem(T value)
        {
            this.Value = value;
        }

        public ListItem(T value, ListItem<T> nextItem)
            : this(value)
        {
            this.NextItem = nextItem;
        }

        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }
    }
}
