using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMyNumberGame
{

    class Program
    {
        static void Main(string[] args)
        {
            GameEngine Game = new GameEngine();
            Game.GetGameMode();
            Game.CreateArray();
            Game.ChooseRandom();
            Game.GuessEngine();
        }
    }
}
