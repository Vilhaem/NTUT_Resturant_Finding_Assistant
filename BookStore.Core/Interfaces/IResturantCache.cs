using BookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Core.Interfaces
{
    public interface IResturantCache
    {
        Resturant Get(int id);
        void Remove(int id);
        void Set(Resturant resturant);
    }
}
