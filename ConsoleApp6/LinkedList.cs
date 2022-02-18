namespace Lab3_for_IT;

public class LinkedList
{
    private class LinkedListNode
    {
        public KeyValuePair Pair { get; }

        public LinkedListNode Next { get; set; }

        public LinkedListNode(KeyValuePair pair, LinkedListNode next = null)
        {
            Pair = pair;
            Next = next;
        }
    }

    private LinkedListNode _first;

    private LinkedListNode _last;

    public void Add(KeyValuePair pair)
    {
        if (_last == null)
        {
            _last = new LinkedListNode(pair);
            _first = _last;
        }
        else
        {
            _last.Next = new LinkedListNode(pair);
            _last = _last.Next;
        }
    }
    public KeyValuePair PopFront()
    {
        if (_first == null)
        {
            return null;
        }
        var firstPair = _first.Pair;
        _first = _first.Next;
        return firstPair;
    } 
    public void RemoveByKey(string key)
    {
        if (_first.Pair.Key == key)
        {
            _first = _first.Next;
            return;
        }
        var current = _first;
        while (current.Next != null)
        {
            if(current.Next.Pair.Key == key)
            {
                current.Next = current.Next.Next;
                if (current.Next == null)
                {
                    _last = current;
                }
                return;
            }
            current = current.Next;
        }
    }
    public KeyValuePair GetItemWithKey(string key)
    {
        var current = _first;
        while (current != null)
        {
            if (current.Pair.Key == key)
            {
                return current.Pair;
            }
            current = current.Next;
        }

        return null;
    }
}