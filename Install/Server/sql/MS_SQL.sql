if not exists (select * from sysobjects where name='i_patch')
begin
create table i_patch (
i_unique int identity primary key,
st_done varchar(1) 
)
end
--CMD


if not exists (select * from sysobjects where name='T_Cartao')
begin
create table T_Cartao (
i_unique numeric(15) identity primary key,
st_empresa varchar(6),
st_matricula varchar(6),
st_titularidade varchar(2),
st_senha varchar(16),
tg_tipoCartao varchar(1),
st_venctoCartao varchar(4),
tg_status varchar(1),
dt_utlPagto datetime,
nu_senhaErrada int ,
dt_inclusao datetime,
dt_bloqueio datetime,
tg_motivoBloqueio varchar(1),
st_banco varchar(4),
st_agencia varchar(4),
st_conta varchar(10),
st_matriculaExtra varchar(10),
st_celCartao varchar(13),
fk_dadosProprietario int ,
fk_infoAdicionais int ,
nu_viaCartao int ,
vr_limiteTotal int ,
vr_limiteMensal int ,
vr_limiteRotativo int ,
vr_extraCota int ,
vr_educacional int ,
vr_disp_educacional int ,
vr_edu_diario int ,
st_aluno varchar(40),
tg_emitido int ,
vr_edu_disp_virtual int ,
nu_rankVirtual int ,
vr_edu_total_ranking int ,
nu_webSenhaErrada int ,
tg_semanaCompleta int ,
tg_excluido int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_empresa' )
begin
alter table T_Cartao add st_empresa varchar(6) 
end
else
begin
alter table T_Cartao alter column st_empresa varchar (6)
end
--CMD

if exists ( select st_empresa from T_Cartao where st_empresa IS NULL )
begin
update T_Cartao set st_empresa = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_matricula' )
begin
alter table T_Cartao add st_matricula varchar(6) 
end
else
begin
alter table T_Cartao alter column st_matricula varchar (6)
end
--CMD

if exists ( select st_matricula from T_Cartao where st_matricula IS NULL )
begin
update T_Cartao set st_matricula = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_titularidade' )
begin
alter table T_Cartao add st_titularidade varchar(2) 
end
else
begin
alter table T_Cartao alter column st_titularidade varchar (2)
end
--CMD

if exists ( select st_titularidade from T_Cartao where st_titularidade IS NULL )
begin
update T_Cartao set st_titularidade = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_senha' )
begin
alter table T_Cartao add st_senha varchar(16) 
end
else
begin
alter table T_Cartao alter column st_senha varchar (16)
end
--CMD

if exists ( select st_senha from T_Cartao where st_senha IS NULL )
begin
update T_Cartao set st_senha = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_st_senhaw' )
begin
drop index T_Cartao.index_T_Cartao_st_senhaw
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_senhaw' )
begin
alter table T_Cartao drop column st_senhaw
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'tg_tipoCartao' )
begin
alter table T_Cartao add tg_tipoCartao varchar(1) 
end
else
begin
alter table T_Cartao alter column tg_tipoCartao varchar (1)
end
--CMD

if exists ( select tg_tipoCartao from T_Cartao where tg_tipoCartao IS NULL )
begin
update T_Cartao set tg_tipoCartao = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_tg_viaCartao' )
begin
drop index T_Cartao.index_T_Cartao_tg_viaCartao
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'tg_viaCartao' )
begin
alter table T_Cartao drop column tg_viaCartao
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_venctoCartao' )
begin
alter table T_Cartao add st_venctoCartao varchar(4) 
end
else
begin
alter table T_Cartao alter column st_venctoCartao varchar (4)
end
--CMD

if exists ( select st_venctoCartao from T_Cartao where st_venctoCartao IS NULL )
begin
update T_Cartao set st_venctoCartao = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_st_cpf' )
begin
drop index T_Cartao.index_T_Cartao_st_cpf
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_cpf' )
begin
alter table T_Cartao drop column st_cpf
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_nu_limiteTotal' )
begin
drop index T_Cartao.index_T_Cartao_nu_limiteTotal
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'nu_limiteTotal' )
begin
alter table T_Cartao drop column nu_limiteTotal
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_nu_limiteMensal' )
begin
drop index T_Cartao.index_T_Cartao_nu_limiteMensal
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'nu_limiteMensal' )
begin
alter table T_Cartao drop column nu_limiteMensal
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_nu_limiteRotativo' )
begin
drop index T_Cartao.index_T_Cartao_nu_limiteRotativo
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'nu_limiteRotativo' )
begin
alter table T_Cartao drop column nu_limiteRotativo
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_nu_extraCota' )
begin
drop index T_Cartao.index_T_Cartao_nu_extraCota
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'nu_extraCota' )
begin
alter table T_Cartao drop column nu_extraCota
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'tg_status' )
begin
alter table T_Cartao add tg_status varchar(1) 
end
else
begin
alter table T_Cartao alter column tg_status varchar (1)
end
--CMD

if exists ( select tg_status from T_Cartao where tg_status IS NULL )
begin
update T_Cartao set tg_status = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'dt_utlPagto' )
begin
alter table T_Cartao add dt_utlPagto datetime
end
--CMD

if exists ( select dt_utlPagto from T_Cartao where dt_utlPagto IS NULL )
begin
update T_Cartao set dt_utlPagto = '1900-01-01 00:00:00.000'
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_nu_diaVencto' )
begin
drop index T_Cartao.index_T_Cartao_nu_diaVencto
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'nu_diaVencto' )
begin
alter table T_Cartao drop column nu_diaVencto
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_nu_diaFechFatura' )
begin
drop index T_Cartao.index_T_Cartao_nu_diaFechFatura
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'nu_diaFechFatura' )
begin
alter table T_Cartao drop column nu_diaFechFatura
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_tg_testeProducao' )
begin
drop index T_Cartao.index_T_Cartao_tg_testeProducao
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'tg_testeProducao' )
begin
alter table T_Cartao drop column tg_testeProducao
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'nu_senhaErrada' )
begin
alter table T_Cartao add nu_senhaErrada int
end
--CMD

if exists ( select nu_senhaErrada from T_Cartao where nu_senhaErrada IS NULL )
begin
update T_Cartao set nu_senhaErrada = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'dt_inclusao' )
begin
alter table T_Cartao add dt_inclusao datetime
end
--CMD

if exists ( select dt_inclusao from T_Cartao where dt_inclusao IS NULL )
begin
update T_Cartao set dt_inclusao = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'dt_bloqueio' )
begin
alter table T_Cartao add dt_bloqueio datetime
end
--CMD

if exists ( select dt_bloqueio from T_Cartao where dt_bloqueio IS NULL )
begin
update T_Cartao set dt_bloqueio = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'tg_motivoBloqueio' )
begin
alter table T_Cartao add tg_motivoBloqueio varchar(1) 
end
else
begin
alter table T_Cartao alter column tg_motivoBloqueio varchar (1)
end
--CMD

if exists ( select tg_motivoBloqueio from T_Cartao where tg_motivoBloqueio IS NULL )
begin
update T_Cartao set tg_motivoBloqueio = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_banco' )
begin
alter table T_Cartao add st_banco varchar(4) 
end
else
begin
alter table T_Cartao alter column st_banco varchar (4)
end
--CMD

if exists ( select st_banco from T_Cartao where st_banco IS NULL )
begin
update T_Cartao set st_banco = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_agencia' )
begin
alter table T_Cartao add st_agencia varchar(4) 
end
else
begin
alter table T_Cartao alter column st_agencia varchar (4)
end
--CMD

if exists ( select st_agencia from T_Cartao where st_agencia IS NULL )
begin
update T_Cartao set st_agencia = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_conta' )
begin
alter table T_Cartao add st_conta varchar(10) 
end
else
begin
alter table T_Cartao alter column st_conta varchar (10)
end
--CMD

if exists ( select st_conta from T_Cartao where st_conta IS NULL )
begin
update T_Cartao set st_conta = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_tg_gerencial' )
begin
drop index T_Cartao.index_T_Cartao_tg_gerencial
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'tg_gerencial' )
begin
alter table T_Cartao drop column tg_gerencial
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_matriculaExtra' )
begin
alter table T_Cartao add st_matriculaExtra varchar(10) 
end
else
begin
alter table T_Cartao alter column st_matriculaExtra varchar (10)
end
--CMD

if exists ( select st_matriculaExtra from T_Cartao where st_matriculaExtra IS NULL )
begin
update T_Cartao set st_matriculaExtra = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_celCartao' )
begin
alter table T_Cartao add st_celCartao varchar(13) 
end
else
begin
alter table T_Cartao alter column st_celCartao varchar (13)
end
--CMD

if exists ( select st_celCartao from T_Cartao where st_celCartao IS NULL )
begin
update T_Cartao set st_celCartao = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_nu_pontos' )
begin
drop index T_Cartao.index_T_Cartao_nu_pontos
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'nu_pontos' )
begin
alter table T_Cartao drop column nu_pontos
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'fk_dadosProprietario' )
begin
alter table T_Cartao add fk_dadosProprietario int
end
--CMD

if exists ( select fk_dadosProprietario from T_Cartao where fk_dadosProprietario IS NULL )
begin
update T_Cartao set fk_dadosProprietario = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'fk_infoAdicionais' )
begin
alter table T_Cartao add fk_infoAdicionais int
end
--CMD

if exists ( select fk_infoAdicionais from T_Cartao where fk_infoAdicionais IS NULL )
begin
update T_Cartao set fk_infoAdicionais = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'nu_viaCartao' )
begin
alter table T_Cartao add nu_viaCartao int
end
--CMD

if exists ( select nu_viaCartao from T_Cartao where nu_viaCartao IS NULL )
begin
update T_Cartao set nu_viaCartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'vr_limiteTotal' )
begin
alter table T_Cartao add vr_limiteTotal int
end
--CMD

if exists ( select vr_limiteTotal from T_Cartao where vr_limiteTotal IS NULL )
begin
update T_Cartao set vr_limiteTotal = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'vr_limiteMensal' )
begin
alter table T_Cartao add vr_limiteMensal int
end
--CMD

if exists ( select vr_limiteMensal from T_Cartao where vr_limiteMensal IS NULL )
begin
update T_Cartao set vr_limiteMensal = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'vr_limiteRotativo' )
begin
alter table T_Cartao add vr_limiteRotativo int
end
--CMD

if exists ( select vr_limiteRotativo from T_Cartao where vr_limiteRotativo IS NULL )
begin
update T_Cartao set vr_limiteRotativo = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'vr_extraCota' )
begin
alter table T_Cartao add vr_extraCota int
end
--CMD

if exists ( select vr_extraCota from T_Cartao where vr_extraCota IS NULL )
begin
update T_Cartao set vr_extraCota = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'vr_educacional' )
begin
alter table T_Cartao add vr_educacional int
end
--CMD

if exists ( select vr_educacional from T_Cartao where vr_educacional IS NULL )
begin
update T_Cartao set vr_educacional = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'vr_disp_educacional' )
begin
alter table T_Cartao add vr_disp_educacional int
end
--CMD

if exists ( select vr_disp_educacional from T_Cartao where vr_disp_educacional IS NULL )
begin
update T_Cartao set vr_disp_educacional = 0
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_vr_edu_extra' )
begin
drop index T_Cartao.index_T_Cartao_vr_edu_extra
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'vr_edu_extra' )
begin
alter table T_Cartao drop column vr_edu_extra
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_vr_disp_edu_extra' )
begin
drop index T_Cartao.index_T_Cartao_vr_disp_edu_extra
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'vr_disp_edu_extra' )
begin
alter table T_Cartao drop column vr_disp_edu_extra
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'vr_edu_diario' )
begin
alter table T_Cartao add vr_edu_diario int
end
--CMD

if exists ( select vr_edu_diario from T_Cartao where vr_edu_diario IS NULL )
begin
update T_Cartao set vr_edu_diario = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_aluno' )
begin
alter table T_Cartao add st_aluno varchar(40) 
end
else
begin
alter table T_Cartao alter column st_aluno varchar (40)
end
--CMD

if exists ( select st_aluno from T_Cartao where st_aluno IS NULL )
begin
update T_Cartao set st_aluno = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_st_senhaEdu' )
begin
drop index T_Cartao.index_T_Cartao_st_senhaEdu
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'st_senhaEdu' )
begin
alter table T_Cartao drop column st_senhaEdu
end
--CMD


if exists (select * from sysindexes where name='index_T_Cartao_tg_bloqueio' )
begin
drop index T_Cartao.index_T_Cartao_tg_bloqueio
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'tg_bloqueio' )
begin
alter table T_Cartao drop column tg_bloqueio
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'tg_emitido' )
begin
alter table T_Cartao add tg_emitido int
end
--CMD

if exists ( select tg_emitido from T_Cartao where tg_emitido IS NULL )
begin
update T_Cartao set tg_emitido = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'vr_edu_disp_virtual' )
begin
alter table T_Cartao add vr_edu_disp_virtual int
end
--CMD

if exists ( select vr_edu_disp_virtual from T_Cartao where vr_edu_disp_virtual IS NULL )
begin
update T_Cartao set vr_edu_disp_virtual = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'nu_rankVirtual' )
begin
alter table T_Cartao add nu_rankVirtual int
end
--CMD

if exists ( select nu_rankVirtual from T_Cartao where nu_rankVirtual IS NULL )
begin
update T_Cartao set nu_rankVirtual = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'vr_edu_total_ranking' )
begin
alter table T_Cartao add vr_edu_total_ranking int
end
--CMD

if exists ( select vr_edu_total_ranking from T_Cartao where vr_edu_total_ranking IS NULL )
begin
update T_Cartao set vr_edu_total_ranking = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'nu_webSenhaErrada' )
begin
alter table T_Cartao add nu_webSenhaErrada int
end
--CMD

if exists ( select nu_webSenhaErrada from T_Cartao where nu_webSenhaErrada IS NULL )
begin
update T_Cartao set nu_webSenhaErrada = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'tg_semanaCompleta' )
begin
alter table T_Cartao add tg_semanaCompleta int
end
--CMD

if exists ( select tg_semanaCompleta from T_Cartao where tg_semanaCompleta IS NULL )
begin
update T_Cartao set tg_semanaCompleta = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Cartao' ) and name = 'tg_excluido' )
begin
alter table T_Cartao add tg_excluido int
end
--CMD

if exists ( select tg_excluido from T_Cartao where tg_excluido IS NULL )
begin
update T_Cartao set tg_excluido = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_Cartao_fk_dadosProprietario' )
begin
drop index T_Cartao.index_T_Cartao_fk_dadosProprietario
end
--CMD
create index index_T_Cartao_fk_dadosProprietario on T_Cartao (fk_dadosProprietario)
--CMD

if exists (select * from sysindexes where name='index_T_Cartao_fk_infoAdicionais' )
begin
drop index T_Cartao.index_T_Cartao_fk_infoAdicionais
end
--CMD
create index index_T_Cartao_fk_infoAdicionais on T_Cartao (fk_infoAdicionais)
--CMD


if not exists (select * from sysobjects where name='T_InfoAdicionais')
begin
create table T_InfoAdicionais (
i_unique numeric(15) identity primary key,
st_codigo varchar(6),
st_empresaAfiliada varchar(30),
st_presenteado varchar(50),
st_recado varchar(80),
dt_edu_nasc datetime,
st_edu_sexo varchar(1),
st_edu_grau varchar(1),
st_edu_serie_semestre varchar(2),
st_edu_turma varchar(10),
st_edu_curso varchar(30),
dt_edu_atualizacao datetime,
st_empresa varchar(6),
st_matricula varchar(6)
)
end
--CMD

if exists (select * from sysindexes where name='index_T_InfoAdicionais_fk_cartao' )
begin
drop index T_InfoAdicionais.index_T_InfoAdicionais_fk_cartao
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'fk_cartao' )
begin
alter table T_InfoAdicionais drop column fk_cartao
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_codigo' )
begin
alter table T_InfoAdicionais add st_codigo varchar(6) 
end
else
begin
alter table T_InfoAdicionais alter column st_codigo varchar (6)
end
--CMD

if exists ( select st_codigo from T_InfoAdicionais where st_codigo IS NULL )
begin
update T_InfoAdicionais set st_codigo = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_empresaAfiliada' )
begin
alter table T_InfoAdicionais add st_empresaAfiliada varchar(30) 
end
else
begin
alter table T_InfoAdicionais alter column st_empresaAfiliada varchar (30)
end
--CMD

if exists ( select st_empresaAfiliada from T_InfoAdicionais where st_empresaAfiliada IS NULL )
begin
update T_InfoAdicionais set st_empresaAfiliada = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_InfoAdicionais_fk_comoSoube' )
begin
drop index T_InfoAdicionais.index_T_InfoAdicionais_fk_comoSoube
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'fk_comoSoube' )
begin
alter table T_InfoAdicionais drop column fk_comoSoube
end
--CMD


if exists (select * from sysindexes where name='index_T_InfoAdicionais_fk_timeRS' )
begin
drop index T_InfoAdicionais.index_T_InfoAdicionais_fk_timeRS
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'fk_timeRS' )
begin
alter table T_InfoAdicionais drop column fk_timeRS
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_presenteado' )
begin
alter table T_InfoAdicionais add st_presenteado varchar(50) 
end
else
begin
alter table T_InfoAdicionais alter column st_presenteado varchar (50)
end
--CMD

if exists ( select st_presenteado from T_InfoAdicionais where st_presenteado IS NULL )
begin
update T_InfoAdicionais set st_presenteado = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_recado' )
begin
alter table T_InfoAdicionais add st_recado varchar(80) 
end
else
begin
alter table T_InfoAdicionais alter column st_recado varchar (80)
end
--CMD

if exists ( select st_recado from T_InfoAdicionais where st_recado IS NULL )
begin
update T_InfoAdicionais set st_recado = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_InfoAdicionais_st_edu_cod_aluno' )
begin
drop index T_InfoAdicionais.index_T_InfoAdicionais_st_edu_cod_aluno
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_edu_cod_aluno' )
begin
alter table T_InfoAdicionais drop column st_edu_cod_aluno
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'dt_edu_nasc' )
begin
alter table T_InfoAdicionais add dt_edu_nasc datetime
end
--CMD

if exists ( select dt_edu_nasc from T_InfoAdicionais where dt_edu_nasc IS NULL )
begin
update T_InfoAdicionais set dt_edu_nasc = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_edu_sexo' )
begin
alter table T_InfoAdicionais add st_edu_sexo varchar(1) 
end
else
begin
alter table T_InfoAdicionais alter column st_edu_sexo varchar (1)
end
--CMD

if exists ( select st_edu_sexo from T_InfoAdicionais where st_edu_sexo IS NULL )
begin
update T_InfoAdicionais set st_edu_sexo = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_edu_grau' )
begin
alter table T_InfoAdicionais add st_edu_grau varchar(1) 
end
else
begin
alter table T_InfoAdicionais alter column st_edu_grau varchar (1)
end
--CMD

if exists ( select st_edu_grau from T_InfoAdicionais where st_edu_grau IS NULL )
begin
update T_InfoAdicionais set st_edu_grau = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_edu_serie_semestre' )
begin
alter table T_InfoAdicionais add st_edu_serie_semestre varchar(2) 
end
else
begin
alter table T_InfoAdicionais alter column st_edu_serie_semestre varchar (2)
end
--CMD

if exists ( select st_edu_serie_semestre from T_InfoAdicionais where st_edu_serie_semestre IS NULL )
begin
update T_InfoAdicionais set st_edu_serie_semestre = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_edu_turma' )
begin
alter table T_InfoAdicionais add st_edu_turma varchar(10) 
end
else
begin
alter table T_InfoAdicionais alter column st_edu_turma varchar (10)
end
--CMD

if exists ( select st_edu_turma from T_InfoAdicionais where st_edu_turma IS NULL )
begin
update T_InfoAdicionais set st_edu_turma = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_edu_curso' )
begin
alter table T_InfoAdicionais add st_edu_curso varchar(30) 
end
else
begin
alter table T_InfoAdicionais alter column st_edu_curso varchar (30)
end
--CMD

if exists ( select st_edu_curso from T_InfoAdicionais where st_edu_curso IS NULL )
begin
update T_InfoAdicionais set st_edu_curso = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'dt_edu_atualizacao' )
begin
alter table T_InfoAdicionais add dt_edu_atualizacao datetime
end
--CMD

if exists ( select dt_edu_atualizacao from T_InfoAdicionais where dt_edu_atualizacao IS NULL )
begin
update T_InfoAdicionais set dt_edu_atualizacao = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_empresa' )
begin
alter table T_InfoAdicionais add st_empresa varchar(6) 
end
else
begin
alter table T_InfoAdicionais alter column st_empresa varchar (6)
end
--CMD

if exists ( select st_empresa from T_InfoAdicionais where st_empresa IS NULL )
begin
update T_InfoAdicionais set st_empresa = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_InfoAdicionais' ) and name = 'st_matricula' )
begin
alter table T_InfoAdicionais add st_matricula varchar(6) 
end
else
begin
alter table T_InfoAdicionais alter column st_matricula varchar (6)
end
--CMD

if exists ( select st_matricula from T_InfoAdicionais where st_matricula IS NULL )
begin
update T_InfoAdicionais set st_matricula = ''
end
--CMD




if not exists (select * from sysobjects where name='T_Proprietario')
begin
create table T_Proprietario (
i_unique numeric(15) identity primary key,
st_cpf varchar(20),
st_nome varchar(99),
st_endereco varchar(900),
st_numero varchar(29),
st_complemento varchar(29),
st_bairro varchar(99),
st_cidade varchar(99),
st_UF varchar(2),
st_cep varchar(20),
st_ddd varchar(3),
st_telefone varchar(20),
dt_nasc datetime,
st_email varchar(199),
vr_renda int ,
st_senhaEdu varchar(16)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_cpf' )
begin
alter table T_Proprietario add st_cpf varchar(20) 
end
else
begin
alter table T_Proprietario alter column st_cpf varchar (20)
end
--CMD

if exists ( select st_cpf from T_Proprietario where st_cpf IS NULL )
begin
update T_Proprietario set st_cpf = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_nome' )
begin
alter table T_Proprietario add st_nome varchar(99) 
end
else
begin
alter table T_Proprietario alter column st_nome varchar (99)
end
--CMD

if exists ( select st_nome from T_Proprietario where st_nome IS NULL )
begin
update T_Proprietario set st_nome = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_endereco' )
begin
alter table T_Proprietario add st_endereco varchar(900) 
end
else
begin
alter table T_Proprietario alter column st_endereco varchar (900)
end
--CMD

if exists ( select st_endereco from T_Proprietario where st_endereco IS NULL )
begin
update T_Proprietario set st_endereco = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_numero' )
begin
alter table T_Proprietario add st_numero varchar(29) 
end
else
begin
alter table T_Proprietario alter column st_numero varchar (29)
end
--CMD

if exists ( select st_numero from T_Proprietario where st_numero IS NULL )
begin
update T_Proprietario set st_numero = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_complemento' )
begin
alter table T_Proprietario add st_complemento varchar(29) 
end
else
begin
alter table T_Proprietario alter column st_complemento varchar (29)
end
--CMD

if exists ( select st_complemento from T_Proprietario where st_complemento IS NULL )
begin
update T_Proprietario set st_complemento = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_bairro' )
begin
alter table T_Proprietario add st_bairro varchar(99) 
end
else
begin
alter table T_Proprietario alter column st_bairro varchar (99)
end
--CMD

if exists ( select st_bairro from T_Proprietario where st_bairro IS NULL )
begin
update T_Proprietario set st_bairro = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_cidade' )
begin
alter table T_Proprietario add st_cidade varchar(99) 
end
else
begin
alter table T_Proprietario alter column st_cidade varchar (99)
end
--CMD

if exists ( select st_cidade from T_Proprietario where st_cidade IS NULL )
begin
update T_Proprietario set st_cidade = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_UF' )
begin
alter table T_Proprietario add st_UF varchar(2) 
end
else
begin
alter table T_Proprietario alter column st_UF varchar (2)
end
--CMD

if exists ( select st_UF from T_Proprietario where st_UF IS NULL )
begin
update T_Proprietario set st_UF = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_cep' )
begin
alter table T_Proprietario add st_cep varchar(20) 
end
else
begin
alter table T_Proprietario alter column st_cep varchar (20)
end
--CMD

if exists ( select st_cep from T_Proprietario where st_cep IS NULL )
begin
update T_Proprietario set st_cep = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_ddd' )
begin
alter table T_Proprietario add st_ddd varchar(3) 
end
else
begin
alter table T_Proprietario alter column st_ddd varchar (3)
end
--CMD

if exists ( select st_ddd from T_Proprietario where st_ddd IS NULL )
begin
update T_Proprietario set st_ddd = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_telefone' )
begin
alter table T_Proprietario add st_telefone varchar(20) 
end
else
begin
alter table T_Proprietario alter column st_telefone varchar (20)
end
--CMD

if exists ( select st_telefone from T_Proprietario where st_telefone IS NULL )
begin
update T_Proprietario set st_telefone = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'dt_nasc' )
begin
alter table T_Proprietario add dt_nasc datetime
end
--CMD

if exists ( select dt_nasc from T_Proprietario where dt_nasc IS NULL )
begin
update T_Proprietario set dt_nasc = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_email' )
begin
alter table T_Proprietario add st_email varchar(199) 
end
else
begin
alter table T_Proprietario alter column st_email varchar (199)
end
--CMD

if exists ( select st_email from T_Proprietario where st_email IS NULL )
begin
update T_Proprietario set st_email = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Proprietario_fk_profissao' )
begin
drop index T_Proprietario.index_T_Proprietario_fk_profissao
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'fk_profissao' )
begin
alter table T_Proprietario drop column fk_profissao
end
--CMD


if exists (select * from sysindexes where name='index_T_Proprietario_nu_renda' )
begin
drop index T_Proprietario.index_T_Proprietario_nu_renda
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'nu_renda' )
begin
alter table T_Proprietario drop column nu_renda
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'vr_renda' )
begin
alter table T_Proprietario add vr_renda int
end
--CMD

if exists ( select vr_renda from T_Proprietario where vr_renda IS NULL )
begin
update T_Proprietario set vr_renda = 0
end
--CMD


if exists (select * from sysindexes where name='index_T_Proprietario_id_instrucao' )
begin
drop index T_Proprietario.index_T_Proprietario_id_instrucao
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'id_instrucao' )
begin
alter table T_Proprietario drop column id_instrucao
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Proprietario' ) and name = 'st_senhaEdu' )
begin
alter table T_Proprietario add st_senhaEdu varchar(16) 
end
else
begin
alter table T_Proprietario alter column st_senhaEdu varchar (16)
end
--CMD

if exists ( select st_senhaEdu from T_Proprietario where st_senhaEdu IS NULL )
begin
update T_Proprietario set st_senhaEdu = ''
end
--CMD




if not exists (select * from sysobjects where name='T_Dependente')
begin
create table T_Dependente (
i_unique numeric(15) identity primary key,
nu_titularidade int ,
st_nome varchar(40),
fk_proprietario int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Dependente' ) and name = 'nu_titularidade' )
begin
alter table T_Dependente add nu_titularidade int
end
--CMD

if exists ( select nu_titularidade from T_Dependente where nu_titularidade IS NULL )
begin
update T_Dependente set nu_titularidade = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Dependente' ) and name = 'st_nome' )
begin
alter table T_Dependente add st_nome varchar(40) 
end
else
begin
alter table T_Dependente alter column st_nome varchar (40)
end
--CMD

if exists ( select st_nome from T_Dependente where st_nome IS NULL )
begin
update T_Dependente set st_nome = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Dependente_st_empresa' )
begin
drop index T_Dependente.index_T_Dependente_st_empresa
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Dependente' ) and name = 'st_empresa' )
begin
alter table T_Dependente drop column st_empresa
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Dependente' ) and name = 'fk_proprietario' )
begin
alter table T_Dependente add fk_proprietario int
end
--CMD

if exists ( select fk_proprietario from T_Dependente where fk_proprietario IS NULL )
begin
update T_Dependente set fk_proprietario = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_Dependente_fk_proprietario' )
begin
drop index T_Dependente.index_T_Dependente_fk_proprietario
end
--CMD
create index index_T_Dependente_fk_proprietario on T_Dependente (fk_proprietario)
--CMD


if not exists (select * from sysobjects where name='LINK_ProprietarioCartao')
begin
create table LINK_ProprietarioCartao (
i_unique numeric(15) identity primary key,
fk_cartao int ,
fk_proprietario int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_ProprietarioCartao' ) and name = 'fk_cartao' )
begin
alter table LINK_ProprietarioCartao add fk_cartao int
end
--CMD

if exists ( select fk_cartao from LINK_ProprietarioCartao where fk_cartao IS NULL )
begin
update LINK_ProprietarioCartao set fk_cartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_ProprietarioCartao' ) and name = 'fk_proprietario' )
begin
alter table LINK_ProprietarioCartao add fk_proprietario int
end
--CMD

if exists ( select fk_proprietario from LINK_ProprietarioCartao where fk_proprietario IS NULL )
begin
update LINK_ProprietarioCartao set fk_proprietario = 0
end
--CMD



if exists (select * from sysindexes where name='index_LINK_ProprietarioCartao_fk_cartao' )
begin
drop index LINK_ProprietarioCartao.index_LINK_ProprietarioCartao_fk_cartao
end
--CMD
create index index_LINK_ProprietarioCartao_fk_cartao on LINK_ProprietarioCartao (fk_cartao)
--CMD

if exists (select * from sysindexes where name='index_LINK_ProprietarioCartao_fk_proprietario' )
begin
drop index LINK_ProprietarioCartao.index_LINK_ProprietarioCartao_fk_proprietario
end
--CMD
create index index_LINK_ProprietarioCartao_fk_proprietario on LINK_ProprietarioCartao (fk_proprietario)
--CMD


if not exists (select * from sysobjects where name='T_Usuario')
begin
create table T_Usuario (
i_unique numeric(15) identity primary key,
tg_nivel varchar(1),
tg_logoff varchar(1),
dt_trocaSenha datetime,
dt_ultUso datetime,
nu_senhaErrada int ,
tg_trocaSenha varchar(1),
st_senha_1 varchar(64),
st_senha_2 varchar(64),
st_senha_3 varchar(64),
st_senha_4 varchar(64),
st_senha_5 varchar(64),
st_empresa varchar(6),
st_senha varchar(64),
tg_bloqueio varchar(1),
st_nome varchar(20),
fk_quiosque int ,
tg_aviso int 
)
end
--CMD

if exists (select * from sysindexes where name='index_T_Usuario_st_name' )
begin
drop index T_Usuario.index_T_Usuario_st_name
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'st_name' )
begin
alter table T_Usuario drop column st_name
end
--CMD


if exists (select * from sysindexes where name='index_T_Usuario_st_pass' )
begin
drop index T_Usuario.index_T_Usuario_st_pass
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'st_pass' )
begin
alter table T_Usuario drop column st_pass
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'tg_nivel' )
begin
alter table T_Usuario add tg_nivel varchar(1) 
end
else
begin
alter table T_Usuario alter column tg_nivel varchar (1)
end
--CMD

if exists ( select tg_nivel from T_Usuario where tg_nivel IS NULL )
begin
update T_Usuario set tg_nivel = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'tg_logoff' )
begin
alter table T_Usuario add tg_logoff varchar(1) 
end
else
begin
alter table T_Usuario alter column tg_logoff varchar (1)
end
--CMD

if exists ( select tg_logoff from T_Usuario where tg_logoff IS NULL )
begin
update T_Usuario set tg_logoff = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'dt_trocaSenha' )
begin
alter table T_Usuario add dt_trocaSenha datetime
end
--CMD

if exists ( select dt_trocaSenha from T_Usuario where dt_trocaSenha IS NULL )
begin
update T_Usuario set dt_trocaSenha = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'dt_ultUso' )
begin
alter table T_Usuario add dt_ultUso datetime
end
--CMD

if exists ( select dt_ultUso from T_Usuario where dt_ultUso IS NULL )
begin
update T_Usuario set dt_ultUso = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'nu_senhaErrada' )
begin
alter table T_Usuario add nu_senhaErrada int
end
--CMD

if exists ( select nu_senhaErrada from T_Usuario where nu_senhaErrada IS NULL )
begin
update T_Usuario set nu_senhaErrada = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'tg_trocaSenha' )
begin
alter table T_Usuario add tg_trocaSenha varchar(1) 
end
else
begin
alter table T_Usuario alter column tg_trocaSenha varchar (1)
end
--CMD

if exists ( select tg_trocaSenha from T_Usuario where tg_trocaSenha IS NULL )
begin
update T_Usuario set tg_trocaSenha = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'st_senha_1' )
begin
alter table T_Usuario add st_senha_1 varchar(64) 
end
else
begin
alter table T_Usuario alter column st_senha_1 varchar (64)
end
--CMD

if exists ( select st_senha_1 from T_Usuario where st_senha_1 IS NULL )
begin
update T_Usuario set st_senha_1 = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'st_senha_2' )
begin
alter table T_Usuario add st_senha_2 varchar(64) 
end
else
begin
alter table T_Usuario alter column st_senha_2 varchar (64)
end
--CMD

if exists ( select st_senha_2 from T_Usuario where st_senha_2 IS NULL )
begin
update T_Usuario set st_senha_2 = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'st_senha_3' )
begin
alter table T_Usuario add st_senha_3 varchar(64) 
end
else
begin
alter table T_Usuario alter column st_senha_3 varchar (64)
end
--CMD

if exists ( select st_senha_3 from T_Usuario where st_senha_3 IS NULL )
begin
update T_Usuario set st_senha_3 = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'st_senha_4' )
begin
alter table T_Usuario add st_senha_4 varchar(64) 
end
else
begin
alter table T_Usuario alter column st_senha_4 varchar (64)
end
--CMD

if exists ( select st_senha_4 from T_Usuario where st_senha_4 IS NULL )
begin
update T_Usuario set st_senha_4 = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'st_senha_5' )
begin
alter table T_Usuario add st_senha_5 varchar(64) 
end
else
begin
alter table T_Usuario alter column st_senha_5 varchar (64)
end
--CMD

if exists ( select st_senha_5 from T_Usuario where st_senha_5 IS NULL )
begin
update T_Usuario set st_senha_5 = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'st_empresa' )
begin
alter table T_Usuario add st_empresa varchar(6) 
end
else
begin
alter table T_Usuario alter column st_empresa varchar (6)
end
--CMD

if exists ( select st_empresa from T_Usuario where st_empresa IS NULL )
begin
update T_Usuario set st_empresa = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'st_senha' )
begin
alter table T_Usuario add st_senha varchar(64) 
end
else
begin
alter table T_Usuario alter column st_senha varchar (64)
end
--CMD

if exists ( select st_senha from T_Usuario where st_senha IS NULL )
begin
update T_Usuario set st_senha = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'tg_bloqueio' )
begin
alter table T_Usuario add tg_bloqueio varchar(1) 
end
else
begin
alter table T_Usuario alter column tg_bloqueio varchar (1)
end
--CMD

if exists ( select tg_bloqueio from T_Usuario where tg_bloqueio IS NULL )
begin
update T_Usuario set tg_bloqueio = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'st_nome' )
begin
alter table T_Usuario add st_nome varchar(20) 
end
else
begin
alter table T_Usuario alter column st_nome varchar (20)
end
--CMD

if exists ( select st_nome from T_Usuario where st_nome IS NULL )
begin
update T_Usuario set st_nome = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'fk_quiosque' )
begin
alter table T_Usuario add fk_quiosque int
end
--CMD

if exists ( select fk_quiosque from T_Usuario where fk_quiosque IS NULL )
begin
update T_Usuario set fk_quiosque = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Usuario' ) and name = 'tg_aviso' )
begin
alter table T_Usuario add tg_aviso int
end
--CMD

if exists ( select tg_aviso from T_Usuario where tg_aviso IS NULL )
begin
update T_Usuario set tg_aviso = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_Usuario_fk_quiosque' )
begin
drop index T_Usuario.index_T_Usuario_fk_quiosque
end
--CMD
create index index_T_Usuario_fk_quiosque on T_Usuario (fk_quiosque)
--CMD


if not exists (select * from sysobjects where name='LINK_LojaEmpresa')
begin
create table LINK_LojaEmpresa (
i_unique numeric(15) identity primary key,
fk_loja int ,
fk_empresa int ,
tx_admin int ,
nu_dias_repasse int ,
st_ag varchar(10),
st_conta varchar(15),
st_banco varchar(15)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_LojaEmpresa' ) and name = 'fk_loja' )
begin
alter table LINK_LojaEmpresa add fk_loja int
end
--CMD

if exists ( select fk_loja from LINK_LojaEmpresa where fk_loja IS NULL )
begin
update LINK_LojaEmpresa set fk_loja = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_LojaEmpresa' ) and name = 'fk_empresa' )
begin
alter table LINK_LojaEmpresa add fk_empresa int
end
--CMD

if exists ( select fk_empresa from LINK_LojaEmpresa where fk_empresa IS NULL )
begin
update LINK_LojaEmpresa set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_LojaEmpresa' ) and name = 'tx_admin' )
begin
alter table LINK_LojaEmpresa add tx_admin int
end
--CMD

if exists ( select tx_admin from LINK_LojaEmpresa where tx_admin IS NULL )
begin
update LINK_LojaEmpresa set tx_admin = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_LojaEmpresa' ) and name = 'nu_dias_repasse' )
begin
alter table LINK_LojaEmpresa add nu_dias_repasse int
end
--CMD

if exists ( select nu_dias_repasse from LINK_LojaEmpresa where nu_dias_repasse IS NULL )
begin
update LINK_LojaEmpresa set nu_dias_repasse = 0
end
--CMD


if exists (select * from sysindexes where name='index_LINK_LojaEmpresa_nu_ag' )
begin
drop index LINK_LojaEmpresa.index_LINK_LojaEmpresa_nu_ag
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_LojaEmpresa' ) and name = 'nu_ag' )
begin
alter table LINK_LojaEmpresa drop column nu_ag
end
--CMD


if exists (select * from sysindexes where name='index_LINK_LojaEmpresa_nu_banco' )
begin
drop index LINK_LojaEmpresa.index_LINK_LojaEmpresa_nu_banco
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_LojaEmpresa' ) and name = 'nu_banco' )
begin
alter table LINK_LojaEmpresa drop column nu_banco
end
--CMD


if exists (select * from sysindexes where name='index_LINK_LojaEmpresa_nu_conta' )
begin
drop index LINK_LojaEmpresa.index_LINK_LojaEmpresa_nu_conta
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_LojaEmpresa' ) and name = 'nu_conta' )
begin
alter table LINK_LojaEmpresa drop column nu_conta
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_LojaEmpresa' ) and name = 'st_ag' )
begin
alter table LINK_LojaEmpresa add st_ag varchar(10) 
end
else
begin
alter table LINK_LojaEmpresa alter column st_ag varchar (10)
end
--CMD

if exists ( select st_ag from LINK_LojaEmpresa where st_ag IS NULL )
begin
update LINK_LojaEmpresa set st_ag = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_LojaEmpresa' ) and name = 'st_conta' )
begin
alter table LINK_LojaEmpresa add st_conta varchar(15) 
end
else
begin
alter table LINK_LojaEmpresa alter column st_conta varchar (15)
end
--CMD

if exists ( select st_conta from LINK_LojaEmpresa where st_conta IS NULL )
begin
update LINK_LojaEmpresa set st_conta = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_LojaEmpresa' ) and name = 'st_banco' )
begin
alter table LINK_LojaEmpresa add st_banco varchar(15) 
end
else
begin
alter table LINK_LojaEmpresa alter column st_banco varchar (15)
end
--CMD

if exists ( select st_banco from LINK_LojaEmpresa where st_banco IS NULL )
begin
update LINK_LojaEmpresa set st_banco = ''
end
--CMD



if exists (select * from sysindexes where name='index_LINK_LojaEmpresa_fk_loja' )
begin
drop index LINK_LojaEmpresa.index_LINK_LojaEmpresa_fk_loja
end
--CMD
create index index_LINK_LojaEmpresa_fk_loja on LINK_LojaEmpresa (fk_loja)
--CMD

if exists (select * from sysindexes where name='index_LINK_LojaEmpresa_fk_empresa' )
begin
drop index LINK_LojaEmpresa.index_LINK_LojaEmpresa_fk_empresa
end
--CMD
create index index_LINK_LojaEmpresa_fk_empresa on LINK_LojaEmpresa (fk_empresa)
--CMD


if not exists (select * from sysobjects where name='T_Loja')
begin
create table T_Loja (
i_unique numeric(15) identity primary key,
nu_CNPJ varchar(14),
st_nome varchar(99),
st_social varchar(99),
st_endereco varchar(199),
st_enderecoInst varchar(199),
nu_inscEst varchar(20),
st_cidade varchar(99),
st_estado varchar(2),
nu_CEP varchar(18),
nu_telefone varchar(20),
nu_fax varchar(20),
st_contato varchar(40),
vr_mensalidade int ,
nu_contaDeb varchar(20),
st_obs varchar(900),
st_loja varchar(40),
tg_blocked varchar(1),
nu_pctValor int ,
vr_transacao int ,
vr_minimo int ,
nu_franquia int ,
nu_periodoFat int ,
nu_diavenc int ,
tg_tipoCobranca varchar(1),
nu_bancoFat int ,
tg_isentoFat int ,
st_senha varchar(16),
tg_cancel int 
)
end
--CMD

if exists (select * from sysindexes where name='index_T_Loja_st_empresa' )
begin
drop index T_Loja.index_T_Loja_st_empresa
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_empresa' )
begin
alter table T_Loja drop column st_empresa
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_CNPJ' )
begin
alter table T_Loja add nu_CNPJ varchar(14) 
end
else
begin
alter table T_Loja alter column nu_CNPJ varchar (14)
end
--CMD

if exists ( select nu_CNPJ from T_Loja where nu_CNPJ IS NULL )
begin
update T_Loja set nu_CNPJ = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_nome' )
begin
alter table T_Loja add st_nome varchar(99) 
end
else
begin
alter table T_Loja alter column st_nome varchar (99)
end
--CMD

if exists ( select st_nome from T_Loja where st_nome IS NULL )
begin
update T_Loja set st_nome = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_social' )
begin
alter table T_Loja add st_social varchar(99) 
end
else
begin
alter table T_Loja alter column st_social varchar (99)
end
--CMD

if exists ( select st_social from T_Loja where st_social IS NULL )
begin
update T_Loja set st_social = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_endereco' )
begin
alter table T_Loja add st_endereco varchar(199) 
end
else
begin
alter table T_Loja alter column st_endereco varchar (199)
end
--CMD

if exists ( select st_endereco from T_Loja where st_endereco IS NULL )
begin
update T_Loja set st_endereco = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_enderecoInst' )
begin
alter table T_Loja add st_enderecoInst varchar(199) 
end
else
begin
alter table T_Loja alter column st_enderecoInst varchar (199)
end
--CMD

if exists ( select st_enderecoInst from T_Loja where st_enderecoInst IS NULL )
begin
update T_Loja set st_enderecoInst = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_inscEst' )
begin
alter table T_Loja add nu_inscEst varchar(20) 
end
else
begin
alter table T_Loja alter column nu_inscEst varchar (20)
end
--CMD

if exists ( select nu_inscEst from T_Loja where nu_inscEst IS NULL )
begin
update T_Loja set nu_inscEst = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Loja_st_ramo' )
begin
drop index T_Loja.index_T_Loja_st_ramo
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_ramo' )
begin
alter table T_Loja drop column st_ramo
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_cidade' )
begin
alter table T_Loja add st_cidade varchar(99) 
end
else
begin
alter table T_Loja alter column st_cidade varchar (99)
end
--CMD

if exists ( select st_cidade from T_Loja where st_cidade IS NULL )
begin
update T_Loja set st_cidade = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_estado' )
begin
alter table T_Loja add st_estado varchar(2) 
end
else
begin
alter table T_Loja alter column st_estado varchar (2)
end
--CMD

if exists ( select st_estado from T_Loja where st_estado IS NULL )
begin
update T_Loja set st_estado = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_CEP' )
begin
alter table T_Loja add nu_CEP varchar(18) 
end
else
begin
alter table T_Loja alter column nu_CEP varchar (18)
end
--CMD

if exists ( select nu_CEP from T_Loja where nu_CEP IS NULL )
begin
update T_Loja set nu_CEP = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_telefone' )
begin
alter table T_Loja add nu_telefone varchar(20) 
end
else
begin
alter table T_Loja alter column nu_telefone varchar (20)
end
--CMD

if exists ( select nu_telefone from T_Loja where nu_telefone IS NULL )
begin
update T_Loja set nu_telefone = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_fax' )
begin
alter table T_Loja add nu_fax varchar(20) 
end
else
begin
alter table T_Loja alter column nu_fax varchar (20)
end
--CMD

if exists ( select nu_fax from T_Loja where nu_fax IS NULL )
begin
update T_Loja set nu_fax = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_contato' )
begin
alter table T_Loja add st_contato varchar(40) 
end
else
begin
alter table T_Loja alter column st_contato varchar (40)
end
--CMD

if exists ( select st_contato from T_Loja where st_contato IS NULL )
begin
update T_Loja set st_contato = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'vr_mensalidade' )
begin
alter table T_Loja add vr_mensalidade int
end
--CMD

if exists ( select vr_mensalidade from T_Loja where vr_mensalidade IS NULL )
begin
update T_Loja set vr_mensalidade = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_contaDeb' )
begin
alter table T_Loja add nu_contaDeb varchar(20) 
end
else
begin
alter table T_Loja alter column nu_contaDeb varchar (20)
end
--CMD

if exists ( select nu_contaDeb from T_Loja where nu_contaDeb IS NULL )
begin
update T_Loja set nu_contaDeb = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_obs' )
begin
alter table T_Loja add st_obs varchar(900) 
end
else
begin
alter table T_Loja alter column st_obs varchar (900)
end
--CMD

if exists ( select st_obs from T_Loja where st_obs IS NULL )
begin
update T_Loja set st_obs = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_loja' )
begin
alter table T_Loja add st_loja varchar(40) 
end
else
begin
alter table T_Loja alter column st_loja varchar (40)
end
--CMD

if exists ( select st_loja from T_Loja where st_loja IS NULL )
begin
update T_Loja set st_loja = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'tg_blocked' )
begin
alter table T_Loja add tg_blocked varchar(1) 
end
else
begin
alter table T_Loja alter column tg_blocked varchar (1)
end
--CMD

if exists ( select tg_blocked from T_Loja where tg_blocked IS NULL )
begin
update T_Loja set tg_blocked = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Loja_nu_cod_tb' )
begin
drop index T_Loja.index_T_Loja_nu_cod_tb
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_cod_tb' )
begin
alter table T_Loja drop column nu_cod_tb
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_pctValor' )
begin
alter table T_Loja add nu_pctValor int
end
--CMD

if exists ( select nu_pctValor from T_Loja where nu_pctValor IS NULL )
begin
update T_Loja set nu_pctValor = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'vr_transacao' )
begin
alter table T_Loja add vr_transacao int
end
--CMD

if exists ( select vr_transacao from T_Loja where vr_transacao IS NULL )
begin
update T_Loja set vr_transacao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'vr_minimo' )
begin
alter table T_Loja add vr_minimo int
end
--CMD

if exists ( select vr_minimo from T_Loja where vr_minimo IS NULL )
begin
update T_Loja set vr_minimo = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_franquia' )
begin
alter table T_Loja add nu_franquia int
end
--CMD

if exists ( select nu_franquia from T_Loja where nu_franquia IS NULL )
begin
update T_Loja set nu_franquia = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_periodoFat' )
begin
alter table T_Loja add nu_periodoFat int
end
--CMD

if exists ( select nu_periodoFat from T_Loja where nu_periodoFat IS NULL )
begin
update T_Loja set nu_periodoFat = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_diavenc' )
begin
alter table T_Loja add nu_diavenc int
end
--CMD

if exists ( select nu_diavenc from T_Loja where nu_diavenc IS NULL )
begin
update T_Loja set nu_diavenc = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'tg_tipoCobranca' )
begin
alter table T_Loja add tg_tipoCobranca varchar(1) 
end
else
begin
alter table T_Loja alter column tg_tipoCobranca varchar (1)
end
--CMD

if exists ( select tg_tipoCobranca from T_Loja where tg_tipoCobranca IS NULL )
begin
update T_Loja set tg_tipoCobranca = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'nu_bancoFat' )
begin
alter table T_Loja add nu_bancoFat int
end
--CMD

if exists ( select nu_bancoFat from T_Loja where nu_bancoFat IS NULL )
begin
update T_Loja set nu_bancoFat = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'tg_isentoFat' )
begin
alter table T_Loja add tg_isentoFat int
end
--CMD

if exists ( select tg_isentoFat from T_Loja where tg_isentoFat IS NULL )
begin
update T_Loja set tg_isentoFat = 0
end
--CMD


if exists (select * from sysindexes where name='index_T_Loja_st_acessoWeb' )
begin
drop index T_Loja.index_T_Loja_st_acessoWeb
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_acessoWeb' )
begin
alter table T_Loja drop column st_acessoWeb
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'st_senha' )
begin
alter table T_Loja add st_senha varchar(16) 
end
else
begin
alter table T_Loja alter column st_senha varchar (16)
end
--CMD

if exists ( select st_senha from T_Loja where st_senha IS NULL )
begin
update T_Loja set st_senha = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Loja' ) and name = 'tg_cancel' )
begin
alter table T_Loja add tg_cancel int
end
--CMD

if exists ( select tg_cancel from T_Loja where tg_cancel IS NULL )
begin
update T_Loja set tg_cancel = 0
end
--CMD




if not exists (select * from sysobjects where name='T_Empresa')
begin
create table T_Empresa (
i_unique numeric(15) identity primary key,
st_empresa varchar(6),
nu_CNPJ varchar(14),
st_fantasia varchar(99),
st_social varchar(99),
st_endereco varchar(99),
st_cidade varchar(99),
st_estado varchar(2),
nu_CEP varchar(14),
nu_telefone varchar(20),
nu_cartoes int ,
nu_parcelas int ,
tg_blocked varchar(1),
fk_admin int ,
nu_contaDeb varchar(20),
vr_mensalidade int ,
nu_pctValor int ,
vr_transacao int ,
vr_minimo int ,
nu_franquia int ,
nu_periodoFat int ,
nu_diaVenc int ,
tg_tipoCobranca varchar(1),
nu_bancoFat int ,
vr_cartaoAtivo int ,
tg_isentoFat int ,
st_obs varchar(400),
tg_bloq int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'st_empresa' )
begin
alter table T_Empresa add st_empresa varchar(6) 
end
else
begin
alter table T_Empresa alter column st_empresa varchar (6)
end
--CMD

if exists ( select st_empresa from T_Empresa where st_empresa IS NULL )
begin
update T_Empresa set st_empresa = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_CNPJ' )
begin
alter table T_Empresa add nu_CNPJ varchar(14) 
end
else
begin
alter table T_Empresa alter column nu_CNPJ varchar (14)
end
--CMD

if exists ( select nu_CNPJ from T_Empresa where nu_CNPJ IS NULL )
begin
update T_Empresa set nu_CNPJ = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'st_fantasia' )
begin
alter table T_Empresa add st_fantasia varchar(99) 
end
else
begin
alter table T_Empresa alter column st_fantasia varchar (99)
end
--CMD

if exists ( select st_fantasia from T_Empresa where st_fantasia IS NULL )
begin
update T_Empresa set st_fantasia = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'st_social' )
begin
alter table T_Empresa add st_social varchar(99) 
end
else
begin
alter table T_Empresa alter column st_social varchar (99)
end
--CMD

if exists ( select st_social from T_Empresa where st_social IS NULL )
begin
update T_Empresa set st_social = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'st_endereco' )
begin
alter table T_Empresa add st_endereco varchar(99) 
end
else
begin
alter table T_Empresa alter column st_endereco varchar (99)
end
--CMD

if exists ( select st_endereco from T_Empresa where st_endereco IS NULL )
begin
update T_Empresa set st_endereco = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'st_cidade' )
begin
alter table T_Empresa add st_cidade varchar(99) 
end
else
begin
alter table T_Empresa alter column st_cidade varchar (99)
end
--CMD

if exists ( select st_cidade from T_Empresa where st_cidade IS NULL )
begin
update T_Empresa set st_cidade = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'st_estado' )
begin
alter table T_Empresa add st_estado varchar(2) 
end
else
begin
alter table T_Empresa alter column st_estado varchar (2)
end
--CMD

if exists ( select st_estado from T_Empresa where st_estado IS NULL )
begin
update T_Empresa set st_estado = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_CEP' )
begin
alter table T_Empresa add nu_CEP varchar(14) 
end
else
begin
alter table T_Empresa alter column nu_CEP varchar (14)
end
--CMD

if exists ( select nu_CEP from T_Empresa where nu_CEP IS NULL )
begin
update T_Empresa set nu_CEP = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_telefone' )
begin
alter table T_Empresa add nu_telefone varchar(20) 
end
else
begin
alter table T_Empresa alter column nu_telefone varchar (20)
end
--CMD

if exists ( select nu_telefone from T_Empresa where nu_telefone IS NULL )
begin
update T_Empresa set nu_telefone = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_cartoes' )
begin
alter table T_Empresa add nu_cartoes int
end
--CMD

if exists ( select nu_cartoes from T_Empresa where nu_cartoes IS NULL )
begin
update T_Empresa set nu_cartoes = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_parcelas' )
begin
alter table T_Empresa add nu_parcelas int
end
--CMD

if exists ( select nu_parcelas from T_Empresa where nu_parcelas IS NULL )
begin
update T_Empresa set nu_parcelas = 0
end
--CMD


if exists (select * from sysindexes where name='index_T_Empresa_nu_fatura' )
begin
drop index T_Empresa.index_T_Empresa_nu_fatura
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_fatura' )
begin
alter table T_Empresa drop column nu_fatura
end
--CMD


if exists (select * from sysindexes where name='index_T_Empresa_nu_diaCredito' )
begin
drop index T_Empresa.index_T_Empresa_nu_diaCredito
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_diaCredito' )
begin
alter table T_Empresa drop column nu_diaCredito
end
--CMD


if exists (select * from sysindexes where name='index_T_Empresa_vr_taxa' )
begin
drop index T_Empresa.index_T_Empresa_vr_taxa
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'vr_taxa' )
begin
alter table T_Empresa drop column vr_taxa
end
--CMD


if exists (select * from sysindexes where name='index_T_Empresa_nu_diasBloqueio' )
begin
drop index T_Empresa.index_T_Empresa_nu_diasBloqueio
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_diasBloqueio' )
begin
alter table T_Empresa drop column nu_diasBloqueio
end
--CMD


if exists (select * from sysindexes where name='index_T_Empresa_vr_pontos' )
begin
drop index T_Empresa.index_T_Empresa_vr_pontos
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'vr_pontos' )
begin
alter table T_Empresa drop column vr_pontos
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'tg_blocked' )
begin
alter table T_Empresa add tg_blocked varchar(1) 
end
else
begin
alter table T_Empresa alter column tg_blocked varchar (1)
end
--CMD

if exists ( select tg_blocked from T_Empresa where tg_blocked IS NULL )
begin
update T_Empresa set tg_blocked = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'fk_admin' )
begin
alter table T_Empresa add fk_admin int
end
--CMD

if exists ( select fk_admin from T_Empresa where fk_admin IS NULL )
begin
update T_Empresa set fk_admin = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_contaDeb' )
begin
alter table T_Empresa add nu_contaDeb varchar(20) 
end
else
begin
alter table T_Empresa alter column nu_contaDeb varchar (20)
end
--CMD

if exists ( select nu_contaDeb from T_Empresa where nu_contaDeb IS NULL )
begin
update T_Empresa set nu_contaDeb = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'vr_mensalidade' )
begin
alter table T_Empresa add vr_mensalidade int
end
--CMD

if exists ( select vr_mensalidade from T_Empresa where vr_mensalidade IS NULL )
begin
update T_Empresa set vr_mensalidade = 0
end
--CMD


if exists (select * from sysindexes where name='index_T_Empresa_vr_cartaoAivo' )
begin
drop index T_Empresa.index_T_Empresa_vr_cartaoAivo
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'vr_cartaoAivo' )
begin
alter table T_Empresa drop column vr_cartaoAivo
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_pctValor' )
begin
alter table T_Empresa add nu_pctValor int
end
--CMD

if exists ( select nu_pctValor from T_Empresa where nu_pctValor IS NULL )
begin
update T_Empresa set nu_pctValor = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'vr_transacao' )
begin
alter table T_Empresa add vr_transacao int
end
--CMD

if exists ( select vr_transacao from T_Empresa where vr_transacao IS NULL )
begin
update T_Empresa set vr_transacao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'vr_minimo' )
begin
alter table T_Empresa add vr_minimo int
end
--CMD

if exists ( select vr_minimo from T_Empresa where vr_minimo IS NULL )
begin
update T_Empresa set vr_minimo = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_franquia' )
begin
alter table T_Empresa add nu_franquia int
end
--CMD

if exists ( select nu_franquia from T_Empresa where nu_franquia IS NULL )
begin
update T_Empresa set nu_franquia = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_periodoFat' )
begin
alter table T_Empresa add nu_periodoFat int
end
--CMD

if exists ( select nu_periodoFat from T_Empresa where nu_periodoFat IS NULL )
begin
update T_Empresa set nu_periodoFat = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_diaVenc' )
begin
alter table T_Empresa add nu_diaVenc int
end
--CMD

if exists ( select nu_diaVenc from T_Empresa where nu_diaVenc IS NULL )
begin
update T_Empresa set nu_diaVenc = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'tg_tipoCobranca' )
begin
alter table T_Empresa add tg_tipoCobranca varchar(1) 
end
else
begin
alter table T_Empresa alter column tg_tipoCobranca varchar (1)
end
--CMD

if exists ( select tg_tipoCobranca from T_Empresa where tg_tipoCobranca IS NULL )
begin
update T_Empresa set tg_tipoCobranca = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'nu_bancoFat' )
begin
alter table T_Empresa add nu_bancoFat int
end
--CMD

if exists ( select nu_bancoFat from T_Empresa where nu_bancoFat IS NULL )
begin
update T_Empresa set nu_bancoFat = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'vr_cartaoAtivo' )
begin
alter table T_Empresa add vr_cartaoAtivo int
end
--CMD

if exists ( select vr_cartaoAtivo from T_Empresa where vr_cartaoAtivo IS NULL )
begin
update T_Empresa set vr_cartaoAtivo = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'tg_isentoFat' )
begin
alter table T_Empresa add tg_isentoFat int
end
--CMD

if exists ( select tg_isentoFat from T_Empresa where tg_isentoFat IS NULL )
begin
update T_Empresa set tg_isentoFat = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'st_obs' )
begin
alter table T_Empresa add st_obs varchar(400) 
end
else
begin
alter table T_Empresa alter column st_obs varchar (400)
end
--CMD

if exists ( select st_obs from T_Empresa where st_obs IS NULL )
begin
update T_Empresa set st_obs = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Empresa' ) and name = 'tg_bloq' )
begin
alter table T_Empresa add tg_bloq int
end
--CMD

if exists ( select tg_bloq from T_Empresa where tg_bloq IS NULL )
begin
update T_Empresa set tg_bloq = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_Empresa_fk_admin' )
begin
drop index T_Empresa.index_T_Empresa_fk_admin
end
--CMD
create index index_T_Empresa_fk_admin on T_Empresa (fk_admin)
--CMD


if not exists (select * from sysobjects where name='T_Terminal')
begin
create table T_Terminal (
i_unique numeric(15) identity primary key,
nu_terminal varchar(12),
fk_loja int ,
st_localizacao varchar(250)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Terminal' ) and name = 'nu_terminal' )
begin
alter table T_Terminal add nu_terminal varchar(12) 
end
else
begin
alter table T_Terminal alter column nu_terminal varchar (12)
end
--CMD

if exists ( select nu_terminal from T_Terminal where nu_terminal IS NULL )
begin
update T_Terminal set nu_terminal = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Terminal_fk_empresa' )
begin
drop index T_Terminal.index_T_Terminal_fk_empresa
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Terminal' ) and name = 'fk_empresa' )
begin
alter table T_Terminal drop column fk_empresa
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Terminal' ) and name = 'fk_loja' )
begin
alter table T_Terminal add fk_loja int
end
--CMD

if exists ( select fk_loja from T_Terminal where fk_loja IS NULL )
begin
update T_Terminal set fk_loja = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Terminal' ) and name = 'st_localizacao' )
begin
alter table T_Terminal add st_localizacao varchar(250) 
end
else
begin
alter table T_Terminal alter column st_localizacao varchar (250)
end
--CMD

if exists ( select st_localizacao from T_Terminal where st_localizacao IS NULL )
begin
update T_Terminal set st_localizacao = ''
end
--CMD



if exists (select * from sysindexes where name='index_T_Terminal_fk_loja' )
begin
drop index T_Terminal.index_T_Terminal_fk_loja
end
--CMD
create index index_T_Terminal_fk_loja on T_Terminal (fk_loja)
--CMD


if not exists (select * from sysobjects where name='LOG_Audit')
begin
create table LOG_Audit (
i_unique numeric(15) identity primary key,
fk_usuario int ,
tg_operacao int ,
dt_operacao datetime,
st_observacao varchar(150),
fk_generic int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Audit' ) and name = 'fk_usuario' )
begin
alter table LOG_Audit add fk_usuario int
end
--CMD

if exists ( select fk_usuario from LOG_Audit where fk_usuario IS NULL )
begin
update LOG_Audit set fk_usuario = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Audit' ) and name = 'tg_operacao' )
begin
alter table LOG_Audit add tg_operacao int
end
--CMD

if exists ( select tg_operacao from LOG_Audit where tg_operacao IS NULL )
begin
update LOG_Audit set tg_operacao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Audit' ) and name = 'dt_operacao' )
begin
alter table LOG_Audit add dt_operacao datetime
end
--CMD

if exists ( select dt_operacao from LOG_Audit where dt_operacao IS NULL )
begin
update LOG_Audit set dt_operacao = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Audit' ) and name = 'st_observacao' )
begin
alter table LOG_Audit add st_observacao varchar(150) 
end
else
begin
alter table LOG_Audit alter column st_observacao varchar (150)
end
--CMD

if exists ( select st_observacao from LOG_Audit where st_observacao IS NULL )
begin
update LOG_Audit set st_observacao = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Audit' ) and name = 'fk_generic' )
begin
alter table LOG_Audit add fk_generic int
end
--CMD

if exists ( select fk_generic from LOG_Audit where fk_generic IS NULL )
begin
update LOG_Audit set fk_generic = 0
end
--CMD



if exists (select * from sysindexes where name='index_LOG_Audit_fk_usuario' )
begin
drop index LOG_Audit.index_LOG_Audit_fk_usuario
end
--CMD
create index index_LOG_Audit_fk_usuario on LOG_Audit (fk_usuario)
--CMD

if exists (select * from sysindexes where name='index_LOG_Audit_fk_generic' )
begin
drop index LOG_Audit.index_LOG_Audit_fk_generic
end
--CMD
create index index_LOG_Audit_fk_generic on LOG_Audit (fk_generic)
--CMD


if not exists (select * from sysobjects where name='LOG_NSU')
begin
create table LOG_NSU (
i_unique numeric(15) identity primary key,
dt_log datetime
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_NSU' ) and name = 'dt_log' )
begin
alter table LOG_NSU add dt_log datetime
end
--CMD

if exists ( select dt_log from LOG_NSU where dt_log IS NULL )
begin
update LOG_NSU set dt_log = '1900-01-01 00:00:00.000'
end
--CMD




if not exists (select * from sysobjects where name='I_Scheduler')
begin
create table I_Scheduler (
i_unique numeric(15) identity primary key,
st_job varchar(400),
tg_type varchar(1),
dt_specific datetime,
st_daily_hhmm varchar(4),
st_weekly_dow int ,
st_weekly_hhmm varchar(4),
nu_monthly_day int ,
st_monthly_hhmm varchar(4),
dt_last datetime,
tg_status varchar(1),
dt_prev datetime
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Scheduler' ) and name = 'st_job' )
begin
alter table I_Scheduler add st_job varchar(400) 
end
else
begin
alter table I_Scheduler alter column st_job varchar (400)
end
--CMD

if exists ( select st_job from I_Scheduler where st_job IS NULL )
begin
update I_Scheduler set st_job = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Scheduler' ) and name = 'tg_type' )
begin
alter table I_Scheduler add tg_type varchar(1) 
end
else
begin
alter table I_Scheduler alter column tg_type varchar (1)
end
--CMD

if exists ( select tg_type from I_Scheduler where tg_type IS NULL )
begin
update I_Scheduler set tg_type = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Scheduler' ) and name = 'dt_specific' )
begin
alter table I_Scheduler add dt_specific datetime
end
--CMD

if exists ( select dt_specific from I_Scheduler where dt_specific IS NULL )
begin
update I_Scheduler set dt_specific = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Scheduler' ) and name = 'st_daily_hhmm' )
begin
alter table I_Scheduler add st_daily_hhmm varchar(4) 
end
else
begin
alter table I_Scheduler alter column st_daily_hhmm varchar (4)
end
--CMD

if exists ( select st_daily_hhmm from I_Scheduler where st_daily_hhmm IS NULL )
begin
update I_Scheduler set st_daily_hhmm = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Scheduler' ) and name = 'st_weekly_dow' )
begin
alter table I_Scheduler add st_weekly_dow int
end
--CMD

if exists ( select st_weekly_dow from I_Scheduler where st_weekly_dow IS NULL )
begin
update I_Scheduler set st_weekly_dow = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Scheduler' ) and name = 'st_weekly_hhmm' )
begin
alter table I_Scheduler add st_weekly_hhmm varchar(4) 
end
else
begin
alter table I_Scheduler alter column st_weekly_hhmm varchar (4)
end
--CMD

if exists ( select st_weekly_hhmm from I_Scheduler where st_weekly_hhmm IS NULL )
begin
update I_Scheduler set st_weekly_hhmm = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Scheduler' ) and name = 'nu_monthly_day' )
begin
alter table I_Scheduler add nu_monthly_day int
end
--CMD

if exists ( select nu_monthly_day from I_Scheduler where nu_monthly_day IS NULL )
begin
update I_Scheduler set nu_monthly_day = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Scheduler' ) and name = 'st_monthly_hhmm' )
begin
alter table I_Scheduler add st_monthly_hhmm varchar(4) 
end
else
begin
alter table I_Scheduler alter column st_monthly_hhmm varchar (4)
end
--CMD

if exists ( select st_monthly_hhmm from I_Scheduler where st_monthly_hhmm IS NULL )
begin
update I_Scheduler set st_monthly_hhmm = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Scheduler' ) and name = 'dt_last' )
begin
alter table I_Scheduler add dt_last datetime
end
--CMD

if exists ( select dt_last from I_Scheduler where dt_last IS NULL )
begin
update I_Scheduler set dt_last = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Scheduler' ) and name = 'tg_status' )
begin
alter table I_Scheduler add tg_status varchar(1) 
end
else
begin
alter table I_Scheduler alter column tg_status varchar (1)
end
--CMD

if exists ( select tg_status from I_Scheduler where tg_status IS NULL )
begin
update I_Scheduler set tg_status = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Scheduler' ) and name = 'dt_prev' )
begin
alter table I_Scheduler add dt_prev datetime
end
--CMD

if exists ( select dt_prev from I_Scheduler where dt_prev IS NULL )
begin
update I_Scheduler set dt_prev = '1900-01-01 00:00:00.000'
end
--CMD




if not exists (select * from sysobjects where name='LOG_Transacoes')
begin
create table LOG_Transacoes (
i_unique numeric(15) identity primary key,
fk_terminal int ,
dt_transacao datetime,
nu_nsu int ,
fk_empresa int ,
fk_cartao int ,
vr_total int ,
nu_parcelas int ,
nu_cod_erro int ,
tg_confirmada varchar(1),
nu_nsuOrig int ,
en_operacao varchar(10),
st_msg_transacao varchar(50),
tg_contabil varchar(1),
fk_loja int ,
vr_saldo_disp int ,
vr_saldo_disp_tot int ,
st_doc varchar(20)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'fk_terminal' )
begin
alter table LOG_Transacoes add fk_terminal int
end
--CMD

if exists ( select fk_terminal from LOG_Transacoes where fk_terminal IS NULL )
begin
update LOG_Transacoes set fk_terminal = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'dt_transacao' )
begin
alter table LOG_Transacoes add dt_transacao datetime
end
--CMD

if exists ( select dt_transacao from LOG_Transacoes where dt_transacao IS NULL )
begin
update LOG_Transacoes set dt_transacao = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'nu_nsu' )
begin
alter table LOG_Transacoes add nu_nsu int
end
--CMD

if exists ( select nu_nsu from LOG_Transacoes where nu_nsu IS NULL )
begin
update LOG_Transacoes set nu_nsu = 0
end
--CMD


if exists (select * from sysindexes where name='index_LOG_Transacoes_nu_nsuEntidade' )
begin
drop index LOG_Transacoes.index_LOG_Transacoes_nu_nsuEntidade
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'nu_nsuEntidade' )
begin
alter table LOG_Transacoes drop column nu_nsuEntidade
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'fk_empresa' )
begin
alter table LOG_Transacoes add fk_empresa int
end
--CMD

if exists ( select fk_empresa from LOG_Transacoes where fk_empresa IS NULL )
begin
update LOG_Transacoes set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'fk_cartao' )
begin
alter table LOG_Transacoes add fk_cartao int
end
--CMD

if exists ( select fk_cartao from LOG_Transacoes where fk_cartao IS NULL )
begin
update LOG_Transacoes set fk_cartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'vr_total' )
begin
alter table LOG_Transacoes add vr_total int
end
--CMD

if exists ( select vr_total from LOG_Transacoes where vr_total IS NULL )
begin
update LOG_Transacoes set vr_total = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'nu_parcelas' )
begin
alter table LOG_Transacoes add nu_parcelas int
end
--CMD

if exists ( select nu_parcelas from LOG_Transacoes where nu_parcelas IS NULL )
begin
update LOG_Transacoes set nu_parcelas = 0
end
--CMD


if exists (select * from sysindexes where name='index_LOG_Transacoes_st_bin_cartao' )
begin
drop index LOG_Transacoes.index_LOG_Transacoes_st_bin_cartao
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'st_bin_cartao' )
begin
alter table LOG_Transacoes drop column st_bin_cartao
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'nu_cod_erro' )
begin
alter table LOG_Transacoes add nu_cod_erro int
end
--CMD

if exists ( select nu_cod_erro from LOG_Transacoes where nu_cod_erro IS NULL )
begin
update LOG_Transacoes set nu_cod_erro = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'tg_confirmada' )
begin
alter table LOG_Transacoes add tg_confirmada varchar(1) 
end
else
begin
alter table LOG_Transacoes alter column tg_confirmada varchar (1)
end
--CMD

if exists ( select tg_confirmada from LOG_Transacoes where tg_confirmada IS NULL )
begin
update LOG_Transacoes set tg_confirmada = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'nu_nsuOrig' )
begin
alter table LOG_Transacoes add nu_nsuOrig int
end
--CMD

if exists ( select nu_nsuOrig from LOG_Transacoes where nu_nsuOrig IS NULL )
begin
update LOG_Transacoes set nu_nsuOrig = 0
end
--CMD


if exists (select * from sysindexes where name='index_LOG_Transacoes_nu_nsuEntOrig' )
begin
drop index LOG_Transacoes.index_LOG_Transacoes_nu_nsuEntOrig
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'nu_nsuEntOrig' )
begin
alter table LOG_Transacoes drop column nu_nsuEntOrig
end
--CMD


if exists (select * from sysindexes where name='index_LOG_Transacoes_dt_transOrig' )
begin
drop index LOG_Transacoes.index_LOG_Transacoes_dt_transOrig
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'dt_transOrig' )
begin
alter table LOG_Transacoes drop column dt_transOrig
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'en_operacao' )
begin
alter table LOG_Transacoes add en_operacao varchar(10) 
end
else
begin
alter table LOG_Transacoes alter column en_operacao varchar (10)
end
--CMD

if exists ( select en_operacao from LOG_Transacoes where en_operacao IS NULL )
begin
update LOG_Transacoes set en_operacao = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'st_msg_transacao' )
begin
alter table LOG_Transacoes add st_msg_transacao varchar(50) 
end
else
begin
alter table LOG_Transacoes alter column st_msg_transacao varchar (50)
end
--CMD

if exists ( select st_msg_transacao from LOG_Transacoes where st_msg_transacao IS NULL )
begin
update LOG_Transacoes set st_msg_transacao = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'tg_contabil' )
begin
alter table LOG_Transacoes add tg_contabil varchar(1) 
end
else
begin
alter table LOG_Transacoes alter column tg_contabil varchar (1)
end
--CMD

if exists ( select tg_contabil from LOG_Transacoes where tg_contabil IS NULL )
begin
update LOG_Transacoes set tg_contabil = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'fk_loja' )
begin
alter table LOG_Transacoes add fk_loja int
end
--CMD

if exists ( select fk_loja from LOG_Transacoes where fk_loja IS NULL )
begin
update LOG_Transacoes set fk_loja = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'vr_saldo_disp' )
begin
alter table LOG_Transacoes add vr_saldo_disp int
end
--CMD

if exists ( select vr_saldo_disp from LOG_Transacoes where vr_saldo_disp IS NULL )
begin
update LOG_Transacoes set vr_saldo_disp = 0
end
--CMD


if exists (select * from sysindexes where name='index_LOG_Transacoes_vr_saldo_disp_edu' )
begin
drop index LOG_Transacoes.index_LOG_Transacoes_vr_saldo_disp_edu
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'vr_saldo_disp_edu' )
begin
alter table LOG_Transacoes drop column vr_saldo_disp_edu
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'vr_saldo_disp_tot' )
begin
alter table LOG_Transacoes add vr_saldo_disp_tot int
end
--CMD

if exists ( select vr_saldo_disp_tot from LOG_Transacoes where vr_saldo_disp_tot IS NULL )
begin
update LOG_Transacoes set vr_saldo_disp_tot = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Transacoes' ) and name = 'st_doc' )
begin
alter table LOG_Transacoes add st_doc varchar(20) 
end
else
begin
alter table LOG_Transacoes alter column st_doc varchar (20)
end
--CMD

if exists ( select st_doc from LOG_Transacoes where st_doc IS NULL )
begin
update LOG_Transacoes set st_doc = ''
end
--CMD



if exists (select * from sysindexes where name='index_LOG_Transacoes_fk_terminal' )
begin
drop index LOG_Transacoes.index_LOG_Transacoes_fk_terminal
end
--CMD
create index index_LOG_Transacoes_fk_terminal on LOG_Transacoes (fk_terminal)
--CMD

if exists (select * from sysindexes where name='index_LOG_Transacoes_fk_empresa' )
begin
drop index LOG_Transacoes.index_LOG_Transacoes_fk_empresa
end
--CMD
create index index_LOG_Transacoes_fk_empresa on LOG_Transacoes (fk_empresa)
--CMD

if exists (select * from sysindexes where name='index_LOG_Transacoes_fk_cartao' )
begin
drop index LOG_Transacoes.index_LOG_Transacoes_fk_cartao
end
--CMD
create index index_LOG_Transacoes_fk_cartao on LOG_Transacoes (fk_cartao)
--CMD

if exists (select * from sysindexes where name='index_LOG_Transacoes_fk_loja' )
begin
drop index LOG_Transacoes.index_LOG_Transacoes_fk_loja
end
--CMD
create index index_LOG_Transacoes_fk_loja on LOG_Transacoes (fk_loja)
--CMD


if not exists (select * from sysobjects where name='T_Parcelas')
begin
create table T_Parcelas (
i_unique numeric(15) identity primary key,
nu_nsu int ,
fk_empresa int ,
fk_cartao int ,
dt_inclusao datetime,
nu_parcela int ,
vr_valor int ,
nu_indice int ,
tg_pago varchar(1),
fk_loja int ,
nu_tot_parcelas int ,
fk_terminal int ,
fk_log_transacoes int 
)
end
--CMD

if exists (select * from sysindexes where name='index_T_Parcelas_nu_nsuEntidade' )
begin
drop index T_Parcelas.index_T_Parcelas_nu_nsuEntidade
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'nu_nsuEntidade' )
begin
alter table T_Parcelas drop column nu_nsuEntidade
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'nu_nsu' )
begin
alter table T_Parcelas add nu_nsu int
end
--CMD

if exists ( select nu_nsu from T_Parcelas where nu_nsu IS NULL )
begin
update T_Parcelas set nu_nsu = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'fk_empresa' )
begin
alter table T_Parcelas add fk_empresa int
end
--CMD

if exists ( select fk_empresa from T_Parcelas where fk_empresa IS NULL )
begin
update T_Parcelas set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'fk_cartao' )
begin
alter table T_Parcelas add fk_cartao int
end
--CMD

if exists ( select fk_cartao from T_Parcelas where fk_cartao IS NULL )
begin
update T_Parcelas set fk_cartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'dt_inclusao' )
begin
alter table T_Parcelas add dt_inclusao datetime
end
--CMD

if exists ( select dt_inclusao from T_Parcelas where dt_inclusao IS NULL )
begin
update T_Parcelas set dt_inclusao = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'nu_parcela' )
begin
alter table T_Parcelas add nu_parcela int
end
--CMD

if exists ( select nu_parcela from T_Parcelas where nu_parcela IS NULL )
begin
update T_Parcelas set nu_parcela = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'vr_valor' )
begin
alter table T_Parcelas add vr_valor int
end
--CMD

if exists ( select vr_valor from T_Parcelas where vr_valor IS NULL )
begin
update T_Parcelas set vr_valor = 0
end
--CMD


if exists (select * from sysindexes where name='index_T_Parcelas_dt_pagto_parcela' )
begin
drop index T_Parcelas.index_T_Parcelas_dt_pagto_parcela
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'dt_pagto_parcela' )
begin
alter table T_Parcelas drop column dt_pagto_parcela
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'nu_indice' )
begin
alter table T_Parcelas add nu_indice int
end
--CMD

if exists ( select nu_indice from T_Parcelas where nu_indice IS NULL )
begin
update T_Parcelas set nu_indice = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'tg_pago' )
begin
alter table T_Parcelas add tg_pago varchar(1) 
end
else
begin
alter table T_Parcelas alter column tg_pago varchar (1)
end
--CMD

if exists ( select tg_pago from T_Parcelas where tg_pago IS NULL )
begin
update T_Parcelas set tg_pago = ''
end
--CMD


if exists (select * from sysindexes where name='index_T_Parcelas_nu_cod_erro' )
begin
drop index T_Parcelas.index_T_Parcelas_nu_cod_erro
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'nu_cod_erro' )
begin
alter table T_Parcelas drop column nu_cod_erro
end
--CMD


if exists (select * from sysindexes where name='index_T_Parcelas_tg_confirmada' )
begin
drop index T_Parcelas.index_T_Parcelas_tg_confirmada
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'tg_confirmada' )
begin
alter table T_Parcelas drop column tg_confirmada
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'fk_loja' )
begin
alter table T_Parcelas add fk_loja int
end
--CMD

if exists ( select fk_loja from T_Parcelas where fk_loja IS NULL )
begin
update T_Parcelas set fk_loja = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'nu_tot_parcelas' )
begin
alter table T_Parcelas add nu_tot_parcelas int
end
--CMD

if exists ( select nu_tot_parcelas from T_Parcelas where nu_tot_parcelas IS NULL )
begin
update T_Parcelas set nu_tot_parcelas = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'fk_terminal' )
begin
alter table T_Parcelas add fk_terminal int
end
--CMD

if exists ( select fk_terminal from T_Parcelas where fk_terminal IS NULL )
begin
update T_Parcelas set fk_terminal = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Parcelas' ) and name = 'fk_log_transacoes' )
begin
alter table T_Parcelas add fk_log_transacoes int
end
--CMD

if exists ( select fk_log_transacoes from T_Parcelas where fk_log_transacoes IS NULL )
begin
update T_Parcelas set fk_log_transacoes = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_Parcelas_fk_empresa' )
begin
drop index T_Parcelas.index_T_Parcelas_fk_empresa
end
--CMD
create index index_T_Parcelas_fk_empresa on T_Parcelas (fk_empresa)
--CMD

if exists (select * from sysindexes where name='index_T_Parcelas_fk_cartao' )
begin
drop index T_Parcelas.index_T_Parcelas_fk_cartao
end
--CMD
create index index_T_Parcelas_fk_cartao on T_Parcelas (fk_cartao)
--CMD

if exists (select * from sysindexes where name='index_T_Parcelas_fk_loja' )
begin
drop index T_Parcelas.index_T_Parcelas_fk_loja
end
--CMD
create index index_T_Parcelas_fk_loja on T_Parcelas (fk_loja)
--CMD

if exists (select * from sysindexes where name='index_T_Parcelas_fk_terminal' )
begin
drop index T_Parcelas.index_T_Parcelas_fk_terminal
end
--CMD
create index index_T_Parcelas_fk_terminal on T_Parcelas (fk_terminal)
--CMD

if exists (select * from sysindexes where name='index_T_Parcelas_fk_log_transacoes' )
begin
drop index T_Parcelas.index_T_Parcelas_fk_log_transacoes
end
--CMD
create index index_T_Parcelas_fk_log_transacoes on T_Parcelas (fk_log_transacoes)
--CMD


if not exists (select * from sysobjects where name='T_PayFone')
begin
create table T_PayFone (
i_unique numeric(15) identity primary key,
st_telefone varchar(10),
tg_tipoCelular varchar(1),
fk_cartao int ,
fk_terminal int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PayFone' ) and name = 'st_telefone' )
begin
alter table T_PayFone add st_telefone varchar(10) 
end
else
begin
alter table T_PayFone alter column st_telefone varchar (10)
end
--CMD

if exists ( select st_telefone from T_PayFone where st_telefone IS NULL )
begin
update T_PayFone set st_telefone = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PayFone' ) and name = 'tg_tipoCelular' )
begin
alter table T_PayFone add tg_tipoCelular varchar(1) 
end
else
begin
alter table T_PayFone alter column tg_tipoCelular varchar (1)
end
--CMD

if exists ( select tg_tipoCelular from T_PayFone where tg_tipoCelular IS NULL )
begin
update T_PayFone set tg_tipoCelular = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PayFone' ) and name = 'fk_cartao' )
begin
alter table T_PayFone add fk_cartao int
end
--CMD

if exists ( select fk_cartao from T_PayFone where fk_cartao IS NULL )
begin
update T_PayFone set fk_cartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PayFone' ) and name = 'fk_terminal' )
begin
alter table T_PayFone add fk_terminal int
end
--CMD

if exists ( select fk_terminal from T_PayFone where fk_terminal IS NULL )
begin
update T_PayFone set fk_terminal = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_PayFone_fk_cartao' )
begin
drop index T_PayFone.index_T_PayFone_fk_cartao
end
--CMD
create index index_T_PayFone_fk_cartao on T_PayFone (fk_cartao)
--CMD

if exists (select * from sysindexes where name='index_T_PayFone_fk_terminal' )
begin
drop index T_PayFone.index_T_PayFone_fk_terminal
end
--CMD
create index index_T_PayFone_fk_terminal on T_PayFone (fk_terminal)
--CMD


if not exists (select * from sysobjects where name='T_PendPayFone')
begin
create table T_PendPayFone (
i_unique numeric(15) identity primary key,
fk_cartao int ,
fk_terminal int ,
nu_nsu int ,
vr_valor int ,
dt_inclusao datetime,
en_situacao varchar(1),
fk_empresa int ,
fk_loja int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PendPayFone' ) and name = 'fk_cartao' )
begin
alter table T_PendPayFone add fk_cartao int
end
--CMD

if exists ( select fk_cartao from T_PendPayFone where fk_cartao IS NULL )
begin
update T_PendPayFone set fk_cartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PendPayFone' ) and name = 'fk_terminal' )
begin
alter table T_PendPayFone add fk_terminal int
end
--CMD

if exists ( select fk_terminal from T_PendPayFone where fk_terminal IS NULL )
begin
update T_PendPayFone set fk_terminal = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PendPayFone' ) and name = 'nu_nsu' )
begin
alter table T_PendPayFone add nu_nsu int
end
--CMD

if exists ( select nu_nsu from T_PendPayFone where nu_nsu IS NULL )
begin
update T_PendPayFone set nu_nsu = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PendPayFone' ) and name = 'vr_valor' )
begin
alter table T_PendPayFone add vr_valor int
end
--CMD

if exists ( select vr_valor from T_PendPayFone where vr_valor IS NULL )
begin
update T_PendPayFone set vr_valor = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PendPayFone' ) and name = 'dt_inclusao' )
begin
alter table T_PendPayFone add dt_inclusao datetime
end
--CMD

if exists ( select dt_inclusao from T_PendPayFone where dt_inclusao IS NULL )
begin
update T_PendPayFone set dt_inclusao = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PendPayFone' ) and name = 'en_situacao' )
begin
alter table T_PendPayFone add en_situacao varchar(1) 
end
else
begin
alter table T_PendPayFone alter column en_situacao varchar (1)
end
--CMD

if exists ( select en_situacao from T_PendPayFone where en_situacao IS NULL )
begin
update T_PendPayFone set en_situacao = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PendPayFone' ) and name = 'fk_empresa' )
begin
alter table T_PendPayFone add fk_empresa int
end
--CMD

if exists ( select fk_empresa from T_PendPayFone where fk_empresa IS NULL )
begin
update T_PendPayFone set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_PendPayFone' ) and name = 'fk_loja' )
begin
alter table T_PendPayFone add fk_loja int
end
--CMD

if exists ( select fk_loja from T_PendPayFone where fk_loja IS NULL )
begin
update T_PendPayFone set fk_loja = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_PendPayFone_fk_cartao' )
begin
drop index T_PendPayFone.index_T_PendPayFone_fk_cartao
end
--CMD
create index index_T_PendPayFone_fk_cartao on T_PendPayFone (fk_cartao)
--CMD

if exists (select * from sysindexes where name='index_T_PendPayFone_fk_terminal' )
begin
drop index T_PendPayFone.index_T_PendPayFone_fk_terminal
end
--CMD
create index index_T_PendPayFone_fk_terminal on T_PendPayFone (fk_terminal)
--CMD

if exists (select * from sysindexes where name='index_T_PendPayFone_fk_empresa' )
begin
drop index T_PendPayFone.index_T_PendPayFone_fk_empresa
end
--CMD
create index index_T_PendPayFone_fk_empresa on T_PendPayFone (fk_empresa)
--CMD

if exists (select * from sysindexes where name='index_T_PendPayFone_fk_loja' )
begin
drop index T_PendPayFone.index_T_PendPayFone_fk_loja
end
--CMD
create index index_T_PendPayFone_fk_loja on T_PendPayFone (fk_loja)
--CMD


if not exists (select * from sysobjects where name='LINK_PFAtivacao')
begin
create table LINK_PFAtivacao (
i_unique numeric(15) identity primary key,
fk_payfone int ,
dt_ativacao datetime,
st_ativacao varchar(50),
tg_status varchar(1)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_PFAtivacao' ) and name = 'fk_payfone' )
begin
alter table LINK_PFAtivacao add fk_payfone int
end
--CMD

if exists ( select fk_payfone from LINK_PFAtivacao where fk_payfone IS NULL )
begin
update LINK_PFAtivacao set fk_payfone = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_PFAtivacao' ) and name = 'dt_ativacao' )
begin
alter table LINK_PFAtivacao add dt_ativacao datetime
end
--CMD

if exists ( select dt_ativacao from LINK_PFAtivacao where dt_ativacao IS NULL )
begin
update LINK_PFAtivacao set dt_ativacao = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_PFAtivacao' ) and name = 'st_ativacao' )
begin
alter table LINK_PFAtivacao add st_ativacao varchar(50) 
end
else
begin
alter table LINK_PFAtivacao alter column st_ativacao varchar (50)
end
--CMD

if exists ( select st_ativacao from LINK_PFAtivacao where st_ativacao IS NULL )
begin
update LINK_PFAtivacao set st_ativacao = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_PFAtivacao' ) and name = 'tg_status' )
begin
alter table LINK_PFAtivacao add tg_status varchar(1) 
end
else
begin
alter table LINK_PFAtivacao alter column tg_status varchar (1)
end
--CMD

if exists ( select tg_status from LINK_PFAtivacao where tg_status IS NULL )
begin
update LINK_PFAtivacao set tg_status = ''
end
--CMD



if exists (select * from sysindexes where name='index_LINK_PFAtivacao_fk_payfone' )
begin
drop index LINK_PFAtivacao.index_LINK_PFAtivacao_fk_payfone
end
--CMD
create index index_LINK_PFAtivacao_fk_payfone on LINK_PFAtivacao (fk_payfone)
--CMD


if not exists (select * from sysobjects where name='LINK_Agenda')
begin
create table LINK_Agenda (
i_unique numeric(15) identity primary key,
fk_schedule int ,
fk_empresa int ,
en_atividade int ,
st_emp_afiliada varchar(20)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_Agenda' ) and name = 'fk_schedule' )
begin
alter table LINK_Agenda add fk_schedule int
end
--CMD

if exists ( select fk_schedule from LINK_Agenda where fk_schedule IS NULL )
begin
update LINK_Agenda set fk_schedule = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_Agenda' ) and name = 'fk_empresa' )
begin
alter table LINK_Agenda add fk_empresa int
end
--CMD

if exists ( select fk_empresa from LINK_Agenda where fk_empresa IS NULL )
begin
update LINK_Agenda set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_Agenda' ) and name = 'en_atividade' )
begin
alter table LINK_Agenda add en_atividade int
end
--CMD

if exists ( select en_atividade from LINK_Agenda where en_atividade IS NULL )
begin
update LINK_Agenda set en_atividade = 0
end
--CMD


if exists (select * from sysindexes where name='index_LINK_Agenda_st_afiliada' )
begin
drop index LINK_Agenda.index_LINK_Agenda_st_afiliada
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_Agenda' ) and name = 'st_afiliada' )
begin
alter table LINK_Agenda drop column st_afiliada
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_Agenda' ) and name = 'st_emp_afiliada' )
begin
alter table LINK_Agenda add st_emp_afiliada varchar(20) 
end
else
begin
alter table LINK_Agenda alter column st_emp_afiliada varchar (20)
end
--CMD

if exists ( select st_emp_afiliada from LINK_Agenda where st_emp_afiliada IS NULL )
begin
update LINK_Agenda set st_emp_afiliada = ''
end
--CMD



if exists (select * from sysindexes where name='index_LINK_Agenda_fk_schedule' )
begin
drop index LINK_Agenda.index_LINK_Agenda_fk_schedule
end
--CMD
create index index_LINK_Agenda_fk_schedule on LINK_Agenda (fk_schedule)
--CMD

if exists (select * from sysindexes where name='index_LINK_Agenda_fk_empresa' )
begin
drop index LINK_Agenda.index_LINK_Agenda_fk_empresa
end
--CMD
create index index_LINK_Agenda_fk_empresa on LINK_Agenda (fk_empresa)
--CMD


if not exists (select * from sysobjects where name='LOG_Fechamento')
begin
create table LOG_Fechamento (
i_unique numeric(15) identity primary key,
st_mes varchar(2),
st_ano varchar(4),
vr_valor int ,
dt_fechamento datetime,
fk_empresa int ,
fk_loja int ,
fk_cartao int ,
fk_parcela int ,
dt_compra datetime,
nu_parcela int ,
st_cartao varchar(14),
st_afiliada varchar(20)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'st_mes' )
begin
alter table LOG_Fechamento add st_mes varchar(2) 
end
else
begin
alter table LOG_Fechamento alter column st_mes varchar (2)
end
--CMD

if exists ( select st_mes from LOG_Fechamento where st_mes IS NULL )
begin
update LOG_Fechamento set st_mes = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'st_ano' )
begin
alter table LOG_Fechamento add st_ano varchar(4) 
end
else
begin
alter table LOG_Fechamento alter column st_ano varchar (4)
end
--CMD

if exists ( select st_ano from LOG_Fechamento where st_ano IS NULL )
begin
update LOG_Fechamento set st_ano = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'vr_valor' )
begin
alter table LOG_Fechamento add vr_valor int
end
--CMD

if exists ( select vr_valor from LOG_Fechamento where vr_valor IS NULL )
begin
update LOG_Fechamento set vr_valor = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'dt_fechamento' )
begin
alter table LOG_Fechamento add dt_fechamento datetime
end
--CMD

if exists ( select dt_fechamento from LOG_Fechamento where dt_fechamento IS NULL )
begin
update LOG_Fechamento set dt_fechamento = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'fk_empresa' )
begin
alter table LOG_Fechamento add fk_empresa int
end
--CMD

if exists ( select fk_empresa from LOG_Fechamento where fk_empresa IS NULL )
begin
update LOG_Fechamento set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'fk_loja' )
begin
alter table LOG_Fechamento add fk_loja int
end
--CMD

if exists ( select fk_loja from LOG_Fechamento where fk_loja IS NULL )
begin
update LOG_Fechamento set fk_loja = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'fk_cartao' )
begin
alter table LOG_Fechamento add fk_cartao int
end
--CMD

if exists ( select fk_cartao from LOG_Fechamento where fk_cartao IS NULL )
begin
update LOG_Fechamento set fk_cartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'fk_parcela' )
begin
alter table LOG_Fechamento add fk_parcela int
end
--CMD

if exists ( select fk_parcela from LOG_Fechamento where fk_parcela IS NULL )
begin
update LOG_Fechamento set fk_parcela = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'dt_compra' )
begin
alter table LOG_Fechamento add dt_compra datetime
end
--CMD

if exists ( select dt_compra from LOG_Fechamento where dt_compra IS NULL )
begin
update LOG_Fechamento set dt_compra = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'nu_parcela' )
begin
alter table LOG_Fechamento add nu_parcela int
end
--CMD

if exists ( select nu_parcela from LOG_Fechamento where nu_parcela IS NULL )
begin
update LOG_Fechamento set nu_parcela = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'st_cartao' )
begin
alter table LOG_Fechamento add st_cartao varchar(14) 
end
else
begin
alter table LOG_Fechamento alter column st_cartao varchar (14)
end
--CMD

if exists ( select st_cartao from LOG_Fechamento where st_cartao IS NULL )
begin
update LOG_Fechamento set st_cartao = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Fechamento' ) and name = 'st_afiliada' )
begin
alter table LOG_Fechamento add st_afiliada varchar(20) 
end
else
begin
alter table LOG_Fechamento alter column st_afiliada varchar (20)
end
--CMD

if exists ( select st_afiliada from LOG_Fechamento where st_afiliada IS NULL )
begin
update LOG_Fechamento set st_afiliada = ''
end
--CMD



if exists (select * from sysindexes where name='index_LOG_Fechamento_fk_empresa' )
begin
drop index LOG_Fechamento.index_LOG_Fechamento_fk_empresa
end
--CMD
create index index_LOG_Fechamento_fk_empresa on LOG_Fechamento (fk_empresa)
--CMD

if exists (select * from sysindexes where name='index_LOG_Fechamento_fk_loja' )
begin
drop index LOG_Fechamento.index_LOG_Fechamento_fk_loja
end
--CMD
create index index_LOG_Fechamento_fk_loja on LOG_Fechamento (fk_loja)
--CMD

if exists (select * from sysindexes where name='index_LOG_Fechamento_fk_cartao' )
begin
drop index LOG_Fechamento.index_LOG_Fechamento_fk_cartao
end
--CMD
create index index_LOG_Fechamento_fk_cartao on LOG_Fechamento (fk_cartao)
--CMD

if exists (select * from sysindexes where name='index_LOG_Fechamento_fk_parcela' )
begin
drop index LOG_Fechamento.index_LOG_Fechamento_fk_parcela
end
--CMD
create index index_LOG_Fechamento_fk_parcela on LOG_Fechamento (fk_parcela)
--CMD


if not exists (select * from sysobjects where name='I_Batch')
begin
create table I_Batch (
i_unique numeric(15) identity primary key,
st_archive varchar(999),
dt_start datetime,
dt_proc_start datetime,
dt_proc_end datetime,
tg_processed varchar(1),
tg_running varchar(1)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Batch' ) and name = 'st_archive' )
begin
alter table I_Batch add st_archive varchar(999) 
end
else
begin
alter table I_Batch alter column st_archive varchar (999)
end
--CMD

if exists ( select st_archive from I_Batch where st_archive IS NULL )
begin
update I_Batch set st_archive = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Batch' ) and name = 'dt_start' )
begin
alter table I_Batch add dt_start datetime
end
--CMD

if exists ( select dt_start from I_Batch where dt_start IS NULL )
begin
update I_Batch set dt_start = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Batch' ) and name = 'dt_proc_start' )
begin
alter table I_Batch add dt_proc_start datetime
end
--CMD

if exists ( select dt_proc_start from I_Batch where dt_proc_start IS NULL )
begin
update I_Batch set dt_proc_start = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Batch' ) and name = 'dt_proc_end' )
begin
alter table I_Batch add dt_proc_end datetime
end
--CMD

if exists ( select dt_proc_end from I_Batch where dt_proc_end IS NULL )
begin
update I_Batch set dt_proc_end = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Batch' ) and name = 'tg_processed' )
begin
alter table I_Batch add tg_processed varchar(1) 
end
else
begin
alter table I_Batch alter column tg_processed varchar (1)
end
--CMD

if exists ( select tg_processed from I_Batch where tg_processed IS NULL )
begin
update I_Batch set tg_processed = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='I_Batch' ) and name = 'tg_running' )
begin
alter table I_Batch add tg_running varchar(1) 
end
else
begin
alter table I_Batch alter column tg_running varchar (1)
end
--CMD

if exists ( select tg_running from I_Batch where tg_running IS NULL )
begin
update I_Batch set tg_running = ''
end
--CMD




if not exists (select * from sysobjects where name='T_Edu_EmpresaVirtual')
begin
create table T_Edu_EmpresaVirtual (
i_unique numeric(15) identity primary key,
st_nome varchar(99),
st_codigo varchar(20),
vr_valorAcao int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_EmpresaVirtual' ) and name = 'st_nome' )
begin
alter table T_Edu_EmpresaVirtual add st_nome varchar(99) 
end
else
begin
alter table T_Edu_EmpresaVirtual alter column st_nome varchar (99)
end
--CMD

if exists ( select st_nome from T_Edu_EmpresaVirtual where st_nome IS NULL )
begin
update T_Edu_EmpresaVirtual set st_nome = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_EmpresaVirtual' ) and name = 'st_codigo' )
begin
alter table T_Edu_EmpresaVirtual add st_codigo varchar(20) 
end
else
begin
alter table T_Edu_EmpresaVirtual alter column st_codigo varchar (20)
end
--CMD

if exists ( select st_codigo from T_Edu_EmpresaVirtual where st_codigo IS NULL )
begin
update T_Edu_EmpresaVirtual set st_codigo = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_EmpresaVirtual' ) and name = 'vr_valorAcao' )
begin
alter table T_Edu_EmpresaVirtual add vr_valorAcao int
end
--CMD

if exists ( select vr_valorAcao from T_Edu_EmpresaVirtual where vr_valorAcao IS NULL )
begin
update T_Edu_EmpresaVirtual set vr_valorAcao = 0
end
--CMD




if not exists (select * from sysobjects where name='T_Edu_AplicacaoVirtual')
begin
create table T_Edu_AplicacaoVirtual (
i_unique numeric(15) identity primary key,
fk_cartao int ,
fk_empresaVirtual int ,
vr_aplicado int ,
dt_aplic datetime,
tg_neg varchar(1),
vr_fundo_hora int ,
vr_preco_fundo int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_AplicacaoVirtual' ) and name = 'fk_cartao' )
begin
alter table T_Edu_AplicacaoVirtual add fk_cartao int
end
--CMD

if exists ( select fk_cartao from T_Edu_AplicacaoVirtual where fk_cartao IS NULL )
begin
update T_Edu_AplicacaoVirtual set fk_cartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_AplicacaoVirtual' ) and name = 'fk_empresaVirtual' )
begin
alter table T_Edu_AplicacaoVirtual add fk_empresaVirtual int
end
--CMD

if exists ( select fk_empresaVirtual from T_Edu_AplicacaoVirtual where fk_empresaVirtual IS NULL )
begin
update T_Edu_AplicacaoVirtual set fk_empresaVirtual = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_AplicacaoVirtual' ) and name = 'vr_aplicado' )
begin
alter table T_Edu_AplicacaoVirtual add vr_aplicado int
end
--CMD

if exists ( select vr_aplicado from T_Edu_AplicacaoVirtual where vr_aplicado IS NULL )
begin
update T_Edu_AplicacaoVirtual set vr_aplicado = 0
end
--CMD


if exists (select * from sysindexes where name='index_T_Edu_AplicacaoVirtual_vr_fundo' )
begin
drop index T_Edu_AplicacaoVirtual.index_T_Edu_AplicacaoVirtual_vr_fundo
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_AplicacaoVirtual' ) and name = 'vr_fundo' )
begin
alter table T_Edu_AplicacaoVirtual drop column vr_fundo
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_AplicacaoVirtual' ) and name = 'dt_aplic' )
begin
alter table T_Edu_AplicacaoVirtual add dt_aplic datetime
end
--CMD

if exists ( select dt_aplic from T_Edu_AplicacaoVirtual where dt_aplic IS NULL )
begin
update T_Edu_AplicacaoVirtual set dt_aplic = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_AplicacaoVirtual' ) and name = 'tg_neg' )
begin
alter table T_Edu_AplicacaoVirtual add tg_neg varchar(1) 
end
else
begin
alter table T_Edu_AplicacaoVirtual alter column tg_neg varchar (1)
end
--CMD

if exists ( select tg_neg from T_Edu_AplicacaoVirtual where tg_neg IS NULL )
begin
update T_Edu_AplicacaoVirtual set tg_neg = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_AplicacaoVirtual' ) and name = 'vr_fundo_hora' )
begin
alter table T_Edu_AplicacaoVirtual add vr_fundo_hora int
end
--CMD

if exists ( select vr_fundo_hora from T_Edu_AplicacaoVirtual where vr_fundo_hora IS NULL )
begin
update T_Edu_AplicacaoVirtual set vr_fundo_hora = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_AplicacaoVirtual' ) and name = 'vr_preco_fundo' )
begin
alter table T_Edu_AplicacaoVirtual add vr_preco_fundo int
end
--CMD

if exists ( select vr_preco_fundo from T_Edu_AplicacaoVirtual where vr_preco_fundo IS NULL )
begin
update T_Edu_AplicacaoVirtual set vr_preco_fundo = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_Edu_AplicacaoVirtual_fk_cartao' )
begin
drop index T_Edu_AplicacaoVirtual.index_T_Edu_AplicacaoVirtual_fk_cartao
end
--CMD
create index index_T_Edu_AplicacaoVirtual_fk_cartao on T_Edu_AplicacaoVirtual (fk_cartao)
--CMD

if exists (select * from sysindexes where name='index_T_Edu_AplicacaoVirtual_fk_empresaVirtual' )
begin
drop index T_Edu_AplicacaoVirtual.index_T_Edu_AplicacaoVirtual_fk_empresaVirtual
end
--CMD
create index index_T_Edu_AplicacaoVirtual_fk_empresaVirtual on T_Edu_AplicacaoVirtual (fk_empresaVirtual)
--CMD


if not exists (select * from sysobjects where name='LOG_Edu_RendimentoEmpresa')
begin
create table LOG_Edu_RendimentoEmpresa (
i_unique numeric(15) identity primary key,
fk_empresaVirtual int ,
vr_pct int ,
dt_rend datetime,
tg_neg varchar(1)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Edu_RendimentoEmpresa' ) and name = 'fk_empresaVirtual' )
begin
alter table LOG_Edu_RendimentoEmpresa add fk_empresaVirtual int
end
--CMD

if exists ( select fk_empresaVirtual from LOG_Edu_RendimentoEmpresa where fk_empresaVirtual IS NULL )
begin
update LOG_Edu_RendimentoEmpresa set fk_empresaVirtual = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Edu_RendimentoEmpresa' ) and name = 'vr_pct' )
begin
alter table LOG_Edu_RendimentoEmpresa add vr_pct int
end
--CMD

if exists ( select vr_pct from LOG_Edu_RendimentoEmpresa where vr_pct IS NULL )
begin
update LOG_Edu_RendimentoEmpresa set vr_pct = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Edu_RendimentoEmpresa' ) and name = 'dt_rend' )
begin
alter table LOG_Edu_RendimentoEmpresa add dt_rend datetime
end
--CMD

if exists ( select dt_rend from LOG_Edu_RendimentoEmpresa where dt_rend IS NULL )
begin
update LOG_Edu_RendimentoEmpresa set dt_rend = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Edu_RendimentoEmpresa' ) and name = 'tg_neg' )
begin
alter table LOG_Edu_RendimentoEmpresa add tg_neg varchar(1) 
end
else
begin
alter table LOG_Edu_RendimentoEmpresa alter column tg_neg varchar (1)
end
--CMD

if exists ( select tg_neg from LOG_Edu_RendimentoEmpresa where tg_neg IS NULL )
begin
update LOG_Edu_RendimentoEmpresa set tg_neg = ''
end
--CMD



if exists (select * from sysindexes where name='index_LOG_Edu_RendimentoEmpresa_fk_empresaVirtual' )
begin
drop index LOG_Edu_RendimentoEmpresa.index_LOG_Edu_RendimentoEmpresa_fk_empresaVirtual
end
--CMD
create index index_LOG_Edu_RendimentoEmpresa_fk_empresaVirtual on LOG_Edu_RendimentoEmpresa (fk_empresaVirtual)
--CMD


if not exists (select * from sysobjects where name='T_Edu_FundoEmpresa')
begin
create table T_Edu_FundoEmpresa (
i_unique numeric(15) identity primary key,
fk_cartao int ,
fk_empresaVirtual int ,
vr_fundo int ,
dt_efetivo datetime
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_FundoEmpresa' ) and name = 'fk_cartao' )
begin
alter table T_Edu_FundoEmpresa add fk_cartao int
end
--CMD

if exists ( select fk_cartao from T_Edu_FundoEmpresa where fk_cartao IS NULL )
begin
update T_Edu_FundoEmpresa set fk_cartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_FundoEmpresa' ) and name = 'fk_empresaVirtual' )
begin
alter table T_Edu_FundoEmpresa add fk_empresaVirtual int
end
--CMD

if exists ( select fk_empresaVirtual from T_Edu_FundoEmpresa where fk_empresaVirtual IS NULL )
begin
update T_Edu_FundoEmpresa set fk_empresaVirtual = 0
end
--CMD


if exists (select * from sysindexes where name='index_T_Edu_FundoEmpresa_dt_dia' )
begin
drop index T_Edu_FundoEmpresa.index_T_Edu_FundoEmpresa_dt_dia
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_FundoEmpresa' ) and name = 'dt_dia' )
begin
alter table T_Edu_FundoEmpresa drop column dt_dia
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_FundoEmpresa' ) and name = 'vr_fundo' )
begin
alter table T_Edu_FundoEmpresa add vr_fundo int
end
--CMD

if exists ( select vr_fundo from T_Edu_FundoEmpresa where vr_fundo IS NULL )
begin
update T_Edu_FundoEmpresa set vr_fundo = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Edu_FundoEmpresa' ) and name = 'dt_efetivo' )
begin
alter table T_Edu_FundoEmpresa add dt_efetivo datetime
end
--CMD

if exists ( select dt_efetivo from T_Edu_FundoEmpresa where dt_efetivo IS NULL )
begin
update T_Edu_FundoEmpresa set dt_efetivo = '1900-01-01 00:00:00.000'
end
--CMD



if exists (select * from sysindexes where name='index_T_Edu_FundoEmpresa_fk_cartao' )
begin
drop index T_Edu_FundoEmpresa.index_T_Edu_FundoEmpresa_fk_cartao
end
--CMD
create index index_T_Edu_FundoEmpresa_fk_cartao on T_Edu_FundoEmpresa (fk_cartao)
--CMD

if exists (select * from sysindexes where name='index_T_Edu_FundoEmpresa_fk_empresaVirtual' )
begin
drop index T_Edu_FundoEmpresa.index_T_Edu_FundoEmpresa_fk_empresaVirtual
end
--CMD
create index index_T_Edu_FundoEmpresa_fk_empresaVirtual on T_Edu_FundoEmpresa (fk_empresaVirtual)
--CMD


if not exists (select * from sysobjects where name='LINK_Edu_FundoEmpresa')
begin
create table LINK_Edu_FundoEmpresa (
i_unique numeric(15) identity primary key,
fk_cartao int ,
fk_empresa int ,
vr_fundo int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_Edu_FundoEmpresa' ) and name = 'fk_cartao' )
begin
alter table LINK_Edu_FundoEmpresa add fk_cartao int
end
--CMD

if exists ( select fk_cartao from LINK_Edu_FundoEmpresa where fk_cartao IS NULL )
begin
update LINK_Edu_FundoEmpresa set fk_cartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_Edu_FundoEmpresa' ) and name = 'fk_empresa' )
begin
alter table LINK_Edu_FundoEmpresa add fk_empresa int
end
--CMD

if exists ( select fk_empresa from LINK_Edu_FundoEmpresa where fk_empresa IS NULL )
begin
update LINK_Edu_FundoEmpresa set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_Edu_FundoEmpresa' ) and name = 'vr_fundo' )
begin
alter table LINK_Edu_FundoEmpresa add vr_fundo int
end
--CMD

if exists ( select vr_fundo from LINK_Edu_FundoEmpresa where vr_fundo IS NULL )
begin
update LINK_Edu_FundoEmpresa set vr_fundo = 0
end
--CMD



if exists (select * from sysindexes where name='index_LINK_Edu_FundoEmpresa_fk_cartao' )
begin
drop index LINK_Edu_FundoEmpresa.index_LINK_Edu_FundoEmpresa_fk_cartao
end
--CMD
create index index_LINK_Edu_FundoEmpresa_fk_cartao on LINK_Edu_FundoEmpresa (fk_cartao)
--CMD

if exists (select * from sysindexes where name='index_LINK_Edu_FundoEmpresa_fk_empresa' )
begin
drop index LINK_Edu_FundoEmpresa.index_LINK_Edu_FundoEmpresa_fk_empresa
end
--CMD
create index index_LINK_Edu_FundoEmpresa_fk_empresa on LINK_Edu_FundoEmpresa (fk_empresa)
--CMD


if not exists (select * from sysobjects where name='T_WebBlock')
begin
create table T_WebBlock (
i_unique numeric(15) identity primary key,
st_ip varchar(99),
fk_cartao int ,
dt_expire datetime
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_WebBlock' ) and name = 'st_ip' )
begin
alter table T_WebBlock add st_ip varchar(99) 
end
else
begin
alter table T_WebBlock alter column st_ip varchar (99)
end
--CMD

if exists ( select st_ip from T_WebBlock where st_ip IS NULL )
begin
update T_WebBlock set st_ip = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_WebBlock' ) and name = 'fk_cartao' )
begin
alter table T_WebBlock add fk_cartao int
end
--CMD

if exists ( select fk_cartao from T_WebBlock where fk_cartao IS NULL )
begin
update T_WebBlock set fk_cartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_WebBlock' ) and name = 'dt_expire' )
begin
alter table T_WebBlock add dt_expire datetime
end
--CMD

if exists ( select dt_expire from T_WebBlock where dt_expire IS NULL )
begin
update T_WebBlock set dt_expire = '1900-01-01 00:00:00.000'
end
--CMD



if exists (select * from sysindexes where name='index_T_WebBlock_fk_cartao' )
begin
drop index T_WebBlock.index_T_WebBlock_fk_cartao
end
--CMD
create index index_T_WebBlock_fk_cartao on T_WebBlock (fk_cartao)
--CMD


if not exists (select * from sysobjects where name='T_Faturamento')
begin
create table T_Faturamento (
i_unique numeric(15) identity primary key,
fk_empresa int ,
fk_loja int ,
vr_cobranca int ,
dt_vencimento datetime,
dt_baixa datetime,
tg_situacao varchar(1),
tg_retBanco int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Faturamento' ) and name = 'fk_empresa' )
begin
alter table T_Faturamento add fk_empresa int
end
--CMD

if exists ( select fk_empresa from T_Faturamento where fk_empresa IS NULL )
begin
update T_Faturamento set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Faturamento' ) and name = 'fk_loja' )
begin
alter table T_Faturamento add fk_loja int
end
--CMD

if exists ( select fk_loja from T_Faturamento where fk_loja IS NULL )
begin
update T_Faturamento set fk_loja = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Faturamento' ) and name = 'vr_cobranca' )
begin
alter table T_Faturamento add vr_cobranca int
end
--CMD

if exists ( select vr_cobranca from T_Faturamento where vr_cobranca IS NULL )
begin
update T_Faturamento set vr_cobranca = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Faturamento' ) and name = 'dt_vencimento' )
begin
alter table T_Faturamento add dt_vencimento datetime
end
--CMD

if exists ( select dt_vencimento from T_Faturamento where dt_vencimento IS NULL )
begin
update T_Faturamento set dt_vencimento = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Faturamento' ) and name = 'dt_baixa' )
begin
alter table T_Faturamento add dt_baixa datetime
end
--CMD

if exists ( select dt_baixa from T_Faturamento where dt_baixa IS NULL )
begin
update T_Faturamento set dt_baixa = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Faturamento' ) and name = 'tg_situacao' )
begin
alter table T_Faturamento add tg_situacao varchar(1) 
end
else
begin
alter table T_Faturamento alter column tg_situacao varchar (1)
end
--CMD

if exists ( select tg_situacao from T_Faturamento where tg_situacao IS NULL )
begin
update T_Faturamento set tg_situacao = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Faturamento' ) and name = 'tg_retBanco' )
begin
alter table T_Faturamento add tg_retBanco int
end
--CMD

if exists ( select tg_retBanco from T_Faturamento where tg_retBanco IS NULL )
begin
update T_Faturamento set tg_retBanco = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_Faturamento_fk_empresa' )
begin
drop index T_Faturamento.index_T_Faturamento_fk_empresa
end
--CMD
create index index_T_Faturamento_fk_empresa on T_Faturamento (fk_empresa)
--CMD

if exists (select * from sysindexes where name='index_T_Faturamento_fk_loja' )
begin
drop index T_Faturamento.index_T_Faturamento_fk_loja
end
--CMD
create index index_T_Faturamento_fk_loja on T_Faturamento (fk_loja)
--CMD


if not exists (select * from sysobjects where name='T_FaturamentoDetalhes')
begin
create table T_FaturamentoDetalhes (
i_unique numeric(15) identity primary key,
fk_fatura int ,
tg_tipoFat int ,
nu_quantidade int ,
vr_cobranca int ,
tg_desconto varchar(1),
st_extras varchar(100),
fk_empresa int ,
fk_loja int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_FaturamentoDetalhes' ) and name = 'fk_fatura' )
begin
alter table T_FaturamentoDetalhes add fk_fatura int
end
--CMD

if exists ( select fk_fatura from T_FaturamentoDetalhes where fk_fatura IS NULL )
begin
update T_FaturamentoDetalhes set fk_fatura = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_FaturamentoDetalhes' ) and name = 'tg_tipoFat' )
begin
alter table T_FaturamentoDetalhes add tg_tipoFat int
end
--CMD

if exists ( select tg_tipoFat from T_FaturamentoDetalhes where tg_tipoFat IS NULL )
begin
update T_FaturamentoDetalhes set tg_tipoFat = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_FaturamentoDetalhes' ) and name = 'nu_quantidade' )
begin
alter table T_FaturamentoDetalhes add nu_quantidade int
end
--CMD

if exists ( select nu_quantidade from T_FaturamentoDetalhes where nu_quantidade IS NULL )
begin
update T_FaturamentoDetalhes set nu_quantidade = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_FaturamentoDetalhes' ) and name = 'vr_cobranca' )
begin
alter table T_FaturamentoDetalhes add vr_cobranca int
end
--CMD

if exists ( select vr_cobranca from T_FaturamentoDetalhes where vr_cobranca IS NULL )
begin
update T_FaturamentoDetalhes set vr_cobranca = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_FaturamentoDetalhes' ) and name = 'tg_desconto' )
begin
alter table T_FaturamentoDetalhes add tg_desconto varchar(1) 
end
else
begin
alter table T_FaturamentoDetalhes alter column tg_desconto varchar (1)
end
--CMD

if exists ( select tg_desconto from T_FaturamentoDetalhes where tg_desconto IS NULL )
begin
update T_FaturamentoDetalhes set tg_desconto = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_FaturamentoDetalhes' ) and name = 'st_extras' )
begin
alter table T_FaturamentoDetalhes add st_extras varchar(100) 
end
else
begin
alter table T_FaturamentoDetalhes alter column st_extras varchar (100)
end
--CMD

if exists ( select st_extras from T_FaturamentoDetalhes where st_extras IS NULL )
begin
update T_FaturamentoDetalhes set st_extras = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_FaturamentoDetalhes' ) and name = 'fk_empresa' )
begin
alter table T_FaturamentoDetalhes add fk_empresa int
end
--CMD

if exists ( select fk_empresa from T_FaturamentoDetalhes where fk_empresa IS NULL )
begin
update T_FaturamentoDetalhes set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_FaturamentoDetalhes' ) and name = 'fk_loja' )
begin
alter table T_FaturamentoDetalhes add fk_loja int
end
--CMD

if exists ( select fk_loja from T_FaturamentoDetalhes where fk_loja IS NULL )
begin
update T_FaturamentoDetalhes set fk_loja = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_FaturamentoDetalhes_fk_fatura' )
begin
drop index T_FaturamentoDetalhes.index_T_FaturamentoDetalhes_fk_fatura
end
--CMD
create index index_T_FaturamentoDetalhes_fk_fatura on T_FaturamentoDetalhes (fk_fatura)
--CMD

if exists (select * from sysindexes where name='index_T_FaturamentoDetalhes_fk_empresa' )
begin
drop index T_FaturamentoDetalhes.index_T_FaturamentoDetalhes_fk_empresa
end
--CMD
create index index_T_FaturamentoDetalhes_fk_empresa on T_FaturamentoDetalhes (fk_empresa)
--CMD

if exists (select * from sysindexes where name='index_T_FaturamentoDetalhes_fk_loja' )
begin
drop index T_FaturamentoDetalhes.index_T_FaturamentoDetalhes_fk_loja
end
--CMD
create index index_T_FaturamentoDetalhes_fk_loja on T_FaturamentoDetalhes (fk_loja)
--CMD


if not exists (select * from sysobjects where name='T_RetCobranca')
begin
create table T_RetCobranca (
i_unique numeric(15) identity primary key,
nu_codBanco int ,
nu_cod int ,
tg_tipoCob varchar(1),
st_codMsg varchar(99)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_RetCobranca' ) and name = 'nu_codBanco' )
begin
alter table T_RetCobranca add nu_codBanco int
end
--CMD

if exists ( select nu_codBanco from T_RetCobranca where nu_codBanco IS NULL )
begin
update T_RetCobranca set nu_codBanco = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_RetCobranca' ) and name = 'nu_cod' )
begin
alter table T_RetCobranca add nu_cod int
end
--CMD

if exists ( select nu_cod from T_RetCobranca where nu_cod IS NULL )
begin
update T_RetCobranca set nu_cod = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_RetCobranca' ) and name = 'tg_tipoCob' )
begin
alter table T_RetCobranca add tg_tipoCob varchar(1) 
end
else
begin
alter table T_RetCobranca alter column tg_tipoCob varchar (1)
end
--CMD

if exists ( select tg_tipoCob from T_RetCobranca where tg_tipoCob IS NULL )
begin
update T_RetCobranca set tg_tipoCob = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_RetCobranca' ) and name = 'st_codMsg' )
begin
alter table T_RetCobranca add st_codMsg varchar(99) 
end
else
begin
alter table T_RetCobranca alter column st_codMsg varchar (99)
end
--CMD

if exists ( select st_codMsg from T_RetCobranca where st_codMsg IS NULL )
begin
update T_RetCobranca set st_codMsg = ''
end
--CMD




if not exists (select * from sysobjects where name='LOG_NSA')
begin
create table LOG_NSA (
i_unique numeric(15) identity primary key,
dt_log datetime
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_NSA' ) and name = 'dt_log' )
begin
alter table LOG_NSA add dt_log datetime
end
--CMD

if exists ( select dt_log from LOG_NSA where dt_log IS NULL )
begin
update LOG_NSA set dt_log = '1900-01-01 00:00:00.000'
end
--CMD




if not exists (select * from sysobjects where name='LOG_NS_FAT')
begin
create table LOG_NS_FAT (
i_unique numeric(15) identity primary key,
dt_log datetime
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_NS_FAT' ) and name = 'dt_log' )
begin
alter table LOG_NS_FAT add dt_log datetime
end
--CMD

if exists ( select dt_log from LOG_NS_FAT where dt_log IS NULL )
begin
update LOG_NS_FAT set dt_log = '1900-01-01 00:00:00.000'
end
--CMD




if not exists (select * from sysobjects where name='T_Chamado')
begin
create table T_Chamado (
i_unique numeric(15) identity primary key,
fk_loja int ,
tg_fechado int ,
fk_operador int ,
nu_prioridade int ,
nu_categoria int ,
dt_abertura datetime,
dt_fechamento datetime,
st_motivo varchar(900),
tg_tecnico int ,
fk_oper_criador int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Chamado' ) and name = 'fk_loja' )
begin
alter table T_Chamado add fk_loja int
end
--CMD

if exists ( select fk_loja from T_Chamado where fk_loja IS NULL )
begin
update T_Chamado set fk_loja = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Chamado' ) and name = 'tg_fechado' )
begin
alter table T_Chamado add tg_fechado int
end
--CMD

if exists ( select tg_fechado from T_Chamado where tg_fechado IS NULL )
begin
update T_Chamado set tg_fechado = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Chamado' ) and name = 'fk_operador' )
begin
alter table T_Chamado add fk_operador int
end
--CMD

if exists ( select fk_operador from T_Chamado where fk_operador IS NULL )
begin
update T_Chamado set fk_operador = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Chamado' ) and name = 'nu_prioridade' )
begin
alter table T_Chamado add nu_prioridade int
end
--CMD

if exists ( select nu_prioridade from T_Chamado where nu_prioridade IS NULL )
begin
update T_Chamado set nu_prioridade = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Chamado' ) and name = 'nu_categoria' )
begin
alter table T_Chamado add nu_categoria int
end
--CMD

if exists ( select nu_categoria from T_Chamado where nu_categoria IS NULL )
begin
update T_Chamado set nu_categoria = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Chamado' ) and name = 'dt_abertura' )
begin
alter table T_Chamado add dt_abertura datetime
end
--CMD

if exists ( select dt_abertura from T_Chamado where dt_abertura IS NULL )
begin
update T_Chamado set dt_abertura = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Chamado' ) and name = 'dt_fechamento' )
begin
alter table T_Chamado add dt_fechamento datetime
end
--CMD

if exists ( select dt_fechamento from T_Chamado where dt_fechamento IS NULL )
begin
update T_Chamado set dt_fechamento = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Chamado' ) and name = 'st_motivo' )
begin
alter table T_Chamado add st_motivo varchar(900) 
end
else
begin
alter table T_Chamado alter column st_motivo varchar (900)
end
--CMD

if exists ( select st_motivo from T_Chamado where st_motivo IS NULL )
begin
update T_Chamado set st_motivo = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Chamado' ) and name = 'tg_tecnico' )
begin
alter table T_Chamado add tg_tecnico int
end
--CMD

if exists ( select tg_tecnico from T_Chamado where tg_tecnico IS NULL )
begin
update T_Chamado set tg_tecnico = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Chamado' ) and name = 'fk_oper_criador' )
begin
alter table T_Chamado add fk_oper_criador int
end
--CMD

if exists ( select fk_oper_criador from T_Chamado where fk_oper_criador IS NULL )
begin
update T_Chamado set fk_oper_criador = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_Chamado_fk_loja' )
begin
drop index T_Chamado.index_T_Chamado_fk_loja
end
--CMD
create index index_T_Chamado_fk_loja on T_Chamado (fk_loja)
--CMD

if exists (select * from sysindexes where name='index_T_Chamado_fk_operador' )
begin
drop index T_Chamado.index_T_Chamado_fk_operador
end
--CMD
create index index_T_Chamado_fk_operador on T_Chamado (fk_operador)
--CMD

if exists (select * from sysindexes where name='index_T_Chamado_fk_oper_criador' )
begin
drop index T_Chamado.index_T_Chamado_fk_oper_criador
end
--CMD
create index index_T_Chamado_fk_oper_criador on T_Chamado (fk_oper_criador)
--CMD


if not exists (select * from sysobjects where name='LOG_Chamado')
begin
create table LOG_Chamado (
i_unique numeric(15) identity primary key,
fk_chamado int ,
fk_operador int ,
st_solucao varchar(900),
dt_solucao datetime
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Chamado' ) and name = 'fk_chamado' )
begin
alter table LOG_Chamado add fk_chamado int
end
--CMD

if exists ( select fk_chamado from LOG_Chamado where fk_chamado IS NULL )
begin
update LOG_Chamado set fk_chamado = 0
end
--CMD


if exists (select * from sysindexes where name='index_LOG_Chamado_st_solution' )
begin
drop index LOG_Chamado.index_LOG_Chamado_st_solution
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Chamado' ) and name = 'st_solution' )
begin
alter table LOG_Chamado drop column st_solution
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Chamado' ) and name = 'fk_operador' )
begin
alter table LOG_Chamado add fk_operador int
end
--CMD

if exists ( select fk_operador from LOG_Chamado where fk_operador IS NULL )
begin
update LOG_Chamado set fk_operador = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Chamado' ) and name = 'st_solucao' )
begin
alter table LOG_Chamado add st_solucao varchar(900) 
end
else
begin
alter table LOG_Chamado alter column st_solucao varchar (900)
end
--CMD

if exists ( select st_solucao from LOG_Chamado where st_solucao IS NULL )
begin
update LOG_Chamado set st_solucao = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_Chamado' ) and name = 'dt_solucao' )
begin
alter table LOG_Chamado add dt_solucao datetime
end
--CMD

if exists ( select dt_solucao from LOG_Chamado where dt_solucao IS NULL )
begin
update LOG_Chamado set dt_solucao = '1900-01-01 00:00:00.000'
end
--CMD



if exists (select * from sysindexes where name='index_LOG_Chamado_fk_chamado' )
begin
drop index LOG_Chamado.index_LOG_Chamado_fk_chamado
end
--CMD
create index index_LOG_Chamado_fk_chamado on LOG_Chamado (fk_chamado)
--CMD

if exists (select * from sysindexes where name='index_LOG_Chamado_fk_operador' )
begin
drop index LOG_Chamado.index_LOG_Chamado_fk_operador
end
--CMD
create index index_LOG_Chamado_fk_operador on LOG_Chamado (fk_operador)
--CMD


if not exists (select * from sysobjects where name='T_ExtraGift')
begin
create table T_ExtraGift (
i_unique numeric(15) identity primary key,
st_nome varchar(40),
vr_valor int ,
fk_empresa int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_ExtraGift' ) and name = 'st_nome' )
begin
alter table T_ExtraGift add st_nome varchar(40) 
end
else
begin
alter table T_ExtraGift alter column st_nome varchar (40)
end
--CMD

if exists ( select st_nome from T_ExtraGift where st_nome IS NULL )
begin
update T_ExtraGift set st_nome = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_ExtraGift' ) and name = 'vr_valor' )
begin
alter table T_ExtraGift add vr_valor int
end
--CMD

if exists ( select vr_valor from T_ExtraGift where vr_valor IS NULL )
begin
update T_ExtraGift set vr_valor = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_ExtraGift' ) and name = 'fk_empresa' )
begin
alter table T_ExtraGift add fk_empresa int
end
--CMD

if exists ( select fk_empresa from T_ExtraGift where fk_empresa IS NULL )
begin
update T_ExtraGift set fk_empresa = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_ExtraGift_fk_empresa' )
begin
drop index T_ExtraGift.index_T_ExtraGift_fk_empresa
end
--CMD
create index index_T_ExtraGift_fk_empresa on T_ExtraGift (fk_empresa)
--CMD


if not exists (select * from sysobjects where name='T_Quiosque')
begin
create table T_Quiosque (
i_unique numeric(15) identity primary key,
fk_empresa int ,
st_nome varchar(40)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Quiosque' ) and name = 'fk_empresa' )
begin
alter table T_Quiosque add fk_empresa int
end
--CMD

if exists ( select fk_empresa from T_Quiosque where fk_empresa IS NULL )
begin
update T_Quiosque set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_Quiosque' ) and name = 'st_nome' )
begin
alter table T_Quiosque add st_nome varchar(40) 
end
else
begin
alter table T_Quiosque alter column st_nome varchar (40)
end
--CMD

if exists ( select st_nome from T_Quiosque where st_nome IS NULL )
begin
update T_Quiosque set st_nome = ''
end
--CMD



if exists (select * from sysindexes where name='index_T_Quiosque_fk_empresa' )
begin
drop index T_Quiosque.index_T_Quiosque_fk_empresa
end
--CMD
create index index_T_Quiosque_fk_empresa on T_Quiosque (fk_empresa)
--CMD


if not exists (select * from sysobjects where name='LOG_VendaCartaoGift')
begin
create table LOG_VendaCartaoGift (
i_unique numeric(15) identity primary key,
fk_vendedor int ,
fk_empresa int ,
fk_cartao int ,
tg_tipoPag int ,
dt_compra datetime,
tg_tipoCartao int ,
st_cheque varchar(80),
nu_nsuCartao int ,
vr_carga int ,
tg_adesao int ,
st_codImpresso varchar(90)
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'fk_vendedor' )
begin
alter table LOG_VendaCartaoGift add fk_vendedor int
end
--CMD

if exists ( select fk_vendedor from LOG_VendaCartaoGift where fk_vendedor IS NULL )
begin
update LOG_VendaCartaoGift set fk_vendedor = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'fk_empresa' )
begin
alter table LOG_VendaCartaoGift add fk_empresa int
end
--CMD

if exists ( select fk_empresa from LOG_VendaCartaoGift where fk_empresa IS NULL )
begin
update LOG_VendaCartaoGift set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'fk_cartao' )
begin
alter table LOG_VendaCartaoGift add fk_cartao int
end
--CMD

if exists ( select fk_cartao from LOG_VendaCartaoGift where fk_cartao IS NULL )
begin
update LOG_VendaCartaoGift set fk_cartao = 0
end
--CMD


if exists (select * from sysindexes where name='index_LOG_VendaCartaoGift_dt_venda' )
begin
drop index LOG_VendaCartaoGift.index_LOG_VendaCartaoGift_dt_venda
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'dt_venda' )
begin
alter table LOG_VendaCartaoGift drop column dt_venda
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'tg_tipoPag' )
begin
alter table LOG_VendaCartaoGift add tg_tipoPag int
end
--CMD

if exists ( select tg_tipoPag from LOG_VendaCartaoGift where tg_tipoPag IS NULL )
begin
update LOG_VendaCartaoGift set tg_tipoPag = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'dt_compra' )
begin
alter table LOG_VendaCartaoGift add dt_compra datetime
end
--CMD

if exists ( select dt_compra from LOG_VendaCartaoGift where dt_compra IS NULL )
begin
update LOG_VendaCartaoGift set dt_compra = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'tg_tipoCartao' )
begin
alter table LOG_VendaCartaoGift add tg_tipoCartao int
end
--CMD

if exists ( select tg_tipoCartao from LOG_VendaCartaoGift where tg_tipoCartao IS NULL )
begin
update LOG_VendaCartaoGift set tg_tipoCartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'st_cheque' )
begin
alter table LOG_VendaCartaoGift add st_cheque varchar(80) 
end
else
begin
alter table LOG_VendaCartaoGift alter column st_cheque varchar (80)
end
--CMD

if exists ( select st_cheque from LOG_VendaCartaoGift where st_cheque IS NULL )
begin
update LOG_VendaCartaoGift set st_cheque = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'nu_nsuCartao' )
begin
alter table LOG_VendaCartaoGift add nu_nsuCartao int
end
--CMD

if exists ( select nu_nsuCartao from LOG_VendaCartaoGift where nu_nsuCartao IS NULL )
begin
update LOG_VendaCartaoGift set nu_nsuCartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'vr_carga' )
begin
alter table LOG_VendaCartaoGift add vr_carga int
end
--CMD

if exists ( select vr_carga from LOG_VendaCartaoGift where vr_carga IS NULL )
begin
update LOG_VendaCartaoGift set vr_carga = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'tg_adesao' )
begin
alter table LOG_VendaCartaoGift add tg_adesao int
end
--CMD

if exists ( select tg_adesao from LOG_VendaCartaoGift where tg_adesao IS NULL )
begin
update LOG_VendaCartaoGift set tg_adesao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaCartaoGift' ) and name = 'st_codImpresso' )
begin
alter table LOG_VendaCartaoGift add st_codImpresso varchar(90) 
end
else
begin
alter table LOG_VendaCartaoGift alter column st_codImpresso varchar (90)
end
--CMD

if exists ( select st_codImpresso from LOG_VendaCartaoGift where st_codImpresso IS NULL )
begin
update LOG_VendaCartaoGift set st_codImpresso = ''
end
--CMD



if exists (select * from sysindexes where name='index_LOG_VendaCartaoGift_fk_vendedor' )
begin
drop index LOG_VendaCartaoGift.index_LOG_VendaCartaoGift_fk_vendedor
end
--CMD
create index index_LOG_VendaCartaoGift_fk_vendedor on LOG_VendaCartaoGift (fk_vendedor)
--CMD

if exists (select * from sysindexes where name='index_LOG_VendaCartaoGift_fk_empresa' )
begin
drop index LOG_VendaCartaoGift.index_LOG_VendaCartaoGift_fk_empresa
end
--CMD
create index index_LOG_VendaCartaoGift_fk_empresa on LOG_VendaCartaoGift (fk_empresa)
--CMD

if exists (select * from sysindexes where name='index_LOG_VendaCartaoGift_fk_cartao' )
begin
drop index LOG_VendaCartaoGift.index_LOG_VendaCartaoGift_fk_cartao
end
--CMD
create index index_LOG_VendaCartaoGift_fk_cartao on LOG_VendaCartaoGift (fk_cartao)
--CMD


if not exists (select * from sysobjects where name='LOG_VendaProdutoGift')
begin
create table LOG_VendaProdutoGift (
i_unique numeric(15) identity primary key,
fk_vendaCartao int ,
st_produto varchar(90),
vr_valor int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaProdutoGift' ) and name = 'fk_vendaCartao' )
begin
alter table LOG_VendaProdutoGift add fk_vendaCartao int
end
--CMD

if exists ( select fk_vendaCartao from LOG_VendaProdutoGift where fk_vendaCartao IS NULL )
begin
update LOG_VendaProdutoGift set fk_vendaCartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaProdutoGift' ) and name = 'st_produto' )
begin
alter table LOG_VendaProdutoGift add st_produto varchar(90) 
end
else
begin
alter table LOG_VendaProdutoGift alter column st_produto varchar (90)
end
--CMD

if exists ( select st_produto from LOG_VendaProdutoGift where st_produto IS NULL )
begin
update LOG_VendaProdutoGift set st_produto = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_VendaProdutoGift' ) and name = 'vr_valor' )
begin
alter table LOG_VendaProdutoGift add vr_valor int
end
--CMD

if exists ( select vr_valor from LOG_VendaProdutoGift where vr_valor IS NULL )
begin
update LOG_VendaProdutoGift set vr_valor = 0
end
--CMD



if exists (select * from sysindexes where name='index_LOG_VendaProdutoGift_fk_vendaCartao' )
begin
drop index LOG_VendaProdutoGift.index_LOG_VendaProdutoGift_fk_vendaCartao
end
--CMD
create index index_LOG_VendaProdutoGift_fk_vendaCartao on LOG_VendaProdutoGift (fk_vendaCartao)
--CMD


if not exists (select * from sysobjects where name='T_ChequesGift')
begin
create table T_ChequesGift (
i_unique numeric(15) identity primary key,
st_identificador varchar(40),
fk_cartao int ,
dt_efetiva datetime,
tg_compensado int ,
vr_valor int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_ChequesGift' ) and name = 'st_identificador' )
begin
alter table T_ChequesGift add st_identificador varchar(40) 
end
else
begin
alter table T_ChequesGift alter column st_identificador varchar (40)
end
--CMD

if exists ( select st_identificador from T_ChequesGift where st_identificador IS NULL )
begin
update T_ChequesGift set st_identificador = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_ChequesGift' ) and name = 'fk_cartao' )
begin
alter table T_ChequesGift add fk_cartao int
end
--CMD

if exists ( select fk_cartao from T_ChequesGift where fk_cartao IS NULL )
begin
update T_ChequesGift set fk_cartao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_ChequesGift' ) and name = 'dt_efetiva' )
begin
alter table T_ChequesGift add dt_efetiva datetime
end
--CMD

if exists ( select dt_efetiva from T_ChequesGift where dt_efetiva IS NULL )
begin
update T_ChequesGift set dt_efetiva = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_ChequesGift' ) and name = 'tg_compensado' )
begin
alter table T_ChequesGift add tg_compensado int
end
--CMD

if exists ( select tg_compensado from T_ChequesGift where tg_compensado IS NULL )
begin
update T_ChequesGift set tg_compensado = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_ChequesGift' ) and name = 'vr_valor' )
begin
alter table T_ChequesGift add vr_valor int
end
--CMD

if exists ( select vr_valor from T_ChequesGift where vr_valor IS NULL )
begin
update T_ChequesGift set vr_valor = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_ChequesGift_fk_cartao' )
begin
drop index T_ChequesGift.index_T_ChequesGift_fk_cartao
end
--CMD
create index index_T_ChequesGift_fk_cartao on T_ChequesGift (fk_cartao)
--CMD


if not exists (select * from sysobjects where name='LOG_GiftRanges')
begin
create table LOG_GiftRanges (
i_unique numeric(15) identity primary key,
fk_empresa int ,
nu_inicio int ,
nu_fim int ,
dt_requisicao datetime
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_GiftRanges' ) and name = 'fk_empresa' )
begin
alter table LOG_GiftRanges add fk_empresa int
end
--CMD

if exists ( select fk_empresa from LOG_GiftRanges where fk_empresa IS NULL )
begin
update LOG_GiftRanges set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_GiftRanges' ) and name = 'nu_inicio' )
begin
alter table LOG_GiftRanges add nu_inicio int
end
--CMD

if exists ( select nu_inicio from LOG_GiftRanges where nu_inicio IS NULL )
begin
update LOG_GiftRanges set nu_inicio = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_GiftRanges' ) and name = 'nu_fim' )
begin
alter table LOG_GiftRanges add nu_fim int
end
--CMD

if exists ( select nu_fim from LOG_GiftRanges where nu_fim IS NULL )
begin
update LOG_GiftRanges set nu_fim = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LOG_GiftRanges' ) and name = 'dt_requisicao' )
begin
alter table LOG_GiftRanges add dt_requisicao datetime
end
--CMD

if exists ( select dt_requisicao from LOG_GiftRanges where dt_requisicao IS NULL )
begin
update LOG_GiftRanges set dt_requisicao = '1900-01-01 00:00:00.000'
end
--CMD



if exists (select * from sysindexes where name='index_LOG_GiftRanges_fk_empresa' )
begin
drop index LOG_GiftRanges.index_LOG_GiftRanges_fk_empresa
end
--CMD
create index index_LOG_GiftRanges_fk_empresa on LOG_GiftRanges (fk_empresa)
--CMD


if not exists (select * from sysobjects where name='T_RepasseLoja')
begin
create table T_RepasseLoja (
i_unique numeric(15) identity primary key,
fk_loja int ,
tg_opcao int ,
vr_valor int ,
st_ident varchar(90),
dt_efetiva datetime
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_RepasseLoja' ) and name = 'fk_loja' )
begin
alter table T_RepasseLoja add fk_loja int
end
--CMD

if exists ( select fk_loja from T_RepasseLoja where fk_loja IS NULL )
begin
update T_RepasseLoja set fk_loja = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_RepasseLoja' ) and name = 'tg_opcao' )
begin
alter table T_RepasseLoja add tg_opcao int
end
--CMD

if exists ( select tg_opcao from T_RepasseLoja where tg_opcao IS NULL )
begin
update T_RepasseLoja set tg_opcao = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_RepasseLoja' ) and name = 'vr_valor' )
begin
alter table T_RepasseLoja add vr_valor int
end
--CMD

if exists ( select vr_valor from T_RepasseLoja where vr_valor IS NULL )
begin
update T_RepasseLoja set vr_valor = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_RepasseLoja' ) and name = 'st_ident' )
begin
alter table T_RepasseLoja add st_ident varchar(90) 
end
else
begin
alter table T_RepasseLoja alter column st_ident varchar (90)
end
--CMD

if exists ( select st_ident from T_RepasseLoja where st_ident IS NULL )
begin
update T_RepasseLoja set st_ident = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_RepasseLoja' ) and name = 'dt_efetiva' )
begin
alter table T_RepasseLoja add dt_efetiva datetime
end
--CMD

if exists ( select dt_efetiva from T_RepasseLoja where dt_efetiva IS NULL )
begin
update T_RepasseLoja set dt_efetiva = '1900-01-01 00:00:00.000'
end
--CMD



if exists (select * from sysindexes where name='index_T_RepasseLoja_fk_loja' )
begin
drop index T_RepasseLoja.index_T_RepasseLoja_fk_loja
end
--CMD
create index index_T_RepasseLoja_fk_loja on T_RepasseLoja (fk_loja)
--CMD


if not exists (select * from sysobjects where name='LINK_RepasseParcela')
begin
create table LINK_RepasseParcela (
i_unique numeric(15) identity primary key,
fk_repasseLoja int ,
fk_parcela int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_RepasseParcela' ) and name = 'fk_repasseLoja' )
begin
alter table LINK_RepasseParcela add fk_repasseLoja int
end
--CMD

if exists ( select fk_repasseLoja from LINK_RepasseParcela where fk_repasseLoja IS NULL )
begin
update LINK_RepasseParcela set fk_repasseLoja = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_RepasseParcela' ) and name = 'fk_parcela' )
begin
alter table LINK_RepasseParcela add fk_parcela int
end
--CMD

if exists ( select fk_parcela from LINK_RepasseParcela where fk_parcela IS NULL )
begin
update LINK_RepasseParcela set fk_parcela = 0
end
--CMD



if exists (select * from sysindexes where name='index_LINK_RepasseParcela_fk_repasseLoja' )
begin
drop index LINK_RepasseParcela.index_LINK_RepasseParcela_fk_repasseLoja
end
--CMD
create index index_LINK_RepasseParcela_fk_repasseLoja on LINK_RepasseParcela (fk_repasseLoja)
--CMD

if exists (select * from sysindexes where name='index_LINK_RepasseParcela_fk_parcela' )
begin
drop index LINK_RepasseParcela.index_LINK_RepasseParcela_fk_parcela
end
--CMD
create index index_LINK_RepasseParcela_fk_parcela on LINK_RepasseParcela (fk_parcela)
--CMD


if not exists (select * from sysobjects where name='T_EmpresaAfiliada')
begin
create table T_EmpresaAfiliada (
i_unique numeric(15) identity primary key,
st_nome varchar(20),
fk_empresa int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_EmpresaAfiliada' ) and name = 'st_nome' )
begin
alter table T_EmpresaAfiliada add st_nome varchar(20) 
end
else
begin
alter table T_EmpresaAfiliada alter column st_nome varchar (20)
end
--CMD

if exists ( select st_nome from T_EmpresaAfiliada where st_nome IS NULL )
begin
update T_EmpresaAfiliada set st_nome = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_EmpresaAfiliada' ) and name = 'fk_empresa' )
begin
alter table T_EmpresaAfiliada add fk_empresa int
end
--CMD

if exists ( select fk_empresa from T_EmpresaAfiliada where fk_empresa IS NULL )
begin
update T_EmpresaAfiliada set fk_empresa = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_EmpresaAfiliada_fk_empresa' )
begin
drop index T_EmpresaAfiliada.index_T_EmpresaAfiliada_fk_empresa
end
--CMD
create index index_T_EmpresaAfiliada_fk_empresa on T_EmpresaAfiliada (fk_empresa)
--CMD


if not exists (select * from sysobjects where name='T_BoletoEdu')
begin
create table T_BoletoEdu (
i_unique numeric(15) identity primary key,
dt_emissao datetime,
vr_imediato int ,
vr_educacional int ,
fk_cartao int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_BoletoEdu' ) and name = 'dt_emissao' )
begin
alter table T_BoletoEdu add dt_emissao datetime
end
--CMD

if exists ( select dt_emissao from T_BoletoEdu where dt_emissao IS NULL )
begin
update T_BoletoEdu set dt_emissao = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_BoletoEdu' ) and name = 'vr_imediato' )
begin
alter table T_BoletoEdu add vr_imediato int
end
--CMD

if exists ( select vr_imediato from T_BoletoEdu where vr_imediato IS NULL )
begin
update T_BoletoEdu set vr_imediato = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_BoletoEdu' ) and name = 'vr_educacional' )
begin
alter table T_BoletoEdu add vr_educacional int
end
--CMD

if exists ( select vr_educacional from T_BoletoEdu where vr_educacional IS NULL )
begin
update T_BoletoEdu set vr_educacional = 0
end
--CMD


if exists (select * from sysindexes where name='index_T_BoletoEdu_fk_dadosProprietario' )
begin
drop index T_BoletoEdu.index_T_BoletoEdu_fk_dadosProprietario
end
--CMD

if exists ( select name from syscolumns where id in (select id from sysobjects where name='T_BoletoEdu' ) and name = 'fk_dadosProprietario' )
begin
alter table T_BoletoEdu drop column fk_dadosProprietario
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_BoletoEdu' ) and name = 'fk_cartao' )
begin
alter table T_BoletoEdu add fk_cartao int
end
--CMD

if exists ( select fk_cartao from T_BoletoEdu where fk_cartao IS NULL )
begin
update T_BoletoEdu set fk_cartao = 0
end
--CMD



if exists (select * from sysindexes where name='index_T_BoletoEdu_fk_cartao' )
begin
drop index T_BoletoEdu.index_T_BoletoEdu_fk_cartao
end
--CMD
create index index_T_BoletoEdu_fk_cartao on T_BoletoEdu (fk_cartao)
--CMD


if not exists (select * from sysobjects where name='LINK_UsuarioTerminal')
begin
create table LINK_UsuarioTerminal (
i_unique numeric(15) identity primary key,
fk_user int ,
fk_term int 
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_UsuarioTerminal' ) and name = 'fk_user' )
begin
alter table LINK_UsuarioTerminal add fk_user int
end
--CMD

if exists ( select fk_user from LINK_UsuarioTerminal where fk_user IS NULL )
begin
update LINK_UsuarioTerminal set fk_user = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='LINK_UsuarioTerminal' ) and name = 'fk_term' )
begin
alter table LINK_UsuarioTerminal add fk_term int
end
--CMD

if exists ( select fk_term from LINK_UsuarioTerminal where fk_term IS NULL )
begin
update LINK_UsuarioTerminal set fk_term = 0
end
--CMD



if exists (select * from sysindexes where name='index_LINK_UsuarioTerminal_fk_user' )
begin
drop index LINK_UsuarioTerminal.index_LINK_UsuarioTerminal_fk_user
end
--CMD
create index index_LINK_UsuarioTerminal_fk_user on LINK_UsuarioTerminal (fk_user)
--CMD

if exists (select * from sysindexes where name='index_LINK_UsuarioTerminal_fk_term' )
begin
drop index LINK_UsuarioTerminal.index_LINK_UsuarioTerminal_fk_term
end
--CMD
create index index_LINK_UsuarioTerminal_fk_term on LINK_UsuarioTerminal (fk_term)
--CMD


if not exists (select * from sysobjects where name='T_MensagemEdu')
begin
create table T_MensagemEdu (
i_unique numeric(15) identity primary key,
st_mens varchar(900),
fk_empresa int ,
dt_ini datetime,
dt_fim datetime
)
end
--CMD

if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_MensagemEdu' ) and name = 'st_mens' )
begin
alter table T_MensagemEdu add st_mens varchar(900) 
end
else
begin
alter table T_MensagemEdu alter column st_mens varchar (900)
end
--CMD

if exists ( select st_mens from T_MensagemEdu where st_mens IS NULL )
begin
update T_MensagemEdu set st_mens = ''
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_MensagemEdu' ) and name = 'fk_empresa' )
begin
alter table T_MensagemEdu add fk_empresa int
end
--CMD

if exists ( select fk_empresa from T_MensagemEdu where fk_empresa IS NULL )
begin
update T_MensagemEdu set fk_empresa = 0
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_MensagemEdu' ) and name = 'dt_ini' )
begin
alter table T_MensagemEdu add dt_ini datetime
end
--CMD

if exists ( select dt_ini from T_MensagemEdu where dt_ini IS NULL )
begin
update T_MensagemEdu set dt_ini = '1900-01-01 00:00:00.000'
end
--CMD


if not exists ( select name from syscolumns where id in (select id from sysobjects where name='T_MensagemEdu' ) and name = 'dt_fim' )
begin
alter table T_MensagemEdu add dt_fim datetime
end
--CMD

if exists ( select dt_fim from T_MensagemEdu where dt_fim IS NULL )
begin
update T_MensagemEdu set dt_fim = '1900-01-01 00:00:00.000'
end
--CMD



if exists (select * from sysindexes where name='index_T_MensagemEdu_fk_empresa' )
begin
drop index T_MensagemEdu.index_T_MensagemEdu_fk_empresa
end
--CMD
create index index_T_MensagemEdu_fk_empresa on T_MensagemEdu (fk_empresa)
--CMD

