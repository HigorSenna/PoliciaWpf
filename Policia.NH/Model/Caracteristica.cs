using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Policia.NH.Model
{
    public class Caracteristica
    {
        public virtual int Id { get; set; }
        public virtual string CorDoCabelo { get; set; }
        public virtual string CorDosOlhos { get; set; }
        public virtual string CorDaPele { get; set; }
        public virtual double AlturaAproximada { get; set; }
        public virtual double Peso { get; set; }
        public virtual int Idade { get; set; }
        public virtual Desaparecido Desaparecido { get; set; }

        public Caracteristica()
        {
        }
    }

    public class CaracteristicaMap : ClassMapping<Caracteristica>
    {
        public CaracteristicaMap()
        {
            Table("Caracteristica");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<string>(x => x.CorDoCabelo);
            Property<string>(x => x.CorDosOlhos);
            Property<string>(x => x.CorDaPele);
            Property<double>(x => x.AlturaAproximada);
            Property<double>(x => x.Peso);
            Property<int>(x => x.Idade);

#warning Verificar One to One com desaparecido
            OneToOne<Desaparecido>(x => x.Desaparecido, m =>
            {
                m.Cascade(Cascade.All);
                m.Constrained(true);
                m.PropertyReference(x => x.Caracteristica);
                m.ForeignKey("DesaparecidoID");
            });
        }
    }
}
