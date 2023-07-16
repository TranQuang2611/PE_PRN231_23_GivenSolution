using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Q1.Models;

var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddODataQueryFilter();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
});


builder.Services.AddControllers().AddOData(option => option.Filter().Select().Expand().OrderBy().Count().SetMaxTop(100));

builder.Services.AddDbContext<PE_PRN_23SumContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")
 ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("CORSPolicy");
app.MapControllers();

app.Run();
