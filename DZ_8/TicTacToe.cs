using System;

namespace DZ_8;

public class TicTacToe
{
    public List<char> gameFild = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
    private int number;
    private bool isWinCombinate = false;


    public void Start()
    {
        while (!isWinCombinate)
        {
            Console.Write("Введите число куда поставить 'X'");
            ShowFild();
            number = EnterNumber();
            SetFildX(number);
            ShowFild();
            isWinCombinate = WinCombinate();
            if (isWinCombinate) break;
            Console.Write("Введите число куда поставить 'O'");
            number = EnterNumber();
            SetFildO(number);
            ShowFild();
            isWinCombinate = WinCombinate();
            if (isWinCombinate) break;
        }
        Console.WriteLine("Игра закончилась");
    }

    public void SetFildX(int number)
    {
        gameFild[number] = 'X';
    }

        public void SetFildO(int number)
    {
        gameFild[number] = 'O';
    }

    public void ShowFild()
    {
        Console.Write($"Игровое поле:\n");   
        Console.Write($"[{gameFild[0]}][{gameFild[1]}][{gameFild[2]}]\n");   
        Console.Write($"[{gameFild[3]}][{gameFild[4]}][{gameFild[5]}]\n");   
        Console.Write($"[{gameFild[6]}][{gameFild[7]}][{gameFild[8]}]\n");   
    }


        public int EnterNumber()
    {
        var input = Console.ReadLine();

        while (!int.TryParse(input, out number) || number < 0  || number > 8)
        {
            Console.Write("Ошибка! Введите корректное целое число от 0 до 8: ");
            input = Console.ReadLine();
        }
        return number;
    }


    public bool WinCombinate()
    {
        switch (gameFild)
        {
            case List<char> str when str[0] == str[1] && str[1] == str[2]:
            isWinCombinate = true;
            break; 
            case List<char> str when str[3] == str[4] && str[4] == str[5]:
            isWinCombinate = true;
            break; 
            case List<char> str when str[6] == str[7] && str[7] == str[8]:
            isWinCombinate = true;
            break; 

            case List<char> str when str[0] == str[3] && str[3] == str[6]:
            isWinCombinate = true;
            break; 
            case List<char> str when str[1] == str[4] && str[4] == str[7]:
            isWinCombinate = true;
            break; 
            case List<char> str when str[2] == str[5] && str[5] == str[8]:
            isWinCombinate = true;
            break; 

            case List<char> str when str[0] == str[4] && str[4] == str[8]:
            isWinCombinate = true;
            break; 
            case List<char> str when str[2] == str[4] && str[4] == str[6]:
            isWinCombinate = true;
            break; 

        }
        return isWinCombinate;
    }
}


