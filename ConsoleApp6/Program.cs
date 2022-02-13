using Lab3_for_IT;
using KeyValuePair = Lab3_for_IT.KeyValuePair;

var list = new LinkedList();
list.Add(new KeyValuePair("key1","value1"));
list.Add(new KeyValuePair("key2","value2"));
list.Add(new KeyValuePair("key3","value3"));
Console.WriteLine(list.GetItemWithKey("key1").Value);
list.RemoveByKey("key2");
Console.WriteLine(list.GetItemWithKey("key3").Value);
Console.WriteLine(list.GetItemWithKey("key2").Value);
Console.WriteLine(list.GetItemWithKey("nothing").Value);