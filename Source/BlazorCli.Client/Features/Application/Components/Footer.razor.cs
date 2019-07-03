namespace BlazorCli.Client.Features.Application.Components
{
  using BlazorCli.Client.Features.Base.Components;

  public class FooterModel: BaseComponent
  {
    protected string Version => ApplicationState.Version;
  }
}
