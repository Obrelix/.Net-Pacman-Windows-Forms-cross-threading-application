using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using System.Windows.Forms;

namespace PacmanWinForms
{

	public abstract class SearchAlgorithm{

		protected Map       _map;
		protected Stopwatch _stopwatch;
		protected bool      _found;
		protected Node      _root;
		protected Node      _target;
		protected int       _pathLength;
		protected string    _title;

		public static int GetHeuristic(Node a, Node b){
			return (int) Math.Abs(a.Location.X - b.Location.X) + (int) Math.Abs(a.Location.Y - b.Location.Y);
		}

		public static int GetFScore(Node a, Node b){
			return a.Cost + GetHeuristic(a, b);
		}

		public SearchAlgorithm(){}

		public SearchAlgorithm(Map map)
        {
			_map = map;
		}

		protected virtual void Reset(){
			_stopwatch  = new Stopwatch();
			_found      = false;
		}

		public virtual Direction Run(Node root, Node target, Direction curDirection){
            _root = root;
            _target = target;
			//Run algorithm
			Search();
			//If the target is reached, draw the path
			if(_found){return FindPath(curDirection);}
            //Print results
            //Print();
            return curDirection;
		}

		protected abstract bool Update();

		protected void Search(){
			bool finished = false;
			while(!finished) {
					_stopwatch.Start();
					finished = Update();
					_stopwatch.Stop();
                //_map.Draw(_root, _target);//, _title);
			}
		}

		protected Direction FindPath(Direction d){
			_stopwatch.Start();
			List<Node> path = new List<Node>();
            //Reload the _target node
            Node currentNode = new Node(_target.Location.X, _target.Location.Y, _target.State);
            currentNode = _target;
			while(currentNode.Location != _root.Location){
				path.Add(currentNode);
				currentNode = currentNode.Predecessor;
			}
			_stopwatch.Stop();
			_pathLength = path.Count;
			foreach(Node node in path){
				node.State = 4;
				//_map.Draw(_root, _target);
			}
            if (path[path.Count - 1].Location.X > _root.Location.X) return Direction.RIGHT;
            else if(path[path.Count - 1].Location.X < _root.Location.X) return Direction.LEFT;
            else if (path[path.Count - 1].Location.Y < _root.Location.Y) return Direction .UP;
            else if (path[path.Count - 1].Location.Y > _root.Location.Y) return Direction.DOWN;
            return d;


        }
        string msg;
	}
}

