# CLSS.ExtensionMethods.IDictionary.SwapKeys

### Problem

Swapping keys in a dictionary usually requires 3 lines of code:

```csharp
var tempVal = dictionary[1];
dictionary[1] = dictionary[4];
dictionary[4] = tempVal;
```

### Solution

`SwapKeys` is an extension method that reduces this operation to 1 line of code:

```csharp
using CLSS;

dictionary.SwapKeys(1, 4);
```

`SwapKeys` takes some additional steps to avoid throwing exceptions. If at the beginning of a swap between key A and B, key A does not exist, instead of throwing an exception, `SwapKeys` will assign the value from key B to key A and remove key B. You can visualize it as swapping content between 2 desk drawers, first one containing a book, second one containing nothing. The swap still treats "nothing" as a valid drawer content, moving the book to the second drawer and moving nothing to the first drawer.

```csharp
using CLSS;

var floats = new Dictionary<int, float>()
{ [0] = 0f, [1] = 1f, [2] = 2f };
floats.SwapKeys(5, 1); // { [0] = 0f, [5] = 1f, [2] = 2f }
```

`SwapKeys` returns the source `IDictionary<TKey, TValue>` to be friendly to a functional-style call chain. The return type will be determined by the invocation syntax of `SwapIndices`. With an implicit type invocation, it returns an `IDictionary<TKey, TValue>`. With an explicit type invocation, it returns the original collection type.

```csharp
using CLSS;

var floats = new Dictionary<int, float>()
{ [0] = 0f, [1] = 1f, [2] = 2f };
floats.SwapKeys(0, 2); // returns IDictionary<int, float>
floats.SwapKeys<Dictionary<int, float>, int, float>(1, 4); // returns Dictionary<int, float>
```

##### This package is a part of the [C# Language Syntactic Sugar suite](https://github.com/tonygiang/CLSS).