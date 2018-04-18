using System;
using Xunit;
using CsBook;


namespace Tests {

    public class UnitTestKompaktkurs {
        private Lessions l = null;

        public UnitTestKompaktkurs() {
            l = new Lessions();
        }

        //[Fact]
        public void Test1() {
            l.DoSomething();
        }

        //[Fact]
        public void TestStrings() {
            //Assert.True(l.Strings());

            String s0 = "Hello";
            Assert.True(String.Copy(s0) == s0);
        }

        //[Fact]
        public void TestStructs() {
            Point p;
            p.x = 1;
            p.y = 2;
            Point q = p;
            Assert.True(p.x == q.x && p.y == q.y);

            p = new Point(9, 7);
            p.MoveTo(1, 2);
            Assert.True((p.Equals(q)));
        }

        //[Fact]
        public void TestClasses() {
            Rectangle r = new Rectangle(new Point(10, 20), 5, 5);
            int area = r.width * r.height;
            Assert.True(area == 25);

            Rectangle r1 = r;
            r1.MoveTo(new Point(1, 1));
            Assert.True(r.Equals(r1));
        }

        //[Fact]
        public void TestObject() {
            object obj = new Rectangle();
            Rectangle r = (Rectangle)obj;
            obj = new int[3];
            int[] a = (int[])obj;
            string s = 123.ToString();
            Assert.True(s == "123");
            obj = 3;
            int i = (int)obj;

            obj = 123;
            s = obj.ToString();
            Assert.Equal("123", s);
        }

        //[Fact]
        public void TestQueue() {
            Queue q = new Queue();
            q.Enqueue(new Rectangle());
            q.Enqueue(3);

            Rectangle r = (Rectangle)q.Dequeue();
            int x = (int)q.Dequeue();
            Assert.Equal(3, x);
        }

        //[Fact]
        public void TestArray() {
            int[,] a = new int[2, 3];
            a[0, 0] = 4;
            a[0, 1] = 2;

            int[] b = new int[3];
            b[0] = 8;
            b[1] = 3;
            b[2] = 34;
            Array.Sort(b);
            Assert.True(b[0] == 3);
        }

        //[Fact]
        public void TestExpression() {
            Rectangle r = new Rectangle();
            int[] a = new int[2];

            Assert.True(r is Rectangle);
            Assert.True(3 is object);
            Assert.True(a is int[]);

            int x = 1000000;
            x = x * x;
            Assert.Throws<OverflowException>(() => {
                x = checked(x * x);
            });
            Assert.Throws<OverflowException>(() => {
                checked {
                    x = x * x;
                }
            });


            Type t = typeof(int);
            Assert.Equal("Int32", t.Name);

            t = 123.GetType();
            Assert.Equal("Int32", t.Name);

            //unsafe {
            //    Console.WriteLine(sizeof(int));
            //}
        }

        //[Fact]
        public void TestStatements() {
            string s = "a,b,c";
            string[] parts = s.Split(',');
            s = String.Join(" + ", parts);
            char[] arr = new char[10];
            s.CopyTo(0, arr, 0, s.Length);
            Assert.Equal(new char[] { 'a', ' ', '+', ' ', 'b', ' ', '+', ' ', 'c' , '\0'}, arr);

            System.Collections.Queue q = new System.Collections.Queue();
            q.Enqueue("Sam"); q.Enqueue("Pat");
            foreach (string s0 in q) Console.WriteLine(s0);

            FinalStateMachine fsm = new FinalStateMachine(new int[] { 'a', 'b', 'b', 'c' });
            Assert.True(fsm.Validate());
        }

        //[Fact]
        public void TestArraySearch() {
            ArraySearch s = new ArraySearch(new int[] { 3, 6, 14, 4, 12, 9, 10, 1, 5 });
            Assert.Equal(0, s.IndexOf(3));
            Assert.Equal(8, s.IndexOf(5));
            Assert.Equal(4, s.IndexOf(12));
            Assert.Equal(-1, s.IndexOf(7));
        }

        [Fact]
        public void TestEA(){
            string[] a = { "Anton", "Berta", "Caesar" };
            for (int i = 0; i < a.Length; i++) {
                Console.WriteLine("a[{0}] = {1}", i, a[i]);
            }
        }
    }
}
