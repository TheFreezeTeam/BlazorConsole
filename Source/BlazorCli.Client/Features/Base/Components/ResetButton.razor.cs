namespace BlazorCli.Client.Features.Base.Components
{
  using BlazorCli.Client.Features.Application;

  public class ResetButtonModel : BaseComponent
  {
    internal void ButtonClick() => Mediator.Send(new ResetStoreAction());
  }
}