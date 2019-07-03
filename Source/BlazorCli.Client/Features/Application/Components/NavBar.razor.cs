namespace BlazorCli.Client.Features.Application.Components
{
  using BlazorCli.Client.Features.Base.Components;

  public class NavBarModel : BaseComponent
  {
    protected string NavMenuCssClass => ApplicationState.IsMenuExpanded ? null : "collapse";
    protected async void ToggleNavMenu() => await Mediator.Send(new ToggleMenuAction());
  }
}
