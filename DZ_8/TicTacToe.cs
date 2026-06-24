using System;

namespace DZ_8;

public class TicTacToe
{
    public List<char> gameFild = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8' };
    private int number;
    private bool isWinCombinate = false;
    private bool isEmptyFild = true;


    public void Start()
    {
        var queueX = new LimitedQueue<int>(3);
        var queueY = new LimitedQueue<int>(3);

        while (!isWinCombinate)
        {
            Console.Write("Введите число куда поставить 'X'");
            ShowFild();
            number = EnterNumber();
            SetFildX(number);
            if (queueX.TryEnqueue(number, out int evictedX))
            {
                SetFildNumber(evictedX);
            }
            ShowFild();
            isWinCombinate = WinCombinate();
            if (isWinCombinate) break;
            Console.Write("Введите число куда поставить 'Y'");
            number = EnterNumber();
            if (queueY.TryEnqueue(number, out int evictedY))
            {
                SetFildNumber(evictedY);
            }
            SetFildY(number);
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

    public void SetFildY(int number)
    {
        gameFild[number] = 'Y';
    }

    public void SetFildNumber(int number)
    {
        char letter = number.ToString()[0];
        gameFild[number] = letter;
    }

    public class LimitedQueue<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();
        private readonly int _limit;

        public LimitedQueue(int limit)
        {
            _limit = limit > 0 ? limit : throw new ArgumentException("Лимит должен быть больше 0.");
        }

        /// <returns>True, если элемент был вытеснен; иначе False.</returns>
        public bool TryEnqueue(T item, out T? evictedItem)
        {
            if (_queue.Count >= _limit)
            {
                evictedItem = _queue.Dequeue();
                _queue.Enqueue(item);
                return true;
            }

            evictedItem = default;
            _queue.Enqueue(item);
            return false;
        }

        public T Dequeue() => _queue.Dequeue();
        public int Count => _queue.Count;
        public IEnumerable<T> GetItems() => _queue;
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

        while (!int.TryParse(input, out number) || number < 0  || number > 8 || !CheckEmptyFild(number))
        {
            if (!int.TryParse(input, out number))
            {
                Console.Write("Ошибка! Введено не число: ");
            }
            if ( number < 0  || number > 8 )
            {
                Console.Write("Ошибка! Число должно быть от 1 до 8: ");
            }
            if (!CheckEmptyFild(number))
            {
                Console.Write("Ошибка! Ячейка уже занята: ");
            }
            input = Console.ReadLine();
        }
        return number;
    }

    public bool CheckEmptyFild(int number)
    {
        if (gameFild[number] != 'X' && gameFild[number] != 'Y')
        {
           isEmptyFild = true; 
        }
        else  isEmptyFild = false;
        
        return isEmptyFild;
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


