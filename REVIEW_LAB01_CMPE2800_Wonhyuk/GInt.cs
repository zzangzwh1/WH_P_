//**************************************************************************************
// Name : Wonhyuk Cho
// Instructor : Simon Walker
// Date : 2022-Jan-16
// SVN Sub Code : CMPE2800_1212_L01Assignment
// CMPE2800 – Lab01 – Review (GInt, Term 1212 Version)
// you will implement addition, subtraction, multiplication, and optionally integer division
//on arbitrary sized unsigned integers. In elementary school you learned how to perform long form of
//these operations. You will now write code to exercise these operations. The standard UInt32 and UInt64
//types you have been using are, of course, range limited. You will create a new type that has no
//estriction on unsigned range
//**************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REVIEW_LAB01_CMPE2800_Wonhyuk
{
   public class GInt : IComparable
    {
        // List<byte> 
        //that will manage the digits of the number it represents
        //This will be the only data member in
        //this user-defined type you will create.
        private List<byte> _list = new List<byte>();

        //empty (default state of zero)
        public GInt()
        {
            _list.Add(0);

        }

        //Construction from UInt64 will require that the newly constructed GInt contains an appropriate
        //representation of the initializing value.This will include the full range of UInt64.
        public GInt(UInt64 a)
        {
            string value = a.ToString();
            foreach (char c in value)
            {
                if (c >= '0' && c <= '9')
                    _list.Add((byte)(Convert.ToByte(c) - 48));
                else
                    throw new IndexOutOfRangeException("Error");
            }
        }
        //Construction from string will transform the ASCII string representation into correct digit information.
        //Any unexpected characters(anything outside the range ‘0’-‘9’) will cause an argument exception.These
        // strings may be ~any length.
        public GInt(string s)
        {
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                    //add byte
                    _list.Add((byte)(Convert.ToByte(c) - 48));
                else
                    throw new IndexOutOfRangeException("Error");
            }

        }
        //constructor that accepts Gint g
        public GInt(GInt g)
        {
            _list = g._list;
        }
        /// <summary>
        ///   public GInt Add(GInt g)
        ///   compare count of Gint and add 
        /// </summary>
        /// <param name="g">Gint</param>
        /// <returns></returns>
        public GInt Add(GInt g)
        {   //create temp list
            List<byte> temp = new List<byte>();
            //Helper that check the counts of lists
            Helper(g);

            byte num = 0;
            for (int i = 0; i < _list.Count; ++i)
            {
                //add last element of list and glist element
                byte sum = (byte)(_list[_list.Count - 1 - i] + g._list[_list.Count - 1 - i]);
                // when lower greater 10 amount of(sum and num)
                if (sum + num >= 10)
                {

                    temp.Add((byte)(sum + num - 10));
                    //num for next element when adding
                    //when num added and over 10 1 must be added on next element
                    num = 1;
                }
                else
                {
                    if (num > 0 && sum + num < 10)
                    {
                        temp.Add((byte)(sum + num));
                        num = 0;
                    }
                    else
                        temp.Add(sum);
                }
            }
            //add num into temp
            if (num > 0)
                temp.Add(num);
            //reverse
            temp.Reverse();
            //create string and input through foreach loop
            string st = "";
            foreach (byte b in temp)
            {
                st += b;
            }

            return new GInt(st);

        }
        /// <summary>
        /// public void Helper(GInt g)
        /// check the count of two lists
        /// when counts is different creating 0 infront of lower count list
        /// and match the count of list 
        /// </summary>
        /// <param name="g">Gint</param>
        public void Helper(GInt g)
        {
            //compare the counts of list and g list
            if (_list.Count > g._list.Count)
            {
                g._list.Reverse();
                //add zero until list count and g list count is same
                while (_list.Count > g._list.Count)
                    g._list.Add(0);

                g._list.Reverse();

            }
            //when glist count have more count than list count
            else
            {
                _list.Reverse();
                //add zero until list count and list count is same
                while (g._list.Count > _list.Count)
                    _list.Add(0);

                _list.Reverse();
            }
        }
        /// <summary>
        /// public static GInt Add(GInt a, GInt b)
        /// adding between Gint a and Gint b
        /// </summary>
        /// <param name="a">first Gint</param>
        /// <param name="b">2nd Gint</param>
        /// <returns></returns>
        public static GInt Add(GInt a, GInt b)
        {
            //create temp list
            List<byte> temp = new List<byte>();
            byte num = 0;
            //already mentioned on helper method
            // this check the counts of a list and b list for adding
            // when they are not matching counts then add 0 so it matched and
            // able to add
            if (a._list.Count > b._list.Count)
            {
                b._list.Reverse();
                //add zero until a list count and b list count is same
                while (a._list.Count > b._list.Count)
                    b._list.Add(0);
                b._list.Reverse();
            }
            else
            {
                a._list.Reverse();
                //add zero until b list count and a list count is same
                while (b._list.Count > a._list.Count)
                    a._list.Add(0);
                a._list.Reverse();
            }
            for (int i = 0; i < a._list.Count; ++i)
            {
                //110-059
                //add last element of a list and b list element
                byte sum = (byte)(a._list[a._list.Count - 1 - i] + b._list[b._list.Count - 1 - i]);
                if (sum + num >= 10)
                {
                    temp.Add((byte)(sum + num - 10));
                    //num for next element when adding
                    //when num added and over 10 1 must be added on next element
                    num = 1;
                }
                else
                {
                    if (num > 0 && sum + num < 10)
                    {
                        temp.Add((byte)(sum + num));
                        num = 0;
                    }
                    else
                        temp.Add(sum);
                }
            }
            //add num into temp list
            if (num > 0)
                temp.Add(num);

            temp.Reverse();
            //create string and input through foreach loop
            string st = "";
            foreach (byte bs in temp)
            {
                st += bs;
            }

            return new GInt(st);

        }
        /// <summary>
        ///  public GInt Sub(GInt g)
        ///  opposite way of add method
        ///  substract gints
        /// </summary>
        /// <param name="g"> Gint</param>
        /// <returns></returns>
        public GInt Sub(GInt g)
        {
            if (this.CompareTo(g) < 0)
                throw new ArgumentException($"{g.Sub(this)}");

            //create temp list
            List<byte> temp = new List<byte>();
            //Helper that check the counts of lists
            Helper(g);
            byte sum = 0;
            byte num = 0;
            for (int i = 0; i < _list.Count; ++i)
            {
                //byte a position and b position
                byte a = _list[_list.Count - 1 - i];
                byte b = g._list[_list.Count - 1 - i];
                //when num is greater than 0
                if (num > 0)
                {
                    if (a - num >= b)
                    {
                        //sum is a- num -b
                        sum = (byte)(a - num - b);
                        //num 0
                        num = 0;
                        //add it to temp 
                        temp.Add(sum);
                    }
                    else
                    {
                        //sum should be a- num +10 -b
                        sum = (byte)(a - num + 10 - b);
                        temp.Add(sum);
                    }
                }

                //44-40
                else
                {
                    //when a is greater than b
                    if (a > b)
                    {
                        //sum should be a -b
                        sum = (byte)(a - b);
                        temp.Add(sum);
                    }
                    else if (a == b)
                    {
                        sum = (byte)(a - b);
                        temp.Add(sum);
                    }
                    else
                    {
                        num = 1;
                        sum = (byte)(a + 10 - b);
                        temp.Add(sum);
                    }

                }

            }
            //reverse
            temp.Reverse();
            // remove 0 
            //if there 0 exists infront of number forexample 06 , 07
            //remove 0
            foreach (byte b in temp.ToList())
            {
                if (b == 0 && temp.Count > 1)
                    temp.Remove(b);
                else
                    break;
            }

            // create string that temp has
            string st = "";
            foreach (byte b in temp)
            {
                st += b;
            }
            //return
            return new GInt(st);

        }
        /// <summary>
        /// public GInt SMult(GInt g)
        /// slow multiplication 
        /// compare two gints and add the larger number of  smaller number amount
        /// for example if test code have 5 gint and 3 gint 
        /// 5+5+5 
        /// </summary>
        /// <param name="g">gint</param>
        /// <returns></returns>
        public GInt SMult(GInt g)
        {
            //create Gint
            GInt b = new GInt();
            //compare gints and when this(Gint) is greater than instance gint g
            if (this.CompareTo(g) > 0)
            {
                // counts
                while (g.CompareTo(new GInt(0)) > 0)
                {
                    //add
                    b = b.Add(this);
                    //sub 
                    g = g.Sub(new GInt(1));
                }

            }//3 5           
            else
            {
                //create Gint c
                GInt c = new GInt(this);
                //counts
                while (c.CompareTo(new GInt(0)) > 0)
                {
                    //add
                    b = b.Add(g);
                    //sub
                    c = c.Sub(new GInt(1));
                }
            }

            return b;

        }
        /// <summary>
        ///  public GInt IDiv(GInt g)
        ///  dividing
        /// </summary>
        /// <param name="g">Gint</param>
        /// <returns></returns>
        public GInt IDiv(GInt g)
        {

            Helper(g);
            //create cnt for count
            GInt cnt = new GInt(0);
            GInt c = new GInt(this);
            //compare this and instance g
            while (c.CompareTo(new GInt(g)) >= 0)
            {

                c = c.Sub(new GInt(g));
                cnt = cnt.Add(new GInt(1));
                //using foreach loop and remove 0 if 0 exists infront of count
                foreach (byte b in g._list.ToList())
                {
                    if (b == 0 && g._list.Count > 1)
                        g._list.Remove(b);
                    else
                        break;
                }

            }

            return cnt;
        }/// <summary>
         /// public GInt FMult(GInt g)
         /// fast multiplication 
         /// this will convert to string at the end and let accept huge number(string)
         /// </summary>
         /// <param name="g">Gint</param>
         /// <returns></returns>
        public GInt FMult(GInt g)
        {
            //check the list counts
            Helper(g);
            //create gint value 
            GInt value = new GInt();
            //  List<byte> temp = new List<byte>();
            int cnt = 0;

            for (int i = 0; i < _list.Count; ++i)
            {

                for (int j = 0; j < g._list.Count; ++j)
                {
                    //add value 
                    //'FO' convert E+  to 0            
                    GInt temp = new GInt((_list[i] * g._list[j]).ToString());


                    cnt = (_list.Count - i - 1) + (g._list.Count - j - 1);
                    while (cnt-- > 0)
                    {

                        temp._list.Add(0);

                        //temp._list.Remove(0);
                    }
                    value = value.Add(temp);

                    //value = value.Add(new GInt((_list[i] * Math.Pow(10, _list.Count - i - 1) * (g._list[j] * Math.Pow(10, g._list.Count - j - 1))).ToString("F0")));

                }

            }
            //remove Zero 
            foreach (byte b in value._list.ToList())
            {
                if (b == 0 && value._list.Count > 1)
                    value._list.Remove(b);
                else
                    break;
            }
            return new GInt(value);
        }
        /// <summary>
        ///  public override string ToString()
        /// overrride tostring
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //count every list and put into string and return
            string s = "";
            for (int i = 0; i < _list.Count; ++i)
            {
                s += _list[i];
            }
            return s;
        }
        /// <summary>
        ///  public int CompareTo(object obj)      
        /// </summary>
        /// <param name="obj"> object(Gint)</param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            int val = 0;
            //when obj is not Gint then throw argumentexception
            if (!(obj is GInt g))
                throw new ArgumentException();
            // when length of _list and g_list is different
            if (_list.Count != g._list.Count)
            {
                //comparing list count and glist
                val = _list.Count.CompareTo(g._list.Count);
            }
            else
            {
                for (int i = 0; i < _list.Count; ++i)
                {
                    //ex)323 321 
                    //comparing each lists position
                    if (_list[i] != g._list[i])
                    {
                        val = _list[i].CompareTo(g._list[i]);
                        break;
                    }
                }
            }

            return val; //a.CompareTo(b);
        }
        /// <summary>
        /// public override bool Equals(object obj)
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (!(obj is GInt g)) return false;
            //return tostring
            return this.ToString().Equals(g.ToString());
        }
        /// <summary>
        ///  public override int GetHashCode()
        ///  return 1
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return 1;
        }
    }
}
