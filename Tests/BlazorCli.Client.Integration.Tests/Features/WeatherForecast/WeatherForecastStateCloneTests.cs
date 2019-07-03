﻿namespace BlazorCli.Client.Integration.Tests.Features.WeatherForecast
{
  using System;
  using BlazorState;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;
  using BlazorCli.Client.Integration.Tests.Infrastructure;
  using System.Collections.Generic;
  using BlazorCli.Client.Features.WeatherForecast;
  using BlazorCli.Shared.Features.WeatherForecast;
  using AnyClone;

  internal class WeatherForecastStateCloneTests
  {
    public WeatherForecastStateCloneTests(TestFixture aTestFixture)
    {
      IServiceProvider serviceProvider = aTestFixture.ServiceProvider;
      IStore store = serviceProvider.GetService<IStore>();
      WeatherForecastsState = store.GetState<WeatherForecastsState>();
    }

    private WeatherForecastsState WeatherForecastsState { get; set; }

    public void ShouldClone()
    {
      //Arrange
      var weatherForecasts = new List<WeatherForecastDto> {
        new WeatherForecastDto
        {
          Date = DateTime.MinValue,
          Summary = "Summary 1",
          TemperatureC = 24
        },
        new WeatherForecastDto
        {
          Date = new DateTime(2019,05,17),
          Summary = "Summary 1",
          TemperatureC = 24
        }
      };
      WeatherForecastsState.Initialize(weatherForecasts);
      
      //Act
      var clone = WeatherForecastsState.Clone() as WeatherForecastsState;

      //Assert
      WeatherForecastsState.ShouldNotBeSameAs(clone);
      WeatherForecastsState.WeatherForecasts.Count.ShouldBe(clone.WeatherForecasts.Count);
      WeatherForecastsState.Guid.ShouldNotBe(clone.Guid);
      WeatherForecastsState.WeatherForecasts[0].TemperatureC.ShouldBe(clone.WeatherForecasts[0].TemperatureC);
      WeatherForecastsState.WeatherForecasts[0].ShouldNotBe(clone.WeatherForecasts[0]);
    }

  }
}
