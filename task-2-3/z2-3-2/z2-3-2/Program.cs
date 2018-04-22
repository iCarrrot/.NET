using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z2_3_2
{
    class BinaryTreeNode<T> : IEnumerable<T>
    {
        public T Value { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }



        public IEnumerator<T> GetEnumerator()
        {
            yield return Value;
            if (Left!= null)
            {
                foreach (T v in Left)
                {
                    yield return v;
                }
            }
            if (Right != null)
            {
                foreach (T v in Right)
                {
                    yield return v;
                }
            }
        }
        public IEnumerable<T> GetEnumeratorBFS()
        {
            Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();
            queue.Enqueue(this);
            while(queue.Count() > 0)
            {
                BinaryTreeNode < T >  el= queue.Dequeue();

                if (el.Left != null) queue.Enqueue(el.Left);
                if (el.Right != null) queue.Enqueue(el.Right);
                yield return el.Value;
            }
        }

        public IEnumerator<T> GetEnumeratorDFSnoYield()
        {
            return new TreeEnumeratorDFS<T>(this);
        }
        public IEnumerator<T> GetEnumeratorBFSnoYield()
        {
            return new TreeEnumeratorBFS<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }

    class TreeEnumeratorDFS<T> : IEnumerator<T>, IEnumerable<T>
    {
        public BinaryTreeNode<T> current = null;
        Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();

        public TreeEnumeratorDFS(BinaryTreeNode<T> tree)
        {
            stack.Push(tree);
        }

        public T Current => current.Value;

        object IEnumerator.Current => current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (stack.Count == 0) return false;
            current = stack.Pop();
            if(current.Left != null) stack.Push(current.Left);
            if(current.Right != null) stack.Push(current.Right);
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class TreeEnumeratorBFS<T> : IEnumerator<T>
    {
        public BinaryTreeNode<T> current = null;
        Queue<BinaryTreeNode<T>> queue = new Queue<BinaryTreeNode<T>>();

        public TreeEnumeratorBFS(BinaryTreeNode<T> tree)
        {
            queue.Enqueue(tree);
        }
        public T Current => current.Value;

        object IEnumerator.Current => current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (queue.Count == 0) return false;
            current = queue.Dequeue();
            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //       12
            //     9    4
            //    6 5    8    
            BinaryTreeNode<int> tree = new BinaryTreeNode<int>()
            {
                Value = 12,
                Left = new BinaryTreeNode<int>()
                {
                    Value = 9,
                    Left = new BinaryTreeNode<int>()
                    {
                        Value = 6
                    },
                    Right = new BinaryTreeNode<int>()
                    {
                        Value = 5
                    }
                },
                Right = new BinaryTreeNode<int>()
                {
                    Value = 4,
                    
                    Right = new BinaryTreeNode<int>()
                    {
                        Value = 8
                    }
                }
            };

            Console.Write("Porządek DFS: ");
            foreach (int i in tree)
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();
            /*
            Console.Write("Porządek DFS bez yield: ");
            var DFSenum = tree.GetEnumeratorDFSnoYield();
            while (DFSenum.MoveNext())
            {
                Console.Write($"{DFSenum.Current}, ");
            }
            Console.WriteLine();
            */
            Console.Write("Porządek BFS: ");
            
            foreach (int i in tree.GetEnumeratorBFS())
            {
                Console.Write($"{i}, ");
            }
            Console.WriteLine();

            Console.Write("Porządek BFS bez Yield: ");
            var BFSenum = tree.GetEnumeratorBFSnoYield();
            while (BFSenum.MoveNext())
            {
                Console.Write($"{BFSenum.Current}, ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
