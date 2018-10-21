using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Threading;
using System.Numerics;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DarkOrange_UI
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    /// 
    class Vector<T>
    {
        T[] array;
        public Vector()
        {
            array = new T[0];
        }
        public Vector(int count)
        {
            array = new T[count];
        }
        public T At(int index)
        {
             
            return array[index];
        }
    
        public T back
        {
            get
            {
                return array[array.Length - 1];
            }
            set
            {
                array[array.Length - 1] = value;
            }
        }
        public void isat(int index, T value)
        {

                array[index] = value;
            
        }
        public T Front
        {
            get
            {
                return array[0];
            }
            set
            {
                array[0] = value;
            }
        }
        public void Clear()
        {
            array = new T[0];
        }

        public void Insert(int pos, T item)
        {
            Array.Resize(ref array, array.Length + 1);
            for (int i = array.Length - 1; i > pos; i--)
                array[i] = array[i - 1];
            array[pos] = item;
        }
        public void push_back(T item)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = item;
        }
        public void pop_back()
        {
            Array.Resize(ref array, array.Length - 1);
          
        }
        public void push_front(T item)
        {
            Insert(0, item);
        }
        public int Count
        {
            get
            {
                return array.Length;
            }
        }
        public T[] ToArray()
        {
            return array;
        }
    }
    public partial class Main : Window
    {
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]

        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }
     

        public Main()
        {
            try
            {
                InitializeComponent();
                formul = "0";
              
                this.MinHeight = 630.5;
                this.MinWidth = 1029.5;
                time1.Interval = TimeSpan.FromSeconds(1);
                time1.Tick += time1_tick;
                time1.IsEnabled = false;




            }
            catch
            {

            }
        }
        Vector<string> sr   = new Vector<string>();
  
       
        private void time1_tick(object sender, EventArgs e)
        {
            try
            {
                FlushMemory();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch 
            {

            }
        }
        DispatcherTimer time1 = new DispatcherTimer();
      
      
        string formul = "";
    
        
       

     

        string varibles(string y)
        {
            string res = "";
            int z = y.Length;
            bool ai = false;
            bool bi = false;
            bool ci = false;
            bool di = false;
            bool ei = false;
         
            string a = "";
            string b = "";
            string c = "";
            string d = "";
            string e = "";
         
            for (int i = 0; i < z; i++)
            {
                if (i != z - 1)
                {
                    if (y[i] == 'a' && y[i + 1] == 'v')
                    {
                        i++;
                        if (ai == false)
                        {
                            a = eval(av.Text).ToString();
                          res += a;
                            ai = true;
                          
                        }
                        else
                        {
                            res += a;
                        }
                        continue;
                    }
                    if (y[i] == 'b' && y[i + 1] == 'v')
                    {
                        i++;
                        if (bi == false)
                        {
                            b = eval(bv.Text).ToString();
                            res += b;
                            bi = true;

                        }
                        else
                        {
                            res += b;
                        }
                        continue;
                    }
                    if (y[i] == 'c' && y[i + 1] == 'v')
                    {
                        i++;
                        if (ci == false)
                        {
                            c = eval(cv.Text).ToString();
                            res += c;
                            ci = true;

                        }
                        else
                        {
                            res += c;
                        }
                        continue;
                    }
                    if (y[i] == 'd' && y[i + 1] == 'v')
                    {
                        i++;
                        if (di == false)
                        {
                            d = eval(dv.Text).ToString();
                            res += d;
                            di = true;

                        }
                        else
                        {
                            res += d;
                        }
                        continue;
                    }
                    if (y[i] == 'e' && y[i + 1] == 'v')
                    {
                        i++;
                        if (ei == false)
                        {
                           e = eval(ev.Text).ToString();
                            res += e;
                            ei = true;

                        }
                        else
                        {
                            res += e;
                        }
                        continue;
                    }
                    
                }
                res += y[i];
            }
            return res;
        }
        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                m = eval(varibles(formul)).ToString();
               
                    ans.Text = m;
             
            }
            catch
            {

            }
          
      
        }
        static int FactFactor(int n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;
            bool[] u = new bool[n + 1];
            List<Tuple<int, int>> p = new List<Tuple<int, int>>();
            for (int i = 2; i <= n; ++i)
                if (!u[i])
                {

                    int k = n / i;
                    int c = 0;
                    while (k > 0)
                    {
                        c += k;
                        k /= i;
                    }

                    p.Add(new Tuple<int, int>(i, c));

                    int j = 2;
                    while (i * j <= n)
                    {
                        u[i * j] = true;
                        ++j;
                    }
                }

            int r = 1;
            for (int i = p.Count - 1; i >= 0; --i)
                r *= Convert.ToInt32(Math.Pow(p[i].Item1, p[i].Item2));
            return r;
        }
        static double dac(int facn)
        {
            if (facn < 0)
            {
                return 0;
            }
            if (facn == 0)
            {
                return 1;
            }
            else
            {
                return facn + dac(facn - 1);
            }
        }
        double sqre(double raz)
        {
            return Math.Sqrt(raz);

        }
        int NOD(int a, int b)
        {
            while (a > 0 && b > 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a + b;
        }
        void processOperator(char op, bool bol)
        {
            try
            {
                double r = 0;
                double l = 0;

                try
                {
                    r = st.back;
                    st.pop_back();
                    l = st.back;
                    st.pop_back();
                }

                catch
                {

                }

                double h = 0;
                switch (op)
                {
                    case '+':
                        st.push_back(l + r);
                        break;
                    case '-':
                        h = l - r;
                        st.push_back(h);
                        break;
                    case '*':
                        st.push_back(l * r);
                        break;
                    case '/':
                        st.push_back(l / r);
                        break;
                    case 'x':
                        st.push_back(0);
                        break;
                    case ':':
                        st.push_back(l / r);
                        break;

                    case '^':
                        if (bol == false)
                        {
                            if (l != 0)
                            {
                                if (r != 0)
                                {
                                    st.push_back(Math.Pow(l, r));
                                }
                                else
                                {
                                    st.push_back(Math.Pow(l, 2));
                                }
                            }
                            else
                            {
                                st.push_back(Math.Pow(r, 2));
                            }
                        }
                        else
                        {
                            st.push_back(Math.Pow(l, r));
                        }
                        break;


                    case '%':
                        st.push_back(Math.Round(l) % Math.Round(r));
                        break;
                    case ',':
                        double k = Convert.ToDouble(l.ToString() + System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + r.ToString());
                        st.push_back(k);
                        break;
                    case '.':
                        double k1 = Convert.ToDouble(l.ToString() + System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator + r.ToString());

                        st.push_back(k1);
                        break;

                    case '!':
                        if (l != 0)
                        {

                            st.push_back(Convert.ToDouble(FactFactor(Convert.ToInt32(l))));
                        }
                        else
                        {

                            st.push_back(Convert.ToDouble(FactFactor(Convert.ToInt32(r))));
                        }
                        break;
                    case 'f':
                        if (l != 0)
                        {

                            st.push_back(dac(Convert.ToInt32(l)));
                        }
                        else
                        {

                            st.push_back(dac(Convert.ToInt32(r)));
                        }
                        break;
                    case 'o':
                        if (l != 0)
                        {

                            st.push_back(Math.Round(l));
                        }
                        else
                        {

                            st.push_back(Math.Round(r));
                        }
                        break;

                    case 'e':
                        if (l != 0)
                        {
                            st.push_back(Math.Exp(l));

                        }
                        else
                        {
                            if (r != 0)
                            {

                                st.push_back(Math.Exp(r));
                            }
                            else
                            {
                                st.push_back(2.7182818284590452);
                            }
                        }
                        break;

                    case 'E':
                        if (l != 0)
                        {
                            st.push_back(Math.Exp(l));

                        }
                        else
                        {
                            if (r != 0)
                            {

                                st.push_back(Math.Exp(r));
                            }
                            else
                            {
                                st.push_back(2.7182818284590452);
                            }
                        }
                        break;
                    case 'u':
                        if (l != 0)
                        {
                            st.push_back(Math.Pow(l, 1 / 3.0));
                        }
                        else
                        {
                            st.push_back(Math.Pow(r, 1 / 3.0));
                        }
                        break;


                    case 'p':
                        if (l != 0 && r != 0)
                        {
                            st.push_back(l / 100 * r);
                        }
                        else
                        {
                            st.push_back(3.141592653589793);
                        };
                        break;
                    case 'g':
                        if (l != 0 && r != 0)
                        {
                            st.push_back(NOD(Convert.ToInt32(l), Convert.ToInt32(r)) + 0.0);
                        }
                        else
                        {
                            st.push_back(9.8);
                        };
                        break;
                    case 'G':
                        if (l != 0 && r != 0)
                        {
                            st.push_back(l * r / NOD(Convert.ToInt32(l), Convert.ToInt32(r)));
                        }
                        else
                        {
                            st.push_back(9.8);
                        };
                        break;
                    case 'P':

                        st.push_back(3.141592653589793);

                        break;
                    case 'z':
                        st.push_back(l / r * 100);
                        break;
                    case 'n':
                        if (l != 0)
                        {
                            st.push_back(Math.Pow(l, 3));
                        }
                        else
                        {
                            st.push_back(Math.Pow(r, 3));
                        }
                        break;
                    case 'S':
                        if (l != 0)
                        {
                            st.push_back(Math.Sinh(l));
                        }
                        else
                        {
                            st.push_back(Math.Sinh(r));
                        }
                        break;
                    case 'C':
                        if (l != 0)
                        {
                            st.push_back(Math.Cosh(l));
                        }
                        else
                        {
                            st.push_back(Math.Cosh(r));
                        }
                        break;
                    case 'T':
                        if (l != 0)
                        {
                            st.push_back(Math.Tanh(l));
                        }
                        else
                        {
                            st.push_back(Math.Tanh(r));
                        }
                        break;
                    case '#':
                        if (bol == false)
                        {
                            if (l != 0)
                            {
                                if (r != 0)
                                {
                                    st.push_back(Math.Pow(r, 1 / l));
                                }
                                else
                                {
                                    st.push_back(sqre(l));
                                }
                            }
                            else
                            {
                                st.push_back(sqre(r));
                            }
                        }
                        else
                        {
                            st.push_back(Math.Pow(r, 1 / l));
                        }
                        break;
                    case 'l':
                        if (bol == false)
                        {
                            if (l != 0 && r != 0)
                            {
                                st.push_back(Math.Log(r) / Math.Log(l));
                            }
                            else
                            {
                                if (l != 0)
                                {
                                    st.push_back(Math.Log(l) / Math.Log(2.7182818284590452));
                                }
                                else
                                {
                                    st.push_back(Math.Log(r) / Math.Log(2.7182818284590452));
                                };
                            }
                        }
                        else
                        {
                            st.push_back(Math.Log(r) / Math.Log(l));
                        }
                        break;
                    case 'L':
                        if (l != 0)
                        {
                            st.push_back(Math.Log10(l));
                        }
                        else
                        {
                            st.push_back(Math.Log10(r));
                        };
                        break;
                    case 'M':
                        if (l != 0)
                        {
                            st.push_back(memory.At(Convert.ToInt32(l)));
                        }
                        else
                        {
                            st.push_back(memory.At(Convert.ToInt32(r)));
                        };
                        break;
                    case 'm':
                        st.push_back(memory.back);
                        break;

                    case 's':
                        if (l != 0)
                        {
                            st.push_back(Math.Sin(3.141592653589793 * l / 180));
                        }
                        else
                        {
                            st.push_back(Math.Sin(3.141592653589793 * r / 180));
                        }
                        break;
                    case 'c':
                        if (l != 0)
                        {
                            st.push_back(Math.Cos(3.141592653589793 * l / 180));
                        }
                        else
                        {
                            st.push_back(Math.Cos(3.141592653589793 * r / 180));
                        }
                        break;
                    case 't':
                        if (l != 0)
                        {
                            st.push_back(Math.Tan(3.141592653589793 * l / 180));
                        }
                        else
                        {
                            st.push_back(Math.Tan(3.141592653589793 * r / 180));
                        }
                        break;

                }
            }
            catch
            {
              
                err2 er = new err2();
                er.ShowDialog();
            }
        }

        static bool isDelim(char c)
        {
            return c == ' ' || c == '=';
        }
        static bool isDigit(char c)
        {

            return c == '0' || c == '1' || c == '2' || c == '3' || c == '4' || c == '5' || c == '6' || c == '7' || c == '8' || c == '9';
        }
        static bool isOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '%' || c == '^' ||
            c == ':' || c == 'n' || c == 'u' || c == '!' || c == '#' || c == 'f' || c == 'o' || c == 'p' || c == 'z' || c == 'c' ||
            c == 'C' || c == 'S' || c == 's' || c == 'T' || c == 't' || c == 'P' || c == 'e' || c == 'L' || c == 'l' || c == 'E' || c == 'x' || c == '=' || c == 'g' || c == 'G';
        }
        static int priority(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                case ':':
                case '%':
                    return 2;

                case '^':
                case '#':
                    return 3;

                case 'n':
                case 'u':
                case 'o':
                case '!':
                case 'f':
                case 'p':
                case 'z':

                    return 4;
                case 'c':
                case 'C':
                case 'S':
                case 's':
                case 't':
                case 'T':
                case 'P':
                case 'e':
                case 'E':
                case 'l':
                case 'L':
                case 'x':
                case 'g':
                case 'G':
                    return 5;

                default:
                    return -1;
            }
        }

        Vector<double> st = new Vector<double>();
        Vector<Tuple<char, bool>> op = new Vector<Tuple<char, bool>>();
        Vector<double> memory = new Vector<double>();
        double eval(string s)
        {
            try
            {
                s += "=";
                st.Clear();

                op.Clear();
                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    if (isDelim(c) || c == '=')
                        continue;
                    if (c == '(')
                    {
                        op.push_back(new Tuple<char, bool>('(', true));
                        if (i + 1 != s.Length)
                        {
                            if (isOperator(s[i + 1]))
                            {
                                st.push_back(0);
                            }
                        }
                    }
                    else if (c == ')')
                    {
                        while (op.back.Item1 != '(')
                        {
                            char t = op.back.Item1;
                            bool t2 = op.back.Item2;
                            op.pop_back();
                            processOperator(t, t2);
                        }

                        op.pop_back();
                    }
                    else if (isOperator(c))
                    {
                        while (op.Count != 0 && priority(op.back.Item1) >= priority(c))
                        {
                            char t = op.back.Item1;
                            bool t2 = op.back.Item2;
                            op.pop_back();
                            processOperator(t, t2);
                        }
                        bool ch = true;
                        if (i == 0)
                        {
                            ch = false;
                        }
                        if (i + 1 != s.Length)
                        {
                            if (isOperator(s[i + 1]) || s[i + 1] == ')')
                            {
                                ch = false;
                                st.push_back(0);
                            }
                        }
                        if (i > 0)
                        {
                            if (isOperator(s[i - 1]) || s[i - 1] == '(')
                            {
                                ch = false;

                            }
                        }
                        op.push_back(new Tuple<char, bool>(c, ch));
                    }
                    else
                    {

                        string operand = "";
                        while (isDigit(s[i]) || s[i] == ',' || s[i] == '.')
                        {
                            if (i == s.Length)
                            {
                                break;
                            }
                            if (s[i] == '.' || s[i] == ',')
                            {
                                operand += ',';
                            }
                            else
                            {
                                operand += s[i];
                            }
                            i++;
                        }
                        --i;
                        st.push_back(Convert.ToDouble((operand)));
                    }
                }
                while (op.Count != 0)
                {
                    char t = op.back.Item1;
                    bool t2 = op.back.Item2;
                    op.pop_back();
                    processOperator(t, t2);
                }
                return st.At(0);
            }
            catch
            {
             
                err2 er = new err2();
                er.ShowDialog();
                return 0.0;
            }
        }
        string m = "";
        private void copy_Copy2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                memory.push_back(Convert.ToDouble(m));
            }
            catch
            {

            }
        }

        private void copy_Copy4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                memory.Clear();
            }
            catch
            {

            }
        }

        private void copy_Copy5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                memory.pop_back();
            }
            catch
            {

            }
        }

       
        Vector<string> formuls = new Vector<string>();
        Vector<string> ab = new Vector<string>();

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                formul = forml.Text;
            }
            catch
            {

            }
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                forml.Text=formul;
            }
            catch
            {

            }
        }

        private void button_Copy3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
