namespace BlazorCli.Client.Features.Counter.Components
{
  using BlazorCli.Client.Features.Base.Components;
  using BlazorCli.Client.Features.Counter;

  public class CounterModel : BaseComponent
  {
    internal void ButtonClick() =>
      Mediator.Send(new IncrementCounterAction { Amount = 5 });
  }
}