using System;
using System.Collections.Generic;

public interface CD
{
    void insert(IComparable key, object attribute);
    object find(IComparable key);
    object remove(IComparable key);
}

public interface Container
{
    bool isEmpty();
    void makeEmpty();
    int size();
}

public class TourOperator : CD, Container
{
    private Dictionary<string, Tuple<string, string>> clients;
    private string nextClientCode;

    public TourOperator(string initialClientCode)
    {
        clients = new Dictionary<string, Tuple<string, string>>();
        nextClientCode = initialClientCode;
    }

    public void insert(IComparable key, object attribute)
    {
        if (attribute is Tuple<string, string> clientInfo)
        {
            clients[(string)key] = clientInfo;
        }
    }

    public object find(IComparable key)
    {
        if (clients.TryGetValue((string)key, out var value))
        {
            return value;
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }

    public object remove(IComparable key)
    {
        if (clients.TryGetValue((string)key, out var value))
        {
            clients.Remove((string)key);
            return value;
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }

    public void add(string nome, string dest)
    {
        insert(nextClientCode, new Tuple<string, string>(nome, dest));
        nextClientCode = GenerateNextClientCode(nextClientCode);
    }

    private string GenerateNextClientCode(string currentCode)
    {
        int numericPart = int.Parse(currentCode.Substring(1));
        char letterPart = currentCode[0];
        if (numericPart == 999)
        {
            numericPart = 0;
            letterPart++;
        }
        else
        {
            numericPart++;
        }
        return $"{letterPart}{numericPart:D3}";
    }

    public bool isEmpty()
    {
        return clients.Count == 0;
    }

    public void makeEmpty()
    {
        clients.Clear();
    }

    public int size()
    {
        return clients.Count;
    }
}