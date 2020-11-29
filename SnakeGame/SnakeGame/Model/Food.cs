using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SnakeGame.Model
{
    public class Food
    {
        public UIElement UIElement { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Food(int size)
        {
            Rectangle rectangle = new Rectangle
            { 
                Width = size,
                Height = size,
                Fill = Brushes.Red,
                RadiusX = 15,
                RadiusY = 15
            };
            UIElement = rectangle;

        }
    }
}
