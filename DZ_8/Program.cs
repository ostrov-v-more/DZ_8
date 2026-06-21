
namespace DZ_8

{

    class Program
    {
        static void Main()
        {

            GuessNumber game = new GuessNumber(player: Player.Machine);
            // game.StartGamePlayer();
            // game.StartGameIA();
            game.Star();
            //     Complex c1 = new Complex(1, 1);
            //     Complex c2 = new Complex(1, 2);

            //     Complex result = c1.Plus(c2);

            //     Console.WriteLine($"Число {result.Real}, {result.Imaginary}");
        }
    }
}