﻿namespace BlazorCli.Client.Integration.Tests.Features.WeatherForecast
{
  using System;
  using System.Threading.Tasks;
  using BlazorCli.Client.Features.WeatherForecast;
  using BlazorCli.Client.Integration.Tests.Infrastructure;
  using BlazorState;
  using MediatR;
  using Microsoft.Extensions.DependencyInjection;
  using Shouldly;

  internal class FetchWeatherForecastTests
  {
    public FetchWeatherForecastTests(
      TestFixture aTestFixture)
    {
      ServiceProvider = aTestFixture.ServiceProvider;
      Mediator = ServiceProvider.GetService<IMediator>();
      Store = ServiceProvider.GetService<IStore>();
      WeatherForecastsState = Store.GetState<WeatherForecastsState>();
    }

    private IMediator Mediator { get; }
    private IServiceProvider ServiceProvider { get; }
    private IStore Store { get; }
    private WeatherForecastsState WeatherForecastsState { get; set; }

    public async Task Should_Fetch_WeatherForecasts()
    {
      // Default WeatherForecastsState is an empty list. So no need to initialize it.
      var fetchWeatherForecastsRequest = new FetchWeatherForecastsAction();

      WeatherForecastsState = await Mediator.Send(fetchWeatherForecastsRequest);

      WeatherForecastsState.WeatherForecasts.Count.ShouldBeGreaterThan(0);
    }
  }
}