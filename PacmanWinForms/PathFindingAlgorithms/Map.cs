using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace PacmanWinForms
{

	public class Map{
	
		/*
		 * [0] Impassable
		 * [1] Unvisited
		 * [2] In frontier
		 * [3] Visited
		 * [4] Path
		 */
         
		public Node[,] map;
        
        public Map(List<Point> wallList, int rows = 31, int cols = 28)
        {
			map = new Node[cols, rows];
			for(int i=0; i<map.GetLength(0); i++){
				for(int j=0; j<map.GetLength(1); j++){
                   
                    map[i,j] = new Node(i,j,1);
				}
			}
            foreach (Point p in wallList)
            map[p.X, p.Y].State = 0;
            
            Debug.WriteLine(LengthX);
			Debug.WriteLine(LengthY);
        }

        public int LengthX{
			get{
				return map.GetLength(0);
			}
		}

		public int LengthY{
			get{
				return map.GetLength(1);
			}
		}

		public void Reset(){
			for(int i=0; i<map.GetLength(0); i++){
				for(int j=0; j<map.GetLength(1); j++){
					map[i,j].Reset();
				}
			}
		}

        public List<Node> GetNeighbours(Node node){
			//Get unvisited immediate neighbours
			List<Node> neighbours = new List<Node>();
            if (node.Location.X == 0 && node.Location.Y == 14)
            {
                TryAdd(neighbours, 27, node.Location.Y);
                TryAdd(neighbours, node.Location.X, node.Location.Y - 1);
                TryAdd(neighbours, node.Location.X, node.Location.Y + 1);
                TryAdd(neighbours, node.Location.X + 1, node.Location.Y);
            }
            else if (node.Location.X == 27 && node.Location.Y == 14)
            {
                TryAdd(neighbours, node.Location.X - 1, node.Location.Y);
                TryAdd(neighbours, node.Location.X, node.Location.Y - 1);
                TryAdd(neighbours, node.Location.X, node.Location.Y + 1);
                TryAdd(neighbours, 0, node.Location.Y);
            }
            else
            {
                TryAdd(neighbours, node.Location.X - 1, node.Location.Y);
                TryAdd(neighbours, node.Location.X, node.Location.Y - 1);
                TryAdd(neighbours, node.Location.X, node.Location.Y + 1);
                TryAdd(neighbours, node.Location.X + 1, node.Location.Y);
            }
            return neighbours;
		}

		private void TryAdd(List<Node> neighbours, int x, int y){
			try{
				Node neighbour = map[ x,  y];
				if(neighbour.State == 1){
					neighbours.Add(neighbour);
				}
			}
			catch(IndexOutOfRangeException){}
		}
	}
}

