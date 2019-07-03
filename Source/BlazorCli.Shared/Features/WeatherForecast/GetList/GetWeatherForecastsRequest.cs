﻿namespace BlazorCli.Shared.Features.WeatherForecast
{
  using BlazorCli.Shared.Features.Base;
  using MediatR;

  public class GetWeatherForecastsRequest : BaseRequest, IRequest<GetWeatherForecastsResponse>
  {
    public const string Route = "api/weatherForecast";

    /// <summary>
    /// The Number of days of forecasts to get
    /// </summary>
    public int Days { get; set; }
  }
}