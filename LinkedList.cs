using System;

namespace ConsoleApp2
{
    class Node
    {
        public int data;
        public Node next;

        public Node(){}

        public Node(int dt)
        {
            data = dt;
            next = null;
        }
    }

    class SortedLinkedList
    {
        protected Node head;
        protected int length = 0;
        
        public SortedLinkedList() { }

        ~SortedLinkedList()
        {
            length = 0;
            while (head != null)
            {
                head = head.next;
            }
        }

        public int Length()
        {
            return length;
        }

        public void MakeEmpty()
        {
            length = 0;
            while (head != null)
            {
                head = head.next;
            }
        }

        public bool IsEmpty()
        {
            return length == 0;
        }

        public bool IsFull()
        {
            bool result = false;
            Node temp = new Node();
            if (temp == null)
                result = true;
            return result;
        }

        public void Insert(int new_data)
        {
            if (IsFull())
            {
                Console.WriteLine("List overflow!");
                return;
            }
            Node newNode = new Node(new_data);
            if (head == null || head.data >= new_data)
            {
                newNode.next = head;
                head = newNode;
                ++length;
            }
            else
            {
                Node current = head;
                while (current.next != null && current.next.data < new_data)
                {
                    current = current.next;
                }
                newNode.next = current.next;
                current.next = newNode;
                ++length;
            }
        }

        public int DeleteItem(int key)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty! There is no " + key + " element!");
                return -10000;
            }
            Node temp = head, prev = null;
            if (temp != null && temp.data == key)
            {
                head = temp.next;
                --length;
                return temp.data;
            }
            while (temp != null && temp.data < key)
            {
                prev = temp;
                temp = temp.next;
            }
            if (temp == null)
            {
                Console.WriteLine("There is no " + key + " element!");
                return -10000;
            }
            prev.next = temp.next;
            --length;
            return temp.data;
        }

        public int Search(int data)
        {
            if (IsEmpty())
            {
                Console.WriteLine("The list is empty! You can't search anything in it!");
                return -10000;
            }
            Node check = head;
            int i = 0;
            while (check != null && check.data <= data)
            {
                if (check.data == data)
                {
                    return i;
                }
                ++i;
                check = check.next;
            }
            Console.WriteLine("There is no "+ data + " element in this list!");
            return -10000;
        }

        public int Retrieve(int key)
        {
            if (IsEmpty())
            {
                Console.WriteLine("The list is empty! Insert some values!");
                return -10000;
            }
            Node current = head;
            while(current != null && current.data <= key)
            {
                if (current.data == key)
                {
                    return current.data;
                }
                current = current.next;
            }
            Console.WriteLine("There is no " + key + " value in this list!");
            return -10000;
        }

        public void Reverse()
        {
            if (IsEmpty())
            {
                Console.WriteLine("The list is empty! It can't be reversed! Insert some values!");
                return;
            }
            Node prev = null, temp = null, current = head;
            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            head = prev;
        }

        public void PrintList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Your list is empty! It can't be printed!");
                return;
            }
            Node printed = head;
            while (printed != null)
            {
                Console.Write(printed.data + " ");
                printed = printed.next;
            }
        }

        //additional problem for Lab1 in DST
        public void AppendOredered(SortedLinkedList list2)
        {
            Node current2 = list2.head;
            while (current2 != null)
            {
                Add(current2.data);
                current2 = current2.next;
            }
            current2 = head; 
            Node current;
            int save = 0;
            for (bool swap = true; swap;)
            {
                swap = false;
                for (current = current2; current.next != null; current = current.next)
                {
                    if (current.data > current.next.data)
                    {
                        save = current.data;
                        current.data = current.next.data;
                        current.next.data = save;
                        swap = true;
                    }
                }
            }
        }

        //adding to the end of a list without sorting
        public void Add(int data)
        {
            if (head == null)
                head = new Node(data);
            Node temp = head;
            while (temp.next != null)
                temp = temp.next;
            temp.next = new Node(data);
        }

        /*public bool IsEqual(SortedLinkedList list)
        {
            if (IsEmpty() || list.IsEmpty())
            {
                Console.WriteLine("One of the lists is empty! Insert some values!");
                return false;
            }
            else if (Length() != list.Length())
            {
                Console.WriteLine("These lists have different lengths! They can't be equal!");
                return false;
            }
            else
            {
                Node current = head, current2 = list.head;
                while (current != null && current2 != null)
                {
                    if (current.data != current2.data)
                    {
                        Console.WriteLine("These lists are not equal!");
                        return false;
                    }
                    current = current.next;
                    current2 = current2.next;
                }
                Console.WriteLine("These lists are equal!");
                return true;
            }
        }*/

        /*public int DeleteAverage()
        {
            if (IsEmpty())
            {
                Console.WriteLine("One of the lists is empty! Insert some values!");
                return -10000;
            }
            else
            {
                int average = RecursiveSum(head) / length, diff = Math.Abs(head.data-average), key = head.data;
                Node temp = head;
                while (temp != null)
                {
                    if (Math.Abs(temp.data-average) < diff)
                    {
                        key = temp.data;
                        diff = Math.Abs(temp.data-average);
                    }
                    temp = temp.next;
                }
                return DeleteItem(key);
            }
        }*/

        /*public int RecursiveSum(Node h)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Your list is empty! It's elements can't be summed!");
                return -10000;
            }
            else
            {
                if (h == null)
                    return 0;
                return h.data + RecursiveSum(h.next);
            }
        }

        public int RecursiveEvenSum(Node h)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Your list is empty! It's elements can't be summed!");
                return -10000;
            }
            else
            {
                if (h == null)
                    return 0;
                else if (h.data % 2 == 0)
                    return h.data + RecursiveEvenSum(h.next);
                else
                    return RecursiveEvenSum(h.next);
            }
        }

        public bool RecursiveSearch(Node h, int key)
        {
            if (IsEmpty())
            {
                Console.WriteLine("The list is empty! Insert some values!");
                return false;
            }
            else
            {
                if (h == null)
                {
                    return false;
                }
                else
                {
                    if (key == h.data)
                        return true;
                    else
                        return RecursiveSearch(h.next, key);
                }
            }
        }

        public void PrintRecursive(Node h)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Your list is empty! It can't be printed!");
                return;
            }
            else
            {
                if (h == null)
                    return;
                Console.Write(h.data + " ");
                PrintRecursive(h.next);
            }
        }*/

        
    }

    /*class SortedCircularLinkedList
    {
        protected Node head;

        public SortedCircularLinkedList() { }

        public void Add(int data)
        {
            Node current = head, newNode = new Node(data);
            if (current == null)
            {
                newNode.next = newNode; //to make it circular
                head = newNode;
            }
            else if (current.data >= data)
            {
                int swap = head.data;
                head.data = newNode.data;
                newNode.data = swap;
                newNode.next = head.next;
                head.next = newNode;
            }
            else
            {
                while (current.next != head && current.next.data < newNode.data)
                    current = current.next;
                newNode.next = current.next;
                current.next = newNode;
            }
        }

        public void Print()
        {
            if (head != null)
            {
                Node temp = head;
                do
                {
                    Console.Write(temp.data + " ");
                    temp = temp.next;
                } while (temp != head);
            }
        }
    }*/

    class Program
    {
        static void Main(string[] args)
        {
            SortedLinkedList list = new SortedLinkedList();
            Console.Write("List content: ");
            list.PrintList();
            list.Insert(-45);
            Console.WriteLine();
            Console.Write("List content: ");
            list.PrintList();
            list.Insert(0);
            Console.WriteLine();
            Console.Write("List content: ");
            list.PrintList();
            list.Insert(1235);
            Console.WriteLine();
            Console.Write("List content: ");
            list.PrintList();
            list.Insert(1);
            Console.WriteLine();
            Console.Write("List content: ");
            list.PrintList();
            list.Insert(-100);
            Console.WriteLine();
            Console.Write("List content: ");
            list.PrintList();
            Console.WriteLine("\nlength of a list: " + list.Length() + "\nRetrieving an item: " + list.Retrieve(0));
            Console.WriteLine("Retrieving an unexisting item: " + list.Retrieve(-1));
            Console.WriteLine("\nDeleting an item: " + list.DeleteItem(1235));
            Console.Write("List content after deleting: ");
            list.PrintList();
            Console.WriteLine("\nLength of a list: " + list.Length() + "\nSearching for an item and getting it's position: " + list.Search(1));
            Console.Write("Reversing a list: ");
            list.Reverse();
            list.PrintList();

            Console.WriteLine();
            SortedLinkedList list2 = new SortedLinkedList();
            list2.Insert(54);
            list2.Insert(12);
            list2.Insert(300);
            list2.Insert(54);
            list2.Insert(0);
            list2.Insert(-4);
            list2.PrintList();

            Console.WriteLine();
            list.AppendOredered(list2);
            list.PrintList();

            Console.ReadKey();
        }
    }
}