namespace BlazorCli.Client.CommandLine
{
  using System.CommandLine.Builder;
  using System.CommandLine.Invocation;
  using BlazorCli.Client.Commands.Sample;
  using FluentValidation;
  using Microsoft.Extensions.DependencyInjection;

  internal class Startup
  {
    public void Configure(TimeWarpCommandLineBuilder aTimeWarpCommandLineBuilder)
    {
      aTimeWarpCommandLineBuilder
        .UseVersionOption()
        // middle-ware
        .UseHelp()
        .UseParseDirective()
        .UseDebugDirective()
        .UseSuggestDirective()
        .RegisterWithDotnetSuggest()
        .UseParseErrorReporting()
        .UseExceptionHandler();
    }

    public void ConfigureServices(IServiceCollection aServiceCollection) => 
      aServiceCollection.AddScoped<IValidator<SampleRequest>, SampleValidator>();
  }
}