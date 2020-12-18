using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SnakeGame.Model
{
    public class SnakeWorld
    {
        private SnakeView snakeView;
        public int ElementSize { get; set; }
        public Snake Snake { get; set; }
        public Food Food { get; set; }        
        public int MainWindowWidth { get; set; }
        public int MainWindowHeight { get; set; }
        public int MainWindowColumns { get; set; }
        public int MainWindowRows { get; set; }
        public bool IsActive { get; set; }
        DispatcherTimer _timer;
        Random random;

        public SnakeWorld()
        {
            random = new Random(DateTime.Now.Millisecond / DateTime.Now.Second);
        }

        public void StartGame(int elementSize, SnakeView snakeView)
        {
            ElementSize = elementSize;
            MainWindowHeight = (int)snakeView.main.ActualHeight;
            MainWindowWidth = (int)snakeView.main.ActualWidth;
            MainWindowColumns = MainWindowWidth / ElementSize;
            MainWindowRows = MainWindowHeight / ElementSize;

            this.snakeView = snakeView;
            ElementSize = elementSize;
            StartSnake();
            
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromTicks(TimeSpan.FromMilliseconds(200).Ticks)

            };
            _timer.Tick += timerTick;
            _timer.Start();
            IsActive = true;
        }
        public void StopGame()
        {
            _timer.Stop();
            IsActive = false;
        }

        private void StartSnake()
        {
            Snake = new Snake(ElementSize);
            Snake.AddFirstElement(MainWindowColumns, MainWindowRows);

        }
        private void AddSnake()
        {
            foreach(var snake in Snake.SnakeElements)
            {
                if (!snakeView.main.Children.Contains(snake.UIElement))
                    snakeView.main.Children.Add(snake.UIElement);
                Canvas.SetLeft(snake.UIElement, snake.X + 3);
                Canvas.SetTop(snake.UIElement, snake.Y + 3);
            }
        }
        private void AddFood()
        {           
            if (!snakeView.main.Children.Contains(Food.UIElement))
                snakeView.main.Children.Add(Food.UIElement);
            Canvas.SetLeft(Food.UIElement, Food.X + 3);
            Canvas.SetTop(Food.UIElement, Food.Y + 3);          
        }
        private bool CheckArea()
        {                      
            if(Snake != null && Snake.SnakeHead != null)
            {
                var snHead = Snake.SnakeHead;
                if(snHead.X > MainWindowWidth - ElementSize || snHead.Y > MainWindowHeight - ElementSize
                    || snHead.X < 0 || snHead.Y < 0)
                {
                    return true;
                }
            }
            return false;
        }
        private void CreateFood()
        {
            if (Food != null)
                return;
            Food = new Food(ElementSize)
            {
                X = random.Next(0, MainWindowColumns) * ElementSize,
                Y = random.Next(0, MainWindowRows) * ElementSize
            };
        }
        private void CheckLastMove()
        {
            if(CheckFood())
            {
                snakeView.UpdatePanel();
                snakeView.main.Children.Remove(Food.UIElement);
                Food = null;
                Snake.SnakeAddElement();
            }
            if(Snake.CheckTail() || CheckArea())
            {               
                StopGame();          
                snakeView.GameOver();
            }
        }
        private bool CheckFood()
        {          
            SnakePart snakeHead = Snake.SnakeHead;
            if (Food != null && snakeHead.X == Food.X && snakeHead.Y == Food.Y)
                return true;
            return false;
        }
        private void AddObjects()
        {
            AddSnake();
            AddFood();
        }

        public void OnKeyPressed(Direction direction)
        {
            if (Snake != null)
                Snake.Direction = direction;
        }

        private void timerTick(object sender, EventArgs e)
        {
            Snake.MoveSnake();
            CheckLastMove();
            CreateFood();
            AddObjects();
        }
    }
}
