using BearerClient;
using HomesEngland.AHP.Data;
using HomesEngland.AHP.DynamicsClient;
using HomesEngland.AHP.Operations.Properties;
using HomesEngland.AHP.Pages.Providers.GrantMilestones;
using Microsoft.EntityFrameworkCore;
using WandleSolutions.Common.ApiClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

string? repository = builder.Configuration["Repository"];

if (repository == "dynamics")
{

	builder.Services.AddSingleton<IAzureBearerTokenProxy, AzureBearerTokenProxy>();
	builder.Services.AddSingleton<ICacheProvider, InMemoryTokenCacheProvider>();

	IHttpClientBuilder httpBuilder = builder.Services.AddHttpClient("dynamicsEnvironment",
		   (httpClient) =>
		   {
			   ApiOptions apiOptions = new ApiOptions();

			   builder.Configuration.Bind("dynamicsEnvironment", apiOptions);

			   ApiClientConfigurationOptions.SetDefaultApiClientConfigurationOptions(httpClient, apiOptions);
		   })
		   .ConfigurePrimaryHttpMessageHandler(() => new ApiClientHandler());

	builder.Services.AddSingleton<IGrantRepository, DynamicsRepository>(_ =>
	{

		IHttpClientFactory httpClientFactory = _.GetRequiredService<IHttpClientFactory>();

		IAzureBearerTokenProxy proxy = _.GetRequiredService<IAzureBearerTokenProxy>();

		ICacheProvider cache = _.GetRequiredService<ICacheProvider>();
		AzureBearerTokenOptions options = builder.Configuration
		.GetSection("dynamicsAad")
		.Get<AzureBearerTokenOptions>();



		IBearerTokenProvider tokenProvider = new AzureBearerTokenProvider(proxy, cache, options);

		ICancellationTokenProvider cancellationTokenProvider = _.GetService<ICancellationTokenProvider>();

		return new DynamicsRepository(httpClientFactory, "dynamicsEnvironment", tokenProvider, cancellationTokenProvider);
	});

	builder.Services.AddSingleton<ISplitMilestoneService, DynamicsSplitMilestoneService>();
}
else
{
	builder.Services.AddDbContextFactory<AhpContext>(options =>
	{
		string connectionString = builder.Configuration.GetConnectionString("AhpContext");
		options.UseSqlServer(connectionString);
	});

	builder.Services.AddScoped<IGrantRepository, SqlGrantRepository>();

	builder.Services.AddDatabaseDeveloperPageExceptionFilter();

	builder.Services.AddSingleton<ISplitMilestoneService, SqlSplitMilestoneService>();

}


builder.Services.AddScoped<MilestoneCreationService>();

builder.Services.AddResponseCompression();
builder.Services.AddApplicationInsightsTelemetry();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseResponseCompression();
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
else
{
	app.UseMigrationsEndPoint();
}

//using (var scope = app.Services.CreateScope())
//{
//	var services = scope.ServiceProvider;

//	var context = services.GetRequiredService<AhpContext>();
//	context.Database.EnsureCreated();
//	// DbInitializer.Initialize(context);
//}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
