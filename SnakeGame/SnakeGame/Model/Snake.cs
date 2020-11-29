using DevExpress.Mvvm.Native;
using System.Collections.Generic;
using System.Linq;


namespace SnakeGame.Model
{
    public class Snake
    {
        public List<SnakePart> SnakeElements { get; set; }
        public Direction Direction { get; set; }
        readonly int elemenetSize;

        public SnakePart SnakeHead => SnakeElements.Count > 0 ? SnakeElements[0]: null;
        public SnakePart SnakeTail { get; set; }
    
        public bool CheckTail()
        {
            SnakePart snakeHead = SnakeHead;
            if(snakeHead != null)
            {
                foreach(var snakeEl in SnakeElements.Where(x => !x.Head))
                {
                   if(snakeEl.X == snakeHead.X && snakeEl.Y == snakeHead.Y)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Snake(int elSize)
        {
            SnakeElements = new List<SnakePart>();
            elemenetSize = elSize;
        }
        internal void MoveSnake()
        {
            SnakePart head = SnakeElements[0];
            SnakePart tail = SnakeElements[SnakeElements.Count - 1];

            SnakeTail = new SnakePart(elemenetSize)
            {
                X = tail.X,
                Y = tail.Y
            };
            head.Head = false;
            tail.Head = true;

            tail.X = head.X;
            tail.Y = head.Y;

            switch(Direction)
            {
                case Direction.Up:
                    tail.Y -= elemenetSize;
                    break;
                case Direction.Down:
                    tail.Y += elemenetSize;
                    break;
                case Direction.Left:
                    tail.X -= elemenetSize;
                    break;
                case Direction.Right:
                    tail.X += elemenetSize;
                    break;
                
            }

            SnakeElements.RemoveAt(SnakeElements.Count - 1);
            SnakeElements.Insert(0, tail);
        }
        internal void SnakeAddElement()
        {
            SnakeElements.Add(new SnakePart(elemenetSize) { X = SnakeTail.X, Y = SnakeTail.Y });
        }

        internal void AddFirstElement( int numColumns, int numRows)
        {
            SnakeElements.Add(new SnakePart(elemenetSize)
            {
                X = (numColumns /2) * elemenetSize,
                Y = (numRows /2) * elemenetSize
            }) ;
            
        }
    }
    
}
