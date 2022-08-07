// A part of the C# Language Syntactic Sugar suite.

using System.Collections.Generic;
using System;

namespace CLSS
{
  public static partial class IDictionarySwapKeys
  {
    /// <summary>
    /// Swaps 2 elements R at the 2 specified keys in place. If either key does
    /// not exist in the source dictionary before swapping, the other key will
    /// be removed after swapping.
    /// </summary>
    /// <typeparam name="T">The type of the
    /// <see cref="IDictionary{TKey, TValue}"/> to swap keys.</typeparam>
    /// <typeparam name="TKey"><inheritdoc cref="IDictionary{TKey, TValue}"
    /// path="/typeparam[@name='TKey']"/></typeparam>
    /// <typeparam name="TValue"><inheritdoc cref="IDictionary{TKey, TValue}"
    /// path="/typeparam[@name='TValue']"/></typeparam>
    /// <param name="dictionary">A dictionary with keys of type
    /// <typeparamref name="TKey"/> and values of type
    /// <typeparamref name="TValue"/>.</param>
    /// <param name="key1">The first key to be swapped.</param>
    /// <param name="key2">The second key to be swapped.</param>
    /// <returns>The source collection.</returns>
    public static T SwapKeys<T, TKey, TValue>(this T dictionary,
      TKey key1,
      TKey key2)
      where T : IDictionary<TKey, TValue>
    {
      if (dictionary == null) throw new ArgumentNullException("dictionary");
      bool hasKey1 = dictionary.ContainsKey(key1);
      bool hasKey2 = dictionary.ContainsKey(key2);
      TValue e1 = default(TValue), e2 = default(TValue);
      if (hasKey1) { e1 = dictionary[key1]; dictionary.Remove(key1); }
      if (hasKey2) { e2 = dictionary[key2]; dictionary.Remove(key2); }
      if (hasKey1) dictionary[key2] = e1;
      if (hasKey2) dictionary[key1] = e2;
      return dictionary;
    }

    /// <inheritdoc cref="SwapKeys{T, TKey, TValue}(T, TKey, TKey)"/>
    public static IDictionary<TKey, TValue> SwapKeys<TKey, TValue>(
      this IDictionary<TKey, TValue> dictionary,
      TKey key1,
      TKey key2)
    {
      if (dictionary == null) throw new ArgumentNullException("dictionary");
      bool hasKey1 = dictionary.ContainsKey(key1);
      bool hasKey2 = dictionary.ContainsKey(key2);
      TValue e1 = default(TValue), e2 = default(TValue);
      if (hasKey1) { e1 = dictionary[key1]; dictionary.Remove(key1); }
      if (hasKey2) { e2 = dictionary[key2]; dictionary.Remove(key2); }
      if (hasKey1) dictionary[key2] = e1;
      if (hasKey2) dictionary[key1] = e2;
      return dictionary;
    }
  }
}