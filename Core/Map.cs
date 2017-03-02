using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core {
	class Map {
		public int Width { get; private set; }
		public int Height { get; private set; }
		char[,] Board;
		public char BlankChar { get; set; }

		public List<IUnit> Units;

		public Map(int Width, int Height, char BlankChar) {
			this.Width = Width;
			this.Height = Height;
			this.BlankChar = BlankChar;

			this.Board = new char[this.Width, this.Height];
			this.DrawMap();
		}

		public char[,] DrawMap() {			
			for (int x = 0; x < this.Width; x++) {
				for (int y = 0; y < this.Height; y++) {
					Board[x, y] = this.BlankChar;
				}
			}

			foreach(IUnit Unit in Units) {
				Board[Unit.PosX, Unit.PosY] = Unit.Symbol;
			}
			return Board;
		}

		public bool isFree(int X, int Y) {
			if (Board[X, Y] == null) return true;
			else return false;
		}


	}
}
