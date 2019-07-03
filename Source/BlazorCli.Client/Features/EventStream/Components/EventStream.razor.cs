namespace BlazorCli.Client.Features.EventStream.Components
{
  using System.Collections.Generic;
  using BlazorCli.Client.Features.Base.Components;

  public class EventStreamModel : BaseComponent
  {
    public IReadOnlyList<string> Events => EventStreamState.Events;

  }
}
