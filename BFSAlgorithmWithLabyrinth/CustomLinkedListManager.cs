global using BFSAlgorithmWithLabyrinth;

namespace BFSAlgorithmWithLabyrinth
{
    public class CustomLinkedListManager
    {
        public void PrintList<T>(QueueModel<T> head)
        {
            CustomLinkedList<T> iterator = head.Front;
            if (head.Front == null)
            {
                Console.WriteLine("\nQueue is empty.\n");
            }
            else
            {
                while (iterator != null)
                {
                    Console.Write(iterator.Data + $"{(iterator.Next != null ? ", " : string.Empty)}");
                    iterator = iterator.Next;
                }
            }
        }

        public bool[] CheckAdjencyListAndSetVisited<T>(QueueModel<T> head, bool[] visited, QueueModel<T> queue)
        {
            CustomLinkedList<T> current = head.Front;
            while (current != null)
            {
                if (!visited[Convert.ToInt32(current.Data)])
                {
                    visited[Convert.ToInt32(current.Data)] = true;
                    Enqueue(queue, current.Data);
                }
                current = current.Next;
            }
            return visited;
        }

        public bool HasValue<T>(QueueModel<T> root) => (root.Front != null || root.Rear != null);

        public T Dequeue<T>(QueueModel<T> root)
        {
            CustomLinkedList<T> temp;
            if (root.Front == null)
            {
                Console.WriteLine("nQueue is empty.");
                return default;
            }

            temp = root.Front;
            T deletedData = root.Front.Data;
            root.Front = root.Front.Next;
            if (root.Front == null)
                root.Rear = null;
            temp = null;
            return deletedData;
        }

        public void Enqueue<T>(QueueModel<T> root, T data)
        {
            CustomLinkedList<T> newData = new CustomLinkedList<T>()
            {
                Data = data,
            };
            if (root.Front == null)
            {
                root.Front = newData;
                root.Rear = newData;
                root.Front.Next = null;
                root.Rear.Next = null;
            }
            else
            {
                root.Rear.Next = newData;
                root.Rear = newData;
                root.Rear.Next = null;
            }
        }
    }
}
