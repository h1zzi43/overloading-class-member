using System;
using System.Collections.Generic;

namespace App.IndexerOverloading.Task1_SimpleDictionary
{
    public class MultiKeyDictionary
    {
        private readonly Dictionary<string, int> _simpleDictionary;
        private readonly Dictionary<(string category, string key), int> _compositeDictionary;

        public MultiKeyDictionary()
        {
            _simpleDictionary = new Dictionary<string, int>();
            _compositeDictionary = new Dictionary<(string category, string key), int>();
        }

        // Индексатор по строковому ключу
        public int this[string key]
        {
            get
            {
                if (_simpleDictionary.TryGetValue(key, out int value))
                {
                    return value;
                }
                throw new KeyNotFoundException($"Key '{key}' not found in the dictionary.");
            }
            set
            {
                _simpleDictionary[key] = value;
            }
        }

        // Индексатор по составному ключу (два строковых параметра)
        public int this[string category, string key]
        {
            get
            {
                var compositeKey = (category, key);
                if (_compositeDictionary.TryGetValue(compositeKey, out int value))
                {
                    return value;
                }
                throw new KeyNotFoundException($"Composite key ('{category}', '{key}') not found in the dictionary.");
            }
            set
            {
                var compositeKey = (category, key);
                _compositeDictionary[compositeKey] = value;
            }
        }
    }
}