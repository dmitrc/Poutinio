﻿using System;

using Windows.UI.Xaml.Controls;

using Yapp.ViewModels;

namespace Yapp.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
