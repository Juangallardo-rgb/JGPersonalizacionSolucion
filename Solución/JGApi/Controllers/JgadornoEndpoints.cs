using Microsoft.EntityFrameworkCore;
using JGApi.Data;
using JGApi.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace JGApi.Controllers;

public static class JgadornoEndpoints
{
    public static void MapJgadornoEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Jgadorno").WithTags(nameof(Jgadorno));

        group.MapGet("/", async (JuanGallardoDbContext db) =>
        {
            return await db.Jgadornos.ToListAsync();
        })
        .WithName("GetAllJgadornos")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Jgadorno>, NotFound>> (int jgadornosid, JuanGallardoDbContext db) =>
        {
            return await db.Jgadornos.AsNoTracking()
                .FirstOrDefaultAsync(model => model.JgadornosId == jgadornosid)
                is Jgadorno model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetJgadornoById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int jgadornosid, Jgadorno jgadorno, JuanGallardoDbContext db) =>
        {
            var affected = await db.Jgadornos
                .Where(model => model.JgadornosId == jgadornosid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.JgadornosId, jgadorno.JgadornosId)
                    .SetProperty(m => m.Jgname, jgadorno.Jgname)
                    .SetProperty(m => m.Jgnavideno, jgadorno.Jgnavideno)
                    .SetProperty(m => m.Jgprice, jgadorno.Jgprice)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateJgadorno")
        .WithOpenApi();

        group.MapPost("/", async (Jgadorno jgadorno, JuanGallardoDbContext db) =>
        {
            db.Jgadornos.Add(jgadorno);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Jgadorno/{jgadorno.JgadornosId}",jgadorno);
        })
        .WithName("CreateJgadorno")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int jgadornosid, JuanGallardoDbContext db) =>
        {
            var affected = await db.Jgadornos
                .Where(model => model.JgadornosId == jgadornosid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteJgadorno")
        .WithOpenApi();
    }
}
