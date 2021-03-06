﻿using System.Collections.ObjectModel;
using FavFighters.Models;
using FavFighters.Services;
using Xamarin.Forms;

namespace FavFighters.ViewModels
{
    public class FavFightersViewModel : BindableObject
    {
        ObservableCollection<Fighter> _fighters;

        public Command<Fighter> FavoriteCommand { get; set; }

        public FavFightersViewModel()
        {
            LoadFighters();

            FavoriteCommand = new Command<Fighter>((f) =>
            {
                MessagingCenter.Send(f, "Favorited");
            });
        }

        public ObservableCollection<Fighter> Fighters
        {
            get { return _fighters; }
            set
            {
                _fighters = value;
                OnPropertyChanged();
            }
        }

        void LoadFighters()
        {
            var fighters = FakeFightersService.Instance.GetFighters();
            Fighters = new ObservableCollection<Fighter>(fighters);
        }
    }
}