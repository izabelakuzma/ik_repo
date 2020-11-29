using SnakeGame.Model;
using SnakeGame.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Uri = SnakeGame.Model.Uri;

namespace SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SnakeView : Window
    {
        private SnakeViewModel snakeViewModel;       
        int score = 0;
   
        public SnakeView()
        {
            InitializeComponent();
            snakeViewModel = new SnakeViewModel(this);           
        }
        
        internal void GameOver()
        {
            if (MessageBox.Show("Do you want to play again?", "GAME OVER!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                RestartGame();
            }
        }

        private void KeyPress(object sender, System.Windows.Input.KeyEventArgs e)
        {
          switch(e.Key)
            {
                case Key.Up:
                    snakeViewModel.OnKeyPressed(Direction.Up);
                    break;
                case Key.Down:
                    snakeViewModel.OnKeyPressed(Direction.Down);
                    break;
                case Key.Left:
                    snakeViewModel.OnKeyPressed(Direction.Left);
                    break;
                case Key.Right:
                    snakeViewModel.OnKeyPressed(Direction.Right);
                    break;
            }
        }

        private void StartEvent(object sender, RoutedEventArgs e)
        {
            snakeViewModel.StartGame(this); 
            StartButton.IsEnabled = false;
        }
        private void RestartGame()
        {
            snakeViewModel.RestartGame(this);
            PanelImages.Children.Clear();
            score = 0;
            UpdateLabel();
        }

        private void RestartEvent(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }
       
        private void LoadRandomImage(string chooseUri)
        {
            PanelImages.Children.Clear();
            var uri = new System.Uri(chooseUri);
            var bitmap = new BitmapImage(uri);
            var image = new Image();
            image.Source = bitmap;
            PanelImages.Children.Add(image);
        } 
        
        internal void UpdatePanel()
        {
            score += 1;
            Uri uri = snakeViewModel.GetRandomNumber();
            var chooseUri = snakeViewModel.GetUri(uri);
            LoadRandomImage(chooseUri);
            UpdateLabel();
        }   
        
        internal void UpdateLabel()
        {            
            ScoreLabel.Content = "Score: " + score;            
        }
    }
}
