using System;
using System.Collections.Generic;
using System.Drawing;

namespace PacmanWinForms
{

	public class Node{

		private Point  _location;
		private Node    _predecessor;
		private int     _cumulativeCost;
		private int     _state;

		public Node(){}

		public Node(int x, int y, int s){
			_location       = new Point (x,y);
			_state    	    = s;
			_predecessor           = null;
			_cumulativeCost = 0;
		}

		public void Reset(){
			if(_state != 0){_state = 1;}
			_predecessor = null;
			_cumulativeCost = 0;
		}

		public Point Location{
			get{
				return _location;
			}
		}

		public int State{
			get{
				return _state;
			}
			set{
				_state = value;
			}
		}

		public Node Predecessor{
			get{
				return _predecessor;
			}
			set{
				_predecessor = value;
			}
		}

		public int Cost{
			get{
				return _cumulativeCost;
			}
			set{
				_cumulativeCost = value;
			}
		}
	}
}

