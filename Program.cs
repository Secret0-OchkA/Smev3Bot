
using Smev_Bot.View;
using System.Text.Json;


//ParserWorker parserWorker = new ParserWorker(SmevBot.Smev3.Smev3Filter.GetDefault());
//var result = await parserWorker.GetDocs();
//foreach (var doc in result)
//{
//    Console.WriteLine($"=============================={doc.Key}==============================");
//    foreach (var item in doc.Value)
//        Console.WriteLine(item.ToString());
//}


string fileName = "jsconfig1.json";
string jsonString = File.ReadAllText(fileName);
BotConfiguration botConfiguration = JsonSerializer.Deserialize<BotConfiguration>(jsonString)!;
TelegramBotView bot = new TelegramBotView(botConfiguration);

await bot.Start();
bot.Stop();

