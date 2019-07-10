namespace BlazorCli.Client.Commands.Sample
{
  using MediatR;

  /// <summary>
  /// Sample 2 Command.
  /// </summary>
  public class Sample2Request : IRequest
  {

    /// <summary>
    /// Some string
    /// </summary>
    public string Parameter1 { get; set; }

    /// <summary>
    /// Some integer
    /// </summary>
    public int Parameter2 { get; set; }

    /// <summary>
    /// Another Integer
    /// </summary>
    public int Parameter3 { get; set; }

  }
}
