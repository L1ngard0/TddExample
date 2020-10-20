using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class LinearEquation
    {
        private List<double> coeff = new List<double>();

        public int Size => coeff.Count; 

        public LinearEquation(string _coeff) 
        {
            char[] sym = new char[] { ' ', '\t', '\n', '\r', ',' };
            string[] arr = _coeff.Split(sym, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = arr[i].Replace('.', ',');
                coeff.Add(double.Parse(arr[i]));
            }
        }

        public LinearEquation(double[] _coeff) 
        {
            coeff = _coeff.ToList();
        }

        public LinearEquation(List<double> _coeff)
        {
            coeff = _coeff.ToList();
        }

        public LinearEquation(IEnumerable<double> _coeff)
        {
            coeff = _coeff.ToList();
        } 
        public LinearEquation(int n)
        {
            if (n <= 0)
                throw new ArgumentException();
            for (int i = 0; i <= n; ++i)
                coeff.Add(0);
        }

        public void RandomIn()
        {
            Random Rand = new Random();
            for (int i = 0; i < Size; ++i)
                coeff[i] = Rand.Next(0, 100);

        }

        public void SameIn(double x) 
        {
            for (int i = 0; i < Size; ++i)
                coeff[i] = x;
        }

        public double this[int index] 
        {
            get
            { 
                if (index < 0 || index >= Size)
                    throw new IndexOutOfRangeException();
                return coeff[index];
            }
            set
            { 
                if (index < 0 || index >= Size)
                    throw new IndexOutOfRangeException();
                coeff[index] = value;
            }
        }

        public static LinearEquation operator +(LinearEquation a, LinearEquation b)//сложение
        {
            var res = a.coeff.Zip(b.coeff, (first, second) => first + second);
            return new LinearEquation(res);

        }

        public static LinearEquation operator -(LinearEquation a, LinearEquation b)//вычитание
        {
            var res = a.coeff.Zip(b.coeff, (first, second) => first - second);
            return new LinearEquation(res);
        }

        public static LinearEquation operator *(LinearEquation a, double r)//умножение справа
        {
            List<double> res = new List<double>();
            for (int i = 0; i < a.Size; ++i)
                res.Add(a[i] * r);
            return new LinearEquation(res);
        }
        public static LinearEquation operator *(double r, LinearEquation a)//умножение слева
        {
            return a * r;
        }

        public static LinearEquation operator -(LinearEquation a)//умножение на -1
        {
            List<double> res = new List<double>();
            for (int i = 0; i < a.Size; ++i)
                res.Add(-a[i]);
            return new LinearEquation(res);
        }

        public static bool operator ==(LinearEquation a, LinearEquation b) //равно
        {
            return a.Equals(b);
        }
        public static bool operator !=(LinearEquation a, LinearEquation b) //не равно
        {
            if (a.Equals(b)) return false;
            else return true;
        }

        public static bool operator false(LinearEquation a)
        {
            if (a) return false;
            else return true;
        }
        public static bool operator true(LinearEquation a)
        {
            for (int i = 0; i < a.Size - 1; ++i)
                if (a[i] != 0) return true;
            if (a[a.Size - 1] == 0) return true;
            else return false;


        }

        public override string ToString()
        {
            string res = "";
            int i;
            for (i = 0; i < Size - 2; i++)
                res += (coeff[i + 1] >= 0) ? (coeff[i].ToString() + 'x' + (i + 1).ToString() + '+') :
                    (coeff[i].ToString() + 'x' + (i + 1).ToString());
            res += coeff[i].ToString() + 'x' + (i + 1).ToString();
            res += '=' + coeff[Size - 1].ToString();
            return res;


        }

        public static implicit operator double[](LinearEquation a) //в массив
        {
            return a.coeff.ToArray();
        }

        public bool IsNull() 
        {
            for (int i = 0; i < Size; ++i)
                if (this[i] != 0) return false;
            return true;
        }


        public void CopyTo(LinearEquation b)
        {
            b.coeff = coeff.ToList();
        }
        public override bool Equals(object obj)
        {
            LinearEquation b = (LinearEquation)obj;
            for (int i = 0; i < Size; ++i)
                if (Math.Abs(this[i] - b[i]) > 1e-9) return false;
            return true;
        }


    }
}