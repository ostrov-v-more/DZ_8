using System;

namespace DZ_8;


public enum Player
{
    Human,
    Machine,
}

public class GuessNumber
{

    private int rangeMin = 0;
    private int rangeMax = 100;
    private int tryCount = 5;
    private int number;
    private int target;
    private readonly Player player;

    // public int target = Random.Shared.Next(rangeMin, rangeMax + 1);


    public GuessNumber(int rangeMin = 0, int rangeMax = 100, int tryCount = 5, Player player = Player.Human)
    {
        this.rangeMin = rangeMin;
        this.rangeMax = rangeMax;
        this.tryCount = tryCount;
        this.player = player;

    }

    public void Star()
    {
        if (player == Player.Human)
        {
            StartGamePlayer();
        }
        else
        {
            StartGameIA();
        }
    }





    public void StartGameIA()
    {
        Console.WriteLine("Задайте число от 0 до 100 \n");
        target = EnterNumber();

        Console.WriteLine("Давай начнем");

        while (tryCount != 0)
        {
            number = BinarySearch(rangeMin, rangeMax);

            if (number == target)
            {
                Console.WriteLine($"Ура, машина угадали, число действиьельно {target}\n");
                Environment.Exit(0);
            }
            else if (number > target)
            {
                Console.WriteLine($"Машина выбрала число: {number}, загаданное число меньше, осталось {tryCount} попыток\n");
                rangeMax = number;
            }
            else
            {
                Console.WriteLine($"Машина выбрала число: {number}, загаданное число больше, осталось {tryCount} попыток\n");
                rangeMin = number;
            }
            tryCount--;
            Console.WriteLine($"Попыток не осталось, машина проиграла, вы загадала {target}\n");
        }
    }

    public void StartGamePlayer()
    {
        Console.WriteLine("Давай начнем");
        target = Random.Shared.Next(rangeMin, rangeMax + 1);

        while (tryCount != 0)
        {
            Console.WriteLine("Машина загадало число, попробуй угадать: ");
            number = EnterNumber();
            if (number == target)
            {
                Console.WriteLine($"Ура, вы угадали, число действиьельно {target}\n");
                Environment.Exit(0);
            }
            else if (number > target)
            {
                Console.WriteLine($"Ваше число больше загаданного, осталось {tryCount} попыток\n");
            }
            else
            {
                Console.WriteLine($"Ваше число меньше загаданного, осталось {tryCount} попыток\n");
            }
            tryCount--;

        }
        Console.WriteLine($"Попыток не осталось, вы проиграли, машина загадала {target}\n");


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


    static int BinarySearch(int rangeMin, int rangeMax)
    {

        int mid = (rangeMin + rangeMax) / 2;
        Console.WriteLine($"Машина выбрало число: {mid} ");
        return mid;
    }


}
