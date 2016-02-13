﻿using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace WebExpress
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : UserControl
    {
        private int ItemsCount;
        public string Bookmarkslayoutpath =
        System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "WebExpress\\user data\\bookmarks-layout.html");

        public string Bookmarkspath =
            System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "WebExpress\\user data\\bookmarks-data.html");

        public string Bookspath = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "WebExpress\\user data\\bookmarks.txt");
        public StartPage()
        {
            InitializeComponent();
            Loaded += StartPage_Loaded;
            ItemsCount = 0;
            loadFavs();
        }
        public void loadFavs()
        {
            Dispatcher.Invoke(() =>
            {
                string[] readText = System.IO.File.ReadAllLines(Bookspath);
                ArrayList arr = new ArrayList();
                foreach (var sr in readText)
                {
                    arr.Add(sr);
                }
                foreach (string s in arr)
                {
                    string[] split = s.Split((char)42);
                    bookmarks.AddBookmark(split[0], split[1]);
                }
            });
        }
        private void StartPage_Loaded(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(BookContainer, (this.ActualWidth / 2) - (BookContainer.ActualWidth / 2));
            Canvas.SetTop(BookContainer, (this.ActualHeight / 2) - (BookContainer.ActualHeight / 2));
        }
    }
}
