namespace BlazorCli.Client.CommandLine
{
  using MediatR;
  using System;
  using System.CommandLine;
  using System.CommandLine.Invocation;
  using System.Threading.Tasks;

  internal class MediatorCommandHandler : ICommandHandler
  {
    private IMediator Mediator { get; }

    private Type Type { get; }

    public MediatorCommandHandler(Type aType, IMediator aMediator)
    {
      Type = aType;
      Mediator = aMediator;
    }

    //https://stackoverflow.com/questions/1089123/setting-a-property-by-reflection-with-a-string-value
    public async Task<int> InvokeAsync(InvocationContext aInvocationContext)
    {
      try
      {
        object request = Activator.CreateInstance(Type);
        foreach (SymbolResult symbolResult in aInvocationContext.ParseResult.CommandResult.Children)
        {
          var optionResult = symbolResult as OptionResult;
          object value = optionResult.GetValueOrDefault();
          Type.GetProperty(symbolResult.Name).SetValue(request, value);
        }

        Type requestType = Type.GetInterface(typeof(IRequest).Name);
        if (requestType != null)
        {
          _ = await Mediator.Send((IRequest)request);
        } else
        {
          Type genericRequestType = Type.GetInterface(typeof(IRequest<>).Name);
          Type x = genericRequestType.GenericTypeArguments[0];
          var foo = (Task)Mediator.GetType().GetMethod(nameof(Mediator.Send)).MakeGenericMethod(x).Invoke(Mediator, new object[] { request, null });
          await foo;
        }

        return 0;
      }
      catch (Exception aException)
      {
        Console.WriteLine($"Error: {aException.Message}");
        return 1;
      }
    }
  }
}