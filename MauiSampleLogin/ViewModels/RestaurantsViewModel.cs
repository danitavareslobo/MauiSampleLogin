﻿using MauiSampleLogin.Inferfaces;
using MauiSampleLogin.Models.Restaurant;

namespace MauiSampleLogin.ViewModels
{
    [ObservableObject]
    public partial class RestaurantsViewModel
    {
        private readonly IRestaurantService _service;
        public ObservableCollection<RestaurantResponse> Restaurants { get; set; } = new ObservableCollection<RestaurantResponse>();
        public RestaurantsViewModel(IRestaurantService service) 
        {
            _service = service;
        }

        public async Task InitAsync()
        {
            var result = await _service
                .GetAllAsync(Preferences.Default.Get("token", string.Empty));

            if (result is null)
                return;

            Restaurants?.Clear();
            foreach (var item in result)
                Restaurants.Add(item);
        }
    }
}
