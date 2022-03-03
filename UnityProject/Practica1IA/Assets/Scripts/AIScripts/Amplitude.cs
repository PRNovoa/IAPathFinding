using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.DataStructures
{
    public class Node
    {
        public CellInfo currentNode { get; private set; }
        public CellInfo previousNode { get; private set; }

        public Locomotion.MoveDirection direction { get; private set; }

        public Node() { }
        public Node(CellInfo _currentNode, CellInfo _previousNode, Locomotion.MoveDirection _direction)
        {
            this.currentNode = _currentNode;
            this.previousNode = _previousNode;

            this.direction = _direction;
        }
    }

    public class Amplitude : AbstractPathMind
    {

        /// <summary>
        /// Called to check every cell until goal found
        /// </summary>
        public class GoalFinder
        {

        }

        #region BaseClasses
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion
    }
}
