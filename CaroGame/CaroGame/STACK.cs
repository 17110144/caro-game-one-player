using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGame
{
    class STACK<T>  //đây là kỹ thuật generic của ngôn ngữ C# cho chép người dùng có thể
                    //thể đưa bất cứ kiểu dữ liệu nào vào class này
    {
        private T[] a = new T[100]; 
        private int _top = -1;

        public T[] A { get => a; set => a = value; }
        public int Top { get => _top; set => _top = value; }

        public void Push(T x)
        {
            this.A[Top + 1] = x;
            this.Top++;
        }
        public T Pop()
        {
            T t = this.A[this.Top];
            this.Top--;
            return t;
        }     
        public int Count()
        {
            return this.Top + 1;
        }
        public void Clear()
        {
            while (this.Top != -1)
            {
                this.Top--;               
            }
        }
        public bool isEmpty()
        {
            if (this.Top == -1)
                return true;
            return false;
        }
    }
}
