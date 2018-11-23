using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame
{
    class STACK<T>
    {
        private T[] a = new T[100]; 
        private int top = -1;

        public T[] A { get => a; set => a = value; }
        public int Top1 { get => top; set => top = value; }

        public void Push(T x)
        {
            this.A[Top1 + 1] = x;
            this.Top1++;
        }
        public T Top()
        {
            return this.A[this.Top1];
        }
        public T Pop()
        {
            T t = this.A[this.Top1 + 1];
            this.Top1--;
            return t;
        }
        public int Count()
        {
            int dem = 0;
            int temtop = this.Top1;
            while(this.Top1 != -1)
            {
                dem++;
                temtop--;
            }
            return dem;
        }
        public void Clear()
        {
            while (this.Top1 != -1)
            {
                this.Top1--;
            }
        }
    }
}
