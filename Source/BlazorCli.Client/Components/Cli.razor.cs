namespace BlazorCli.Client.Components
{
  using BlazorCli.Client.Features.Base.Components;
  using Microsoft.AspNetCore.Components;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public class CliBase: BaseComponent
  {
    protected readonly string TabKey = "9";
    public CliBase()
    {
      Output = new List<string>();
    }
    protected List<string> Output { get; set; }
    protected string Input { get; set; }

    protected string Text => string.Join("<br/>", Output);

    protected override Task OnInitAsync()
    {
      Output.Add("Line 1");
      Output.Add("Welcome to the Blazor console");
      return base.OnInitAsync();
    }

    protected string ReadLine() => "something";

    protected void WriteLine(string aString) => Output.Add(aString);

    protected void HandleKeyPress(UIKeyboardEventArgs aUIKeyboardEventArgs)
    {
      WriteLine(aUIKeyboardEventArgs.Key);

      if (aUIKeyboardEventArgs.Key == "Enter")
      {
        WriteLine("You pressed Enter");
      }
      if (aUIKeyboardEventArgs.Key == "Tab")
      {
        WriteLine("You pressed Tab");
      }
    }

    protected void HandleKeyDown(UIKeyboardEventArgs aUIKeyboardEventArgs)
    {
      WriteLine(aUIKeyboardEventArgs.Key);
      if(aUIKeyboardEventArgs.Key == "Tab")
      {
        WriteLine("Offer Suggestion now");

      }

    }

  }
}
