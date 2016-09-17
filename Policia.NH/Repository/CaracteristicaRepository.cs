using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHibernate;
using Policia.NH.Model;

namespace Policia.NH.Repository
{
    public class CaracteristicaRepository
    {
        private ISession session;

        public CaracteristicaRepository(ISession session)
        {
            this.session = session;
        }

        public IList<Caracteristica> GetAll()
        {
            var caracteristicas = this.session.CreateCriteria<Caracteristica>().List<Caracteristica>();

            return caracteristicas;
        }

        public bool Gravar(Caracteristica caracteristica)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.SaveOrUpdate(caracteristica);

                transacao.Commit();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Excluir(Caracteristica caracteristica)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.Delete(caracteristica);

                transacao.Commit();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
