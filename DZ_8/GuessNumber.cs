using System;

namespace DZ_8;

public class GuessNumber

{

    private static int rangeMin = 0;
    private static int rangeMax = 100;
    private int tryCount = 5;
    private int number;
    public int randomNumber = Random.Shared.Next(rangeMin, rangeMax + 1);


    public void StartGame()
    {
        Console.WriteLine("Давай начнем");

        while (tryCount != 0)
        {
            Console.WriteLine("Машина загадало число, попробуй угадать: ");
            number = EnterNumber();
            if (number == randomNumber)
            {
                Console.WriteLine($"Ура, вы угадали, число действиьельно {randomNumber}\n");
                Environment.Exit(0);
            }
            else if (number > randomNumber)
            {
                tryCount--;
                Console.WriteLine($"Ваше число больше загаданного, осталось {tryCount} попыток\n");
            }
            else
            {
                tryCount--;
                Console.WriteLine($"Ваше число меньше загаданного, осталось {tryCount} попыток\n");
            }

        }
        Console.WriteLine($"Попыток не осталось, вы проиграли\n");


    }

    public int EnterNumber()
    {
        var input = Console.ReadLine();
        while (!int.TryParse(input, out number))
        {
            Console.Write("Ошибка! Введите корректное целое число: ");
            input = Console.ReadLine();
        }
        return number;
    }


}
