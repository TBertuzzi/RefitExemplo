using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using RefitExemplo.Models;

namespace RefitExemplo.Services
{
    public interface IRestApi
    {
        [Get("/todos")]
        Task<ICollection<Usuario>> GetTodos();

        [Get("/todos/{id}")]
        Task<Usuario> GetTodos(long id);

        //Apenas de Exemplo , não existe o método na API
        //[Post("/usuario/incluir")]
        //Task<Usuario> IncluirUsuario([Body(BodySerializationMethod.Json)] Usuario usuario);
    }
}
