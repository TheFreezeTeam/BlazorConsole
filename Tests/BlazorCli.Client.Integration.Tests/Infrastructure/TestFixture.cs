﻿namespace BlazorCli.Client.Integration.Tests.Infrastructure
{
  using System;
  using System.Reflection;
  using System.Text.Json.Serialization;
  using BlazorCli.Client;
  using BlazorCli.Client.Features.Application;
  using BlazorCli.Client.Features.Counter;
  using BlazorCli.Client.Features.EventStream;
  using BlazorCli.Client.Features.WeatherForecast;
  using BlazorHostedCSharp.Client.Features.ClientLoader;
  using BlazorState;
  using Microsoft.AspNetCore.Blazor.Hosting;
  using Microsoft.Extensions.DependencyInjection;

  /// <summary>
  /// A known starting state(baseline) for all tests.
  /// And Common set of functions
  /// </summary>
  public class TestFixture//: IMediatorFixture, IStoreFixture, IServiceProviderFixture
  {
    public TestFixture(BlazorStateTestServer aBlazorStateTestServer)
    {
      BlazorStateTestServer = aBlazorStateTestServer;
      WebAssemblyHostBuilder = BlazorWebAssemblyHost.CreateDefaultBuilder()
          .ConfigureServices(ConfigureServices);

    }

    public IWebAssemblyHostBuilder WebAssemblyHostBuilder { get; }
    /// <summary>
    /// This is the ServiceProvider that will be used by the Client
    /// </summary>
    public IServiceProvider ServiceProvider => WebAssemblyHostBuilder.Build().Services;

    private BlazorStateTestServer BlazorStateTestServer { get; }

    /// <summary>
    /// Special configuration for Testing with the Test Server
    /// </summary>
    /// <param name="aServiceCollection"></param>
    private void ConfigureServices(IServiceCollection aServiceCollection)
    {
      aServiceCollection.AddSingleton(BlazorStateTestServer.CreateClient());
      aServiceCollection.AddBlazorState
      (
        aOptions => aOptions.Assemblies =
        new Assembly[] { typeof(Startup).GetTypeInfo().Assembly }
      );

      aServiceCollection.AddSingleton
      (
        new JsonSerializerOptions
        {
          PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        }
      );

      aServiceCollection.AddSingleton<IClientLoaderConfiguration, ClientLoaderTestConfiguration>();
      aServiceCollection.AddTransient<ApplicationState>();
      aServiceCollection.AddTransient<CounterState>();
      aServiceCollection.AddTransient<EventStreamState>();
      aServiceCollection.AddTransient<WeatherForecastsState>();
    }
  }
}