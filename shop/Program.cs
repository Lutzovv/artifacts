using Newtonsoft.Json;

namespace artifacts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shop = new ShopManeger();
            
            Console.WriteLine("Магический магазин артефактов");
            Console.WriteLine("============================");

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Загрузить все данные");
                Console.WriteLine("2. Найти проклятые артефакты (сила > 50)");
                Console.WriteLine("3. Показать статистику по редкости");
                Console.WriteLine("4. Топ артефактов по силе");
                Console.WriteLine("5. Создать отчет");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите действие: ");

                var choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        shop.LoadAllData();
                        Console.WriteLine($"Загружено {shop.Artifacts.Count} артефактов");
                        break;
                        
                    case "2":
                        var cursed = shop.FindCursedArtifacts();
                        Console.WriteLine($"Найдено {cursed.Count} проклятых артефактов:");
                        foreach (var item in cursed)
                        {
                            Console.WriteLine($"- {item.Name} (Сила: {item.PowerLevel}, Проклятие: {item.CurseDescription})");
                        }
                        
                        // Экспорт в JSON с помощью Newtonsoft.Json
                        File.WriteAllText("cursed_artifacts.json", 
                            JsonConvert.SerializeObject(cursed, Formatting.Indented));
                        Console.WriteLine("Результаты сохранены в cursed_artifacts.json");
                        break;
                        
                    case "3":
                        var byRarity = shop.GroupByRarity();
                        foreach (var group in byRarity)
                        {
                            Console.WriteLine($"{group.Key}: {group.Value} шт.");
                        }
                        break;
                        
                    case "4":
                        Console.Write("Введите количество: ");
                        if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
                        {
                            var top = shop.TopByPower(count);
                            Console.WriteLine($"Топ {count} артефактов по силе:");
                            foreach (var item in top)
                            {
                                Console.WriteLine($"- {item.Name} (Сила: {item.PowerLevel}, Редкость: {item.Rarity})");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                        break;
                        
                    case "5":
                        shop.GenerateReport();
                        Console.WriteLine("Отчет сохранен в файл report.txt");
                        break;
                        
                    case "6":
                        return;
                        
                    default:
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }
        }
    }
}

