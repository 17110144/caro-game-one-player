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
        public void Push(T x)
        {
            this.a[top + 1] = x;
            this.top++;
        }
        public T Top()
        {
            return this.a[this.top];
        }
        public T Pop()
        {
            T t = this.a[this.top + 1];
            this.top--;
            return t;
        }
        public int Count()
        {
            int dem = 0;
            int temtop = this.top;
            while(this.top != -1)
            {
                dem++;
                temtop--;
            }
            return dem;
        }
        public void Clear()
        {
            while (this.top != -1)
            {
                this.top--;
            }
        }
    }
}
