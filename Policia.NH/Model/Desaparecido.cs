using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Policia.NH.Model
{
    public class Desaparecido
    {
        public Desaparecido()
        {
        }

        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string UltimoLugarVisto { get; set; }

        public virtual string Contato { get; set; }

        public virtual byte[] Imagem { get; set; }

        public virtual DateTime DataDesaparecimento { get; set; }

        public virtual Caracteristica Caracteristica { get; set; }
    }

    public class DesaparecidoMap : ClassMapping<Desaparecido>
    {
        public DesaparecidoMap()
        {
            Table("Desaparecido");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.Nome);
            Property<string>(x => x.UltimoLugarVisto);
            Property<string>(x => x.Contato);
            Property<DateTime>(x => x.DataDesaparecimento);

            Property<byte[]>(x => x.Imagem);

            OneToOne<Caracteristica>(x => x.Caracteristica, m =>
            {
                m.Cascade(Cascade.All);
                m.Constrained(true);
                m.ForeignKey("CaracteristicaID");
            });
        }
    }
}
