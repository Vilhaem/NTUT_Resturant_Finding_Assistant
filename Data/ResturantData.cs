namespace NTUT_Resturant_Finding_Assistant
{
    public static class ResturantData
    {
        public static void Initialize(AppDbContext db)
        {
            var resturants = new List<Resturant>
            {
                new Resturant {Id = 1, Name = "Cafe", Style = "Cafe", PriceClass = 1, Distance = 2.5, Address = "123 Main St", Rating = 4.5 },
                new Resturant {Id = 2, Name = "Pizza", Style = "Pizza", PriceClass = 0, Distance = 1.5, Address = "123 Main St", Rating = 4.5 },
                new Resturant {Id = 3, Name = "Burger", Style = "Burger", PriceClass = 0, Distance = 5, Address = "123 Main St", Rating = 4.5 },
                new Resturant {Id = 4, Name = "Chinese", Style = "Chinese", PriceClass = 2, Distance = 2, Address = "123 Main St", Rating = 4.5 },
                new Resturant {Id = 5, Name = "Italian", Style = "Italian", PriceClass = 1, Distance = 1, Address = "123 Main St", Rating = 4.5 },
                new Resturant {Id = 6, Name = "Thai", Style = "Thai", PriceClass = 0, Distance = 0.25, Address = "123 Main St", Rating = 4.5 },
                new Resturant {Id = 7, Name = "Indian", Style = "Indian", PriceClass = 0, Distance = 3, Address = "123 Main St", Rating = 4.5 },
                new Resturant {Id = 8,Name = "Mexican", Style = "Mexican", PriceClass = 1, Distance = 5, Address = "123 Main St", Rating = 4.5 },
                new Resturant {Id = 9, Name = "Sushi", Style = "Sushi", PriceClass = 0, Distance = 4, Address = "123 Main St", Rating = 4.5 },
                new Resturant {Id = 10, Name = "Steak", Style = "Steak", PriceClass = 2, Distance = 0.6, Address = "123 Main St", Rating = 4.5 },
                new Resturant {Id = 11, Name = "Seafood", Style = "Seafood", PriceClass = 1, Distance = 2, Address = "123 Main St", Rating = 4.5}
            };
            db.Resturants.AddRange(resturants);
            db.SaveChanges();
        }
    }
}