using System.Collections.Generic;
using System.Threading.Tasks;
using api_tw.Interfaces;
using api_tw.Models;
using Microsoft.EntityFrameworkCore;

namespace api_tw.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        easyTalkContext conexao = new easyTalkContext();

        public async Task<List<Categoria>> Get()
        {
            return await conexao.Categoria.ToListAsync();   
        }

        public async Task<Categoria> Get(int id)
        {
            return await conexao.Categoria.FindAsync(id);
        }

        public async Task<Categoria> Post(Categoria categoria)
        {
            await conexao.Categoria.AddAsync(categoria);
            await conexao.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Put(Categoria categoria)
        {
            conexao.Entry(categoria).State = EntityState.Modified;
            await conexao.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Delete(Categoria categoria)
        {
            conexao.Categoria.Remove(categoria);
            await conexao.SaveChangesAsync();
            return categoria;
        }
    }
}