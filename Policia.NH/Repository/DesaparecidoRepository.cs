using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHibernate;
using Policia.NH.Model;

namespace Policia.NH.Repository
{
    public class DesaparecidoRepository
    {
        private ISession session;

        public DesaparecidoRepository(ISession session)
        {
            this.session = session;
        }

        public IList<Desaparecido> GetAll()
        {
            var desaparecidos = this.session.CreateCriteria<Desaparecido>().List<Desaparecido>();

            return desaparecidos;
        }

        public bool Gravar(Desaparecido desaparecido)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.SaveOrUpdate(desaparecido);

                transacao.Commit();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Excluir(Desaparecido desaparecido)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.Delete(desaparecido);

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
