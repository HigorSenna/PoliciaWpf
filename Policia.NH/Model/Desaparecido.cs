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
        public virtual String Nome{get;set;}
        public virtual String UltimoLugarVisto { get; set; }
        public virtual String Contato { get; set; }

#warning Verificar como fica o Byte no banco
        public virtual byte[] Imagem { get; set; }
        public DateTime DataDesaparecimento { get; set; }
        public Caracteristica Caracteristica { get; set; }
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

            Property<String>(x => x.Nome);
            Property<String>(x => x.UltimoLugarVisto);
            Property<String>(x => x.Contato);
            Property<DateTime>(x => x.DataDesaparecimento);

#warning Verificar como fica o Byte no banco
            Property<byte[]>(x => x.Imagem);

#warning Verificar o One to One com caracteristica
            OneToOne<Caracteristica>(x => x.Caracteristica, m =>
            {

            });
        }
    }
}
