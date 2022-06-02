using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Armagetron.Movement
{
    static public class DirectionSelecter
    {
        readonly static private TurnNode _forwardNode = new TurnNode(Vector3.left, Vector3.right);
        readonly static private TurnNode _rightNode = new TurnNode(Vector3.forward, Vector3.back);
        readonly static private TurnNode _leftNode = new TurnNode(Vector3.back, Vector3.forward);
        readonly static private TurnNode _backNode = new TurnNode(Vector3.right, Vector3.left);

        readonly static private Dictionary<MoveDirection, TurnNode> _directionTurnNodePair = new Dictionary<MoveDirection, TurnNode>()
        {
            { MoveDirection.Forward, _forwardNode },
            { MoveDirection.Back, _backNode },
            { MoveDirection.Left, _leftNode },
            { MoveDirection.Right, _rightNode },
        };

        static public Direction GetDirectionAfterTurn(MoveDirection _currentDirection, TurnDirection turnDirection)
        {
            if (turnDirection == TurnDirection.Right)
            {
                Direction direction;
                direction.VectorDirection = _directionTurnNodePair[_currentDirection].RightTurn;
                direction.EnumValueDirection = MoveVectorToMoveDirectionEnum(direction.VectorDirection);
                return direction;
            }
            else
            {
                Direction direction;
                direction.VectorDirection = _directionTurnNodePair[_currentDirection].LeftTurn;
                direction.EnumValueDirection = MoveVectorToMoveDirectionEnum(direction.VectorDirection);
                return direction;
            }
        }

        static private MoveDirection MoveVectorToMoveDirectionEnum(Vector3 vector)
        {
            switch (vector)
            {
                case vector == Vector3.forward:
                    return MoveDirection.Forward;
            }
        }

    }

    public struct Direction
    {
        public Vector3 VectorDirection;
        public MoveDirection EnumValueDirection;
    }


    public struct TurnNode
    {
        readonly public Vector3 LeftTurn;
        readonly public Vector3 RightTurn;

        public TurnNode(Vector3 leftTurn, Vector3 rightTurn)
        {
            LeftTurn = leftTurn;
            RightTurn = rightTurn;
        }
    }
}
