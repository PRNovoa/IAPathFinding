using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.DataStructures
{
    public class Node
    {
        public CellInfo currentNode { get; private set; }
        public CellInfo previousNode { get; private set; }

        public Locomotion.MoveDirection direction { get; private set; }

        public Node()
        { }

        public Node(CellInfo _currentNode, CellInfo _previousNode, Locomotion.MoveDirection _direction)
        {
            this.currentNode = _currentNode;
            this.previousNode = _previousNode;

            this.direction = _direction;
        }
    }

    public class Amplitude : AbstractPathMind
    {
        private int pathCost;

        private Node node;

        private CellInfo goal;

        private List<Node> toSearch = new List<Node>();
        private List<Node> searched = new List<Node>();

        private bool foundGoal = false;

        private bool repeat;

        public override Locomotion.MoveDirection GetNextMove(BoardInfo boardInfo, CellInfo currentPos, CellInfo[] goals)
        {
            if (toSearch.Count <= 0)
            {
                toSearch.Add(new Node(currentPos, null, Locomotion.MoveDirection.None));
                
                GoalFinder(boardInfo, currentPos, goals);
            }
            return Locomotion.MoveDirection.None;
        }

        #region AuxiliaryFunctions

        private bool CheckRepeated(List<Node> list, BoardInfo boardInfo, int index)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (toSearch[0].currentNode.WalkableNeighbours(boardInfo)[index].CellId == list[i].currentNode.CellId)
                {
                    Debug.Log("daasd");
                    return true;
                }
            }
            return false;
        }

        #endregion AuxiliaryFunctions

        #region Algorithm

        /// <summary>
        /// Called to check every cell until goal found
        /// </summary>
        private CellInfo GoalFinder(BoardInfo boardInfo, CellInfo currentPos, CellInfo[] goals)
        {
            if (toSearch.Count <= 0)
            {
                Debug.Log("AY CARUMBA");
                return currentPos;
            }

            while (!foundGoal)
            {
                for (int i = 0; i < toSearch[0].currentNode.WalkableNeighbours(boardInfo).Length; i++)
                {
                    repeat = false;

                    if (toSearch[0].currentNode.WalkableNeighbours(boardInfo)[i] != null && searched[0].currentNode.WalkableNeighbours(boardInfo)[i] != null)
                    {
                        Debug.Log("Entrada");
                        repeat = CheckRepeated(searched, boardInfo, i);
                        Debug.Log("Medio");
                        repeat = CheckRepeated(toSearch, boardInfo, i);
                        Debug.Log("Salida");
                    }

                    if (!repeat)
                    {
                        switch (i)
                        {
                            case (0):
                                toSearch.Add(new Node(toSearch[0].currentNode.WalkableNeighbours(boardInfo)[i], toSearch[0].currentNode, Locomotion.MoveDirection.Up));
                                break;

                            case (1):
                                toSearch.Add(new Node(toSearch[0].currentNode.WalkableNeighbours(boardInfo)[i], toSearch[0].currentNode, Locomotion.MoveDirection.Right));
                                break;

                            case (2):
                                toSearch.Add(new Node(toSearch[0].currentNode.WalkableNeighbours(boardInfo)[i], toSearch[0].currentNode, Locomotion.MoveDirection.Down));
                                break;

                            case (3):
                                toSearch.Add(new Node(toSearch[0].currentNode.WalkableNeighbours(boardInfo)[i], toSearch[0].currentNode, Locomotion.MoveDirection.Left));
                                break;
                        }
                    }
                    if (toSearch[0].currentNode.CellId == goals[0].CellId) { foundGoal = true; }
                }
                if (foundGoal)
                {
                    Debug.Log("AY CARAMBA");
                    return toSearch[0].currentNode;
                }
            }
            return null;
            
        }

        #endregion Algorithm
    }
}