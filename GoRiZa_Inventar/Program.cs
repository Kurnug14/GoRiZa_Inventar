using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GoRiZa_Inventar.Model;
using GoRiZa_Inventar.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GoRiZa_InventarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GoRiZa")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region GEGENSTAND
async Task<List<Gegenstand>> GetAllGeg(GoRiZa_InventarContext context) => await context.Gegs.ToListAsync();

app.MapPost("/gegenstand", async (GoRiZa_InventarContext context, Gegenstand gegenstand) =>
{
 
    context.Gegs.Add(gegenstand);
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.MapGet("/gegenstand", async (GoRiZa_InventarContext context) => 
    await context.Gegs.ToListAsync()
);

app.MapGet("/gegenstand/{id}", async (GoRiZa_InventarContext context, int id) =>
    await context.Gegs.FindAsync(id) is Gegenstand gegenstand ?
    Results.Ok(gegenstand) :
    Results.NotFound("No such Gegenstand with this ID"));

app.MapPut("/gegenstand/{id}", async (GoRiZa_InventarContext context, Gegenstand gegenstand, int id) =>
{
    var current = await context.Gegs.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");
    current.GegenstandName = gegenstand.GegenstandName;
    current.KategorieId = gegenstand.KategorieId;
    current.Beschreib = gegenstand.Beschreib;
    current.Anzahl = gegenstand.Anzahl;

    await context.SaveChangesAsync();
    return Results.Ok(await GetAllGeg(context));
});

app.MapDelete("/gegenstand/{id}", async (GoRiZa_InventarContext context, int id) =>
{
    var current = await context.Gegs.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");

    context.Gegs.Remove(current);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllGeg(context));
});
#endregion
#region BENUTZER
async Task<List<Benutzer>> GetAllBen(GoRiZa_InventarContext context) => await context.Benutzers.ToListAsync();

app.MapGet("/benutzer", async (GoRiZa_InventarContext context) => await context.Benutzers.ToListAsync());

app.MapGet("/benutzer/{id}", async (GoRiZa_InventarContext context, int id) =>
    await context.Benutzers.FindAsync(id) is Benutzer benutzer ?
    Results.Ok(benutzer) :
    Results.NotFound("No such Benutzer with this ID"));

app.MapPost("/benutzer", async (GoRiZa_InventarContext context, Benutzer benutzer) =>
{
    context.Benutzers.Add(benutzer);
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/benutzer/{id}", async (GoRiZa_InventarContext context, Benutzer benutzer, int id) =>
{
    var current = await context.Benutzers.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");
    current.Name = benutzer.Name;
    current.Vorname = benutzer.Vorname;

    await context.SaveChangesAsync();
    return Results.Ok(await GetAllBen(context));
});

app.MapDelete("/benutzer/{id}", async (GoRiZa_InventarContext context, int id) =>
{
    var current = await context.Benutzers.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");

    context.Benutzers.Remove(current);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllBen(context));
});
#endregion
#region COMPUTER
async Task<List<Computer>> GetAllCom(GoRiZa_InventarContext context) => await context.Computers.ToListAsync();

app.MapGet("/computer", async (GoRiZa_InventarContext context) => await context.Computers.ToListAsync());

app.MapGet("/computer/{id}", async (GoRiZa_InventarContext context, int id) =>
    await context.Computers.FindAsync(id) is Computer computer?
    Results.Ok(computer) :
    Results.NotFound("No such Computer with this ID"));

app.MapPost("/computer", async (GoRiZa_InventarContext context, Computer computer) =>
{
    context.Computers.Add(computer);
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/computer/{id}", async (GoRiZa_InventarContext context, Computer computer, int id) =>
{
    var current = await context.Computers.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");
    current.BenutzerId = computer.BenutzerId;
    current.GegenstandId = computer.GegenstandId;

    await context.SaveChangesAsync();
    return Results.Ok(await GetAllCom(context));
});

app.MapDelete("/computer/{id}", async (GoRiZa_InventarContext context, int id) =>
{
    var current = await context.Computers.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");

    context.Computers.Remove(current);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllCom(context));
});
#endregion
#region KATEGORIE
async Task<List<Kategorie>> GetAllKat(GoRiZa_InventarContext context) => await context.Kategories.ToListAsync();

app.MapGet("/kategorie", async (GoRiZa_InventarContext context) => await context.Kategories.ToListAsync());

app.MapGet("/kategorie/{id}", async (GoRiZa_InventarContext context, int id) =>
    await context.Kategories.FindAsync(id) is Kategorie kategorie ?
    Results.Ok(kategorie) :
    Results.NotFound("No such Kategorie with this Id")
    );


app.MapPost("/kategorie", async (GoRiZa_InventarContext context, Kategorie kategorie) =>
{
    context.Kategories.Add(kategorie);
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/kategorie/{id}", async (GoRiZa_InventarContext context, Kategorie kategorie, int id) =>
{
    var current = await context.Kategories.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");

    current.KategorieName = kategorie.KategorieName;

    await context.SaveChangesAsync();
    return Results.Ok(await GetAllKat(context));
});

app.MapDelete("/kategorie/{id}", async (GoRiZa_InventarContext context, int id) =>
{
    var current = await context.Kategories.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");

    context.Kategories.Remove(current);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllKat(context));
});

#endregion
#region MATERIAL
async Task<List<Material>> GetAllMat(GoRiZa_InventarContext context) => await context.Materials.ToListAsync();

app.MapGet("/material", async (GoRiZa_InventarContext context) => await context.Materials.ToListAsync());

app.MapGet("/material/{id}", async (GoRiZa_InventarContext context, int id) =>
    await context.Materials.FindAsync(id) is Material material?
    Results.Ok(material) :
    Results.NotFound("No such Material with this Id")
    ); 

app.MapPost("/material", async (GoRiZa_InventarContext context, Material material) =>
{
    context.Materials.Add(material);
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/material/{id}", async (GoRiZa_InventarContext context, Material material, int id) =>
{
    var current = await context.Materials.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");

    current.GegenstandId = material.GegenstandId;
    current.Lagerbestand = material.Lagerbestand;

    await context.SaveChangesAsync();
    return Results.Ok(await GetAllMat(context));
});

app.MapDelete("/material/{id}", async (GoRiZa_InventarContext context, int id) =>
{
    var current = await context.Materials.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");

    context.Materials.Remove(current);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllMat(context));
});
#endregion
#region RAUM

async Task<List<Raum>> GetAllRau(GoRiZa_InventarContext context) => await context.Raums.ToListAsync();

app.MapGet("/raum", async (GoRiZa_InventarContext context) => await context.Raums.ToListAsync());

app.MapGet("/rauml/{id}", async (GoRiZa_InventarContext context, int id) =>
    await context.Raums.FindAsync(id) is Raum raum ?
    Results.Ok(raum) :
    Results.NotFound("No such Raum with this Id")
    );

app.MapPost("/raum", async (GoRiZa_InventarContext context, Raum raum) =>
{
    context.Raums.Add(raum);
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/raum/{id}", async (GoRiZa_InventarContext context, Raum raum, int id) =>
{
    var current = await context.Raums.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");

    current.RaumName = raum.RaumName;

    await context.SaveChangesAsync();
    return Results.Ok(await GetAllRau(context));
});

app.MapDelete("/raum/{id}", async (GoRiZa_InventarContext context, int id) =>
{
    var current = await context.Raums.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");

    context.Raums.Remove(current);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllRau(context));
});
#endregion 
#region RAUMGEGENSTAND
async Task<List<RaumGegenstand>> GetAllReg(GoRiZa_InventarContext context) => await context.RaumGegenstands.ToListAsync();

app.MapGet("/raumgegenstand", async (GoRiZa_InventarContext context) => await context.RaumGegenstands.ToListAsync());

app.MapGet("/raumgegenstand/{id}", async (GoRiZa_InventarContext context, int id) =>
    await context.RaumGegenstands.FindAsync(id) is RaumGegenstand raumgeg ?
    Results.Ok(raumgeg) :
    Results.NotFound("No such Kategorie with this Id")
    );

app.MapPost("/raumgegenstand", async (GoRiZa_InventarContext context, RaumGegenstand raumGegenstand) =>
{
    context.RaumGegenstands.Add(raumGegenstand);
    await context.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/raumgegenstand/{id}", async (GoRiZa_InventarContext context, RaumGegenstand raumGegenstand, int id) =>
{
    var current = await context.RaumGegenstands.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");

    current.RaumId = raumGegenstand.RaumId;
    current.GegenstandId = raumGegenstand.GegenstandId;

    await context.SaveChangesAsync();
    return Results.Ok(await GetAllReg(context));
});

app.MapDelete("/raumgegenstand/{id}", async (GoRiZa_InventarContext context, int id) =>
{
    var current = await context.RaumGegenstands.FindAsync(id);
    if (current == null) return Results.NotFound("No such Id");

    context.RaumGegenstands.Remove(current);
    await context.SaveChangesAsync();
    return Results.Ok(await GetAllReg(context));
});
#endregion

app.UseHttpsRedirection();

app.Run();