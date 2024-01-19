using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree
{
    public class Node
    {
        public int data;
        public Node lc;
        public Node rc;
        public Node(int data, Node leftchild = null, Node rightchild = null)
        {
            this.data = data;
            lc = leftchild;
            rc = rightchild;
        }
    }
    public class Tree
    {
        public Node root;
        public Tree(Node root)
        {
            this.root = root;
        }
        public void preorder(Node start)
        {
            if (start == null)
                return;
            Console.Write(start.data);
            preorder(start.lc);
            preorder(start.rc);
        }
        public void inorder(Node start)
        {
            if (start == null)
                return;
            inorder(start.lc);
            Console.Write(start.data);
            inorder(start.rc);
        }
        public void postorder(Node start)
        {
            if (start == null)
                return;
            postorder(start.lc);
            postorder(start.rc);
            Console.Write(start.data);
        }
        public int sum(Node start)
        {
            if (start == null)
                return 0;
            int s = 0;
            s += start.data;
            s += sum(start.lc);
            s += sum(start.rc);
            return s;
        }
        public int countofnodes(Node start)
        {
            if (start == null)
                return 0;
            int count = 1;
            count += countofnodes(start.lc);
            count += countofnodes(start.rc);
            return count;
        }
        public int countofleafs(Node start)
        {
            int count = 0;
            if (start == null)
                return 0;
            if (start.lc == null && start.rc == null)
                return 1;
            count += countofleafs(start.lc);
            count += countofleafs(start.rc);
            return count;
        }
        public int depth(Node start)
        {
            if (start == null)
                return 0;
            int left = depth(start.lc);
            int right = depth(start.rc);
            int max;
            if (left > right)
                max = left;
            else
                max = right;
            return max + 1;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Node f = new Node(6);
                Node e = new Node(5);
                Node d = new Node(4);
                Node c = new Node(3, leftchild: f);
                Node b = new Node(2, leftchild: d, rightchild: e);
                Node a = new Node(1, leftchild: b, rightchild: c);
                Tree t = new Tree(a);
                Console.Write("Preorder: ");
                t.preorder(t.root);
                Console.WriteLine();
                Console.Write("Inorder: ");
                t.inorder(t.root);
                Console.WriteLine();
                Console.Write("Postorder: ");
                t.postorder(t.root);
                Console.WriteLine();
                Console.WriteLine("Sum is: {0}", t.sum(a));
                Console.WriteLine("Count of nodes: {0}", t.countofnodes(a));
                Console.WriteLine("Count of leafs: {0}", t.countofleafs(a));
                Console.WriteLine("tree's depth: {0}", t.depth(a));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }   
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
