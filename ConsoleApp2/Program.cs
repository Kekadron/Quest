using System;
using System.Collections.Generic;
using ConsoleApp2;

internal class Program
{
    static void Main(string[] args)
    {
        
        Scene scene0 = new Scene(
            "=========================="
            + "\n|| Подошёл к техникуму  ||"
            + "\n==========================",
            new List<string> { "Пошёл на пары", "Пошёл домой", "Попал в аварию", "Пошёл за шавухой" },
            new List<int> { 1, 2, 3, 4 }
        );
        Scene scene1 = new Scene(
            "Пришли на пару\n"
            + "Прошло 15 минут и Вы уснули\n"
            + "Пара закончилась, что дальше?",
            new List<string> { "Дальше идти на пары", "Пойти домой", "Пойти за шавухой" },
            new List<int> { 1, 2, 4 }
        );
        Scene scene2 = new Scene(
            "Вы пришли домой.\n"
            + "К вам подошла мама и спросила почему вы так рано вернулись",
            new List<string> { "Сказать правду", "Соврать (шанс 75%)" },
            new List<int> { 0, 2 } 
        );
        Scene scene3 = new Scene(
            "И зачем вы это сделали?\n"
            + "GAME OVER",
            new List<string>() { }, 
            new List<int>() { } 
        );
        Scene scene4 = new Scene(
            "Вы проголодались и решили купить шавухи\n"
            + "Вы сделали заказ\n"
            + "Прошло 10 минут и вам отдали шавуху\n"
            + "Вы наелись и пошли домой",
            new List<string>() { }, 
            new List<int> { 2 } 
        );

        // Создем список сцен.
        List<Scene> scenes = new List<Scene> { scene0, scene1, scene2, scene3, scene4 };

        int currentSceneIndex = 0;

        while (true)
        {
            Scene currentScene = scenes[currentSceneIndex];
            Console.WriteLine(currentScene.Description);
            for (int i = 0; i < currentScene.Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {currentScene.Choices[i]}");
            }

            if (currentScene.Choices.Count == 0)
            {
                break;
            }

            int choiceIndex = int.Parse(Console.ReadLine()) - 1;
            int nextSceneIndex = currentScene.NextScenes[choiceIndex];

            // Рандом в сцене с мамой
            if (currentSceneIndex == 2 && choiceIndex == 1) 
            {
                Random rnd = new Random();
                int success = rnd.Next(1, 4);
                if(success != 1)
                {
                    Console.WriteLine("Мама вам поверила!");
                    nextSceneIndex = 0;
                }
                if (success == 1)
                {
                    Console.WriteLine("Мама вам не поверила и отправила на пары");
                    nextSceneIndex = 1;
                }
            }

            currentSceneIndex = nextSceneIndex;
        }
    }
}