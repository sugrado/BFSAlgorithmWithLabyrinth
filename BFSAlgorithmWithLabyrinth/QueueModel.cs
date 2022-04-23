namespace BFSAlgorithmWithLabyrinth
{
    public class QueueModel<T>
    {
        public CustomLinkedList<T> Front { get; set; } 
        public CustomLinkedList<T> Rear { get; set; } 
    }

    public class CustomLinkedList<T>
    {
        public T Data { get; set; }
        public CustomLinkedList<T> Next { get; set; }
    }
}
