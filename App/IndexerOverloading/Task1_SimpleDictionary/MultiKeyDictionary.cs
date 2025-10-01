// Задача: Перегрузка индексаторов — MultiKeyDictionary
// Реализуйте два индексатора: по ключу и по паре (category, key).
// При чтении отсутствующих ключей кидайте KeyNotFoundException.

namespace App.IndexerOverloading.Task1_SimpleDictionary;

public class MultiKeyDictionary
{
    // Индексатор по одному ключу
    public int this[string key]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }

    // Индексатор по категории и ключу
    public int this[string category, string key]
    {
        get => throw new NotImplementedException();
        set => throw new NotImplementedException();
    }
}