using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using System.Windows.Forms;

namespace PacmanWinForms
{

    public class BreadthFirst : SearchAlgorithm
    {

        /* The Breadth First Search Algorithm
		 *   An extension of the Flood Fill Algorithm, in which a search area expands outward by checking each node's
		 *   immediate neighbours. After being checked, a node's unchecked neighbours are added to the queue. 
		 * 
		 *   + Accurate
		 *   - Slow
		 */

        private Queue _open = new Queue();

        public BreadthFirst() { }
        public BreadthFirst(Map map) : base(map)
        {
            _title = "Breadth First Search Algorithm";
        }

        public override Direction Run(Node root, Node target, Direction curDirection)
        {
            //Setup
            Reset();
            _root = root;
            _open.Enqueue(_root);
            _target = target;
            return base.Run(root, target, curDirection);
        }

        protected override void Reset()
        {
            _open.Clear();
            base.Reset();
        }

        protected override bool Update()
        {
			Node currentNode = (Node) _open.Dequeue();
			currentNode.State = 3;
			if(currentNode.Location.Equals(_target.Location))
            {
                //Check if the current node is the target
                _found = true;
				return true;
			}
			else
            {
				//Enqueue the unvisited neighbours of the current node
				List<Node> toAdd = _map.GetNeighbours(currentNode);
                foreach (Node newNode in toAdd)
                {
                    newNode.State = 2;
                    newNode.Predecessor = currentNode;
                    _open.Enqueue(newNode);
                }
			}
			if(_open.Count == 0){
				_found = false;
				return true;
			}
			return false;
		}
        

    }
}
