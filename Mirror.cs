using Ooui;
using System.Collections.Generic;
using Xamarin.Forms;
using Button = Xamarin.Forms.Button;
using Label = Xamarin.Forms.Label;
using Color = Xamarin.Forms.Color;
using System.Threading.Tasks;

namespace ScribbLED
{
    public class Mirror : ContentPage
    {
        private static List<Button> _buttons = new List<Button>();

        public void Publish()
        {
            UI.Publish("/", CreateGrid);
        }

        private Ooui.Element CreateGrid()
        {
            var grid = new Grid
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = 50 },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = 50 }
                },
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                }
            };
            var label = new Label
            {
                Text = "ScribbLED - draw something",
                HorizontalTextAlignment = TextAlignment.Center
            };
            grid.Children.Add(label, 0, 0);
            Grid.SetColumnSpan(label, 5);
            for (var row = 1; row < 8; row++)
            {
                for (var column = 0; column < 5; column++)
                {
                    grid.Children.Add(CreateButton(), column, row);
                }
            }
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            var reset = new Button
            {
                Text = "Reset"
            };
            reset.Clicked += (s, a) => _buttons.ForEach(_ => _.BackgroundColor = Color.Black);
            var draw = new Button
            {
                Text = "Draw"
            };
            draw.Clicked += (s, a) => DrawImage();
            layout.Children.Add(reset);
            layout.Children.Add(draw);
            grid.Children.Add(layout, 0, 8);
            Grid.SetColumnSpan(layout, 5);
            return new ContentPage
            {
                Content = grid
            }.GetOouiElement();

        }

        private Button CreateButton()
        {
            var button = new Button
            {
                HeightRequest = 100,
                WidthRequest = 100,
                MinimumHeightRequest = 100,
                MinimumWidthRequest = 100,
                BackgroundColor = Color.Black
            };
            button.Clicked += (s, a) => ((Button)s).BackgroundColor = Color.White;
            _buttons.Add(button);
            return button;
        }

        private void DrawImage()
        {
            
        }
    }
}
