using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Policia.NH.Model
{
    public class Usuario
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Departamento { get; set; }
        public virtual string Patente { get; set; }
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }
        public virtual int Idade { get; set; }
    }

    public class UsuarioMap : ClassMapping<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<String>(x => x.Nome);
            Property<String>(x => x.Departamento);
            Property<String>(x => x.Patente);
            Property<String>(x => x.Login);
            Property<String>(x => x.Senha);
            Property<int>(x => x.Idade);
        }
    }
}
