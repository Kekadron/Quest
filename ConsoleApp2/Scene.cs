namespace ConsoleApp2
{
    public class Scene
    {
        public string Description { get; }
        public List<string> Choices { get; }
        public List<int> NextScenes { get; }

        public Scene(string description, List<string> choices, List<int> nextScenes)
        {
            Description = description;
            Choices = choices;
            NextScenes = nextScenes;
        }
    }
}
