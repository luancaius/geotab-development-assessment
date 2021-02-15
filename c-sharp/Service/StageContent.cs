namespace Service
{
    public class StageContent
    {
        public string Content { get; set; }
        
        public StageContent(Stage stage)
        {
            switch (stage)
            {
                case Stage.Start:
                    Content = "Press ? to get instructions.";
                    break;
                case Stage.Options:
                    Content = "Press c to get categories\nPress r to get random jokes";
                    break;
                case Stage.RandomName:
                    Content = "Want to use a random name? y/n";
                    break;
                case Stage.SpecifyCategory:
                    Content = "Want to specify a category? y/n";
                    break;
                case Stage.EnterCategory:
                    Content = "Enter a category;";
                    break;
                case Stage.HowManyJokes:
                    Content = "How many jokes do you want? (1-9)";
                    break;
                default:
                    Content = "Invalid stage";
                    break;
            }
        }
    }
}