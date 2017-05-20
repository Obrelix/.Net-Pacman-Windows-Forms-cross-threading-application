using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using System.Windows.Forms;

namespace PacmanWinForms
{

	public class BestFirst: SearchAlgorithm{

		/* The (Greedy) Best First Search Algorithm
		 *   An extension of the Breadth First Search Algorithm, in which the search area expands outward by checking each nodes's
		 *   immediate neighbours. Rather than being added to a set queue, nodes are evaluated in increasing order of their
		 *   heuristic value, an estimate of their distance from the target node, not taking into account any obstacles.
		 * 
		 *   + Fast
		 *   - Inaccurate
		 */

		private List<Node> _open = new List<Node>();

		public BestFirst(){}
		public BestFirst(Map map) : base(map)
        {
			_title = "Best First Search Algorithm";
		}

		public override Direction Run(Node root, Node target, Direction curDirection)
        {
			//Setup
			Reset();
			_root = root;
			_open.Add(_root);
			_target = target;
			return base.Run(root, target, curDirection);
		}

		protected override void Reset(){
			_open.Clear();
			base.Reset();
		}

		protected override bool Update(){
			_stopwatch.Start();
            //Find the node with the lowest heuristic score (closest to the target, irrespective of obstacles)
			Node currentNode = _open[0];
			int minHeuristic = GetHeuristic(currentNode, _target);
			foreach(Node node in _open){
				int heuristic = GetHeuristic(node, _target);
				if(heuristic <= minHeuristic){
					currentNode = node;
					minHeuristic = heuristic;
				}
			}
			_open.Remove(currentNode);
			currentNode.State = 3;
			if(currentNode.Location.Equals(_target.Location)){
                //Check if the current node is the target
				_found = true;
				return true;
			}
			else{
				//Enqueue the unvisited neighbours of the current node
				List<Node> toAdd = _map.GetNeighbours(currentNode);
				foreach(Node newNode in toAdd){
					newNode.State = 2;
					newNode.Predecessor = currentNode;
					_open.Add(newNode);
				}
			}
			if(_open.Count == 0){
				_found = false;
				return true;
			}
			_stopwatch.Stop();
			return false;
		}
	}
}


