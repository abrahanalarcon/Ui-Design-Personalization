using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Ui_Design___Personalization;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    private string _temperature;
    private string _weatherDescription;
    private string _humidity;
    private string _windSpeed;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Temperature
    {
        get { return _temperature; }
        set
        {
            if (_temperature != value)
            {
                _temperature = value;
                OnPropertyChanged(nameof(Temperature));
            }
        }
    }

    public string WeatherDescription
    {
        get { return _weatherDescription; }
        set
        {
            if (_weatherDescription != value)
            {
                _weatherDescription = value;
                OnPropertyChanged(nameof(WeatherDescription));
            }
        }
    }

    public string Humidity
    {
        get { return _humidity; }
        set
        {
            if (_humidity != value)
            {
                _humidity = value;
                OnPropertyChanged(nameof(Humidity));
            }
        }
    }

    public string WindSpeed
    {
        get { return _windSpeed; }
        set
        {
            if (_windSpeed != value)
            {
                _windSpeed = value;
                OnPropertyChanged(nameof(WindSpeed));
            }
        }
    }

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this; 

        // Datos ficticios iniciales
        Temperature = "25";
        WeatherDescription = "Soleado";
        Humidity = "Humedad: 60%";
        WindSpeed = "Viento: 15 km/h";
    }

    private void UpdateButton_Clicked(object sender, EventArgs e)
    {
        
        Temperature = GenerateRandomTemperature();
        WeatherDescription = GetRandomWeatherDescription();
        Humidity = $"Humedad: {new Random().Next(40, 90)}%";
        WindSpeed = $"Viento: {new Random().Next(5, 30)} km/h";
    }

    private string GenerateRandomTemperature()
    {
        
        return new Random().Next(15, 36).ToString();
    }

    private string GetRandomWeatherDescription()
    {
        string[] descriptions = { "Soleado", "Parcialmente Nublado", "Nublado", "Lluvioso", "Tormenta" };
        return descriptions[new Random().Next(descriptions.Length)];
    }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
