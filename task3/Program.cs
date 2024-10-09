using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class ExtendedDictionaryElement<T, U, V>
{
    public T Key { get; set; }
    public U Value1 { get; set; }
    public V Value2 { get; set; }

    public ExtendedDictionaryElement(T key, U value1, V value2)
    {
        Key = key;
        Value1 = value1;
        Value2 = value2;
    }
}

public class ExtendedDictionary<T, U, V> : IEnumerable<ExtendedDictionaryElement<T, U, V>>
{
    private Dictionary<T, ExtendedDictionaryElement<T, U, V>> dictionary;

    public ExtendedDictionary()
    {
        dictionary = new Dictionary<T, ExtendedDictionaryElement<T, U, V>>();
    }

    public void Add(T key, U value1, V value2)
    {
        dictionary[key] = new ExtendedDictionaryElement<T, U, V>(key, value1, value2);
    }

    public bool Remove(T key)
    {
        return dictionary.Remove(key);
    }

    public bool ContainsKey(T key)
    {
        return dictionary.ContainsKey(key);
    }

    public bool ContainsValue(U value1, V value2)
    {
        foreach (var element in dictionary.Values)
        {
            if (EqualityComparer<U>.Default.Equals(element.Value1, value1) &&
                EqualityComparer<V>.Default.Equals(element.Value2, value2))
            {
                return true;
            }
        }
        return false;
    }

    public ExtendedDictionaryElement<T, U, V> this[T key]
    {
        get
        {
            return dictionary[key];
        }
    }

    public int Count
    {
        get { return dictionary.Count; }
    }

    public IEnumerator<ExtendedDictionaryElement<T, U, V>> GetEnumerator()
    {
        return dictionary.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

[TestFixture]
public class ExtendedDictionaryTests
{
    private ExtendedDictionary<string, int, string> dict;

    [SetUp]
    public void Setup()
    {
        dict = new ExtendedDictionary<string, int, string>();
    }

    [Test]
    public void TestAdd()
    {
        dict.Add("key1", 1, "value1");
        Assert.That(dict.ContainsKey("key1"), Is.True);
    }

    [Test]
    public void TestRemove()
    {
        dict.Add("key1", 1, "value1");
        bool removed = dict.Remove("key1");
        Assert.That(removed, Is.True);
        Assert.That(dict.ContainsKey("key1"), Is.False);
    }

    [Test]
    public void TestContainsKey()
    {
        dict.Add("key2", 2, "value2");
        Assert.That(dict.ContainsKey("key2"), Is.True);
        Assert.That(dict.ContainsKey("nonexistent"), Is.False);
    }

    [Test]
    public void TestContainsValue()
    {
        dict.Add("key2", 2, "value2");
        Assert.That(dict.ContainsValue(2, "value2"), Is.True);
        Assert.That(dict.ContainsValue(3, "value3"), Is.False);
    }

    [Test]
    public void TestIndexer()
    {
        dict.Add("key2", 2, "value2");
        var element = dict["key2"];
        Assert.That(element.Key, Is.EqualTo("key2"));
        Assert.That(element.Value1, Is.EqualTo(2));
        Assert.That(element.Value2, Is.EqualTo("value2"));
    }

    [Test]
    public void TestCount()
    {
        Assert.That(dict.Count, Is.EqualTo(0));
        dict.Add("key1", 1, "value1");
        Assert.That(dict.Count, Is.EqualTo(1));
    }

    [Test]
    public void TestEnumeration()
    {
        dict.Add("key1", 1, "value1");
        dict.Add("key2", 2, "value2");

        int count = 0;
        foreach (var elem in dict)
        {
            Assert.That(elem.Key, Is.EqualTo($"key{elem.Value1}"));
            Assert.That(elem.Value2, Is.EqualTo($"value{elem.Value1}"));
            count++;
        }
        Assert.That(count, Is.EqualTo(2));
    }

    public static void RunTests()
    {
        ExtendedDictionary<string, int, string> dict = new ExtendedDictionary<string, int, string>();

        // Тест додавання елемента
        dict.Add("key1", 1, "value1");
        Console.WriteLine($"Add test: {dict.ContainsKey("key1")}");

        // Тест видалення елемента
        dict.Remove("key1");
        Console.WriteLine($"Remove test: {!dict.ContainsKey("key1")}");

        // Тест перевірки наявності ключа
        dict.Add("key2", 2, "value2");
        Console.WriteLine($"ContainsKey test: {dict.ContainsKey("key2")}");

        // Тест перевірки наявності значення
        Console.WriteLine($"ContainsValue test: {dict.ContainsValue(2, "value2")}");

        // Тест індексатора
        var element = dict["key2"];
        Console.WriteLine($"Indexer test: {element.Key == "key2" && element.Value1 == 2 && element.Value2 == "value2"}");

        // Тест властивості Count
        Console.WriteLine($"Count test: {dict.Count == 1}");

        // Тест foreach
        foreach (var elem in dict)
        {
            Console.WriteLine($"Foreach test: {elem.Key == "key2" && elem.Value1 == 2 && elem.Value2 == "value2"}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ExtendedDictionaryTests.RunTests();
    }
}