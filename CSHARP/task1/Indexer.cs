using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class Indexer
    {
        double[] arr;
        int start;
        int length;

        public Indexer(double[] _arr, int _start, int _length)
        {
            if (_start < 0 || _length <= 0 || _start + _length >= _arr.Length)
                throw new ArgumentException();
            else
            {
                arr = _arr;
                start = _start;
                length = _length;
            }

        }
        public int Length => length;

        public double this[int index]
        {
            get
            {
                if (Index(index))
                    return arr[start + index];
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (Index(index))
                    arr[start + index] = value;
                else throw new IndexOutOfRangeException();
            }
        }
        private bool Index(int index)
        {
            if (index < 0 || index >= Length) return false;
            else return true;
        }
    }
}
