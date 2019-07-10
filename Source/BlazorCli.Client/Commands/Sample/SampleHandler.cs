namespace BlazorCli.Client.Commands.Sample
{
  using System;
  using System.Threading;
  using System.Threading.Tasks;
  using MediatR;

  internal class SampleHandler
    : IRequestHandler<SampleRequest>
  {
    public Task<Unit> Handle(SampleRequest aSampleRequest, CancellationToken aCancellationToken)
    {

      Console.WriteLine($"Parameter1:{aSampleRequest.Parameter1}");
      Console.WriteLine($"Parameter2:{aSampleRequest.Parameter2}");
      Console.WriteLine($"Parameter3:{aSampleRequest.Parameter3}");
      return Unit.Task;
    }
  }
}
