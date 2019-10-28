using System.Collections.Generic;
using System.Threading.Tasks;
using api_tw.Models;

namespace api_tw.Interfaces
{
    public interface ICategoriaRepositorio
    {
         Task<List<Categoria>> Get();

         Task<Categoria> Get(int id);

         Task<Categoria> Post (Categoria categoria);

         Task<Categoria> Put(Categoria categoria);

         Task<Categoria> Delete(Categoria categoria);
    }
}