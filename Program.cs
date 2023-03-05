using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MaintenanceReminder.Data;
using Quartz;
using MaintenanceReminder.BackgroundServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MaintenanceReminderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MaintenanceReminderContext") ?? throw new InvalidOperationException("Connection string 'MaintenanceReminderContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddQuartz(q =>
{
    q.UseMicrosoftDependencyInjectionJobFactory();
    var jobKey = new JobKey("CheckDaysTillEndOfMaintenance");
    q.AddJob<CheckDaysTillEndOfMaintenance>(opts => opts.WithIdentity(jobKey));

    q.AddTrigger(opts => opts
        .ForJob(jobKey).WithIdentity("CheckDaysTillEndOfMaintenance-trigger").WithCronSchedule("0 * * ? * *"));
});

builder.Services.AddQuartzServer(options =>
{
    options.WaitForJobsToComplete = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
