using System;
using System.Linq;
using University.BL.Models;
using University.BL.Repositories;
using University.BL.Repositories.Implements;

namespace University.Test
{


    internal class Program
    {
        private static readonly UniversityModel university = new UniversityModel();
        private static readonly ICourseRepository courseRepository
            = new CourseRepository(new UniversityModel());
        static void Main(string[] args)

        {

            var books = Book.Books();
            var authors = Author.Authors();


            //var courses = university.Course.ToList();
            //var courses2 = courseRepository.GetAll().Result;
            //foreach (var item in courses2)
            //{
            //    Console.WriteLine($"{item.Title} {item.Credits}");
            //}

            //Mostrar en consola los 3 libros con más ventas.
            //Mostrar en consola los 3 libros con menos ventas.
            //Mostrar en consola el autor con más libros publicados.

            var ex3 = from b in books
                      join a in authors on b.AuthorId equals a.AuthorId
                      group a by (a.AuthorId, a.Name) into Query
                      orderby Query.Count() descending
                      select Query;

            //Mostrar en consola el autor y la cantidad de libros publicados.
            //Mostrar en consola los libros publicados hace menos de 50 años.
            //Mostrar en consola el libro más viejo.

            var ex4 = books.OrderBy(x => x.PublicationDate).FirstOrDefault();

            //Mostrar en consola los autores que tengan un libro que comience con 'El'.

            var ex5 = from b in books
                      join a in authors on b.AuthorId equals a.AuthorId
                      where 
                      select Query;

            //Linq
            var ex1 = books.OrderByDescending(x => x.Sales).Take(3).ToList();
            var ex2 = books.OrderBy(x => x.Sales).Take(3).ToList();

            foreach (var item in ex2)
            {
                Console.WriteLine($"{item.Title} - {item.Sales}");
            }

            Console.ReadKey();
        }
    }
}
