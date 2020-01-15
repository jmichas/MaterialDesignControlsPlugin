using System;
using System.Collections.Generic;
using System.Windows.Input;
using Plugin.MaterialDesignControls;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialPickerPage : ContentPage
    {
        public string SelectedSizes { get; set; }

        public object SelectedItem { get; set; }

        public object SecondarySelectedItem { get; set; }

        public List<Measurement> ItemsSource { get; set; }

        public List<Monkey> SecondaryItemsSource { get; set; }

        public MaterialPickerPage()
        {
            InitializeComponent();

            this.pckColors.ItemsSource = new List<string> { "Red", "Blue", "Green" };
            this.pckSizes.ItemsSource = new List<string> { "P", "M", "X", "XL" };

            this.pckModels.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            this.pckModels.SelectedIndexChanged += PckModels_SelectedIndexChanged;

            this.pckModels2.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            this.pckModels3.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };
            this.pckModels4.ItemsSource = new List<string> { "Model A", "Model B", "Model C", "Model D" };

            this.pckDouble.SelectedIndexesChanged += PckDouble_SelectedIndexChanged;
            this.ItemsSource = new List<Measurement> { 
                new Measurement{Data=1,Display="1 Foot" },
                new Measurement{Data=2,Display="2 Foot" },
                new Measurement{Data=3,Display="3 Foot" },
                new Measurement{Data=4,Display="4 Foot" }
            };
            this.SecondaryItemsSource = new List<Monkey> {
                new Monkey{Id=1,Name="Rhesus"},
                new Monkey{Id=1,Name="Mandrill"},
                new Monkey{Id=1,Name="Macaque"},
                new Monkey{Id=1,Name="Proboscis"},
            };
            this.SelectedItem = ItemsSource[1];
            this.SecondarySelectedItem = SecondaryItemsSource[2];

            this.TapCommand = new Command<string>(OnTap);

            this.Tap2Command = new Command<string>(OnTap2);

            this.Tap3Command = new Command<string>(OnTap3);

            this.BindingContext = this;
        }

        public class Measurement
        {
            public int Data { get; set; }
            public string Display { get; set; }
        }

        public class Monkey
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        private void PckDouble_SelectedIndexChanged(object sender, SelectedIndexesEventArgs e)
        {
            this.lblSelectedIndexes.Text = $"SelectedIndexes: {e.SelectedIndexes[0]} - {e.SelectedIndexes[1]}";
        }

        private void PckModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblSelectedIndex.Text = $"SelectedIndex: {this.pckModels.SelectedIndex}";
        }

        public ICommand TapCommand { get; set; }

        public async void OnTap(object parameter)
        {
            //if (!string.IsNullOrEmpty(this.pckColors.SelectedItem))
            if(this.pckColors.SelectedItem!=null)
            {
                this.pckColors.AssistiveText = null;
                await this.DisplayAlert("Saved", !string.IsNullOrEmpty(this.SelectedSizes) ? this.SelectedSizes : "Select option", "Ok");
            }
            else
            {
                this.pckColors.AssistiveText = "The color is required";
            }
        }

        public ICommand Tap2Command { get; set; }

        public async void OnTap2(object parameter)
        {
            await this.DisplayAlert("Saved", $"{SelectedItem} - {SecondarySelectedItem}", "Ok");
        }

        public ICommand Tap3Command { get; set; }

        public async void OnTap3(object parameter)
        {
            this.pckDoubleWithFocus.Focus();
        }
    }
}
