﻿namespace BlazorCli.Client
{
  using System.Threading.Tasks;
  using BlazorState.Pipeline.ReduxDevTools;
  using BlazorState.Features.JavaScriptInterop;
  using BlazorState.Features.Routing;
  using Microsoft.AspNetCore.Components;
  using System;
  using BlazorHostedCSharp.Client.Features.ClientLoader;

  public class AppModel : ComponentBase
  {
    [Inject] private JsonRequestHandler JsonRequestHandler { get; set; }
    [Inject] private ReduxDevToolsInterop ReduxDevToolsInterop { get; set; }

    // Injected so it is created by the container. Even though the ide says it is not used it is.
    [Inject] private RouteManager RouteManager { get; set; }

    [Inject] private ClientLoader ClientLoader { get; set; }

    readonly TimeSpan DelayTimeSpan = TimeSpan.FromSeconds(10);

    protected override async Task OnAfterRenderAsync()
    {
      await ReduxDevToolsInterop.InitAsync();
      await JsonRequestHandler.InitAsync();
      await ClientLoader.InitAsync();
    }
  }
}