/*
 * Created using C# networking tutoials by Tom Weiland
 * Last completed part: 5
 * part 6: https://www.youtube.com/playlist?list=PLXkn83W0QkfnqsK8I0RAz5AbUxfg3bOQ5
 */

using System;
using System.Threading;

namespace GameServer {
    class Program {
        const int MAX_PLAYERS = 500;
        const int PORT = 26950;

        private static bool isRunning = false;

        static void Main(string[] args) {
            Console.Title = "Game Server";

            isRunning = true;

            Thread mainThread = new Thread(new ThreadStart(MainThread));
            mainThread.Start();

            Server.Start(MAX_PLAYERS, PORT);

            //Console.ReadKey();
        }

        private static void MainThread() {
            Console.WriteLine($"Main thread Started. Running at {Constants.TICKS_PER_SEC} ticks per second.");
            DateTime _nextLoop = DateTime.Now;

            while (isRunning) {
                while (_nextLoop < DateTime.Now) {
                    GameLogic.Update();

                    _nextLoop = _nextLoop.AddMilliseconds(Constants.MS_PER_TICK);

                    //Reduces thread resources while idle (lowers cpu usage)
                    if (_nextLoop > DateTime.Now) {
                        Thread.Sleep(_nextLoop - DateTime.Now);
                    }
                }
            } 
        }
    }
}
