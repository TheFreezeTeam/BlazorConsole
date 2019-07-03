namespace BlazorCli.Client.Features.Counter
{
  using MediatR;
  using BlazorCli.Shared.Features.Base;

  public class IncrementCounterAction : BaseRequest, IRequest<CounterState>
  {
    public int Amount { get; set; }
  }
}