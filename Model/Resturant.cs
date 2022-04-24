namespace NTUT_Resturant_Finding_Assistant
{
    public class Resturant
    {   public int Id { get; set; }
        public string Name { get; set; }
        public string Style { get; set; }
        public int PriceClass { get; set; }
        public double Distance { get; set; }
        public string Address { get; set; }
        public double Rating { get; set; }
        
        private enum PriceClassEnum
        {
            Cheap = 0,
            Normal = 1,
            Expensive = 2
        }
        public string getPriceLabel()
        {
            switch (PriceClass)
            {
                case (int)PriceClassEnum.Cheap:
                    return "Cheap";
                case (int)PriceClassEnum.Normal:
                    return "Normal";
                case (int)PriceClassEnum.Expensive:
                    return "Expensive";
                default:
                    return "Wrong Class";
            }
        }      
    }
}