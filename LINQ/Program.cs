using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
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
            string sentence = "the quick brown fox jumps over the lazy dog";
            // Split the string into individual words to create a collection.  
            // 공백(스페이스바) 기준으로 단어 쪼개서 저장
            string[] words = sentence.Split(' ');

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

            // 쿼리식 : 간결
            var query = from x in students
                        where x.Scores[0] > 90
                        orderby x.Last descending
                        select new { x.ID, Score = x.Scores[0] };

            // 메서드 : 모든 쿼리 구문 사용 가능
            var query2 = students.Where(x => x.Scores[0] > 90)
                                 .OrderByDescending(x => x.Last)
                                 .Take(3)   // 정렬된 자료 중 앞에서 부터 3개 까지 가져와라 (쿼리식으로는 불가)
                                 .Select(x => new { x.ID, Score = x.Scores[0] });


            //foreach(IGrouping<char, Student> g in query)
            foreach (var s in query)
            {
                Console.WriteLine($"\t{s.ID} {s.Score}");
            }
           
            
        }
    }
}
