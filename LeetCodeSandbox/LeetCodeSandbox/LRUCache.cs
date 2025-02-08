using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSandbox
{
    public class LRUCache
    {
        /*
        get a value corresponding to key in O(1) time
        put a key-value in the cache in O(1)

        corner cases:

            What if we put a value that already exists in the LRU cache?

        if put would exceed the capacity, delete the key-value least recently used i.e. least recently get() and put()

        Capacity = 3

        Hashset<int>()
        Queue<int>

        put(1)
        Hashset<int>(){1}
        Queue<int>() 1

        put(2)
        Hashset<int>(){1, 2}
        Queue<int>() 1, 2

        put(4)
        Hashset<int>(){1, 2, 4}
        Queue<int>() 1, 2, 4

        get(2)


        1) put a new element in LRU when LRU is not full
            enqueue element to the queue
            add an element to the hashset
        2) put a new element in LRU when LRU is full
            dequeue the least used element from the queue
            take the element we just dequeued and delete it from the HashSet
        3) get an element from LRU
            get the element from the Dict
            surface the element to the front of the queue***

        ***
            - would require us to traverse the queue in O(n) to surface to the front of the queue

        solutions either
        1) come up with a way to locate the element in the queue in O(1) time using a pointer or some index reference to the location from the Dict => corresponding location in the queue
        2) use some other data structure which allows access in O(1) time but also maintains the least used elemernty


        List<Tuple<int, int>> queue (key, value) // key vaulue pairs
        Dictionary<int, int> positions (key, index) // key, index pointer to the position in the queue where the key resides.

    */

        private int Capacity = -1;
        private LinkedList<KeyValuePair<int, int>> queue = new LinkedList<KeyValuePair<int, int>>(); // key vaulue pairs
        private Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> positions = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>(); // key, index location of the key
        public LRUCache(int capacity)
        {
            Capacity = capacity;
        }

        public int Get(int key)
        {
            if (!positions.ContainsKey(key))
            {
                return -1;
            }

            // remove the elkement from the queue, add it back to the back of the queue
            var node = positions[key];

            // move to the back of the queue
            queue.Remove(node);
            queue.AddLast(node);
            return node.Value.Value;
        }

        public void Put(int key, int value)
        {

            if (positions.ContainsKey(key))
            {
                // overwrite
                positions[key].Value = new KeyValuePair<int, int>(key, value);
                queue.Remove(positions[key]);
                queue.AddLast(positions[key]);
            }
            else if (queue.Count() < Capacity)
            {
                var newNode = queue.AddLast(new KeyValuePair<int, int>(key, value));
                if (!positions.TryAdd(key, newNode))
                {

                    positions[key] = newNode;
                }
            }
            else
            {
                var toRemove = queue.First(); // TODO: does this get me the first elemnt in the queue
                queue.Remove(toRemove); // memorize Methods for removing and adding to list, queue.AddList() queue.AddFirst() queue[]
                positions.Remove(toRemove.Key); // TODO memorize methods for Dictionary

                var newElt = queue.AddLast(new KeyValuePair<int, int>(key, value));
                positions.TryAdd(key, newElt);

            }
        }
    }
}
