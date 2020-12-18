using SnakeGame.Model;
using System;
using Uri = SnakeGame.Model.Uri;

namespace SnakeGame.ViewModel
{
    public class SnakeViewModel
    {       
        public SnakeWorld SnakeWorld { get; }      
        int elementSize = 10;
       
       
        public SnakeViewModel(SnakeView snakeView)
        {
            SnakeWorld = new SnakeWorld();          
        }
        public void OnKeyPressed(Direction direction)
        {
            SnakeWorld.OnKeyPressed(direction);
        }
        public Uri GetRandomNumber()
        {
            var random = new Random();
            return (Uri)random.Next(Enum.GetNames(typeof(Uri)).Length);
        }
        public string GetUri(Uri uri)
        {
            switch (uri)
            {
                case Uri.Uri_1:
                    return "https://cdn.pixabay.com/photo/2015/02/28/15/25/snake-653639_960_720.jpg";
                case Uri.Uri_2:
                    return "https://cdn.pixabay.com/photo/2018/04/06/11/49/snake-3295605_960_720.jpg";
                case Uri.Uri_3:
                    return "https://cdn.pixabay.com/photo/2020/11/08/12/17/snake-5723536_960_720.jpg";
                case Uri.Uri_4:
                    return "https://cdn.pixabay.com/photo/2015/02/28/15/25/rattlesnake-653646_960_720.jpg";
                case Uri.Uri_5:
                    return "https://cdn.pixabay.com/photo/2013/12/10/18/22/green-tree-python-226553_960_720.jpg";
                default:
                    throw new Exception();

            }
        }
        public void StartGame(SnakeView snakeView)
        {
            SnakeWorld.StartGame(elementSize, snakeView);
        }
        public void RestartGame(SnakeView snakeView)
        {
            SnakeWorld.StopGame();
            snakeView.main.Children.Clear();
            if(!SnakeWorld.IsActive)
            {
                SnakeWorld.StartGame(elementSize, snakeView);
            }
        }

    }
}
