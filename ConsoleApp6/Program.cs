using Lab3_for_IT;


var lines = File.ReadAllLines("dictionary.txt");
var dictionary = new StringsDictionary();
foreach (var line in lines)
{
    var index = line.IndexOf(';');
    dictionary.Add(line.Substring(0, index), line.Substring(index + 1));
}

Console.WriteLine(dictionary.Get("ABACUS"));
Console.WriteLine(dictionary.Get("ABADDON"));
Console.WriteLine(dictionary.GetCollisionCount());
Console.WriteLine(dictionary.GetBucketCount());