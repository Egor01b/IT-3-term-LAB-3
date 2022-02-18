namespace Lab3_for_IT;

public class StringsDictionary
{
    private const int InitialSize = 10;

    private LinkedList[] _buckets = new LinkedList[InitialSize];

    public void Add(string key, string value)
    {
        if (GetLoad() > 0.75)
        {
            ExpandBuckets(_buckets.Length * 2);
        }

        var bucket = CalculateHash(key) % _buckets.Length;
        if (_buckets[bucket] == null)
        {
            _buckets[bucket] = new LinkedList();
        }

        _buckets[bucket].Add(new KeyValuePair(key, value));
    }

    public void Remove(string key)
    {
        var bucket = CalculateHash(key) % _buckets.Length;
        if (_buckets[bucket] != null)
        {
            _buckets[bucket].RemoveByKey(key);
        }
    }

    public string Get(string key)
    {
        var bucket = CalculateHash(key) % _buckets.Length;
        if (_buckets[bucket] != null)
        {
            var item = _buckets[bucket].GetItemWithKey(key);
            if (item == null)
                return null;
            return item.Value;
        }

        return null;
    }

    private float GetLoad()
    {
        var full = 0;
        for (int i = 0; i < _buckets.Length; i++)
        {
            if (_buckets[i] != null)
            {
                full++;
            }
        }

        return full / _buckets.Length;
    }

    private void ExpandBuckets(int newCount)
    {
        var list = new LinkedList();
        for (int i = 0; i < _buckets.Length; i++)
        {
            if (_buckets[i] != null)
            {
                // УУбать все элементы в List
                while (true)
                {
                    var el = _buckets[i].PopFront();
                    if (el == null) // если список пуст
                    {
                        break;
                    }

                    list.Add(el);
                }
            }
        }

        _buckets = new LinkedList[newCount];
        while (true)
        {
            var el = list.PopFront();
            if (el == null) // если список пуст
            {
                break;
            }

            Add(el.Key, el.Value);
        }
    }

    private int CalculateHash(string key)
    {
        // function to convert string value to number 
        var arr = key.ToCharArray();
        var result = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            result += arr[i] * i;
        }

        result %= 2069;
        return result;
    }
}    