using CleanArch.Application.Repository;
using CleanArch.Application.UseCases;
using CleanArch.Domain.Repositories;
using CleanArch.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IncluirAlunoUseCase>();
            builder.Services.AddScoped<ListarTodosAlunosUseCase>();
            builder.Services.AddScoped<ListarUmAlunoUseCase>();
            builder.Services.AddScoped<AlterarAlunoUseCase>();
            builder.Services.AddScoped<ExcluirAlunoUseCase>();
            
            builder.Services.AddScoped<IncluirProfessorUseCase>();
            builder.Services.AddScoped<ListarTodosProfessoresUseCase>();
            builder.Services.AddScoped<ListarUmProfessorUseCase>();
            builder.Services.AddScoped<AlterarProfessorUseCase>();
            builder.Services.AddScoped<ExcluirProfessorUseCase>();

            builder.Services.AddScoped<IncluirCursoUseCase>();
            builder.Services.AddScoped<ListarTodosCursosUseCase>();
            builder.Services.AddScoped<ListarUmCursoUseCase>();
            builder.Services.AddScoped<AlterarCursoUseCase>();
            builder.Services.AddScoped<ExcluirCursoUseCase>();

            builder.Services.AddScoped<IncluirMatriculaUseCase>();
            builder.Services.AddScoped<ListarTodasMatriculasUseCase>();
            builder.Services.AddScoped<AlterarMatriculaUseCase>();


            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
            builder.Services.AddScoped<ICursoRepository, CursoRepository>();
            builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();

            builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MinhaConexao")));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}