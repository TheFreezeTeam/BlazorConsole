﻿namespace BlazorCli.Server
{
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.Hosting;

  public class Program
  {
    public static IHostBuilder CreateHostBuilder(string[] aArgumentArray) =>
      Host.CreateDefaultBuilder(aArgumentArray)
        .ConfigureWebHostDefaults(aWebHostBuilder => aWebHostBuilder.UseStartup<Startup>());

    public static void Main(string[] aArgumentArray) => CreateHostBuilder(aArgumentArray).Build().Run();
  }
}