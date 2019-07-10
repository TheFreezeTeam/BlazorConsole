namespace BlazorCli.Client.Components
{
  using BlazorCli.Client.Features.Base.Components;
  using Microsoft.AspNetCore.Components;
  using System;
  using System.Collections.Generic;
  using System.CommandLine;
  using System.CommandLine.Invocation;
  using System.Linq;
  using System.Threading.Tasks;

  public class CliBase : BaseComponent
  {
    protected readonly string TabKey = "9";
    [Inject] public Parser Parser { get; set; }

    protected string Input { get; set; }

    protected List<string> Output { get; set; }

    protected string Text => string.Join("<br/>", Output);

    private ParseResult ParseResult { get; set; }

    private int SuggestedIndex { get; set; }

    private string Suggestion => Suggestions.Count > 0 ? Suggestions[SuggestedIndex] : null;

    private List<string> Suggestions { get; set; }

    public CliBase()
    {
      Output = new List<string>();
      Suggestions = new List<string>();
    }

    protected async Task HandleKeyPress(UIKeyboardEventArgs aUIKeyboardEventArgs)
    {
      Console.WriteLine($"HandleKeyPress Key:{aUIKeyboardEventArgs.Key} Input:{Input}");
      if (aUIKeyboardEventArgs.Key == "Enter")
      {
        WriteLine("You pressed Enter");
        try
        {
          string[] args = Input?.Split(' ');
          _ = await Parser.InvokeAsync(args);
        }
        catch (Exception e)
        {
          Console.WriteLine($"Error: {e.Message}");
          //Logger.LogError(e, "Error", args);
        }
        // Process the command
      }
      if (aUIKeyboardEventArgs.Key == "Tab")
      {
        HandleTabKeyPress(aUIKeyboardEventArgs);
      }
      else
      {
        Suggestions.Clear();
      }
    }

    protected override Task OnInitAsync()
    {
      Output.Add("Line 1");
      Output.Add("Welcome to the Blazor console");
      Input = null;
      return base.OnInitAsync();
    }

    protected string ReadLine() => "something";

    protected void WriteLine(string aString) => Output.Add(aString);

    private void HandleTabKeyPress(UIKeyboardEventArgs aUIKeyboardEventArgs)
    {
      Console.WriteLine($"HandleTabKeyPress ShiftKey:{aUIKeyboardEventArgs.ShiftKey}");
      if (Suggestions.Count > 0)
      {
        SuggestedIndex = aUIKeyboardEventArgs.ShiftKey ? MovePrevious() : MoveNext();
      }
      else
      {
        Console.WriteLine($"HandleTabKeyPress Parsing Input:{Input}");
        ParseResult = Parser.Parse(Input);
        Suggestions = ParseResult.Suggestions().ToList();
        SuggestedIndex = 0;
      }
      //WriteLine(Suggestion);
      Console.WriteLine($"HandleTabKeyPress Suggestion:{Suggestion}");
      IEnumerable<Token> matchedTokens = ParseResult.Tokens.TakeWhile(aToken => !ParseResult.UnmatchedTokens.Contains(aToken.Value));

      string newInput = string.Join(" ", matchedTokens.Select(t => t.Value));
      Console.WriteLine($"HandleTabKeyPress matchedTokens Joined:{newInput}");
      newInput = $"{newInput} {Suggestion}";

      Input = newInput ?? Input;

      Console.WriteLine($"HandleTabKeyPress Input:{Input}");
      StateHasChanged();
    }

    private int MoveNext()
    {
      //WriteLine("You pressed Tab");
      return (SuggestedIndex == Suggestions.Count - 1) ? 0 : SuggestedIndex + 1;
    }

    private int MovePrevious()
    {
      //WriteLine("You pressed Shft-Tab");
      return (SuggestedIndex == 0) ? Suggestions.Count - 1 : SuggestedIndex - 1;
    }
  }
}