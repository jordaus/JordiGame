using System;

namespace JordiGame
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new JordiGame())
                game.Run();
        }
    }
}
