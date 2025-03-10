using Person.Models;
using Person.Data;
using Microsoft.EntityFrameworkCore;

namespace Person.Routes;

public static class PersonRoute
{
    public static void PersonRoutes(this WebApplication app)
    {
        var route = app.MapGroup("person");

        route.MapPost("",
            async (Request req, PersonContent context) =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(req.name))
                    {
                        return Results.BadRequest(new { message = "O nome da pessoa é obrigatório." });
                    }

                    var person = new Models.Person(req.name);

                    await context.AddAsync(person);
                    await context.SaveChangesAsync();

                    return Results.Created($"/person/{person.Id}", person);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = "Erro ao criar a pessoa.", details = ex.Message });
                }
            }
        );

        route.MapGet("", async (PersonContent context) =>
        {
            try
            {
                var people = await context.People.ToListAsync();
                return Results.Ok(people);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new { message = "Erro ao obter as pessoas.", details = ex.Message });
            }
        });

        route.MapPut("{id:guid}",
            async (Guid id, Request req, PersonContent context) =>
            {
                try
                {
                    var person = await context.People.FindAsync(id);
                    
                    if (person == null)
                        return Results.NotFound(new { message = "Pessoa não encontrada." });

                    person.ChangeName(req.name);
                    await context.SaveChangesAsync();

                    return Results.NoContent();
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = "Erro ao atualizar a pessoa.", details = ex.Message });
                }
            });

        route.MapDelete("{id:guid}",
            async (Guid id, PersonContent context) =>
            {
                try
                {
                    var person = await context.People.FindAsync(id);

                    if (person == null)
                        return Results.NotFound(new { message = "Pessoa não encontrada." });

                    person.SetInactive();
                    await context.SaveChangesAsync();

                    return Results.Ok(new { message = "Pessoa desativada com sucesso." });
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = "Erro ao desativar a pessoa.", details = ex.Message });
                }
            });
    }
}
