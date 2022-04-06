namespace NTUT_Resturant_Finding_Assistant.Model
{
    public class Resturant
    {
        public string? Name { get; set; }
        public enum Style 
        {
            Chinese,
            Japanese,
            Western,
            FastFood,
            Others
        }
        
        public enum PriceLabel
        {
            Cheap,
            Normal,
            Expensive
        }
        // 
        public decimal Distance { get; set; }
        public decimal Rating { get; set; }
        public int DataID { get; set; }
        
        
    }
}