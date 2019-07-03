namespace BlazorCli.Client.Features.Application.Components
{
  using BlazorCli.Client.Features.Base.Components;

  public class SideBarModel: BaseComponent
  {
    protected string NavMenuCssClass => ApplicationState.IsMenuExpanded ? null : "collapse";
  }
}
  