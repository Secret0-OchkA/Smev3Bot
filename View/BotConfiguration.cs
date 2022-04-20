namespace Smev_Bot.View
{
    public class BotConfiguration
    {
        public string name { get; set; }
        public string key { get; set; }

        public BotConfiguration(string name ,string key)
        {
            this.name = name;
            this.key = key;
        }
    }
}

