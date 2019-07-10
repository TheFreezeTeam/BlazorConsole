namespace BlazorCli.Client.Features.Counter
{
  using MediatR;
  using BlazorCli.Shared.Features.Base;

  /// <summary>
  /// Will increment the count by the Amount passed.
  /// </summary>
  public class IncrementCounterAction : BaseRequest, IRequest<CounterState>
  {
    /// <summary>
    /// The Amount by which you would like to increment the count.
    /// </summary>
    /// <remarks>
    /// Use negative amount if you would like to decrement.
    /// </remarks>
    public int Amount { get; set; }
  }
}