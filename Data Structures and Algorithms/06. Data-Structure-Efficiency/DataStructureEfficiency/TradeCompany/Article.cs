namespace TradeCompany
{
    using System;
    using System.Text;

    public class Article : IComparable
    {
        public Article()
        { }

        public Article(int barcode, string vendor, string title, decimal price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public int Barcode { get; set; }
        public string Vendor { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(object obj)
        {
            // ?? this.Barcode.Equals(other.Barcode) && this.Title.Equals(other.Title) && this.Vendor.Equals(other.Vendor) && 
            var other = (Article)obj;
            if (this.Price.Equals(other.Price))
            {
                return 0;        
            }
            else if(this.Price < other.Price)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("Title: {0}, Price: {1}", this.Title, this.Price);
            return result.ToString();
        }
    }
}
