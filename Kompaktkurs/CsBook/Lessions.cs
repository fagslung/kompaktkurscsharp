using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CsBook {

    public class Lessions {

        public void DoSomething() {
            Console.WriteLine("Hello World");

            ArrayList a = new ArrayList();
            a.Add("Anton");
            a.Add("Berta");
            a.Add("Caesar");
            for (int i = 0; i < a.Count; i++) {
                Console.WriteLine(a[i]);
            }

            Hashtable phone = new Hashtable();
            phone["Müller"] = 1234;
            phone["Maier"] = 7789;
            phone["Huber"] = 009;
            foreach (DictionaryEntry x in phone) {
                Console.Write(x.Key + " = ");
                Console.WriteLine(x.Value);
            }

            StringBuilder buffer = new StringBuilder();
            buffer.Append(/*arg[0]*/"Martin.cs");
            buffer.Insert(0, "myfiles\\");
            buffer.Replace(".cs", ".exe");
            Console.WriteLine(buffer.ToString());
        }

        public Boolean Strings() {
            String s0 = "Hello";

            return s0 + " World" == "Hello World";
        }

    }

    public struct Point {
        public int x, y;

        public Point(int a, int b) {
            x = a;
            y = b;
        }

        public void MoveTo(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }

    public class Rectangle {
        Point origin; // linker unterer Eckpunkt
        public int width, height;

        public Rectangle() {
            origin = new Point(0, 0);
            width = height = 1;
        }

        public Rectangle(Point p, int w, int h) {
            origin = p;
            width = w;
            height = h;
        }

        public void MoveTo(Point p) {
            origin = p;
        }
    }

    public class Queue {
        object[] values = new object[10];
        int pos = 0;

        public void Enqueue(object x) {
            if (pos < 10) {
                values[pos] = x;
                pos++;
            } else {
                throw new Exception();
            }
        }

        public object Dequeue() {
            if (pos > 0) {
                object result = values[pos];
                pos--;
                return result;
            } else {
                throw new Exception();
            }
        }
    }

    public struct Time {
        private int h;
        private int m;
        private int s;

        public Time(int h, int m, int s) {
            this.h = h;
            this.m = m;
            this.s = s;
        }

        public override String ToString() {

            return h + ":" + m + ":" + s;
        }
        
    }

    public class FinalStateMachine {
        IEnumerator input;

        public FinalStateMachine(int[] input) {
            if (input != null) {
                this.input = input.GetEnumerator();
            }
        }

        int next() {
            if (input.MoveNext()) {
                return (int)input.Current;
            }
            throw new IndexOutOfRangeException();
        }

        public Boolean Validate() {
            int state = 0;
            int ch = next();
            Boolean result = false;

            switch (state) {
                case 0: 
                    if (ch == 'a') {
                        ch = next();
                        goto case 1;
                    } else if (ch == 'c') {
                        goto case 2;
                    } else
                        goto default;
                case 1:
                    if (ch == 'b') {
                        ch = next();
                        goto case 1;
                    } else if (ch == 'c') {
                        goto case 2;
                    } else {
                        goto default;
                    }
                case 2:
                    Console.WriteLine("input valid");
                    result = true;
                    break;
                default:
                    Console.WriteLine("illegal character: " + (char)ch);
                    break;
            }

            return result;
        }
    }

    public struct ArraySearch {
        int[] tab;

        public ArraySearch(int[] tab) {
            this.tab = tab;    
        }

        public int IndexOf(int val) {
            //int idx = -1;

            //int cur = 0;
            //while (idx == -1 && cur < tab.Length) {
            //    if (tab[cur] == val) {
            //        idx = cur;
            //    }
            //    cur++;
            //}

            //return idx;
            int idx = tab.Length - 1;
            while (idx >= 0 && tab[idx] != val) idx--;
            return idx;
        }
    }
}

namespace B {
    using System;
    using CsBook;

    public class Test {
        enum DayOfWeek {
            Mon, Tue, Wed, Thu, Fri, Sat, Sun
        }

        static System.DayOfWeek Convert(DayOfWeek d) {
            switch (d) {
                case DayOfWeek.Mon: return System.DayOfWeek.Monday;
                case DayOfWeek.Tue: return System.DayOfWeek.Tuesday;
                case DayOfWeek.Wed: return System.DayOfWeek.Wednesday;
                case DayOfWeek.Thu: return System.DayOfWeek.Thursday;
                case DayOfWeek.Fri: return System.DayOfWeek.Friday;
                case DayOfWeek.Sat: return System.DayOfWeek.Saturday;
                default /*Sun*/: return System.DayOfWeek.Sunday;
            }
        }

        //public static void Main() {
        //    Time t = new Time(21, 1, 0);
        //    Console.WriteLine(t);

        //    foreach(String day in new String[] {"Mon", "Fri"}) {
        //        DayOfWeek d = (DayOfWeek) Enum.Parse(typeof(DayOfWeek), day);
        //        Console.WriteLine(d + " " + Convert(d));
        //    }
        //}
    }


}