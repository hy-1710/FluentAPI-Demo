using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotattion
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new PlutoContext();

            //LINQ syntax

            //customize column group
            var query = (from x in context.Courses
                         where 
                          x.authorId == 1
                         orderby x.Level descending, x.Name
                         select new {Name = x.Name , Author = x.Author.Name });

            //grouping
            var query1 = (from x in context.Courses
                         group x by x.Level
                         into g
                         select g);
            foreach(var group in query1)
            {
                Console.WriteLine(group.Key);

                foreach(var course in group)
                {
                    Console.WriteLine("\t{0}", course.Name);
                }
               
            }
                      

            //Extension methods

            var courses = context.Courses.Where(c => c.Name.Contains("c#")).OrderBy(c => c.Name);

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }
        }
    }
}
