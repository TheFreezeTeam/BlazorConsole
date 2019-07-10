namespace BlazorCli.Client.Features.Application
{
  using MediatR;

  /// <summary>
  /// Reset all the states in the store
  /// </summary>
  public class ResetStoreAction : IRequest { }
}
