﻿using System;
using System.Reflection;
using System.Web;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Context;
using NHibernate.Mapping.ByCode;
using Policia.NH.Model;
using Policia.NH.Repository;

namespace Policia.NH.Config
{
    public class ConfigDB
    {
        public static string StringConexao =
            "Persist Security Info=False;server=localhost;port=3306;" +
            "database=policia;uid=root;pwd=aluno";

        private ISessionFactory SessionFactory;


        private static ConfigDB _instance = null;
        public static ConfigDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigDB();
                }

                return _instance;
            }
        }
#warning Criar o repository da classe aqui
        public UsuarioRepository UsuarioRepository { get; set; }
        public DesaparecidoRepository DesaparecidoRepository { get; set; }
        public CaracteristicaRepository CaracteristicaRepository { get; set; }

        public ConfigDB()
        {
            if (Conexao())
            {
#warning Adicionar as novas classes criadas aqui
                this.UsuarioRepository = new UsuarioRepository(Session);
                this.DesaparecidoRepository = new DesaparecidoRepository(Session);
                this.CaracteristicaRepository = new CaracteristicaRepository(Session);
            }
        }

        private bool Conexao()
        {
            //Cria a configuração com o NH
            var config = new Configuration();
            try
            {
                //Integração com o Banco de Dados
                config.DataBaseIntegration(c =>
                {
                    //Dialeto de Banco
                    c.Dialect<NHibernate.Dialect.MySQLDialect>();
                    //Conexao string
                    c.ConnectionString = StringConexao;
                    //Drive de conexão com o banco
                    c.Driver<NHibernate.Driver.MySqlDataDriver>();
                    // Provedor de conexão do MySQL 
                    c.ConnectionProvider<NHibernate.Connection.DriverConnectionProvider>();
                    // GERA LOG DOS SQL EXECUTADOS NO CONSOLE
                    c.LogSqlInConsole = true;
                    // DESCOMENTAR CASO QUEIRA VISUALIZAR O LOG DE SQL FORMATADO NO CONSOLE
                    c.LogFormattedSql = true;
                    // CRIA O SCHEMA DO BANCO DE DADOS SEMPRE QUE A CONFIGURATION FOR UTILIZADA
                    c.SchemaAction = SchemaAutoAction.Update;
                });

                //Realiza o mapeamento das classes
                var maps = this.Mapeamento();
                config.AddMapping(maps);

                //Verifico se a aplicação é Desktop ou Web
                if (HttpContext.Current == null)
                {
                    config.CurrentSessionContext<ThreadStaticSessionContext>();
                }
                else
                {
                    config.CurrentSessionContext<WebSessionContext>();
                }

                this.SessionFactory = config.BuildSessionFactory();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private HbmMapping Mapeamento()
        {
            try
            {
                var mapper = new ModelMapper();

#warning Adicionar os maps quandop criar uma nova classe.
                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(UsuarioMap)).GetTypes());

                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(DesaparecidoMap)).GetTypes());

                mapper.AddMappings(
                    Assembly.GetAssembly(typeof(CaracteristicaMap)).GetTypes());

                return mapper.CompileMappingForAllExplicitlyAddedEntities();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private ISession Session
        {
            get
            {
                try
                {
                    if (CurrentSessionContext.HasBind(SessionFactory))
                        return SessionFactory.GetCurrentSession();

                    var session = SessionFactory.OpenSession();
                    CurrentSessionContext.Bind(session);

                    return session;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
    }
}
