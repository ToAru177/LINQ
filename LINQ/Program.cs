using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            


            int[] ar = new int[] { 4, 8, 8, 5 };

            // LINQ
            /*
            // 열거하다..
            IEnumerable<int> query = from x in ar
                                     where x % 2 == 0
                                     orderby x descending
                                     select x;
            */

            // 짝수 이고 5보다 큰 경우
            // for문을 사용할 경우 7번 반복 실행해야 할 것을 지연실행 하면 4번만 실행 하면 된다...
            var query = from x in ar
                        where x % 2 == 0
                        select x;

            query = from x in query
                    where x > 5
                    select x;

            // 아래 문장이 시작할 때(query.ToList() 메서드가 호출 될 때) 위의 LINQ가 실행 됨
            List<int> list = query.ToList();

            int count = query.Count();
            int first = query.First();  // 원소가 없으면 예외 발생
            int last = query.LastOrDefault();   // 원소가 없으면 기본값 반환(int일 경우 0)

            IEnumerable<string> query2 = from x in query
                                         select (x * 3).ToString();

            List<string> list2 = query2.ToList();

        }
    }
}
