namespace BlazorCli.Client.Features.Application
{
  using MediatR;
  /// <summary>
  /// Toggle the Menu between expanded and collapsed.
  /// </summary>
  public class ToggleMenuAction : IRequest<ApplicationState> { }
}
