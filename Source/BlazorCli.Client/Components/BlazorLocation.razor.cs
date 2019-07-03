﻿namespace BlazorCli.Client.Components
{
  using BlazorState;
  using BlazorState.Services;
  using Microsoft.AspNetCore.Components;

  public class BlazorLocationModel : BlazorStateComponent
  {
    [Inject] public BlazorHostingLocation BlazorHostingLocation { get; set; }

    public string LocationName => BlazorHostingLocation.IsClientSide ? "Client Side" : "Server Side";
  }
}
