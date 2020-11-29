using System.Windows;
using System.Windows.Media;


namespace SnakeGame.Model
{    
    public class SnakePart
    {
        public UIElement UIElement { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public SnakePart(int size)
        {
            UIElement = new System.Windows.Shapes.Rectangle
            {
                Width = size,
                Height = size,
                Fill = Brushes.Green
               
            };
            
        }
        public bool Head { get;  set; }

    }
}
