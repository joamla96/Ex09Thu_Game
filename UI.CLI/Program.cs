using System;
using System.Threading;
using Core;

namespace UI.CLI {
	class Program {
		static void Main(string[] args) {
			Program A = new Program();

			Console.CursorVisible = false;

			A.Run();
		}

		private void Run() {
			Map Map = new Map(80, 24, ' ');

			Player P1 = new Player(Map, 'X', "Player 1", 0,0);
			Map.Units.Add(P1);

			while(true) {
				DrawMap(Map);
				Thread.Sleep(1000);
				Console.Clear();
			}
		}

		private void DrawMap(Map Map) {
			for(int y = 0; y < Map.Height; y++) {
				for(int x = 0; x < Map.Width; x++) {
					Console.Write(Map.Board[x,y]);
				}
				Console.WriteLine();
			} 
		}
	}
}
