using System;
using static System.Console;
namespace lab6
{

    class Program
    {
        public static void Main(String[] args)
        {
          Deque q;
            do
            {
                q = new Deque();
                string Input;
                Input = ReadLine();
                for (int i = 0; i < Input.Length; i++)
                    q.insertTail(Input[i]);
                q.printDeque();
                if (!q.isPalindrome())
                    WriteLine("This is not Pallindrom. Try again"); 
            }
            while (!q.isPalindrome());// надо чтоб если строка не палиндром то заново просило строку
         //  q.printHalfDeque();
            q.printDeque();
            WriteLine("This is Pallindrom");
            WriteLine();
        }
    }
    public class Node
    {
        public char data;
        public Node next;
        public Node prev;
        public Node(char data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }
    }
    public class Deque
    {
        private Node Head;
        private Node Tail;
        private int Size;
        public Deque()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }
        public bool isEmpty()
        {
            if (this.Size == 0)
                return true;
            else
                return false;
        }
        public void insertHead(char element)
        {
            Node node = new Node(element);
            node.next = this.Head;
            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                this.Head.prev = node;
                this.Head = node;
            }
            this.Size++;
        }
        public void insertTail(char element)
        {
            Node node = new Node(element);
            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                this.Tail.next = node;
                node.prev = this.Tail;
                this.Tail = node;
            }
            this.Size++;
        }
        public void removeHead()
        {
            if (this.isEmpty() == true)
            {
                return;
            }
            Node temp = this.Head;
            this.Head = temp.next;
            if (this.Head == null)
            {
                this.Tail = null;
            }
            else
            {
                this.Head.prev = null;
            }
            this.Size--;
            temp = null;
        }
        public void removeTail()
        {
            if (this.isEmpty())
                return;
            Node temp = this.Tail;
            this.Tail = temp.prev;
            if (this.Tail == null)
            {
                this.Head = null;
            }
            else
            {
                this.Tail.next = null;
            }
            this.Size--;
            temp = null;
        }
        public Node head() => this.Head;
        
        public Node tail()=>this.Tail;
        public int size() => this.Size;
        public void printDeque()
        {
            Node node = this.Head;
            Console.Write("\nДана черга:\n");
            while (node != null)
            {
                Console.Write(node.data);
                node = node.next;
            }
            Console.Write("\n");
        }
       //проверка на паллиндром
        public bool isPalindrome()
        {
            Deque current = (Deque)this.MemberwiseClone();
            if (!current.isEmpty())
            {
                while (current.size() > 1)
                {
                    if (current.head().data == current.tail().data)
                    {
                        current.removeTail(); //вот тут начинают пропадать элементы
                        current.removeHead();
                    }
                    else
                        return false; 
                }
                this.printDeque();
                return true;
            }
            else return false;
        }
        //Написание половины палиндрома начиная с хвоста
        public void printHalfDeque()
        {
            Deque current = (Deque)this.MemberwiseClone();
            WriteLine("Half of Deque:");
            while (current.size() != 0)
            {
                Write(current.tail().data);
                //  this.insertHead(current.tail().data);
                current.removeHead();
                current.removeTail(); //вот тут вроде не пропадают элементы
            }
        }
    }
}
