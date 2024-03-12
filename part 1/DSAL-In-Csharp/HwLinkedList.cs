namespace DSAL;
public class Node<T>
{
    public T Value { get; set; }
    public Node<T>? Next { get; set; }

    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}
public class HwLinkedList<T>
{
    private Node<T>? Head { get; set; }
    private Node<T>? Tail { get; set; }
    //-------------------------------------------------
    private bool IsEmpty()
    {
        return Head == null;
    }
    private Node<T>? GetBefore(Node<T> node)
    {
        if (IsEmpty() || Head == Tail) return null;
        var current = Head;
        while (current != null)
        {
            if (current.Next == node) return current;
            current = current.Next;
        }
        return null;
    }
    public void PrintList()
    {
        var current = Head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
    //-------------------------------------------------
    public void AddLast(T value)
    {
        var newNode = new Node<T>(value);

        if (IsEmpty())
            Head = Tail = newNode;
        else
        {
            //add the newNode after last node
            //point newNode as next-node for current-last-node 
            Tail!.Next = newNode;
            //update tail reference
            Tail = newNode;
        }

    }
    public void AddFirst(T value)
    {
        var newNode = new Node<T>(value);

        if (IsEmpty())
            Tail = Head = newNode;
        else
        {
            //point current-first-node as next-node for newNode
            newNode.Next = Head;
            //update head reference
            Head = newNode;
        }
    }

    public int IndexOf(T value)
    {
        int index = 0;
        var current = Head;
        while (current != null)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, value)) return index;
            index++;
            current = current.Next;
        }
        return -1;// Not found
    }
    public bool Contains(T value)
    {
        return IndexOf(value) != -1;// Not found
    }
    public void RemoveFirst()
    {
        if (IsEmpty())
            throw new Exception();

        var secondNode = Head?.Next;
        if (secondNode != null)
        {

            //remove first-node link
            Head!.Next = null;
            //update Head reference
            Head = secondNode;
        }
    }

    public void RemoveLast()
    {
        if (IsEmpty())
            throw new Exception();
        //get before-last-node 
        var beforeLastNode = GetBefore(Tail!);
        if (beforeLastNode != null)
        {
            //remove last-node link
            beforeLastNode.Next = null;
            //update tail reference
            Tail = beforeLastNode;
        }
    }
}