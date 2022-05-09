using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IBookRepository bookRepo, IAuthorRepository authRepo, IResturantRepository resturantRepo)
        {
            BookRepository = bookRepo;
            AuthorRepository = authRepo;
            ResturantRepository = resturantRepo;
        }

        public IBookRepository BookRepository { get; private set; }
        public IAuthorRepository AuthorRepository { get; private set; }
        public IResturantRepository ResturantRepository { get; private set; }
    }
}
