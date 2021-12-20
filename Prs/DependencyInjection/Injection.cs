using Application.Repository.Bu;
using Application.Repository.CarteiraConta;
using Application.Repository.Clientes;
using Application.Repository.Categoria;
using Application.Repository.Concorrente;
using Application.Repository.Edital;
using Application.Repository.Historico;
using Application.Repository.Ldap;
using Application.Repository.Modalidade;
using Application.Repository.ParecerDiretor;
using Application.Repository.ParecerGerente;
using Application.Repository.ParecerLicitacao;
using Application.Repository.Role;
using Application.Repository.Sla;
using Application.Repository.SolicitacaoCadastro;
using Application.Repository.Usuario;
using Infrastructure.Repository.Bu.Create;
using Infrastructure.Repository.Bu.GetAll;
using Infrastructure.Repository.Bu.GetById;
using Infrastructure.Repository.Bu.Update;
using Infrastructure.Repository.CarteiraConta.CreateCarteiraConta;
using Infrastructure.Repository.CarteiraConta.DeleteCarteiraConta;
using Infrastructure.Repository.CarteiraConta.GetAllCarteiraContas;
using Infrastructure.Repository.CarteiraConta.GetFormCarteiraConta;
using Infrastructure.Repository.Cliente.Create;
using Infrastructure.Repository.Cliente.GetAllClientes;
using Infrastructure.Repository.Cliente.GetById;
using Infrastructure.Repository.Cliente.GetByName;
using Infrastructure.Repository.Cliente.Update;
using Infrastructure.Repository.Categoria.Create;
using Infrastructure.Repository.Categoria.GetAll;
using Infrastructure.Repository.Categoria.GetById;
using Infrastructure.Repository.Categoria.GetDadosCategoria;
using Infrastructure.Repository.Categoria.Update;
using Infrastructure.Repository.Concorrente.Create;
using Infrastructure.Repository.Concorrente.GetAll;
using Infrastructure.Repository.Concorrente.GetById;
using Infrastructure.Repository.Concorrente.GetByName;
using Infrastructure.Repository.Concorrente.Update;
using Infrastructure.Repository.Edital.Create;
using Infrastructure.Repository.Edital.Delete;
using Infrastructure.Repository.Edital.GetById;
using Infrastructure.Repository.Edital.GetDadosCadastrarEdital;
using Infrastructure.Repository.Edital.GetTotalEdital;
using Infrastructure.Repository.Edital.GetTotalEditalGanhos;
using Infrastructure.Repository.Edital.GetTotalEditalGo;
using Infrastructure.Repository.Edital.GetTotalEditalNogo;
using Infrastructure.Repository.Edital.GetTotalEditalSuspenso;
using Infrastructure.Repository.Edital.RestaurarEditalSuspenso;
using Infrastructure.Repository.Edital.SuspenderEdital;
using Infrastructure.Repository.Edital.Update;
using Infrastructure.Repository.Edital.VerifyExists;
using Infrastructure.Repository.Historico.CriarHistorico;
using Infrastructure.Repository.Historico.GetHistoricoByEditalId;
using Infrastructure.Repository.Ldap.GetUserLdap;
using Infrastructure.Repository.Ldap.LoginLdap;
using Infrastructure.Repository.Modalidade.Create;
using Infrastructure.Repository.Modalidade.GetAll;
using Infrastructure.Repository.Modalidade.GetById;
using Infrastructure.Repository.Modalidade.Update;
using Infrastructure.Repository.ParecerDiretor.Create;
using Infrastructure.Repository.ParecerDiretor.Delete;
using Infrastructure.Repository.ParecerDiretor.GetById;
using Infrastructure.Repository.ParecerDiretor.GetDadosParecerDiretor;
using Infrastructure.Repository.ParecerDiretor.GetWaitingDiretor;
using Infrastructure.Repository.ParecerDiretor.Update;
using Infrastructure.Repository.ParecerDiretor.VerifiExists;
using Infrastructure.Repository.ParecerGerente.Create;
using Infrastructure.Repository.ParecerGerente.GetById;
using Infrastructure.Repository.ParecerGerente.GetDadosParecerGerente;
using Infrastructure.Repository.ParecerGerente.GetWaitingGerente;
using Infrastructure.Repository.ParecerGerente.Update;
using Infrastructure.Repository.ParecerGerente.VerifiExists;
using Infrastructure.Repository.ParecerLicitacao.Create;
using Infrastructure.Repository.ParecerLicitacao.Delete;
using Infrastructure.Repository.ParecerLicitacao.Finalize;
using Infrastructure.Repository.ParecerLicitacao.GetAguardandoFinalizacao;
using Infrastructure.Repository.ParecerLicitacao.GetByIdParecerLicitacao;
using Infrastructure.Repository.ParecerLicitacao.GetDadosParecerLicitacao;
using Infrastructure.Repository.ParecerLicitacao.GetWaitingLicitacao;
using Infrastructure.Repository.ParecerLicitacao.Suspenso;
using Infrastructure.Repository.ParecerLicitacao.Update;
using Infrastructure.Repository.ParecerLicitacao.VerifyExists;
using Infrastructure.Repository.Role.GetAllRoles;
using Infrastructure.Repository.Sla.GetSlaDiretores;
using Infrastructure.Repository.Sla.GetSlaEditalDiretor;
using Infrastructure.Repository.Sla.GetSlaEditalGerente;
using Infrastructure.Repository.Sla.GetSlaGerentes;
using Infrastructure.Repository.Sla.GetTMC;
using Infrastructure.Repository.Sla.GetTMPD;
using Infrastructure.Repository.Sla.GetTMPG;
using Infrastructure.Repository.Sla.VerifySlaDiretor;
using Infrastructure.Repository.Sla.VerifySlaGerente;
using Infrastructure.Repository.SolicitacaoCadastro.Create;
using Infrastructure.Repository.SolicitacaoCadastro.DeleteSolicitacao;
using Infrastructure.Repository.SolicitacaoCadastro.GetAllSolicitacao;
using Infrastructure.Repository.SolicitacaoCadastro.GetByIdSolicitacao;
using Infrastructure.Repository.Usuario.CreateUser;
using Infrastructure.Repository.Usuario.GetUserByEmail;
using Infrastructure.Repository.Usuario.GetUserByLogin;
using Infrastructure.Repository.Usuario.Notification;
using Infrastructure.Repository.Usuario.RecreateUser;
using Infrastructure.Repository.Usuario.UpdateDB;
using Infrastructure.Repository.Usuario.UpdateToken;
using Microsoft.Extensions.DependencyInjection;
using Application.Repository.MotivoComum;
using Infrastructure.Repository.MotivoComum.GetAllMotivoComum;
using Infrastructure.Repository.MotivoComum.GetByIdMotivoComum;
using Infrastructure.Repository.MotivoComum.CreateMotivoComum;
using Infrastructure.Repository.MotivoComum.UpdateMotivoComum;
using Application.Repository.Anexo;
using Infrastructure.Repository.Anexo.GetById;
using Infrastructure.Repository.Anexo.ConversorTemp;
using Infrastructure.Repository.Anexo.Create;
using Infrastructure.Repository.Anexo.Update;
using Application.Repository.MotivoPerda;
using Infrastructure.Repository.MotivoPerda.GetAll;
using Infrastructure.Repository.MotivoPerda.GetById;
using Infrastructure.Repository.MotivoPerda.Create;
using Infrastructure.Repository.MotivoPerda.Update;
using Application.Repository.Comentario;
using Infrastructure.Repository.Comentario.GetLast;
using Infrastructure.Repository.Comentario.GetById;
using Infrastructure.Repository.Comentario.Create;
using Infrastructure.Repository.Comentario.Update;
using Infrastructure.Repository.Comentario.Delete;
using Infrastructure.Repository.CarteiraConta.DeleteGerenteCarteiraConta;
using Infrastructure.Repository.CarteiraConta.DeleteGerenteComCarteira;
using Application.Repository.Dissidio;
using Infrastructure.Repository.Dissidio.ObterStatusDissidios;
using Infrastructure.Repository.Dissidio.GetDissidioByEstadoId;
using Infrastructure.Repository.Dissidio.GetDissidioById;
using Infrastructure.Repository.Dissidio.CreateDissidio;
using Infrastructure.Repository.Dissidio.UpdateDissidio;
using Application.Repository.Empresa;
using Infrastructure.Repository.Empresa.GetAll;
using Infrastructure.Repository.Empresa.GetById;
using Infrastructure.Repository.Empresa.Create;
using Infrastructure.Repository.Empresa.Update;
using Infrastructure.Repository.Usuario.GetAll;
using Application.Repository.DocumentoCL;
using Infrastructure.Repository.DocumentosCl;
using Infrastructure.Repository.DocumentosCl.GetById;
using Infrastructure.Repository.DocumentosCl.Create;
using Infrastructure.Repository.DocumentosCl.Update;
using Infrastructure.Repository.DocumentosCl.Delete;
using Application.Repository.PreVenda;
using Infrastructure.Repository.PreVenda.GetAll;
using Infrastructure.Repository.PreVenda.GetDadosPreVenda;
using Infrastructure.Repository.PreVenda.VerifyPreVenda;
using Infrastructure.Repository.PreVenda.Create;
using Infrastructure.Repository.PreVenda.Update;
using Application.Repository.ConsultaPublica;
using Infrastructure.Repository.ConsultaPublica.GetAll;
using Infrastructure.Repository.ConsultaPublica.GetById;
using Infrastructure.Repository.ConsultaPublica.GetDadosForm;
using Infrastructure.Repository.ConsultaPublica.Create;
using Infrastructure.Repository.ConsultaPublica.Update;
using Infrastructure.Repository.ConsultaPublica.Delete;
using Application.Repository.Portal;
using Infrastructure.Repository.Portal.GetAll;
using Infrastructure.Repository.Portal.GetById;
using Infrastructure.Repository.Portal.Create;
using Infrastructure.Repository.Portal.Update;
using Application.Repository.Relatorio;
using Infrastructure.Repository.Relatorio.Create;
using Infrastructure.Repository.Relatorio.GetDadosRelatorio;
using Application.Repository.Email;
using Infrastructure.Repository.Email.GetByIdEdital;
using Infrastructure.Repository.Edital.GetTotalEditalPerda;

namespace Prs.DependencyInjection
{
    public static class Injection
    {
        public static void Execute(IServiceCollection services)
        {
            Infrastructure(services);
            Application(services);
        }

        public static void Application(IServiceCollection services)
        {
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddSingleton<ISlaRepository, SlaRepository>();
            services.AddSingleton<ILdapRepository, LdapRepository>();
            services.AddSingleton<IEditalRepository, EditalRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<ISolicitacaoCadastroRespository, SolicitacaoCadastroRepository>();
            services.AddSingleton<ICarteiraContaRepository, CarteiraContaRepository>();
            services.AddSingleton<IHistoricoRepository, HistoricoRepository>();
            services.AddSingleton<IParecerGerenteRepository, ParecerGerenteRepository>();
            services.AddSingleton<IParecerDiretorRepository, ParecerDiretorRepository>();
            services.AddSingleton<IParecerLicitacaoRepository, ParecerLicitacaoRepository>();
            services.AddSingleton<IBuRepository, BuRepository>();


            services.AddSingleton<IClientesRepository, ClientesRepository>();

            services.AddSingleton<ICategoriaRepository, CategoriaRepository>();
            services.AddSingleton<IConcorrenteRepository, ConcorrenteRepository>();
            services.AddSingleton<IMotivoComumRepository, MotivoComumRepository>();
            services.AddSingleton<IMotivoPerdaRepository, MotivoPerdaRepository>();
            services.AddSingleton<IComentarioRepository, ComentarioRepository>();
            

            services.AddSingleton<IClientesRepository, ClientesRepository>();
            services.AddSingleton<ICategoriaRepository, CategoriaRepository>();
            services.AddSingleton<IConcorrenteRepository, ConcorrenteRepository>();
            services.AddSingleton<IModalidadeRepository, ModalidadeRepository>();
            services.AddSingleton<IAnexoRepository, AnexoRepository>();

            services.AddSingleton<IDissidioRepository, DissidioRepository>();
            services.AddSingleton<IEmpresaRepository, EmpresaRepository>();

            services.AddSingleton<IDocumentoClRepository, DocumentoClRepository>();

            services.AddSingleton<IPreVendaRepository, PreVendaRepository>();
            services.AddSingleton<IConsultaPublicaRepository, ConsultaPublicaRepository>();
            services.AddSingleton<IPortalRepository, PortalRepository>();

            services.AddSingleton<IRelatorioRepository, RelatorioRepository>();

            services.AddSingleton<IEmailRepository, EmailRepository>();
        }

        public static void Infrastructure(IServiceCollection services)
        {
            services.AddSingleton<IGetUserByLogin, GetUserByLogin>();
            services.AddSingleton<IGetUserByEmail, GetUserByEmail>();
            services.AddSingleton<IUpdateToken, UpdateToken>();
            services.AddSingleton<ICreateUser, CreateUser>();
            services.AddSingleton<IGetAllUsuario, GetAllUsuario>();
            services.AddSingleton<IUpdateDB, UpdateDB>();
            services.AddSingleton<IRecreateUser, RecreateUser>();
            services.AddSingleton<INotification, Notification>();
            services.AddSingleton<IGetTMC, GetTMC>();
            services.AddSingleton<IGetTMPG, GetTMPG>();
            services.AddSingleton<IGetTMPD, GetTMPD>();
            services.AddSingleton<IVerifySlaGerente, VerifySlaGerente>();
            services.AddSingleton<IVerifySlaDiretor, VerifySlaDiretor>();
            services.AddSingleton<IGetSlaGerentes, GetSlaGerentes>();
            services.AddSingleton<IGetSlaDiretores, GetSlaDiretores>();
            services.AddSingleton<IGetTotalEditalGanhos, GetTotalEditalGanhos>();
            services.AddSingleton<IGetTotalEditalPerda, GetTotalEditalPerda>();
            services.AddSingleton<IGetTotalEdital, GetTotalEdital>();
            services.AddSingleton<IGetDadosCadastrarEdital, GetDadosCadastrarEdital>();
            services.AddSingleton<IGetById, GetById>();
            services.AddSingleton<IGetTotalEditalGo, GetTotalEditalGo>();
            services.AddSingleton<IGetTotalEditalNogo, GetTotalEditalNogo>();
            services.AddSingleton<IGetTotalEditalSuspenso, GetTotalEditalSuspenso>();
            services.AddSingleton<IVerifyExists, VerifyExists>();
            services.AddSingleton<ICreate, Create>();
            services.AddSingleton<IUpdate, Update>();
            services.AddSingleton<IDeleteEdital, DeleteEdital>();
            services.AddSingleton<ISuspenderEdital, SuspenderEdital>();
            services.AddSingleton<ICreateSolicitacao, CreateSolicitacao>();
            services.AddSingleton<IGetAllSolicitacao, GetAllSolicitacao>();
            services.AddSingleton<IGetByIdSolicitacao, GetByIdSolicitacao>();
            services.AddSingleton<IDeleteSolicitacao, DeleteSolicitacao>();
            
            services.AddSingleton<IGetAllCarteiraContas, GetAllCarteiraContas>();
            services.AddSingleton<ICreateCarteiraConta, CreateCarteiraConta>();
            services.AddSingleton<IDeleteCarteiraConta, DeleteCarteiraConta>();
            services.AddSingleton<IGetFormCarteiraConta, GetFormCarteiraConta>();
            services.AddSingleton<IDeleteGerenteCarteiraConta, DeleteGerenteCarteiraConta>();
            services.AddSingleton<IDeleteGerenteComCarteiraConta, DeleteGerenteComCarteiraConta>();
            
            services.AddSingleton<ICriarHistorico, CriarHistorico>();
            services.AddSingleton<IGetHistoricoByEditalId, GetHistoricoByEditalId>();
            services.AddSingleton<IGetAllRoles, GetAllRoles>();
            services.AddSingleton<IGetUserLdap, GetUserLdap>();
            services.AddSingleton<ILoginLdap, LoginLdap>();

            services.AddSingleton<IGetWaitingGerente, GetWaitingGerente>();
            services.AddSingleton<IGetByIdGerente, GetByIdGerente>();
            services.AddSingleton<IGetSlaEditalGerente, GetSlaEditalGerente>();
            services.AddSingleton<IGetDadosParecerGerente, GetDadosParecerGerente>();
            services.AddSingleton<IVerifiExistsParecerGerente, VerifiExistsParecerGerente>();
            services.AddSingleton<ICreateParecerGerente, CreateParecerGerente>();
            services.AddSingleton<IUpdateParecerGerente, UpdateParecerGerente>();

            services.AddSingleton<IGetWaitingParecerDiretor, GetWaitingParecerDiretor>();
            services.AddSingleton<IGetByIdParecerDiretor, GetByIdParecerDiretor>();
            services.AddSingleton<IGetDadosParecerDiretor, GetDadosParecerDiretor>();
            services.AddSingleton<IGetSlaEditalDiretor, GetSlaEditalDiretor>();
            services.AddSingleton<IVerifiExistsParecerDiretor, VerifiExistsParecerDiretor>();
            services.AddSingleton<ICreateParecerDiretor, CreateParecerDiretor>();
            services.AddSingleton<IUpdateParecerDiretor, UpdateParecerDiretor>();
            services.AddSingleton<IDeleteParecerDiretor, DeleteParecerDiretor>();

            services.AddSingleton<IGetWaitingLicitacao, GetWaitingLicitacao>();
            services.AddSingleton<IGetByIdParecerLicitacao, GetByIdParecerLicitacao>();
            services.AddSingleton<IGetDadosParecerLicitacao, GetDadosParecerLicitacao>();
            services.AddSingleton<IVerifyExistsParecerLicitacao, VerifyExistsParecerLicitacao>();
            services.AddSingleton<ICreateParecerLicitacao, CreateParecerLicitacao>();
            services.AddSingleton<IUpdateParecerLicitacao, UpdateParecerLicitacao>();
            services.AddSingleton<IFinalizeParecerLicitacao, FinalizeParecerLicitacao>();
            services.AddSingleton<IDeleteParecerLicitacao, DeleteParecerLicitacao>();
            services.AddSingleton<ISuspensoParecerLicitacao, SuspensoParecerLicitacao>();
            services.AddSingleton<IRestaurarEditalSuspenso, RestaurarEditalSuspenso>();
            services.AddSingleton<IGetAguardandoFinalizacao, GetAguardandoFinalizacao>();

            services.AddSingleton<IGetAllBu, GetAllBu>();
            services.AddSingleton<IGetByIdBu, GetByIdBu>();
            services.AddSingleton<ICreateBu, CreateBu>();
            services.AddSingleton<IUpdateBu, UpdateBu>();

            services.AddSingleton<IGetAllClientes, GetAllClientes>();
            services.AddSingleton<IGetByIdCliente, GetByIdCliente>();
            services.AddSingleton<IGetByNameCliente, GetByNameCliente>();
            services.AddSingleton<ICreateCliente, CreateCliente>();
            services.AddSingleton<IUpdateCliente, UpdateCliente>();

            services.AddSingleton<IGetAllCategoria, GetAllCategoria>();
            services.AddSingleton<IGetByIdCategoria, GetByIdCategoria>();
            services.AddSingleton<IGetDadosCategoria, GetDadosCategoria>();
            services.AddSingleton<ICreateCategoria, CreateCategoria>();
            services.AddSingleton<IUpdateCategoria, UpdateCategoria>();

            services.AddSingleton<IGetAllConcorrente, GetAllConcorrente>();
            services.AddSingleton<IGetByIdConcorrente, GetByIdConcorrente>();
            services.AddSingleton<IGetByNameConcorrente, GetByNameConcorrente>();
            services.AddSingleton<ICreateConcorrente, CreateConcorrente>();
            services.AddSingleton<IUpdateConcorrente, UpdateConcorrente>();


            services.AddSingleton<IGetAllMotivoComum, GetAllMotivoComum>();
            services.AddSingleton<IGetByIdMotivoComum, GetByIdMotivoComum>();
            services.AddSingleton<ICreateMotivoComum, CreateMotivoComum>();
            services.AddSingleton<IUpdateMotivoComum, UpdateMotivoComum>();

            services.AddSingleton<IGetAllModalidade, GetAllModalidade>();
            services.AddSingleton<IGetByIdModalidade, GetByIdModalidade>();
            services.AddSingleton<ICreateModalidade, CreateModalidade>();
            services.AddSingleton<IUpdateModalidade, UpdateModalidade>();

            services.AddSingleton<IGetAllMotivoPerda, GetAllMotivoPerda>();
            services.AddSingleton<IGetByIdMotivoPerda, GetByIdMotivoPerda>();
            services.AddSingleton<ICreateMotivoPerda, CreateMotivoPerda>();
            services.AddSingleton<IUpdateMotivoPerda, UpdateMotivoPerda>();

            services.AddSingleton<IGetLastComentario, GetLastComentario>();
            services.AddSingleton<IGetByIdComentario, GetByIdComentario>();
            services.AddSingleton<ICreateComenterio, CreateComenterio>();
            services.AddSingleton<IUpdateComentario, UpdateComentario>();
            services.AddSingleton<IDeleteComentario, DeleteComentario>();

            services.AddSingleton<IObterStatusDissidios, ObterStatusDissidios>();
            services.AddSingleton<IGetDissidioByEstadoId, GetDissidioByEstadoId>();
            services.AddSingleton<IGetDissidioById, GetDissidioById>();
            services.AddSingleton<ICreateDissidio, CreateDissidio>();
            services.AddSingleton<IUpdateDissidio, UpdateDissidio>();

            services.AddSingleton<IGetByIdAnexo, GetByIdAnexo>();
            services.AddSingleton<IConversorTemp, ConversorTemp>();
            services.AddSingleton<ICreateAnexo, CreateAnexo>();
            services.AddSingleton<IUpdateAnexo, UpdateAnexo>();

            services.AddSingleton<IGetAllEmpresa, GetAllEmpresa>();
            services.AddSingleton<IGetByIdEmpresa, GetByIdEmpresa>();
            services.AddSingleton<ICreateEmpresa, CreateEmpresa>();
            services.AddSingleton<IUpdateEmpresa, UpdateEmpresa>();

            services.AddSingleton<IGetAllDocumentos, GetAllDocumentos>();
            services.AddSingleton<IGetByIdDocumento, GetByIdDocumento>();
            services.AddSingleton<ICreateDocumentoCl, CreateDocumentoCl>();
            services.AddSingleton<IUpdateDocumentoCl, UpdateDocumentoCl>();
            services.AddSingleton<IDeleteDocumentoCl, DeleteDocumentoCl>();

            services.AddSingleton<IGetAllPreVenda, GetAllPreVenda>();
            services.AddSingleton<IVerifyPreVenda, VerifyPreVenda>();
            services.AddSingleton<IGetDadosPreVenda, GetDadosPreVenda>();
            services.AddSingleton<ICreatePreVenda, CreatePreVenda>();
            services.AddSingleton<IUpdatePreVenda, UpdatePreVenda>();

            services.AddSingleton<IGetAllConsultaPublica, GetAllConsultaPublica>();
            services.AddSingleton<IGetByIdConsultaPublica, GetByIdConsultaPublica>();
            services.AddSingleton<IGetDadosFormConsultaPublica, GetDadosFormConsultaPublica>();
            services.AddSingleton<ICreateConsultaPublica, CreateConsultaPublica>();
            services.AddSingleton<IUpdateConsultaPublica, UpdateConsultaPublica>();
            services.AddSingleton<IDeleteConsultaPublica, DeleteConsultaPublica>();

            services.AddSingleton<IGetAllPortal, GetAllPortal>();
            services.AddSingleton<IGetByIdPortal, GetByIdPortal>();
            services.AddSingleton<ICreatePortal, CreatePortal>();
            services.AddSingleton<IUpdatePortal, UpdatePortal>();

            services.AddSingleton<ICreateRelatorio, CreateRelatorio>();
            services.AddSingleton<IGetFormRelatorio, GetFormRelatorio>();

            services.AddSingleton<IGetByIdEdital, GetByIdEdital>();
        }

    }
}
