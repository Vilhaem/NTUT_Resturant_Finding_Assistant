namespace NTUT_Resturant_Finding_Assistant
{
    public static class ResturantData
    {
        public static void Initialize(AppDbContext db)
        {
            var resturants = new List<Resturant>
            {
                new Resturant {Name = "Cafe", Style = "Cafe", PriceClass = 1, Distance = 2.5, Address = "123 Main St", Rating = 4.5 ,ImageURL="None"},
                new Resturant {Name = "Pizza", Style = "Pizza", PriceClass = 0, Distance = 1.5, Address = "123 Main St", Rating = 4.5,ImageURL="None" },
                new Resturant {Name = "Burger", Style = "Burger", PriceClass = 0, Distance = 5, Address = "123 Main St", Rating = 4.5,ImageURL="None" },
                new Resturant {Name = "Chinese", Style = "Chinese", PriceClass = 2, Distance = 2, Address = "123 Main St", Rating = 4.5,ImageURL="None" },
                new Resturant {Name = "Italian", Style = "Italian", PriceClass = 1, Distance = 1, Address = "123 Main St", Rating = 4.5,ImageURL="None" },
                new Resturant {Name = "Thai", Style = "Thai", PriceClass = 0, Distance = 0.25, Address = "123 Main St", Rating = 4.5,ImageURL="None" },
                new Resturant {Name = "Indian", Style = "Indian", PriceClass = 0, Distance = 3, Address = "123 Main St", Rating = 4.5 ,ImageURL="None"},
                new Resturant {Name = "Mexican", Style = "Mexican", PriceClass = 1, Distance = 5, Address = "123 Main St", Rating = 4.5,ImageURL="None" },
                new Resturant {Name = "Sushi", Style = "Sushi", PriceClass = 0, Distance = 4, Address = "123 Main St", Rating = 4.5 ,ImageURL="None"},
                new Resturant {Name = "Steak", Style = "Steak", PriceClass = 2, Distance = 0.6, Address = "123 Main St", Rating = 4.5 ,ImageURL="None"},
                new Resturant {Name = "Seafood", Style = "Seafood", PriceClass = 1, Distance = 2, Address = "123 Main St", Rating = 4.5,ImageURL="None"}
            };
            db.Resturants.AddRange(resturants);
            db.SaveChanges();
        }
    }
}