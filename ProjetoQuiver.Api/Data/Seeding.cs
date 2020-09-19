using ProjetoQuiver.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoQuiver.Api.Data
{
    public class Seeding
    {
        private DataContext _context;

        public Seeding(DataContext context)
        {
            _context = context;
        }

        public void Seed() 
        {
            if (_context.Contato.Any() || _context.Telefone.Any() || _context.Corretora.Any())
            {
                return;
            }
            else
            {
                Telefone t1 = new Telefone() { Numero = "(012)98888-7777" };
                Telefone t2 = new Telefone() { Numero = "(012)96666-5555" };
                Telefone t3 = new Telefone() { Numero = "(012)91111-8888" };
                Telefone t4 = new Telefone() { Numero = "(012)92222-6666" };
                Telefone t5 = new Telefone() { Numero = "(012)93333-5555" };
                Telefone t6 = new Telefone() { Numero = "(012)94444-4444" };
                Telefone t7 = new Telefone() { Numero = "(012)95555-3333" };
                Telefone t8 = new Telefone() { Numero = "(012)96666-2222" };
                Telefone t9 = new Telefone() { Numero = "(012)97777-1111" };
                Telefone t10 = new Telefone() { Numero = "(012)98888-9999" };
                Telefone t11 = new Telefone() { Numero = "(012)90000-1111" };
                Telefone t12 = new Telefone() { Numero = "(012)97474-0101" };

                Contato c1 = new Contato() { Nome = "Luiz", Sobrenome = "Roberto", Email = "luiz@gmail.com", Telefones = new List<Telefone>() { t1, t2 } };
                Contato c2 = new Contato() { Nome = "Maria", Sobrenome = "Santos", Email = "maria@gmail.com", Telefones = new List<Telefone>() { t3, t4 } };
                Contato c3 = new Contato() { Nome = "Leonardo", Sobrenome = "Souza", Email = "leonardo@gmail.com", Telefones = new List<Telefone>() { t5, t6 } };
                Contato c4 = new Contato() { Nome = "Pedro", Sobrenome = "Soares", Email = "pedro@gmail.com", Telefones = new List<Telefone>() { t7, t8 } };
                Contato c5 = new Contato() { Nome = "Roberto", Sobrenome = "Cavalcante", Email = "roberto@gmail.com", Telefones = new List<Telefone>() { t9, t10 } };
                Contato c6 = new Contato() { Nome = "Rafael", Sobrenome = "Dumon", Email = "rafael@gmail.com", Telefones = new List<Telefone>() { t11, t12 } };

                Corretora co1 = new Corretora() { Nome = "Porto Seguro", Password = "sdfert", Role = "funcionario", Contatos = new List<Contato> { c1, c2 } };
                Corretora co2 = new Corretora() { Nome = "Caixa Seguros", Password = "errtyy", Role = "gerente", Contatos = new List<Contato> { c3, c4 } };
                Corretora co3 = new Corretora() { Nome = "Quiver Seguro", Password = "wsderf", Role = "diretor", Contatos = new List<Contato> { c5, c6 } };
                
                _context.Telefone.AddRange(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
                _context.Contato.AddRange(c1, c2, c3, c4, c5, c6);
                _context.Corretora.AddRange(co1, co2, co3);

                _context.SaveChanges();
            }
        }
    }
}
