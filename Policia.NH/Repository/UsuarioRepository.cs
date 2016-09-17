using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NHibernate;
using Policia.NH.Model;

namespace Policia.NH.Repository
{
    public class UsuarioRepository
    {
        private ISession session;

        public UsuarioRepository(ISession session)
        {
            this.session = session;
        }

        public IList<Usuario> GetAll()
        {
            var usuario = this.session.CreateCriteria<Usuario>().List<Usuario>();

            return usuario;
        }

        public bool Gravar(Usuario usuario)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.SaveOrUpdate(usuario);

                transacao.Commit();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool Excluir(Usuario usuario)
        {
            try
            {
                var transacao = this.session.BeginTransaction();

                this.session.Delete(usuario);

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
