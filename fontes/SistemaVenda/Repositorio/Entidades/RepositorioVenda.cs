using Dominio.Entidades;
using Dominio.Repositorio;
using Microsoft.EntityFrameworkCore;
using Repositorio.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Repositorio.Entidades
{
    public class RepositorioVenda : Repositorio<Venda>, IRepositorioVenda
    {
        public RepositorioVenda(ApplicationDbContext dbContext): base(dbContext)
        {
        }

        public override IEnumerable<Venda> Read()
        {
            return DbSetContext.Include(x => x.Cliente).Include(y => y.Produtos).AsNoTracking().ToList();
        }
        
        public override Venda Read(int id)
        {
            return DbSetContext.Where(x => x.Codigo == id).Include(x => x.Cliente).Include(y => y.Produtos).FirstOrDefault();
        }

        public override void Delete(int id)
        {
            //Excluir os id's de venda que estão na tabela VendaProdutos            
            var listaProdutos = DbSetContext.Include(x => x.Produtos)
                                    .Where(y => y.Codigo == id).AsNoTracking().ToList();

            VendaProdutos vendaprodutos;
            foreach (var item in listaProdutos[0].Produtos)
            {
                vendaprodutos = new VendaProdutos();
                vendaprodutos.CodigoVenda = id;
                vendaprodutos.CodigoProduto = item.CodigoProduto;

                //delete dos produtos da venda
                DbSet<VendaProdutos> DbSetAux;
                DbSetAux = Db.Set<VendaProdutos>();
                DbSetAux.Attach(vendaprodutos);
                DbSetAux.Remove(vendaprodutos);
                Db.SaveChanges();
            }

            //delete da venda
            base.Delete(id);
        }
    }
}
