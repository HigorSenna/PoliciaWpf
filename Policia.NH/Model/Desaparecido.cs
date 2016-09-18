using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Policia.NH.Model
{
    public class Desaparecido
    {
        public Desaparecido()
        {
            this.Caracteristica = new Caracteristica();
        }

        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        public virtual string UltimoLugarVisto { get; set; }

        public virtual string Contato { get; set; }

#warning Verificar como fica o Byte no banco
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

#warning Verificar como fica o Byte no banco
            Property<byte[]>(x => x.Imagem);

#warning Verificar o One to One com caracteristica
            OneToOne<Caracteristica>(x => x.Caracteristica, m =>
            {
                m.Cascade(Cascade.All);
                m.Key(k => k.Column("IdEvento"));
            });
        }
    }
}
