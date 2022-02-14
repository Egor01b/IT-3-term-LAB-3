namespace Lab3_for_IT;

public class StringsDictionary
{
    private const int InitialSize = 10;

    private LinkedList[] _buckets = new LinkedList[InitialSize];

    public void Add(string key, string value)
    {
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

