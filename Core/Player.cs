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

			this.Init();
		}

		public void Init() {
			Thread Mover = new Thread(this.Move);
			Mover.Start();
		}

		public void Hit() {
			Life--;
		}

		private bool IsAlive() {
			if (this.Life > 0) return true;
			else return false;
		}

		private void Move() { // Run this in a thread!
			char Key = char.Parse(Console.ReadKey().ToString());
			if(Key == this.MoveControls[0]) {
				// Up
				int newY = this.PosY++;
				if(Map.isFree(this.PosX, newY)) {
					this.PosY = newY;
				}
			} else if(Key == this.MoveControls[1]) {
				// Left
				int newX = this.PosX--;
				if (Map.isFree(newX, this.PosY)) {
					this.PosX = newX;
				}
			} else if(Key == this.MoveControls[2]) {
				// Down
				int newY = this.PosY--;
				if (Map.isFree(this.PosX, newY)) {
					this.PosY = newY;
				}
			} else if(Key == this.MoveControls[3]) {
				int newX = this.PosX++;
				if(Map.isFree(newX, this.PosY)) {
					this.PosX = newX;
				}
			}

			Map.DrawMap();
		}
	}
}
