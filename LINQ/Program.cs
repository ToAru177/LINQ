using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Item
    {
        public int Id { get; set; }
        public int Score { get; set; }
    }
    public class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public List<int> Scores;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Item i1 = new Item();
            i1.Id = 1;
            i1.Score = 2;

            // object initialization expression
            Item i2 = new Item { Id = 1, Score = 2 };
            #region student
            List<Student> students = new List<Student>
            {
                new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
                new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
                new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91}}
            };
            #endregion

            /*
            var query = from x in students
                        let totalScore = x.Scores[0] + x.Scores[1] + x.Scores[2] + x.Scores[3]
                        where totalScore > 300
                        orderby totalScore descending
                        // 익명 자료형이 아닌 경우
                        select new Item { Id = x.ID, Score = totalScore };  // projection
            */

            var query = from x in students
                        let totalScore = x.Scores[0] + x.Scores[1] + x.Scores[2] + x.Scores[3]
                        where totalScore > 300
                        orderby totalScore descending
                        // 익명 자료형이 아닌 경우
                        select new { ID2 = x.ID, Score2 = totalScore };  // projection


            //foreach(IGrouping<char, Student> g in query)
            foreach (var s in query)
            {
                Console.WriteLine($"\t{s.ID2} {s.Score2}");
            }
        }
    }
}
