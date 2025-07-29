namespace proje.Entities
{
    public class ToDoItem
    {
        public Guid ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
