using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Policia.NH.Model
{
    public class Caracteristica
    {
        public virtual int Id { get; set; }
        public virtual String CorDoCabelo { get; set; }
        public virtual String CorDosOlhos { get; set; }
        public virtual String CorDaPele { get; set; }
        public virtual double AlturaAproximada { get; set; }
        public virtual double Peso { get; set; }
        public virtual int Idade { get; set; }
        public virtual Desaparecido Desaparecido { get; set; }

        public Caracteristica()
        {
            this.Desaparecido = new Desaparecido();
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

            Property<String>(x => x.CorDoCabelo);
            Property<String>(x => x.CorDosOlhos);
            Property<String>(x => x.CorDaPele);
            Property<double>(x => x.AlturaAproximada);
            Property<double>(x => x.Peso);
            Property<int>(x => x.Idade);

#warning Verificar One to One com desaparecido
            OneToOne<Desaparecido>(x => x.Desaparecido, m =>
            {
                
            });
        }
    }
}
