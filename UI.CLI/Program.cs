using System;
using Core;

namespace UI.CLI {
	class Program {
		static void Main(string[] args) {
			Program A = new Program();
			A.Run();
		}

		private void Run() {
			Map Map = new Map(Console.WindowWidth, Console.WindowHeight, ' ');
		}
	}
}
