using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace Core {
	class Player : IUnit {
		public char Symbol { get; private set; }
		public string Name { get; private set; }
		public int Life { get; private set; }
		private Map Map;
		private char[] MoveControls = new char[4] { 'w', 'a', 's', 'd' }; // Order: Up, Left, Down, Right
		public int PosX { get; private set; }
		public int PosY { get; private set; }
		bool Alive {
			get {
				return this.IsAlive();
			}
		}

		public Player(Map Map, char Symbol, string Name, int PosX, int PosY, int Life = 100) {
			this.Map = Map;
			this.Symbol = Symbol;
			this.Name = Name;
			this.PosX = PosX;
			this.PosY = PosY;
			this.Life = Life;
		}

		public void Hit() {
			Life--;
		}

		private bool IsAlive() {
			if (this.Life > 0) return true;
			else return false;
		}

		private void Move() {
			char Key = char.Parse(Console.ReadKey().ToString());
			switch(Key) {
				case this.MoveControls[0]:
					break;
			}
		}
	}
}
