CREATE TABLE IF NOT EXISTS `i_patch` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_done` VARCHAR(1),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

CREATE TABLE IF NOT EXISTS `T_Cartao` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_empresa` VARCHAR(6),
`st_matricula` VARCHAR(6),
`st_titularidade` VARCHAR(2),
`st_senha` VARCHAR(16),
`tg_tipoCartao` VARCHAR(1),
`st_venctoCartao` VARCHAR(4),
`tg_status` VARCHAR(1),
`dt_utlPagto` DATETIME,
`nu_senhaErrada` BIGINT UNSIGNED,
`dt_inclusao` DATETIME,
`dt_bloqueio` DATETIME,
`tg_motivoBloqueio` VARCHAR(1),
`st_banco` VARCHAR(4),
`st_agencia` VARCHAR(4),
`st_conta` VARCHAR(10),
`st_matriculaExtra` VARCHAR(10),
`st_celCartao` VARCHAR(13),
`fk_dadosProprietario` BIGINT UNSIGNED,
`fk_infoAdicionais` BIGINT UNSIGNED,
`nu_viaCartao` BIGINT UNSIGNED,
`vr_limiteTotal` BIGINT UNSIGNED,
`vr_limiteMensal` BIGINT UNSIGNED,
`vr_limiteRotativo` BIGINT UNSIGNED,
`vr_extraCota` BIGINT UNSIGNED,
`vr_educacional` BIGINT UNSIGNED,
`vr_disp_educacional` BIGINT UNSIGNED,
`vr_edu_diario` BIGINT UNSIGNED,
`st_aluno` VARCHAR(40),
`tg_emitido` BIGINT UNSIGNED,
`vr_edu_disp_virtual` BIGINT UNSIGNED,
`nu_rankVirtual` BIGINT UNSIGNED,
`vr_edu_total_ranking` BIGINT UNSIGNED,
`nu_webSenhaErrada` BIGINT UNSIGNED,
`tg_semanaCompleta` BIGINT UNSIGNED,
`tg_excluido` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_st_empresa;
##CMD

CREATE PROCEDURE ADD_T_Cartao_st_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `st_empresa` VARCHAR(6);
else
ALTER TABLE `T_Cartao` MODIFY `st_empresa` VARCHAR(6);
end if;
select count(*) from T_Cartao where st_empresa is null into var_find;
if var_find > 0 then 
update T_Cartao set st_empresa = '' where st_empresa is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_st_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_st_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_st_matricula;
##CMD

CREATE PROCEDURE ADD_T_Cartao_st_matricula ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_matricula' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `st_matricula` VARCHAR(6);
else
ALTER TABLE `T_Cartao` MODIFY `st_matricula` VARCHAR(6);
end if;
select count(*) from T_Cartao where st_matricula is null into var_find;
if var_find > 0 then 
update T_Cartao set st_matricula = '' where st_matricula is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_st_matricula ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_st_matricula;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_st_titularidade;
##CMD

CREATE PROCEDURE ADD_T_Cartao_st_titularidade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_titularidade' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `st_titularidade` VARCHAR(2);
else
ALTER TABLE `T_Cartao` MODIFY `st_titularidade` VARCHAR(2);
end if;
select count(*) from T_Cartao where st_titularidade is null into var_find;
if var_find > 0 then 
update T_Cartao set st_titularidade = '' where st_titularidade is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_st_titularidade ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_st_titularidade;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_st_senha;
##CMD

CREATE PROCEDURE ADD_T_Cartao_st_senha ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_senha' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `st_senha` VARCHAR(16);
else
ALTER TABLE `T_Cartao` MODIFY `st_senha` VARCHAR(16);
end if;
select count(*) from T_Cartao where st_senha is null into var_find;
if var_find > 0 then 
update T_Cartao set st_senha = '' where st_senha is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_st_senha ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_st_senha;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_st_senhaw;
##CMD
CREATE PROCEDURE DEL_T_Cartao_st_senhaw ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_senhaw' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `st_senhaw` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_st_senhaw ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_st_senhaw;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_tg_tipoCartao;
##CMD

CREATE PROCEDURE ADD_T_Cartao_tg_tipoCartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'tg_tipoCartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `tg_tipoCartao` VARCHAR(1);
else
ALTER TABLE `T_Cartao` MODIFY `tg_tipoCartao` VARCHAR(1);
end if;
select count(*) from T_Cartao where tg_tipoCartao is null into var_find;
if var_find > 0 then 
update T_Cartao set tg_tipoCartao = '' where tg_tipoCartao is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_tg_tipoCartao ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_tg_tipoCartao;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_tg_viaCartao;
##CMD
CREATE PROCEDURE DEL_T_Cartao_tg_viaCartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'tg_viaCartao' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `tg_viaCartao` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_tg_viaCartao ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_tg_viaCartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_st_venctoCartao;
##CMD

CREATE PROCEDURE ADD_T_Cartao_st_venctoCartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_venctoCartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `st_venctoCartao` VARCHAR(4);
else
ALTER TABLE `T_Cartao` MODIFY `st_venctoCartao` VARCHAR(4);
end if;
select count(*) from T_Cartao where st_venctoCartao is null into var_find;
if var_find > 0 then 
update T_Cartao set st_venctoCartao = '' where st_venctoCartao is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_st_venctoCartao ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_st_venctoCartao;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_st_cpf;
##CMD
CREATE PROCEDURE DEL_T_Cartao_st_cpf ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_cpf' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `st_cpf` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_st_cpf ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_st_cpf;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_nu_limiteTotal;
##CMD
CREATE PROCEDURE DEL_T_Cartao_nu_limiteTotal ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'nu_limiteTotal' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `nu_limiteTotal` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_nu_limiteTotal ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_nu_limiteTotal;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_nu_limiteMensal;
##CMD
CREATE PROCEDURE DEL_T_Cartao_nu_limiteMensal ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'nu_limiteMensal' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `nu_limiteMensal` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_nu_limiteMensal ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_nu_limiteMensal;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_nu_limiteRotativo;
##CMD
CREATE PROCEDURE DEL_T_Cartao_nu_limiteRotativo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'nu_limiteRotativo' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `nu_limiteRotativo` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_nu_limiteRotativo ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_nu_limiteRotativo;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_nu_extraCota;
##CMD
CREATE PROCEDURE DEL_T_Cartao_nu_extraCota ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'nu_extraCota' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `nu_extraCota` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_nu_extraCota ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_nu_extraCota;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_tg_status;
##CMD

CREATE PROCEDURE ADD_T_Cartao_tg_status ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'tg_status' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `tg_status` VARCHAR(1);
else
ALTER TABLE `T_Cartao` MODIFY `tg_status` VARCHAR(1);
end if;
select count(*) from T_Cartao where tg_status is null into var_find;
if var_find > 0 then 
update T_Cartao set tg_status = '' where tg_status is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_tg_status ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_tg_status;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_dt_utlPagto;
##CMD

CREATE PROCEDURE ADD_T_Cartao_dt_utlPagto ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'dt_utlPagto' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `dt_utlPagto` DATETIME;
end if;
select count(*) from T_Cartao where dt_utlPagto is null into var_find;
if var_find > 0 then 
update T_Cartao set dt_utlPagto = '1900-01-01 00:00:00.000' where dt_utlPagto is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_dt_utlPagto ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_dt_utlPagto;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_nu_diaVencto;
##CMD
CREATE PROCEDURE DEL_T_Cartao_nu_diaVencto ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'nu_diaVencto' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `nu_diaVencto` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_nu_diaVencto ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_nu_diaVencto;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_nu_diaFechFatura;
##CMD
CREATE PROCEDURE DEL_T_Cartao_nu_diaFechFatura ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'nu_diaFechFatura' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `nu_diaFechFatura` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_nu_diaFechFatura ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_nu_diaFechFatura;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_tg_testeProducao;
##CMD
CREATE PROCEDURE DEL_T_Cartao_tg_testeProducao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'tg_testeProducao' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `tg_testeProducao` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_tg_testeProducao ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_tg_testeProducao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_nu_senhaErrada;
##CMD

CREATE PROCEDURE ADD_T_Cartao_nu_senhaErrada ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'nu_senhaErrada' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `nu_senhaErrada` BIGINT;
end if;
select count(*) from T_Cartao where nu_senhaErrada is null into var_find;
if var_find > 0 then 
update T_Cartao set nu_senhaErrada = 0 where nu_senhaErrada is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_nu_senhaErrada ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_nu_senhaErrada;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_dt_inclusao;
##CMD

CREATE PROCEDURE ADD_T_Cartao_dt_inclusao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'dt_inclusao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `dt_inclusao` DATETIME;
end if;
select count(*) from T_Cartao where dt_inclusao is null into var_find;
if var_find > 0 then 
update T_Cartao set dt_inclusao = '1900-01-01 00:00:00.000' where dt_inclusao is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_dt_inclusao ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_dt_inclusao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_dt_bloqueio;
##CMD

CREATE PROCEDURE ADD_T_Cartao_dt_bloqueio ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'dt_bloqueio' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `dt_bloqueio` DATETIME;
end if;
select count(*) from T_Cartao where dt_bloqueio is null into var_find;
if var_find > 0 then 
update T_Cartao set dt_bloqueio = '1900-01-01 00:00:00.000' where dt_bloqueio is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_dt_bloqueio ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_dt_bloqueio;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_tg_motivoBloqueio;
##CMD

CREATE PROCEDURE ADD_T_Cartao_tg_motivoBloqueio ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'tg_motivoBloqueio' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `tg_motivoBloqueio` VARCHAR(1);
else
ALTER TABLE `T_Cartao` MODIFY `tg_motivoBloqueio` VARCHAR(1);
end if;
select count(*) from T_Cartao where tg_motivoBloqueio is null into var_find;
if var_find > 0 then 
update T_Cartao set tg_motivoBloqueio = '' where tg_motivoBloqueio is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_tg_motivoBloqueio ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_tg_motivoBloqueio;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_st_banco;
##CMD

CREATE PROCEDURE ADD_T_Cartao_st_banco ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_banco' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `st_banco` VARCHAR(4);
else
ALTER TABLE `T_Cartao` MODIFY `st_banco` VARCHAR(4);
end if;
select count(*) from T_Cartao where st_banco is null into var_find;
if var_find > 0 then 
update T_Cartao set st_banco = '' where st_banco is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_st_banco ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_st_banco;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_st_agencia;
##CMD

CREATE PROCEDURE ADD_T_Cartao_st_agencia ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_agencia' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `st_agencia` VARCHAR(4);
else
ALTER TABLE `T_Cartao` MODIFY `st_agencia` VARCHAR(4);
end if;
select count(*) from T_Cartao where st_agencia is null into var_find;
if var_find > 0 then 
update T_Cartao set st_agencia = '' where st_agencia is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_st_agencia ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_st_agencia;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_st_conta;
##CMD

CREATE PROCEDURE ADD_T_Cartao_st_conta ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_conta' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `st_conta` VARCHAR(10);
else
ALTER TABLE `T_Cartao` MODIFY `st_conta` VARCHAR(10);
end if;
select count(*) from T_Cartao where st_conta is null into var_find;
if var_find > 0 then 
update T_Cartao set st_conta = '' where st_conta is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_st_conta ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_st_conta;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_tg_gerencial;
##CMD
CREATE PROCEDURE DEL_T_Cartao_tg_gerencial ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'tg_gerencial' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `tg_gerencial` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_tg_gerencial ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_tg_gerencial;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_st_matriculaExtra;
##CMD

CREATE PROCEDURE ADD_T_Cartao_st_matriculaExtra ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_matriculaExtra' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `st_matriculaExtra` VARCHAR(10);
else
ALTER TABLE `T_Cartao` MODIFY `st_matriculaExtra` VARCHAR(10);
end if;
select count(*) from T_Cartao where st_matriculaExtra is null into var_find;
if var_find > 0 then 
update T_Cartao set st_matriculaExtra = '' where st_matriculaExtra is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_st_matriculaExtra ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_st_matriculaExtra;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_st_celCartao;
##CMD

CREATE PROCEDURE ADD_T_Cartao_st_celCartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_celCartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `st_celCartao` VARCHAR(13);
else
ALTER TABLE `T_Cartao` MODIFY `st_celCartao` VARCHAR(13);
end if;
select count(*) from T_Cartao where st_celCartao is null into var_find;
if var_find > 0 then 
update T_Cartao set st_celCartao = '' where st_celCartao is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_st_celCartao ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_st_celCartao;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_nu_pontos;
##CMD
CREATE PROCEDURE DEL_T_Cartao_nu_pontos ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'nu_pontos' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `nu_pontos` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_nu_pontos ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_nu_pontos;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_fk_dadosProprietario;
##CMD

CREATE PROCEDURE ADD_T_Cartao_fk_dadosProprietario ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'fk_dadosProprietario' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `fk_dadosProprietario` BIGINT;
end if;
select count(*) from T_Cartao where fk_dadosProprietario is null into var_find;
if var_find > 0 then 
update T_Cartao set fk_dadosProprietario = 0 where fk_dadosProprietario is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'fk_dadosProprietario' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD INDEX `index_fk_dadosProprietario`(fk_dadosProprietario);
end if;
END;
##CMD
CALL ADD_T_Cartao_fk_dadosProprietario ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_fk_dadosProprietario;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_fk_infoAdicionais;
##CMD

CREATE PROCEDURE ADD_T_Cartao_fk_infoAdicionais ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'fk_infoAdicionais' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `fk_infoAdicionais` BIGINT;
end if;
select count(*) from T_Cartao where fk_infoAdicionais is null into var_find;
if var_find > 0 then 
update T_Cartao set fk_infoAdicionais = 0 where fk_infoAdicionais is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'fk_infoAdicionais' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD INDEX `index_fk_infoAdicionais`(fk_infoAdicionais);
end if;
END;
##CMD
CALL ADD_T_Cartao_fk_infoAdicionais ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_fk_infoAdicionais;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_nu_viaCartao;
##CMD

CREATE PROCEDURE ADD_T_Cartao_nu_viaCartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'nu_viaCartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `nu_viaCartao` BIGINT;
end if;
select count(*) from T_Cartao where nu_viaCartao is null into var_find;
if var_find > 0 then 
update T_Cartao set nu_viaCartao = 0 where nu_viaCartao is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_nu_viaCartao ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_nu_viaCartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_vr_limiteTotal;
##CMD

CREATE PROCEDURE ADD_T_Cartao_vr_limiteTotal ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'vr_limiteTotal' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `vr_limiteTotal` BIGINT;
end if;
select count(*) from T_Cartao where vr_limiteTotal is null into var_find;
if var_find > 0 then 
update T_Cartao set vr_limiteTotal = 0 where vr_limiteTotal is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_vr_limiteTotal ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_vr_limiteTotal;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_vr_limiteMensal;
##CMD

CREATE PROCEDURE ADD_T_Cartao_vr_limiteMensal ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'vr_limiteMensal' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `vr_limiteMensal` BIGINT;
end if;
select count(*) from T_Cartao where vr_limiteMensal is null into var_find;
if var_find > 0 then 
update T_Cartao set vr_limiteMensal = 0 where vr_limiteMensal is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_vr_limiteMensal ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_vr_limiteMensal;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_vr_limiteRotativo;
##CMD

CREATE PROCEDURE ADD_T_Cartao_vr_limiteRotativo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'vr_limiteRotativo' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `vr_limiteRotativo` BIGINT;
end if;
select count(*) from T_Cartao where vr_limiteRotativo is null into var_find;
if var_find > 0 then 
update T_Cartao set vr_limiteRotativo = 0 where vr_limiteRotativo is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_vr_limiteRotativo ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_vr_limiteRotativo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_vr_extraCota;
##CMD

CREATE PROCEDURE ADD_T_Cartao_vr_extraCota ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'vr_extraCota' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `vr_extraCota` BIGINT;
end if;
select count(*) from T_Cartao where vr_extraCota is null into var_find;
if var_find > 0 then 
update T_Cartao set vr_extraCota = 0 where vr_extraCota is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_vr_extraCota ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_vr_extraCota;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_vr_educacional;
##CMD

CREATE PROCEDURE ADD_T_Cartao_vr_educacional ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'vr_educacional' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `vr_educacional` BIGINT;
end if;
select count(*) from T_Cartao where vr_educacional is null into var_find;
if var_find > 0 then 
update T_Cartao set vr_educacional = 0 where vr_educacional is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_vr_educacional ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_vr_educacional;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_vr_disp_educacional;
##CMD

CREATE PROCEDURE ADD_T_Cartao_vr_disp_educacional ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'vr_disp_educacional' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `vr_disp_educacional` BIGINT;
end if;
select count(*) from T_Cartao where vr_disp_educacional is null into var_find;
if var_find > 0 then 
update T_Cartao set vr_disp_educacional = 0 where vr_disp_educacional is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_vr_disp_educacional ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_vr_disp_educacional;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_vr_edu_extra;
##CMD
CREATE PROCEDURE DEL_T_Cartao_vr_edu_extra ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'vr_edu_extra' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `vr_edu_extra` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_vr_edu_extra ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_vr_edu_extra;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_vr_disp_edu_extra;
##CMD
CREATE PROCEDURE DEL_T_Cartao_vr_disp_edu_extra ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'vr_disp_edu_extra' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `vr_disp_edu_extra` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_vr_disp_edu_extra ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_vr_disp_edu_extra;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_vr_edu_diario;
##CMD

CREATE PROCEDURE ADD_T_Cartao_vr_edu_diario ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'vr_edu_diario' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `vr_edu_diario` BIGINT;
end if;
select count(*) from T_Cartao where vr_edu_diario is null into var_find;
if var_find > 0 then 
update T_Cartao set vr_edu_diario = 0 where vr_edu_diario is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_vr_edu_diario ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_vr_edu_diario;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_st_aluno;
##CMD

CREATE PROCEDURE ADD_T_Cartao_st_aluno ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_aluno' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `st_aluno` VARCHAR(40);
else
ALTER TABLE `T_Cartao` MODIFY `st_aluno` VARCHAR(40);
end if;
select count(*) from T_Cartao where st_aluno is null into var_find;
if var_find > 0 then 
update T_Cartao set st_aluno = '' where st_aluno is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_st_aluno ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_st_aluno;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_st_senhaEdu;
##CMD
CREATE PROCEDURE DEL_T_Cartao_st_senhaEdu ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'st_senhaEdu' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `st_senhaEdu` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_st_senhaEdu ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_st_senhaEdu;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Cartao_tg_bloqueio;
##CMD
CREATE PROCEDURE DEL_T_Cartao_tg_bloqueio ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'tg_bloqueio' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Cartao` DROP COLUMN `tg_bloqueio` ;
end if;
END;
##CMD

CALL DEL_T_Cartao_tg_bloqueio ( );
##CMD
DROP PROCEDURE  DEL_T_Cartao_tg_bloqueio;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_tg_emitido;
##CMD

CREATE PROCEDURE ADD_T_Cartao_tg_emitido ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'tg_emitido' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `tg_emitido` BIGINT;
end if;
select count(*) from T_Cartao where tg_emitido is null into var_find;
if var_find > 0 then 
update T_Cartao set tg_emitido = 0 where tg_emitido is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_tg_emitido ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_tg_emitido;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_vr_edu_disp_virtual;
##CMD

CREATE PROCEDURE ADD_T_Cartao_vr_edu_disp_virtual ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'vr_edu_disp_virtual' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `vr_edu_disp_virtual` BIGINT;
end if;
select count(*) from T_Cartao where vr_edu_disp_virtual is null into var_find;
if var_find > 0 then 
update T_Cartao set vr_edu_disp_virtual = 0 where vr_edu_disp_virtual is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_vr_edu_disp_virtual ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_vr_edu_disp_virtual;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_nu_rankVirtual;
##CMD

CREATE PROCEDURE ADD_T_Cartao_nu_rankVirtual ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'nu_rankVirtual' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `nu_rankVirtual` BIGINT;
end if;
select count(*) from T_Cartao where nu_rankVirtual is null into var_find;
if var_find > 0 then 
update T_Cartao set nu_rankVirtual = 0 where nu_rankVirtual is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_nu_rankVirtual ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_nu_rankVirtual;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_vr_edu_total_ranking;
##CMD

CREATE PROCEDURE ADD_T_Cartao_vr_edu_total_ranking ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'vr_edu_total_ranking' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `vr_edu_total_ranking` BIGINT;
end if;
select count(*) from T_Cartao where vr_edu_total_ranking is null into var_find;
if var_find > 0 then 
update T_Cartao set vr_edu_total_ranking = 0 where vr_edu_total_ranking is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_vr_edu_total_ranking ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_vr_edu_total_ranking;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_nu_webSenhaErrada;
##CMD

CREATE PROCEDURE ADD_T_Cartao_nu_webSenhaErrada ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'nu_webSenhaErrada' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `nu_webSenhaErrada` BIGINT;
end if;
select count(*) from T_Cartao where nu_webSenhaErrada is null into var_find;
if var_find > 0 then 
update T_Cartao set nu_webSenhaErrada = 0 where nu_webSenhaErrada is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_nu_webSenhaErrada ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_nu_webSenhaErrada;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_tg_semanaCompleta;
##CMD

CREATE PROCEDURE ADD_T_Cartao_tg_semanaCompleta ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'tg_semanaCompleta' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `tg_semanaCompleta` BIGINT;
end if;
select count(*) from T_Cartao where tg_semanaCompleta is null into var_find;
if var_find > 0 then 
update T_Cartao set tg_semanaCompleta = 0 where tg_semanaCompleta is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_tg_semanaCompleta ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_tg_semanaCompleta;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Cartao_tg_excluido;
##CMD

CREATE PROCEDURE ADD_T_Cartao_tg_excluido ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Cartao' and column_name = 'tg_excluido' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Cartao` ADD COLUMN `tg_excluido` BIGINT;
end if;
select count(*) from T_Cartao where tg_excluido is null into var_find;
if var_find > 0 then 
update T_Cartao set tg_excluido = 0 where tg_excluido is null;
end if;
END;
##CMD
CALL ADD_T_Cartao_tg_excluido ( );
##CMD
DROP PROCEDURE  ADD_T_Cartao_tg_excluido;
##CMD


CREATE TABLE IF NOT EXISTS `T_InfoAdicionais` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_codigo` VARCHAR(6),
`st_empresaAfiliada` VARCHAR(30),
`st_presenteado` VARCHAR(50),
`st_recado` VARCHAR(80),
`dt_edu_nasc` DATETIME,
`st_edu_sexo` VARCHAR(1),
`st_edu_grau` VARCHAR(1),
`st_edu_serie_semestre` VARCHAR(2),
`st_edu_turma` VARCHAR(10),
`st_edu_curso` VARCHAR(30),
`dt_edu_atualizacao` DATETIME,
`st_empresa` VARCHAR(6),
`st_matricula` VARCHAR(6),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_InfoAdicionais_fk_cartao;
##CMD
CREATE PROCEDURE DEL_T_InfoAdicionais_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'fk_cartao' into var_find;
if var_find = 1 then 
ALTER TABLE `T_InfoAdicionais` DROP COLUMN `fk_cartao` ;
end if;
END;
##CMD

CALL DEL_T_InfoAdicionais_fk_cartao ( );
##CMD
DROP PROCEDURE  DEL_T_InfoAdicionais_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_st_codigo;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_st_codigo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_codigo' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `st_codigo` VARCHAR(6);
else
ALTER TABLE `T_InfoAdicionais` MODIFY `st_codigo` VARCHAR(6);
end if;
select count(*) from T_InfoAdicionais where st_codigo is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set st_codigo = '' where st_codigo is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_st_codigo ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_st_codigo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_st_empresaAfiliada;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_st_empresaAfiliada ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_empresaAfiliada' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `st_empresaAfiliada` VARCHAR(30);
else
ALTER TABLE `T_InfoAdicionais` MODIFY `st_empresaAfiliada` VARCHAR(30);
end if;
select count(*) from T_InfoAdicionais where st_empresaAfiliada is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set st_empresaAfiliada = '' where st_empresaAfiliada is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_st_empresaAfiliada ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_st_empresaAfiliada;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_InfoAdicionais_fk_comoSoube;
##CMD
CREATE PROCEDURE DEL_T_InfoAdicionais_fk_comoSoube ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'fk_comoSoube' into var_find;
if var_find = 1 then 
ALTER TABLE `T_InfoAdicionais` DROP COLUMN `fk_comoSoube` ;
end if;
END;
##CMD

CALL DEL_T_InfoAdicionais_fk_comoSoube ( );
##CMD
DROP PROCEDURE  DEL_T_InfoAdicionais_fk_comoSoube;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_InfoAdicionais_fk_timeRS;
##CMD
CREATE PROCEDURE DEL_T_InfoAdicionais_fk_timeRS ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'fk_timeRS' into var_find;
if var_find = 1 then 
ALTER TABLE `T_InfoAdicionais` DROP COLUMN `fk_timeRS` ;
end if;
END;
##CMD

CALL DEL_T_InfoAdicionais_fk_timeRS ( );
##CMD
DROP PROCEDURE  DEL_T_InfoAdicionais_fk_timeRS;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_st_presenteado;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_st_presenteado ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_presenteado' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `st_presenteado` VARCHAR(50);
else
ALTER TABLE `T_InfoAdicionais` MODIFY `st_presenteado` VARCHAR(50);
end if;
select count(*) from T_InfoAdicionais where st_presenteado is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set st_presenteado = '' where st_presenteado is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_st_presenteado ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_st_presenteado;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_st_recado;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_st_recado ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_recado' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `st_recado` VARCHAR(80);
else
ALTER TABLE `T_InfoAdicionais` MODIFY `st_recado` VARCHAR(80);
end if;
select count(*) from T_InfoAdicionais where st_recado is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set st_recado = '' where st_recado is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_st_recado ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_st_recado;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_InfoAdicionais_st_edu_cod_aluno;
##CMD
CREATE PROCEDURE DEL_T_InfoAdicionais_st_edu_cod_aluno ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_edu_cod_aluno' into var_find;
if var_find = 1 then 
ALTER TABLE `T_InfoAdicionais` DROP COLUMN `st_edu_cod_aluno` ;
end if;
END;
##CMD

CALL DEL_T_InfoAdicionais_st_edu_cod_aluno ( );
##CMD
DROP PROCEDURE  DEL_T_InfoAdicionais_st_edu_cod_aluno;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_dt_edu_nasc;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_dt_edu_nasc ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'dt_edu_nasc' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `dt_edu_nasc` DATETIME;
end if;
select count(*) from T_InfoAdicionais where dt_edu_nasc is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set dt_edu_nasc = '1900-01-01 00:00:00.000' where dt_edu_nasc is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_dt_edu_nasc ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_dt_edu_nasc;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_st_edu_sexo;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_st_edu_sexo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_edu_sexo' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `st_edu_sexo` VARCHAR(1);
else
ALTER TABLE `T_InfoAdicionais` MODIFY `st_edu_sexo` VARCHAR(1);
end if;
select count(*) from T_InfoAdicionais where st_edu_sexo is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set st_edu_sexo = '' where st_edu_sexo is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_st_edu_sexo ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_st_edu_sexo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_st_edu_grau;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_st_edu_grau ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_edu_grau' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `st_edu_grau` VARCHAR(1);
else
ALTER TABLE `T_InfoAdicionais` MODIFY `st_edu_grau` VARCHAR(1);
end if;
select count(*) from T_InfoAdicionais where st_edu_grau is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set st_edu_grau = '' where st_edu_grau is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_st_edu_grau ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_st_edu_grau;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_st_edu_serie_semestre;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_st_edu_serie_semestre ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_edu_serie_semestre' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `st_edu_serie_semestre` VARCHAR(2);
else
ALTER TABLE `T_InfoAdicionais` MODIFY `st_edu_serie_semestre` VARCHAR(2);
end if;
select count(*) from T_InfoAdicionais where st_edu_serie_semestre is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set st_edu_serie_semestre = '' where st_edu_serie_semestre is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_st_edu_serie_semestre ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_st_edu_serie_semestre;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_st_edu_turma;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_st_edu_turma ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_edu_turma' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `st_edu_turma` VARCHAR(10);
else
ALTER TABLE `T_InfoAdicionais` MODIFY `st_edu_turma` VARCHAR(10);
end if;
select count(*) from T_InfoAdicionais where st_edu_turma is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set st_edu_turma = '' where st_edu_turma is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_st_edu_turma ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_st_edu_turma;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_st_edu_curso;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_st_edu_curso ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_edu_curso' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `st_edu_curso` VARCHAR(30);
else
ALTER TABLE `T_InfoAdicionais` MODIFY `st_edu_curso` VARCHAR(30);
end if;
select count(*) from T_InfoAdicionais where st_edu_curso is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set st_edu_curso = '' where st_edu_curso is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_st_edu_curso ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_st_edu_curso;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_dt_edu_atualizacao;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_dt_edu_atualizacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'dt_edu_atualizacao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `dt_edu_atualizacao` DATETIME;
end if;
select count(*) from T_InfoAdicionais where dt_edu_atualizacao is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set dt_edu_atualizacao = '1900-01-01 00:00:00.000' where dt_edu_atualizacao is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_dt_edu_atualizacao ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_dt_edu_atualizacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_st_empresa;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_st_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `st_empresa` VARCHAR(6);
else
ALTER TABLE `T_InfoAdicionais` MODIFY `st_empresa` VARCHAR(6);
end if;
select count(*) from T_InfoAdicionais where st_empresa is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set st_empresa = '' where st_empresa is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_st_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_st_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_InfoAdicionais_st_matricula;
##CMD

CREATE PROCEDURE ADD_T_InfoAdicionais_st_matricula ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_InfoAdicionais' and column_name = 'st_matricula' into var_find;
if var_find = 0 then 
ALTER TABLE `T_InfoAdicionais` ADD COLUMN `st_matricula` VARCHAR(6);
else
ALTER TABLE `T_InfoAdicionais` MODIFY `st_matricula` VARCHAR(6);
end if;
select count(*) from T_InfoAdicionais where st_matricula is null into var_find;
if var_find > 0 then 
update T_InfoAdicionais set st_matricula = '' where st_matricula is null;
end if;
END;
##CMD
CALL ADD_T_InfoAdicionais_st_matricula ( );
##CMD
DROP PROCEDURE  ADD_T_InfoAdicionais_st_matricula;
##CMD


CREATE TABLE IF NOT EXISTS `T_Proprietario` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_cpf` VARCHAR(20),
`st_nome` VARCHAR(99),
`st_endereco` VARCHAR(900),
`st_numero` VARCHAR(29),
`st_complemento` VARCHAR(29),
`st_bairro` VARCHAR(99),
`st_cidade` VARCHAR(99),
`st_UF` VARCHAR(2),
`st_cep` VARCHAR(20),
`st_ddd` VARCHAR(3),
`st_telefone` VARCHAR(20),
`dt_nasc` DATETIME,
`st_email` VARCHAR(199),
`vr_renda` BIGINT UNSIGNED,
`st_senhaEdu` VARCHAR(16),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_cpf;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_cpf ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_cpf' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_cpf` VARCHAR(20);
else
ALTER TABLE `T_Proprietario` MODIFY `st_cpf` VARCHAR(20);
end if;
select count(*) from T_Proprietario where st_cpf is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_cpf = '' where st_cpf is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_cpf ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_cpf;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_nome;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_nome ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_nome' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_nome` VARCHAR(99);
else
ALTER TABLE `T_Proprietario` MODIFY `st_nome` VARCHAR(99);
end if;
select count(*) from T_Proprietario where st_nome is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_nome = '' where st_nome is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_nome ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_nome;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_endereco;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_endereco ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_endereco' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_endereco` VARCHAR(900);
else
ALTER TABLE `T_Proprietario` MODIFY `st_endereco` VARCHAR(900);
end if;
select count(*) from T_Proprietario where st_endereco is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_endereco = '' where st_endereco is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_endereco ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_endereco;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_numero;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_numero ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_numero' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_numero` VARCHAR(29);
else
ALTER TABLE `T_Proprietario` MODIFY `st_numero` VARCHAR(29);
end if;
select count(*) from T_Proprietario where st_numero is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_numero = '' where st_numero is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_numero ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_numero;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_complemento;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_complemento ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_complemento' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_complemento` VARCHAR(29);
else
ALTER TABLE `T_Proprietario` MODIFY `st_complemento` VARCHAR(29);
end if;
select count(*) from T_Proprietario where st_complemento is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_complemento = '' where st_complemento is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_complemento ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_complemento;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_bairro;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_bairro ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_bairro' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_bairro` VARCHAR(99);
else
ALTER TABLE `T_Proprietario` MODIFY `st_bairro` VARCHAR(99);
end if;
select count(*) from T_Proprietario where st_bairro is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_bairro = '' where st_bairro is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_bairro ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_bairro;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_cidade;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_cidade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_cidade' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_cidade` VARCHAR(99);
else
ALTER TABLE `T_Proprietario` MODIFY `st_cidade` VARCHAR(99);
end if;
select count(*) from T_Proprietario where st_cidade is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_cidade = '' where st_cidade is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_cidade ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_cidade;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_UF;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_UF ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_UF' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_UF` VARCHAR(2);
else
ALTER TABLE `T_Proprietario` MODIFY `st_UF` VARCHAR(2);
end if;
select count(*) from T_Proprietario where st_UF is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_UF = '' where st_UF is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_UF ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_UF;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_cep;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_cep ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_cep' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_cep` VARCHAR(20);
else
ALTER TABLE `T_Proprietario` MODIFY `st_cep` VARCHAR(20);
end if;
select count(*) from T_Proprietario where st_cep is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_cep = '' where st_cep is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_cep ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_cep;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_ddd;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_ddd ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_ddd' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_ddd` VARCHAR(3);
else
ALTER TABLE `T_Proprietario` MODIFY `st_ddd` VARCHAR(3);
end if;
select count(*) from T_Proprietario where st_ddd is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_ddd = '' where st_ddd is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_ddd ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_ddd;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_telefone;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_telefone ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_telefone' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_telefone` VARCHAR(20);
else
ALTER TABLE `T_Proprietario` MODIFY `st_telefone` VARCHAR(20);
end if;
select count(*) from T_Proprietario where st_telefone is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_telefone = '' where st_telefone is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_telefone ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_telefone;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_dt_nasc;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_dt_nasc ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'dt_nasc' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `dt_nasc` DATETIME;
end if;
select count(*) from T_Proprietario where dt_nasc is null into var_find;
if var_find > 0 then 
update T_Proprietario set dt_nasc = '1900-01-01 00:00:00.000' where dt_nasc is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_dt_nasc ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_dt_nasc;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_email;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_email ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_email' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_email` VARCHAR(199);
else
ALTER TABLE `T_Proprietario` MODIFY `st_email` VARCHAR(199);
end if;
select count(*) from T_Proprietario where st_email is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_email = '' where st_email is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_email ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_email;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Proprietario_fk_profissao;
##CMD
CREATE PROCEDURE DEL_T_Proprietario_fk_profissao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'fk_profissao' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Proprietario` DROP COLUMN `fk_profissao` ;
end if;
END;
##CMD

CALL DEL_T_Proprietario_fk_profissao ( );
##CMD
DROP PROCEDURE  DEL_T_Proprietario_fk_profissao;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Proprietario_nu_renda;
##CMD
CREATE PROCEDURE DEL_T_Proprietario_nu_renda ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'nu_renda' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Proprietario` DROP COLUMN `nu_renda` ;
end if;
END;
##CMD

CALL DEL_T_Proprietario_nu_renda ( );
##CMD
DROP PROCEDURE  DEL_T_Proprietario_nu_renda;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_vr_renda;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_vr_renda ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'vr_renda' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `vr_renda` BIGINT;
end if;
select count(*) from T_Proprietario where vr_renda is null into var_find;
if var_find > 0 then 
update T_Proprietario set vr_renda = 0 where vr_renda is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_vr_renda ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_vr_renda;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Proprietario_id_instrucao;
##CMD
CREATE PROCEDURE DEL_T_Proprietario_id_instrucao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'id_instrucao' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Proprietario` DROP COLUMN `id_instrucao` ;
end if;
END;
##CMD

CALL DEL_T_Proprietario_id_instrucao ( );
##CMD
DROP PROCEDURE  DEL_T_Proprietario_id_instrucao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Proprietario_st_senhaEdu;
##CMD

CREATE PROCEDURE ADD_T_Proprietario_st_senhaEdu ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Proprietario' and column_name = 'st_senhaEdu' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Proprietario` ADD COLUMN `st_senhaEdu` VARCHAR(16);
else
ALTER TABLE `T_Proprietario` MODIFY `st_senhaEdu` VARCHAR(16);
end if;
select count(*) from T_Proprietario where st_senhaEdu is null into var_find;
if var_find > 0 then 
update T_Proprietario set st_senhaEdu = '' where st_senhaEdu is null;
end if;
END;
##CMD
CALL ADD_T_Proprietario_st_senhaEdu ( );
##CMD
DROP PROCEDURE  ADD_T_Proprietario_st_senhaEdu;
##CMD


CREATE TABLE IF NOT EXISTS `T_Dependente` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`nu_titularidade` BIGINT UNSIGNED,
`st_nome` VARCHAR(40),
`fk_proprietario` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Dependente_nu_titularidade;
##CMD

CREATE PROCEDURE ADD_T_Dependente_nu_titularidade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Dependente' and column_name = 'nu_titularidade' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Dependente` ADD COLUMN `nu_titularidade` BIGINT;
end if;
select count(*) from T_Dependente where nu_titularidade is null into var_find;
if var_find > 0 then 
update T_Dependente set nu_titularidade = 0 where nu_titularidade is null;
end if;
END;
##CMD
CALL ADD_T_Dependente_nu_titularidade ( );
##CMD
DROP PROCEDURE  ADD_T_Dependente_nu_titularidade;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Dependente_st_nome;
##CMD

CREATE PROCEDURE ADD_T_Dependente_st_nome ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Dependente' and column_name = 'st_nome' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Dependente` ADD COLUMN `st_nome` VARCHAR(40);
else
ALTER TABLE `T_Dependente` MODIFY `st_nome` VARCHAR(40);
end if;
select count(*) from T_Dependente where st_nome is null into var_find;
if var_find > 0 then 
update T_Dependente set st_nome = '' where st_nome is null;
end if;
END;
##CMD
CALL ADD_T_Dependente_st_nome ( );
##CMD
DROP PROCEDURE  ADD_T_Dependente_st_nome;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Dependente_st_empresa;
##CMD
CREATE PROCEDURE DEL_T_Dependente_st_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Dependente' and column_name = 'st_empresa' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Dependente` DROP COLUMN `st_empresa` ;
end if;
END;
##CMD

CALL DEL_T_Dependente_st_empresa ( );
##CMD
DROP PROCEDURE  DEL_T_Dependente_st_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Dependente_fk_proprietario;
##CMD

CREATE PROCEDURE ADD_T_Dependente_fk_proprietario ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Dependente' and column_name = 'fk_proprietario' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Dependente` ADD COLUMN `fk_proprietario` BIGINT;
end if;
select count(*) from T_Dependente where fk_proprietario is null into var_find;
if var_find > 0 then 
update T_Dependente set fk_proprietario = 0 where fk_proprietario is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Dependente' and column_name = 'fk_proprietario' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Dependente` ADD INDEX `index_fk_proprietario`(fk_proprietario);
end if;
END;
##CMD
CALL ADD_T_Dependente_fk_proprietario ( );
##CMD
DROP PROCEDURE  ADD_T_Dependente_fk_proprietario;
##CMD


CREATE TABLE IF NOT EXISTS `LINK_ProprietarioCartao` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_cartao` BIGINT UNSIGNED,
`fk_proprietario` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_ProprietarioCartao_fk_cartao;
##CMD

CREATE PROCEDURE ADD_LINK_ProprietarioCartao_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_ProprietarioCartao' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_ProprietarioCartao` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from LINK_ProprietarioCartao where fk_cartao is null into var_find;
if var_find > 0 then 
update LINK_ProprietarioCartao set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_ProprietarioCartao' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_ProprietarioCartao` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_LINK_ProprietarioCartao_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_LINK_ProprietarioCartao_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_ProprietarioCartao_fk_proprietario;
##CMD

CREATE PROCEDURE ADD_LINK_ProprietarioCartao_fk_proprietario ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_ProprietarioCartao' and column_name = 'fk_proprietario' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_ProprietarioCartao` ADD COLUMN `fk_proprietario` BIGINT;
end if;
select count(*) from LINK_ProprietarioCartao where fk_proprietario is null into var_find;
if var_find > 0 then 
update LINK_ProprietarioCartao set fk_proprietario = 0 where fk_proprietario is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_ProprietarioCartao' and column_name = 'fk_proprietario' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_ProprietarioCartao` ADD INDEX `index_fk_proprietario`(fk_proprietario);
end if;
END;
##CMD
CALL ADD_LINK_ProprietarioCartao_fk_proprietario ( );
##CMD
DROP PROCEDURE  ADD_LINK_ProprietarioCartao_fk_proprietario;
##CMD


CREATE TABLE IF NOT EXISTS `T_Usuario` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`tg_nivel` VARCHAR(1),
`tg_logoff` VARCHAR(1),
`dt_trocaSenha` DATETIME,
`dt_ultUso` DATETIME,
`nu_senhaErrada` BIGINT UNSIGNED,
`tg_trocaSenha` VARCHAR(1),
`st_senha_1` VARCHAR(64),
`st_senha_2` VARCHAR(64),
`st_senha_3` VARCHAR(64),
`st_senha_4` VARCHAR(64),
`st_senha_5` VARCHAR(64),
`st_empresa` VARCHAR(6),
`st_senha` VARCHAR(64),
`tg_bloqueio` VARCHAR(1),
`st_nome` VARCHAR(20),
`fk_quiosque` BIGINT UNSIGNED,
`tg_aviso` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Usuario_st_name;
##CMD
CREATE PROCEDURE DEL_T_Usuario_st_name ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'st_name' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Usuario` DROP COLUMN `st_name` ;
end if;
END;
##CMD

CALL DEL_T_Usuario_st_name ( );
##CMD
DROP PROCEDURE  DEL_T_Usuario_st_name;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Usuario_st_pass;
##CMD
CREATE PROCEDURE DEL_T_Usuario_st_pass ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'st_pass' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Usuario` DROP COLUMN `st_pass` ;
end if;
END;
##CMD

CALL DEL_T_Usuario_st_pass ( );
##CMD
DROP PROCEDURE  DEL_T_Usuario_st_pass;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_tg_nivel;
##CMD

CREATE PROCEDURE ADD_T_Usuario_tg_nivel ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'tg_nivel' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `tg_nivel` VARCHAR(1);
else
ALTER TABLE `T_Usuario` MODIFY `tg_nivel` VARCHAR(1);
end if;
select count(*) from T_Usuario where tg_nivel is null into var_find;
if var_find > 0 then 
update T_Usuario set tg_nivel = '' where tg_nivel is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_tg_nivel ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_tg_nivel;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_tg_logoff;
##CMD

CREATE PROCEDURE ADD_T_Usuario_tg_logoff ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'tg_logoff' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `tg_logoff` VARCHAR(1);
else
ALTER TABLE `T_Usuario` MODIFY `tg_logoff` VARCHAR(1);
end if;
select count(*) from T_Usuario where tg_logoff is null into var_find;
if var_find > 0 then 
update T_Usuario set tg_logoff = '' where tg_logoff is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_tg_logoff ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_tg_logoff;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_dt_trocaSenha;
##CMD

CREATE PROCEDURE ADD_T_Usuario_dt_trocaSenha ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'dt_trocaSenha' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `dt_trocaSenha` DATETIME;
end if;
select count(*) from T_Usuario where dt_trocaSenha is null into var_find;
if var_find > 0 then 
update T_Usuario set dt_trocaSenha = '1900-01-01 00:00:00.000' where dt_trocaSenha is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_dt_trocaSenha ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_dt_trocaSenha;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_dt_ultUso;
##CMD

CREATE PROCEDURE ADD_T_Usuario_dt_ultUso ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'dt_ultUso' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `dt_ultUso` DATETIME;
end if;
select count(*) from T_Usuario where dt_ultUso is null into var_find;
if var_find > 0 then 
update T_Usuario set dt_ultUso = '1900-01-01 00:00:00.000' where dt_ultUso is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_dt_ultUso ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_dt_ultUso;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_nu_senhaErrada;
##CMD

CREATE PROCEDURE ADD_T_Usuario_nu_senhaErrada ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'nu_senhaErrada' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `nu_senhaErrada` BIGINT;
end if;
select count(*) from T_Usuario where nu_senhaErrada is null into var_find;
if var_find > 0 then 
update T_Usuario set nu_senhaErrada = 0 where nu_senhaErrada is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_nu_senhaErrada ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_nu_senhaErrada;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_tg_trocaSenha;
##CMD

CREATE PROCEDURE ADD_T_Usuario_tg_trocaSenha ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'tg_trocaSenha' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `tg_trocaSenha` VARCHAR(1);
else
ALTER TABLE `T_Usuario` MODIFY `tg_trocaSenha` VARCHAR(1);
end if;
select count(*) from T_Usuario where tg_trocaSenha is null into var_find;
if var_find > 0 then 
update T_Usuario set tg_trocaSenha = '' where tg_trocaSenha is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_tg_trocaSenha ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_tg_trocaSenha;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_st_senha_1;
##CMD

CREATE PROCEDURE ADD_T_Usuario_st_senha_1 ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'st_senha_1' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `st_senha_1` VARCHAR(64);
else
ALTER TABLE `T_Usuario` MODIFY `st_senha_1` VARCHAR(64);
end if;
select count(*) from T_Usuario where st_senha_1 is null into var_find;
if var_find > 0 then 
update T_Usuario set st_senha_1 = '' where st_senha_1 is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_st_senha_1 ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_st_senha_1;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_st_senha_2;
##CMD

CREATE PROCEDURE ADD_T_Usuario_st_senha_2 ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'st_senha_2' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `st_senha_2` VARCHAR(64);
else
ALTER TABLE `T_Usuario` MODIFY `st_senha_2` VARCHAR(64);
end if;
select count(*) from T_Usuario where st_senha_2 is null into var_find;
if var_find > 0 then 
update T_Usuario set st_senha_2 = '' where st_senha_2 is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_st_senha_2 ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_st_senha_2;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_st_senha_3;
##CMD

CREATE PROCEDURE ADD_T_Usuario_st_senha_3 ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'st_senha_3' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `st_senha_3` VARCHAR(64);
else
ALTER TABLE `T_Usuario` MODIFY `st_senha_3` VARCHAR(64);
end if;
select count(*) from T_Usuario where st_senha_3 is null into var_find;
if var_find > 0 then 
update T_Usuario set st_senha_3 = '' where st_senha_3 is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_st_senha_3 ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_st_senha_3;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_st_senha_4;
##CMD

CREATE PROCEDURE ADD_T_Usuario_st_senha_4 ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'st_senha_4' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `st_senha_4` VARCHAR(64);
else
ALTER TABLE `T_Usuario` MODIFY `st_senha_4` VARCHAR(64);
end if;
select count(*) from T_Usuario where st_senha_4 is null into var_find;
if var_find > 0 then 
update T_Usuario set st_senha_4 = '' where st_senha_4 is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_st_senha_4 ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_st_senha_4;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_st_senha_5;
##CMD

CREATE PROCEDURE ADD_T_Usuario_st_senha_5 ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'st_senha_5' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `st_senha_5` VARCHAR(64);
else
ALTER TABLE `T_Usuario` MODIFY `st_senha_5` VARCHAR(64);
end if;
select count(*) from T_Usuario where st_senha_5 is null into var_find;
if var_find > 0 then 
update T_Usuario set st_senha_5 = '' where st_senha_5 is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_st_senha_5 ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_st_senha_5;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_st_empresa;
##CMD

CREATE PROCEDURE ADD_T_Usuario_st_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'st_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `st_empresa` VARCHAR(6);
else
ALTER TABLE `T_Usuario` MODIFY `st_empresa` VARCHAR(6);
end if;
select count(*) from T_Usuario where st_empresa is null into var_find;
if var_find > 0 then 
update T_Usuario set st_empresa = '' where st_empresa is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_st_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_st_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_st_senha;
##CMD

CREATE PROCEDURE ADD_T_Usuario_st_senha ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'st_senha' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `st_senha` VARCHAR(64);
else
ALTER TABLE `T_Usuario` MODIFY `st_senha` VARCHAR(64);
end if;
select count(*) from T_Usuario where st_senha is null into var_find;
if var_find > 0 then 
update T_Usuario set st_senha = '' where st_senha is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_st_senha ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_st_senha;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_tg_bloqueio;
##CMD

CREATE PROCEDURE ADD_T_Usuario_tg_bloqueio ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'tg_bloqueio' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `tg_bloqueio` VARCHAR(1);
else
ALTER TABLE `T_Usuario` MODIFY `tg_bloqueio` VARCHAR(1);
end if;
select count(*) from T_Usuario where tg_bloqueio is null into var_find;
if var_find > 0 then 
update T_Usuario set tg_bloqueio = '' where tg_bloqueio is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_tg_bloqueio ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_tg_bloqueio;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_st_nome;
##CMD

CREATE PROCEDURE ADD_T_Usuario_st_nome ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'st_nome' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `st_nome` VARCHAR(20);
else
ALTER TABLE `T_Usuario` MODIFY `st_nome` VARCHAR(20);
end if;
select count(*) from T_Usuario where st_nome is null into var_find;
if var_find > 0 then 
update T_Usuario set st_nome = '' where st_nome is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_st_nome ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_st_nome;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_fk_quiosque;
##CMD

CREATE PROCEDURE ADD_T_Usuario_fk_quiosque ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'fk_quiosque' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `fk_quiosque` BIGINT;
end if;
select count(*) from T_Usuario where fk_quiosque is null into var_find;
if var_find > 0 then 
update T_Usuario set fk_quiosque = 0 where fk_quiosque is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'fk_quiosque' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD INDEX `index_fk_quiosque`(fk_quiosque);
end if;
END;
##CMD
CALL ADD_T_Usuario_fk_quiosque ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_fk_quiosque;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Usuario_tg_aviso;
##CMD

CREATE PROCEDURE ADD_T_Usuario_tg_aviso ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Usuario' and column_name = 'tg_aviso' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Usuario` ADD COLUMN `tg_aviso` BIGINT;
end if;
select count(*) from T_Usuario where tg_aviso is null into var_find;
if var_find > 0 then 
update T_Usuario set tg_aviso = 0 where tg_aviso is null;
end if;
END;
##CMD
CALL ADD_T_Usuario_tg_aviso ( );
##CMD
DROP PROCEDURE  ADD_T_Usuario_tg_aviso;
##CMD


CREATE TABLE IF NOT EXISTS `LINK_LojaEmpresa` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_loja` BIGINT UNSIGNED,
`fk_empresa` BIGINT UNSIGNED,
`tx_admin` BIGINT UNSIGNED,
`nu_dias_repasse` BIGINT UNSIGNED,
`st_ag` VARCHAR(10),
`st_conta` VARCHAR(15),
`st_banco` VARCHAR(15),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_LojaEmpresa_fk_loja;
##CMD

CREATE PROCEDURE ADD_LINK_LojaEmpresa_fk_loja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'fk_loja' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_LojaEmpresa` ADD COLUMN `fk_loja` BIGINT;
end if;
select count(*) from LINK_LojaEmpresa where fk_loja is null into var_find;
if var_find > 0 then 
update LINK_LojaEmpresa set fk_loja = 0 where fk_loja is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'fk_loja' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_LojaEmpresa` ADD INDEX `index_fk_loja`(fk_loja);
end if;
END;
##CMD
CALL ADD_LINK_LojaEmpresa_fk_loja ( );
##CMD
DROP PROCEDURE  ADD_LINK_LojaEmpresa_fk_loja;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_LojaEmpresa_fk_empresa;
##CMD

CREATE PROCEDURE ADD_LINK_LojaEmpresa_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_LojaEmpresa` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from LINK_LojaEmpresa where fk_empresa is null into var_find;
if var_find > 0 then 
update LINK_LojaEmpresa set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_LojaEmpresa` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_LINK_LojaEmpresa_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_LINK_LojaEmpresa_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_LojaEmpresa_tx_admin;
##CMD

CREATE PROCEDURE ADD_LINK_LojaEmpresa_tx_admin ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'tx_admin' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_LojaEmpresa` ADD COLUMN `tx_admin` BIGINT;
end if;
select count(*) from LINK_LojaEmpresa where tx_admin is null into var_find;
if var_find > 0 then 
update LINK_LojaEmpresa set tx_admin = 0 where tx_admin is null;
end if;
END;
##CMD
CALL ADD_LINK_LojaEmpresa_tx_admin ( );
##CMD
DROP PROCEDURE  ADD_LINK_LojaEmpresa_tx_admin;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_LojaEmpresa_nu_dias_repasse;
##CMD

CREATE PROCEDURE ADD_LINK_LojaEmpresa_nu_dias_repasse ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'nu_dias_repasse' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_LojaEmpresa` ADD COLUMN `nu_dias_repasse` BIGINT;
end if;
select count(*) from LINK_LojaEmpresa where nu_dias_repasse is null into var_find;
if var_find > 0 then 
update LINK_LojaEmpresa set nu_dias_repasse = 0 where nu_dias_repasse is null;
end if;
END;
##CMD
CALL ADD_LINK_LojaEmpresa_nu_dias_repasse ( );
##CMD
DROP PROCEDURE  ADD_LINK_LojaEmpresa_nu_dias_repasse;
##CMD

DROP PROCEDURE IF EXISTS DEL_LINK_LojaEmpresa_nu_ag;
##CMD
CREATE PROCEDURE DEL_LINK_LojaEmpresa_nu_ag ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'nu_ag' into var_find;
if var_find = 1 then 
ALTER TABLE `LINK_LojaEmpresa` DROP COLUMN `nu_ag` ;
end if;
END;
##CMD

CALL DEL_LINK_LojaEmpresa_nu_ag ( );
##CMD
DROP PROCEDURE  DEL_LINK_LojaEmpresa_nu_ag;
##CMD

DROP PROCEDURE IF EXISTS DEL_LINK_LojaEmpresa_nu_banco;
##CMD
CREATE PROCEDURE DEL_LINK_LojaEmpresa_nu_banco ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'nu_banco' into var_find;
if var_find = 1 then 
ALTER TABLE `LINK_LojaEmpresa` DROP COLUMN `nu_banco` ;
end if;
END;
##CMD

CALL DEL_LINK_LojaEmpresa_nu_banco ( );
##CMD
DROP PROCEDURE  DEL_LINK_LojaEmpresa_nu_banco;
##CMD

DROP PROCEDURE IF EXISTS DEL_LINK_LojaEmpresa_nu_conta;
##CMD
CREATE PROCEDURE DEL_LINK_LojaEmpresa_nu_conta ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'nu_conta' into var_find;
if var_find = 1 then 
ALTER TABLE `LINK_LojaEmpresa` DROP COLUMN `nu_conta` ;
end if;
END;
##CMD

CALL DEL_LINK_LojaEmpresa_nu_conta ( );
##CMD
DROP PROCEDURE  DEL_LINK_LojaEmpresa_nu_conta;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_LojaEmpresa_st_ag;
##CMD

CREATE PROCEDURE ADD_LINK_LojaEmpresa_st_ag ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'st_ag' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_LojaEmpresa` ADD COLUMN `st_ag` VARCHAR(10);
else
ALTER TABLE `LINK_LojaEmpresa` MODIFY `st_ag` VARCHAR(10);
end if;
select count(*) from LINK_LojaEmpresa where st_ag is null into var_find;
if var_find > 0 then 
update LINK_LojaEmpresa set st_ag = '' where st_ag is null;
end if;
END;
##CMD
CALL ADD_LINK_LojaEmpresa_st_ag ( );
##CMD
DROP PROCEDURE  ADD_LINK_LojaEmpresa_st_ag;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_LojaEmpresa_st_conta;
##CMD

CREATE PROCEDURE ADD_LINK_LojaEmpresa_st_conta ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'st_conta' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_LojaEmpresa` ADD COLUMN `st_conta` VARCHAR(15);
else
ALTER TABLE `LINK_LojaEmpresa` MODIFY `st_conta` VARCHAR(15);
end if;
select count(*) from LINK_LojaEmpresa where st_conta is null into var_find;
if var_find > 0 then 
update LINK_LojaEmpresa set st_conta = '' where st_conta is null;
end if;
END;
##CMD
CALL ADD_LINK_LojaEmpresa_st_conta ( );
##CMD
DROP PROCEDURE  ADD_LINK_LojaEmpresa_st_conta;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_LojaEmpresa_st_banco;
##CMD

CREATE PROCEDURE ADD_LINK_LojaEmpresa_st_banco ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_LojaEmpresa' and column_name = 'st_banco' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_LojaEmpresa` ADD COLUMN `st_banco` VARCHAR(15);
else
ALTER TABLE `LINK_LojaEmpresa` MODIFY `st_banco` VARCHAR(15);
end if;
select count(*) from LINK_LojaEmpresa where st_banco is null into var_find;
if var_find > 0 then 
update LINK_LojaEmpresa set st_banco = '' where st_banco is null;
end if;
END;
##CMD
CALL ADD_LINK_LojaEmpresa_st_banco ( );
##CMD
DROP PROCEDURE  ADD_LINK_LojaEmpresa_st_banco;
##CMD


CREATE TABLE IF NOT EXISTS `T_Loja` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`nu_CNPJ` VARCHAR(14),
`st_nome` VARCHAR(99),
`st_social` VARCHAR(99),
`st_endereco` VARCHAR(199),
`st_enderecoInst` VARCHAR(199),
`nu_inscEst` VARCHAR(20),
`st_cidade` VARCHAR(99),
`st_estado` VARCHAR(2),
`nu_CEP` VARCHAR(18),
`nu_telefone` VARCHAR(20),
`nu_fax` VARCHAR(20),
`st_contato` VARCHAR(40),
`vr_mensalidade` BIGINT UNSIGNED,
`nu_contaDeb` VARCHAR(20),
`st_obs` VARCHAR(900),
`st_loja` VARCHAR(40),
`tg_blocked` VARCHAR(1),
`nu_pctValor` BIGINT UNSIGNED,
`vr_transacao` BIGINT UNSIGNED,
`vr_minimo` BIGINT UNSIGNED,
`nu_franquia` BIGINT UNSIGNED,
`nu_periodoFat` BIGINT UNSIGNED,
`nu_diavenc` BIGINT UNSIGNED,
`tg_tipoCobranca` VARCHAR(1),
`nu_bancoFat` BIGINT UNSIGNED,
`tg_isentoFat` BIGINT UNSIGNED,
`st_senha` VARCHAR(16),
`tg_cancel` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Loja_st_empresa;
##CMD
CREATE PROCEDURE DEL_T_Loja_st_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_empresa' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Loja` DROP COLUMN `st_empresa` ;
end if;
END;
##CMD

CALL DEL_T_Loja_st_empresa ( );
##CMD
DROP PROCEDURE  DEL_T_Loja_st_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_nu_CNPJ;
##CMD

CREATE PROCEDURE ADD_T_Loja_nu_CNPJ ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_CNPJ' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `nu_CNPJ` VARCHAR(14);
else
ALTER TABLE `T_Loja` MODIFY `nu_CNPJ` VARCHAR(14);
end if;
select count(*) from T_Loja where nu_CNPJ is null into var_find;
if var_find > 0 then 
update T_Loja set nu_CNPJ = '' where nu_CNPJ is null;
end if;
END;
##CMD
CALL ADD_T_Loja_nu_CNPJ ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_nu_CNPJ;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_st_nome;
##CMD

CREATE PROCEDURE ADD_T_Loja_st_nome ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_nome' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `st_nome` VARCHAR(99);
else
ALTER TABLE `T_Loja` MODIFY `st_nome` VARCHAR(99);
end if;
select count(*) from T_Loja where st_nome is null into var_find;
if var_find > 0 then 
update T_Loja set st_nome = '' where st_nome is null;
end if;
END;
##CMD
CALL ADD_T_Loja_st_nome ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_st_nome;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_st_social;
##CMD

CREATE PROCEDURE ADD_T_Loja_st_social ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_social' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `st_social` VARCHAR(99);
else
ALTER TABLE `T_Loja` MODIFY `st_social` VARCHAR(99);
end if;
select count(*) from T_Loja where st_social is null into var_find;
if var_find > 0 then 
update T_Loja set st_social = '' where st_social is null;
end if;
END;
##CMD
CALL ADD_T_Loja_st_social ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_st_social;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_st_endereco;
##CMD

CREATE PROCEDURE ADD_T_Loja_st_endereco ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_endereco' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `st_endereco` VARCHAR(199);
else
ALTER TABLE `T_Loja` MODIFY `st_endereco` VARCHAR(199);
end if;
select count(*) from T_Loja where st_endereco is null into var_find;
if var_find > 0 then 
update T_Loja set st_endereco = '' where st_endereco is null;
end if;
END;
##CMD
CALL ADD_T_Loja_st_endereco ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_st_endereco;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_st_enderecoInst;
##CMD

CREATE PROCEDURE ADD_T_Loja_st_enderecoInst ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_enderecoInst' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `st_enderecoInst` VARCHAR(199);
else
ALTER TABLE `T_Loja` MODIFY `st_enderecoInst` VARCHAR(199);
end if;
select count(*) from T_Loja where st_enderecoInst is null into var_find;
if var_find > 0 then 
update T_Loja set st_enderecoInst = '' where st_enderecoInst is null;
end if;
END;
##CMD
CALL ADD_T_Loja_st_enderecoInst ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_st_enderecoInst;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_nu_inscEst;
##CMD

CREATE PROCEDURE ADD_T_Loja_nu_inscEst ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_inscEst' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `nu_inscEst` VARCHAR(20);
else
ALTER TABLE `T_Loja` MODIFY `nu_inscEst` VARCHAR(20);
end if;
select count(*) from T_Loja where nu_inscEst is null into var_find;
if var_find > 0 then 
update T_Loja set nu_inscEst = '' where nu_inscEst is null;
end if;
END;
##CMD
CALL ADD_T_Loja_nu_inscEst ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_nu_inscEst;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Loja_st_ramo;
##CMD
CREATE PROCEDURE DEL_T_Loja_st_ramo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_ramo' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Loja` DROP COLUMN `st_ramo` ;
end if;
END;
##CMD

CALL DEL_T_Loja_st_ramo ( );
##CMD
DROP PROCEDURE  DEL_T_Loja_st_ramo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_st_cidade;
##CMD

CREATE PROCEDURE ADD_T_Loja_st_cidade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_cidade' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `st_cidade` VARCHAR(99);
else
ALTER TABLE `T_Loja` MODIFY `st_cidade` VARCHAR(99);
end if;
select count(*) from T_Loja where st_cidade is null into var_find;
if var_find > 0 then 
update T_Loja set st_cidade = '' where st_cidade is null;
end if;
END;
##CMD
CALL ADD_T_Loja_st_cidade ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_st_cidade;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_st_estado;
##CMD

CREATE PROCEDURE ADD_T_Loja_st_estado ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_estado' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `st_estado` VARCHAR(2);
else
ALTER TABLE `T_Loja` MODIFY `st_estado` VARCHAR(2);
end if;
select count(*) from T_Loja where st_estado is null into var_find;
if var_find > 0 then 
update T_Loja set st_estado = '' where st_estado is null;
end if;
END;
##CMD
CALL ADD_T_Loja_st_estado ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_st_estado;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_nu_CEP;
##CMD

CREATE PROCEDURE ADD_T_Loja_nu_CEP ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_CEP' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `nu_CEP` VARCHAR(18);
else
ALTER TABLE `T_Loja` MODIFY `nu_CEP` VARCHAR(18);
end if;
select count(*) from T_Loja where nu_CEP is null into var_find;
if var_find > 0 then 
update T_Loja set nu_CEP = '' where nu_CEP is null;
end if;
END;
##CMD
CALL ADD_T_Loja_nu_CEP ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_nu_CEP;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_nu_telefone;
##CMD

CREATE PROCEDURE ADD_T_Loja_nu_telefone ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_telefone' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `nu_telefone` VARCHAR(20);
else
ALTER TABLE `T_Loja` MODIFY `nu_telefone` VARCHAR(20);
end if;
select count(*) from T_Loja where nu_telefone is null into var_find;
if var_find > 0 then 
update T_Loja set nu_telefone = '' where nu_telefone is null;
end if;
END;
##CMD
CALL ADD_T_Loja_nu_telefone ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_nu_telefone;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_nu_fax;
##CMD

CREATE PROCEDURE ADD_T_Loja_nu_fax ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_fax' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `nu_fax` VARCHAR(20);
else
ALTER TABLE `T_Loja` MODIFY `nu_fax` VARCHAR(20);
end if;
select count(*) from T_Loja where nu_fax is null into var_find;
if var_find > 0 then 
update T_Loja set nu_fax = '' where nu_fax is null;
end if;
END;
##CMD
CALL ADD_T_Loja_nu_fax ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_nu_fax;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_st_contato;
##CMD

CREATE PROCEDURE ADD_T_Loja_st_contato ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_contato' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `st_contato` VARCHAR(40);
else
ALTER TABLE `T_Loja` MODIFY `st_contato` VARCHAR(40);
end if;
select count(*) from T_Loja where st_contato is null into var_find;
if var_find > 0 then 
update T_Loja set st_contato = '' where st_contato is null;
end if;
END;
##CMD
CALL ADD_T_Loja_st_contato ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_st_contato;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_vr_mensalidade;
##CMD

CREATE PROCEDURE ADD_T_Loja_vr_mensalidade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'vr_mensalidade' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `vr_mensalidade` BIGINT;
end if;
select count(*) from T_Loja where vr_mensalidade is null into var_find;
if var_find > 0 then 
update T_Loja set vr_mensalidade = 0 where vr_mensalidade is null;
end if;
END;
##CMD
CALL ADD_T_Loja_vr_mensalidade ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_vr_mensalidade;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_nu_contaDeb;
##CMD

CREATE PROCEDURE ADD_T_Loja_nu_contaDeb ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_contaDeb' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `nu_contaDeb` VARCHAR(20);
else
ALTER TABLE `T_Loja` MODIFY `nu_contaDeb` VARCHAR(20);
end if;
select count(*) from T_Loja where nu_contaDeb is null into var_find;
if var_find > 0 then 
update T_Loja set nu_contaDeb = '' where nu_contaDeb is null;
end if;
END;
##CMD
CALL ADD_T_Loja_nu_contaDeb ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_nu_contaDeb;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_st_obs;
##CMD

CREATE PROCEDURE ADD_T_Loja_st_obs ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_obs' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `st_obs` VARCHAR(900);
else
ALTER TABLE `T_Loja` MODIFY `st_obs` VARCHAR(900);
end if;
select count(*) from T_Loja where st_obs is null into var_find;
if var_find > 0 then 
update T_Loja set st_obs = '' where st_obs is null;
end if;
END;
##CMD
CALL ADD_T_Loja_st_obs ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_st_obs;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_st_loja;
##CMD

CREATE PROCEDURE ADD_T_Loja_st_loja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_loja' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `st_loja` VARCHAR(40);
else
ALTER TABLE `T_Loja` MODIFY `st_loja` VARCHAR(40);
end if;
select count(*) from T_Loja where st_loja is null into var_find;
if var_find > 0 then 
update T_Loja set st_loja = '' where st_loja is null;
end if;
END;
##CMD
CALL ADD_T_Loja_st_loja ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_st_loja;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_tg_blocked;
##CMD

CREATE PROCEDURE ADD_T_Loja_tg_blocked ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'tg_blocked' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `tg_blocked` VARCHAR(1);
else
ALTER TABLE `T_Loja` MODIFY `tg_blocked` VARCHAR(1);
end if;
select count(*) from T_Loja where tg_blocked is null into var_find;
if var_find > 0 then 
update T_Loja set tg_blocked = '' where tg_blocked is null;
end if;
END;
##CMD
CALL ADD_T_Loja_tg_blocked ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_tg_blocked;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Loja_nu_cod_tb;
##CMD
CREATE PROCEDURE DEL_T_Loja_nu_cod_tb ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_cod_tb' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Loja` DROP COLUMN `nu_cod_tb` ;
end if;
END;
##CMD

CALL DEL_T_Loja_nu_cod_tb ( );
##CMD
DROP PROCEDURE  DEL_T_Loja_nu_cod_tb;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_nu_pctValor;
##CMD

CREATE PROCEDURE ADD_T_Loja_nu_pctValor ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_pctValor' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `nu_pctValor` BIGINT;
end if;
select count(*) from T_Loja where nu_pctValor is null into var_find;
if var_find > 0 then 
update T_Loja set nu_pctValor = 0 where nu_pctValor is null;
end if;
END;
##CMD
CALL ADD_T_Loja_nu_pctValor ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_nu_pctValor;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_vr_transacao;
##CMD

CREATE PROCEDURE ADD_T_Loja_vr_transacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'vr_transacao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `vr_transacao` BIGINT;
end if;
select count(*) from T_Loja where vr_transacao is null into var_find;
if var_find > 0 then 
update T_Loja set vr_transacao = 0 where vr_transacao is null;
end if;
END;
##CMD
CALL ADD_T_Loja_vr_transacao ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_vr_transacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_vr_minimo;
##CMD

CREATE PROCEDURE ADD_T_Loja_vr_minimo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'vr_minimo' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `vr_minimo` BIGINT;
end if;
select count(*) from T_Loja where vr_minimo is null into var_find;
if var_find > 0 then 
update T_Loja set vr_minimo = 0 where vr_minimo is null;
end if;
END;
##CMD
CALL ADD_T_Loja_vr_minimo ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_vr_minimo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_nu_franquia;
##CMD

CREATE PROCEDURE ADD_T_Loja_nu_franquia ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_franquia' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `nu_franquia` BIGINT;
end if;
select count(*) from T_Loja where nu_franquia is null into var_find;
if var_find > 0 then 
update T_Loja set nu_franquia = 0 where nu_franquia is null;
end if;
END;
##CMD
CALL ADD_T_Loja_nu_franquia ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_nu_franquia;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_nu_periodoFat;
##CMD

CREATE PROCEDURE ADD_T_Loja_nu_periodoFat ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_periodoFat' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `nu_periodoFat` BIGINT;
end if;
select count(*) from T_Loja where nu_periodoFat is null into var_find;
if var_find > 0 then 
update T_Loja set nu_periodoFat = 0 where nu_periodoFat is null;
end if;
END;
##CMD
CALL ADD_T_Loja_nu_periodoFat ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_nu_periodoFat;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_nu_diavenc;
##CMD

CREATE PROCEDURE ADD_T_Loja_nu_diavenc ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_diavenc' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `nu_diavenc` BIGINT;
end if;
select count(*) from T_Loja where nu_diavenc is null into var_find;
if var_find > 0 then 
update T_Loja set nu_diavenc = 0 where nu_diavenc is null;
end if;
END;
##CMD
CALL ADD_T_Loja_nu_diavenc ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_nu_diavenc;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_tg_tipoCobranca;
##CMD

CREATE PROCEDURE ADD_T_Loja_tg_tipoCobranca ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'tg_tipoCobranca' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `tg_tipoCobranca` VARCHAR(1);
else
ALTER TABLE `T_Loja` MODIFY `tg_tipoCobranca` VARCHAR(1);
end if;
select count(*) from T_Loja where tg_tipoCobranca is null into var_find;
if var_find > 0 then 
update T_Loja set tg_tipoCobranca = '' where tg_tipoCobranca is null;
end if;
END;
##CMD
CALL ADD_T_Loja_tg_tipoCobranca ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_tg_tipoCobranca;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_nu_bancoFat;
##CMD

CREATE PROCEDURE ADD_T_Loja_nu_bancoFat ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'nu_bancoFat' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `nu_bancoFat` BIGINT;
end if;
select count(*) from T_Loja where nu_bancoFat is null into var_find;
if var_find > 0 then 
update T_Loja set nu_bancoFat = 0 where nu_bancoFat is null;
end if;
END;
##CMD
CALL ADD_T_Loja_nu_bancoFat ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_nu_bancoFat;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_tg_isentoFat;
##CMD

CREATE PROCEDURE ADD_T_Loja_tg_isentoFat ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'tg_isentoFat' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `tg_isentoFat` BIGINT;
end if;
select count(*) from T_Loja where tg_isentoFat is null into var_find;
if var_find > 0 then 
update T_Loja set tg_isentoFat = 0 where tg_isentoFat is null;
end if;
END;
##CMD
CALL ADD_T_Loja_tg_isentoFat ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_tg_isentoFat;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Loja_st_acessoWeb;
##CMD
CREATE PROCEDURE DEL_T_Loja_st_acessoWeb ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_acessoWeb' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Loja` DROP COLUMN `st_acessoWeb` ;
end if;
END;
##CMD

CALL DEL_T_Loja_st_acessoWeb ( );
##CMD
DROP PROCEDURE  DEL_T_Loja_st_acessoWeb;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_st_senha;
##CMD

CREATE PROCEDURE ADD_T_Loja_st_senha ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'st_senha' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `st_senha` VARCHAR(16);
else
ALTER TABLE `T_Loja` MODIFY `st_senha` VARCHAR(16);
end if;
select count(*) from T_Loja where st_senha is null into var_find;
if var_find > 0 then 
update T_Loja set st_senha = '' where st_senha is null;
end if;
END;
##CMD
CALL ADD_T_Loja_st_senha ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_st_senha;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Loja_tg_cancel;
##CMD

CREATE PROCEDURE ADD_T_Loja_tg_cancel ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Loja' and column_name = 'tg_cancel' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Loja` ADD COLUMN `tg_cancel` BIGINT;
end if;
select count(*) from T_Loja where tg_cancel is null into var_find;
if var_find > 0 then 
update T_Loja set tg_cancel = 0 where tg_cancel is null;
end if;
END;
##CMD
CALL ADD_T_Loja_tg_cancel ( );
##CMD
DROP PROCEDURE  ADD_T_Loja_tg_cancel;
##CMD


CREATE TABLE IF NOT EXISTS `T_Empresa` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_empresa` VARCHAR(6),
`nu_CNPJ` VARCHAR(14),
`st_fantasia` VARCHAR(99),
`st_social` VARCHAR(99),
`st_endereco` VARCHAR(99),
`st_cidade` VARCHAR(99),
`st_estado` VARCHAR(2),
`nu_CEP` VARCHAR(14),
`nu_telefone` VARCHAR(20),
`nu_cartoes` BIGINT UNSIGNED,
`nu_parcelas` BIGINT UNSIGNED,
`tg_blocked` VARCHAR(1),
`fk_admin` BIGINT UNSIGNED,
`nu_contaDeb` VARCHAR(20),
`vr_mensalidade` BIGINT UNSIGNED,
`nu_pctValor` BIGINT UNSIGNED,
`vr_transacao` BIGINT UNSIGNED,
`vr_minimo` BIGINT UNSIGNED,
`nu_franquia` BIGINT UNSIGNED,
`nu_periodoFat` BIGINT UNSIGNED,
`nu_diaVenc` BIGINT UNSIGNED,
`tg_tipoCobranca` VARCHAR(1),
`nu_bancoFat` BIGINT UNSIGNED,
`vr_cartaoAtivo` BIGINT UNSIGNED,
`tg_isentoFat` BIGINT UNSIGNED,
`st_obs` VARCHAR(400),
`tg_bloq` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_st_empresa;
##CMD

CREATE PROCEDURE ADD_T_Empresa_st_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'st_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `st_empresa` VARCHAR(6);
else
ALTER TABLE `T_Empresa` MODIFY `st_empresa` VARCHAR(6);
end if;
select count(*) from T_Empresa where st_empresa is null into var_find;
if var_find > 0 then 
update T_Empresa set st_empresa = '' where st_empresa is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_st_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_st_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_nu_CNPJ;
##CMD

CREATE PROCEDURE ADD_T_Empresa_nu_CNPJ ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_CNPJ' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `nu_CNPJ` VARCHAR(14);
else
ALTER TABLE `T_Empresa` MODIFY `nu_CNPJ` VARCHAR(14);
end if;
select count(*) from T_Empresa where nu_CNPJ is null into var_find;
if var_find > 0 then 
update T_Empresa set nu_CNPJ = '' where nu_CNPJ is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_nu_CNPJ ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_nu_CNPJ;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_st_fantasia;
##CMD

CREATE PROCEDURE ADD_T_Empresa_st_fantasia ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'st_fantasia' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `st_fantasia` VARCHAR(99);
else
ALTER TABLE `T_Empresa` MODIFY `st_fantasia` VARCHAR(99);
end if;
select count(*) from T_Empresa where st_fantasia is null into var_find;
if var_find > 0 then 
update T_Empresa set st_fantasia = '' where st_fantasia is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_st_fantasia ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_st_fantasia;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_st_social;
##CMD

CREATE PROCEDURE ADD_T_Empresa_st_social ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'st_social' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `st_social` VARCHAR(99);
else
ALTER TABLE `T_Empresa` MODIFY `st_social` VARCHAR(99);
end if;
select count(*) from T_Empresa where st_social is null into var_find;
if var_find > 0 then 
update T_Empresa set st_social = '' where st_social is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_st_social ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_st_social;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_st_endereco;
##CMD

CREATE PROCEDURE ADD_T_Empresa_st_endereco ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'st_endereco' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `st_endereco` VARCHAR(99);
else
ALTER TABLE `T_Empresa` MODIFY `st_endereco` VARCHAR(99);
end if;
select count(*) from T_Empresa where st_endereco is null into var_find;
if var_find > 0 then 
update T_Empresa set st_endereco = '' where st_endereco is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_st_endereco ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_st_endereco;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_st_cidade;
##CMD

CREATE PROCEDURE ADD_T_Empresa_st_cidade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'st_cidade' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `st_cidade` VARCHAR(99);
else
ALTER TABLE `T_Empresa` MODIFY `st_cidade` VARCHAR(99);
end if;
select count(*) from T_Empresa where st_cidade is null into var_find;
if var_find > 0 then 
update T_Empresa set st_cidade = '' where st_cidade is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_st_cidade ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_st_cidade;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_st_estado;
##CMD

CREATE PROCEDURE ADD_T_Empresa_st_estado ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'st_estado' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `st_estado` VARCHAR(2);
else
ALTER TABLE `T_Empresa` MODIFY `st_estado` VARCHAR(2);
end if;
select count(*) from T_Empresa where st_estado is null into var_find;
if var_find > 0 then 
update T_Empresa set st_estado = '' where st_estado is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_st_estado ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_st_estado;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_nu_CEP;
##CMD

CREATE PROCEDURE ADD_T_Empresa_nu_CEP ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_CEP' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `nu_CEP` VARCHAR(14);
else
ALTER TABLE `T_Empresa` MODIFY `nu_CEP` VARCHAR(14);
end if;
select count(*) from T_Empresa where nu_CEP is null into var_find;
if var_find > 0 then 
update T_Empresa set nu_CEP = '' where nu_CEP is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_nu_CEP ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_nu_CEP;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_nu_telefone;
##CMD

CREATE PROCEDURE ADD_T_Empresa_nu_telefone ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_telefone' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `nu_telefone` VARCHAR(20);
else
ALTER TABLE `T_Empresa` MODIFY `nu_telefone` VARCHAR(20);
end if;
select count(*) from T_Empresa where nu_telefone is null into var_find;
if var_find > 0 then 
update T_Empresa set nu_telefone = '' where nu_telefone is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_nu_telefone ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_nu_telefone;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_nu_cartoes;
##CMD

CREATE PROCEDURE ADD_T_Empresa_nu_cartoes ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_cartoes' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `nu_cartoes` BIGINT;
end if;
select count(*) from T_Empresa where nu_cartoes is null into var_find;
if var_find > 0 then 
update T_Empresa set nu_cartoes = 0 where nu_cartoes is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_nu_cartoes ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_nu_cartoes;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_nu_parcelas;
##CMD

CREATE PROCEDURE ADD_T_Empresa_nu_parcelas ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_parcelas' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `nu_parcelas` BIGINT;
end if;
select count(*) from T_Empresa where nu_parcelas is null into var_find;
if var_find > 0 then 
update T_Empresa set nu_parcelas = 0 where nu_parcelas is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_nu_parcelas ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_nu_parcelas;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Empresa_nu_fatura;
##CMD
CREATE PROCEDURE DEL_T_Empresa_nu_fatura ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_fatura' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Empresa` DROP COLUMN `nu_fatura` ;
end if;
END;
##CMD

CALL DEL_T_Empresa_nu_fatura ( );
##CMD
DROP PROCEDURE  DEL_T_Empresa_nu_fatura;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Empresa_nu_diaCredito;
##CMD
CREATE PROCEDURE DEL_T_Empresa_nu_diaCredito ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_diaCredito' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Empresa` DROP COLUMN `nu_diaCredito` ;
end if;
END;
##CMD

CALL DEL_T_Empresa_nu_diaCredito ( );
##CMD
DROP PROCEDURE  DEL_T_Empresa_nu_diaCredito;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Empresa_vr_taxa;
##CMD
CREATE PROCEDURE DEL_T_Empresa_vr_taxa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'vr_taxa' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Empresa` DROP COLUMN `vr_taxa` ;
end if;
END;
##CMD

CALL DEL_T_Empresa_vr_taxa ( );
##CMD
DROP PROCEDURE  DEL_T_Empresa_vr_taxa;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Empresa_nu_diasBloqueio;
##CMD
CREATE PROCEDURE DEL_T_Empresa_nu_diasBloqueio ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_diasBloqueio' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Empresa` DROP COLUMN `nu_diasBloqueio` ;
end if;
END;
##CMD

CALL DEL_T_Empresa_nu_diasBloqueio ( );
##CMD
DROP PROCEDURE  DEL_T_Empresa_nu_diasBloqueio;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Empresa_vr_pontos;
##CMD
CREATE PROCEDURE DEL_T_Empresa_vr_pontos ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'vr_pontos' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Empresa` DROP COLUMN `vr_pontos` ;
end if;
END;
##CMD

CALL DEL_T_Empresa_vr_pontos ( );
##CMD
DROP PROCEDURE  DEL_T_Empresa_vr_pontos;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_tg_blocked;
##CMD

CREATE PROCEDURE ADD_T_Empresa_tg_blocked ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'tg_blocked' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `tg_blocked` VARCHAR(1);
else
ALTER TABLE `T_Empresa` MODIFY `tg_blocked` VARCHAR(1);
end if;
select count(*) from T_Empresa where tg_blocked is null into var_find;
if var_find > 0 then 
update T_Empresa set tg_blocked = '' where tg_blocked is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_tg_blocked ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_tg_blocked;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_fk_admin;
##CMD

CREATE PROCEDURE ADD_T_Empresa_fk_admin ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'fk_admin' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `fk_admin` BIGINT;
end if;
select count(*) from T_Empresa where fk_admin is null into var_find;
if var_find > 0 then 
update T_Empresa set fk_admin = 0 where fk_admin is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'fk_admin' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD INDEX `index_fk_admin`(fk_admin);
end if;
END;
##CMD
CALL ADD_T_Empresa_fk_admin ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_fk_admin;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_nu_contaDeb;
##CMD

CREATE PROCEDURE ADD_T_Empresa_nu_contaDeb ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_contaDeb' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `nu_contaDeb` VARCHAR(20);
else
ALTER TABLE `T_Empresa` MODIFY `nu_contaDeb` VARCHAR(20);
end if;
select count(*) from T_Empresa where nu_contaDeb is null into var_find;
if var_find > 0 then 
update T_Empresa set nu_contaDeb = '' where nu_contaDeb is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_nu_contaDeb ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_nu_contaDeb;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_vr_mensalidade;
##CMD

CREATE PROCEDURE ADD_T_Empresa_vr_mensalidade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'vr_mensalidade' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `vr_mensalidade` BIGINT;
end if;
select count(*) from T_Empresa where vr_mensalidade is null into var_find;
if var_find > 0 then 
update T_Empresa set vr_mensalidade = 0 where vr_mensalidade is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_vr_mensalidade ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_vr_mensalidade;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Empresa_vr_cartaoAivo;
##CMD
CREATE PROCEDURE DEL_T_Empresa_vr_cartaoAivo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'vr_cartaoAivo' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Empresa` DROP COLUMN `vr_cartaoAivo` ;
end if;
END;
##CMD

CALL DEL_T_Empresa_vr_cartaoAivo ( );
##CMD
DROP PROCEDURE  DEL_T_Empresa_vr_cartaoAivo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_nu_pctValor;
##CMD

CREATE PROCEDURE ADD_T_Empresa_nu_pctValor ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_pctValor' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `nu_pctValor` BIGINT;
end if;
select count(*) from T_Empresa where nu_pctValor is null into var_find;
if var_find > 0 then 
update T_Empresa set nu_pctValor = 0 where nu_pctValor is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_nu_pctValor ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_nu_pctValor;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_vr_transacao;
##CMD

CREATE PROCEDURE ADD_T_Empresa_vr_transacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'vr_transacao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `vr_transacao` BIGINT;
end if;
select count(*) from T_Empresa where vr_transacao is null into var_find;
if var_find > 0 then 
update T_Empresa set vr_transacao = 0 where vr_transacao is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_vr_transacao ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_vr_transacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_vr_minimo;
##CMD

CREATE PROCEDURE ADD_T_Empresa_vr_minimo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'vr_minimo' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `vr_minimo` BIGINT;
end if;
select count(*) from T_Empresa where vr_minimo is null into var_find;
if var_find > 0 then 
update T_Empresa set vr_minimo = 0 where vr_minimo is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_vr_minimo ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_vr_minimo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_nu_franquia;
##CMD

CREATE PROCEDURE ADD_T_Empresa_nu_franquia ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_franquia' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `nu_franquia` BIGINT;
end if;
select count(*) from T_Empresa where nu_franquia is null into var_find;
if var_find > 0 then 
update T_Empresa set nu_franquia = 0 where nu_franquia is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_nu_franquia ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_nu_franquia;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_nu_periodoFat;
##CMD

CREATE PROCEDURE ADD_T_Empresa_nu_periodoFat ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_periodoFat' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `nu_periodoFat` BIGINT;
end if;
select count(*) from T_Empresa where nu_periodoFat is null into var_find;
if var_find > 0 then 
update T_Empresa set nu_periodoFat = 0 where nu_periodoFat is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_nu_periodoFat ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_nu_periodoFat;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_nu_diaVenc;
##CMD

CREATE PROCEDURE ADD_T_Empresa_nu_diaVenc ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_diaVenc' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `nu_diaVenc` BIGINT;
end if;
select count(*) from T_Empresa where nu_diaVenc is null into var_find;
if var_find > 0 then 
update T_Empresa set nu_diaVenc = 0 where nu_diaVenc is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_nu_diaVenc ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_nu_diaVenc;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_tg_tipoCobranca;
##CMD

CREATE PROCEDURE ADD_T_Empresa_tg_tipoCobranca ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'tg_tipoCobranca' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `tg_tipoCobranca` VARCHAR(1);
else
ALTER TABLE `T_Empresa` MODIFY `tg_tipoCobranca` VARCHAR(1);
end if;
select count(*) from T_Empresa where tg_tipoCobranca is null into var_find;
if var_find > 0 then 
update T_Empresa set tg_tipoCobranca = '' where tg_tipoCobranca is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_tg_tipoCobranca ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_tg_tipoCobranca;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_nu_bancoFat;
##CMD

CREATE PROCEDURE ADD_T_Empresa_nu_bancoFat ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'nu_bancoFat' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `nu_bancoFat` BIGINT;
end if;
select count(*) from T_Empresa where nu_bancoFat is null into var_find;
if var_find > 0 then 
update T_Empresa set nu_bancoFat = 0 where nu_bancoFat is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_nu_bancoFat ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_nu_bancoFat;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_vr_cartaoAtivo;
##CMD

CREATE PROCEDURE ADD_T_Empresa_vr_cartaoAtivo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'vr_cartaoAtivo' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `vr_cartaoAtivo` BIGINT;
end if;
select count(*) from T_Empresa where vr_cartaoAtivo is null into var_find;
if var_find > 0 then 
update T_Empresa set vr_cartaoAtivo = 0 where vr_cartaoAtivo is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_vr_cartaoAtivo ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_vr_cartaoAtivo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_tg_isentoFat;
##CMD

CREATE PROCEDURE ADD_T_Empresa_tg_isentoFat ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'tg_isentoFat' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `tg_isentoFat` BIGINT;
end if;
select count(*) from T_Empresa where tg_isentoFat is null into var_find;
if var_find > 0 then 
update T_Empresa set tg_isentoFat = 0 where tg_isentoFat is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_tg_isentoFat ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_tg_isentoFat;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_st_obs;
##CMD

CREATE PROCEDURE ADD_T_Empresa_st_obs ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'st_obs' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `st_obs` VARCHAR(400);
else
ALTER TABLE `T_Empresa` MODIFY `st_obs` VARCHAR(400);
end if;
select count(*) from T_Empresa where st_obs is null into var_find;
if var_find > 0 then 
update T_Empresa set st_obs = '' where st_obs is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_st_obs ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_st_obs;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Empresa_tg_bloq;
##CMD

CREATE PROCEDURE ADD_T_Empresa_tg_bloq ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Empresa' and column_name = 'tg_bloq' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Empresa` ADD COLUMN `tg_bloq` BIGINT;
end if;
select count(*) from T_Empresa where tg_bloq is null into var_find;
if var_find > 0 then 
update T_Empresa set tg_bloq = 0 where tg_bloq is null;
end if;
END;
##CMD
CALL ADD_T_Empresa_tg_bloq ( );
##CMD
DROP PROCEDURE  ADD_T_Empresa_tg_bloq;
##CMD


CREATE TABLE IF NOT EXISTS `T_Terminal` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`nu_terminal` VARCHAR(12),
`fk_loja` BIGINT UNSIGNED,
`st_localizacao` VARCHAR(250),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Terminal_nu_terminal;
##CMD

CREATE PROCEDURE ADD_T_Terminal_nu_terminal ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Terminal' and column_name = 'nu_terminal' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Terminal` ADD COLUMN `nu_terminal` VARCHAR(12);
else
ALTER TABLE `T_Terminal` MODIFY `nu_terminal` VARCHAR(12);
end if;
select count(*) from T_Terminal where nu_terminal is null into var_find;
if var_find > 0 then 
update T_Terminal set nu_terminal = '' where nu_terminal is null;
end if;
END;
##CMD
CALL ADD_T_Terminal_nu_terminal ( );
##CMD
DROP PROCEDURE  ADD_T_Terminal_nu_terminal;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Terminal_fk_empresa;
##CMD
CREATE PROCEDURE DEL_T_Terminal_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Terminal' and column_name = 'fk_empresa' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Terminal` DROP COLUMN `fk_empresa` ;
end if;
END;
##CMD

CALL DEL_T_Terminal_fk_empresa ( );
##CMD
DROP PROCEDURE  DEL_T_Terminal_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Terminal_fk_loja;
##CMD

CREATE PROCEDURE ADD_T_Terminal_fk_loja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Terminal' and column_name = 'fk_loja' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Terminal` ADD COLUMN `fk_loja` BIGINT;
end if;
select count(*) from T_Terminal where fk_loja is null into var_find;
if var_find > 0 then 
update T_Terminal set fk_loja = 0 where fk_loja is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Terminal' and column_name = 'fk_loja' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Terminal` ADD INDEX `index_fk_loja`(fk_loja);
end if;
END;
##CMD
CALL ADD_T_Terminal_fk_loja ( );
##CMD
DROP PROCEDURE  ADD_T_Terminal_fk_loja;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Terminal_st_localizacao;
##CMD

CREATE PROCEDURE ADD_T_Terminal_st_localizacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Terminal' and column_name = 'st_localizacao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Terminal` ADD COLUMN `st_localizacao` VARCHAR(250);
else
ALTER TABLE `T_Terminal` MODIFY `st_localizacao` VARCHAR(250);
end if;
select count(*) from T_Terminal where st_localizacao is null into var_find;
if var_find > 0 then 
update T_Terminal set st_localizacao = '' where st_localizacao is null;
end if;
END;
##CMD
CALL ADD_T_Terminal_st_localizacao ( );
##CMD
DROP PROCEDURE  ADD_T_Terminal_st_localizacao;
##CMD


CREATE TABLE IF NOT EXISTS `LOG_Audit` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_usuario` BIGINT UNSIGNED,
`tg_operacao` BIGINT UNSIGNED,
`dt_operacao` DATETIME,
`st_observacao` VARCHAR(150),
`fk_generic` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Audit_fk_usuario;
##CMD

CREATE PROCEDURE ADD_LOG_Audit_fk_usuario ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Audit' and column_name = 'fk_usuario' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Audit` ADD COLUMN `fk_usuario` BIGINT;
end if;
select count(*) from LOG_Audit where fk_usuario is null into var_find;
if var_find > 0 then 
update LOG_Audit set fk_usuario = 0 where fk_usuario is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Audit' and column_name = 'fk_usuario' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Audit` ADD INDEX `index_fk_usuario`(fk_usuario);
end if;
END;
##CMD
CALL ADD_LOG_Audit_fk_usuario ( );
##CMD
DROP PROCEDURE  ADD_LOG_Audit_fk_usuario;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Audit_tg_operacao;
##CMD

CREATE PROCEDURE ADD_LOG_Audit_tg_operacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Audit' and column_name = 'tg_operacao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Audit` ADD COLUMN `tg_operacao` BIGINT;
end if;
select count(*) from LOG_Audit where tg_operacao is null into var_find;
if var_find > 0 then 
update LOG_Audit set tg_operacao = 0 where tg_operacao is null;
end if;
END;
##CMD
CALL ADD_LOG_Audit_tg_operacao ( );
##CMD
DROP PROCEDURE  ADD_LOG_Audit_tg_operacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Audit_dt_operacao;
##CMD

CREATE PROCEDURE ADD_LOG_Audit_dt_operacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Audit' and column_name = 'dt_operacao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Audit` ADD COLUMN `dt_operacao` DATETIME;
end if;
select count(*) from LOG_Audit where dt_operacao is null into var_find;
if var_find > 0 then 
update LOG_Audit set dt_operacao = '1900-01-01 00:00:00.000' where dt_operacao is null;
end if;
END;
##CMD
CALL ADD_LOG_Audit_dt_operacao ( );
##CMD
DROP PROCEDURE  ADD_LOG_Audit_dt_operacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Audit_st_observacao;
##CMD

CREATE PROCEDURE ADD_LOG_Audit_st_observacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Audit' and column_name = 'st_observacao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Audit` ADD COLUMN `st_observacao` VARCHAR(150);
else
ALTER TABLE `LOG_Audit` MODIFY `st_observacao` VARCHAR(150);
end if;
select count(*) from LOG_Audit where st_observacao is null into var_find;
if var_find > 0 then 
update LOG_Audit set st_observacao = '' where st_observacao is null;
end if;
END;
##CMD
CALL ADD_LOG_Audit_st_observacao ( );
##CMD
DROP PROCEDURE  ADD_LOG_Audit_st_observacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Audit_fk_generic;
##CMD

CREATE PROCEDURE ADD_LOG_Audit_fk_generic ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Audit' and column_name = 'fk_generic' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Audit` ADD COLUMN `fk_generic` BIGINT;
end if;
select count(*) from LOG_Audit where fk_generic is null into var_find;
if var_find > 0 then 
update LOG_Audit set fk_generic = 0 where fk_generic is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Audit' and column_name = 'fk_generic' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Audit` ADD INDEX `index_fk_generic`(fk_generic);
end if;
END;
##CMD
CALL ADD_LOG_Audit_fk_generic ( );
##CMD
DROP PROCEDURE  ADD_LOG_Audit_fk_generic;
##CMD


CREATE TABLE IF NOT EXISTS `LOG_NSU` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`dt_log` DATETIME,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_NSU_dt_log;
##CMD

CREATE PROCEDURE ADD_LOG_NSU_dt_log ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_NSU' and column_name = 'dt_log' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_NSU` ADD COLUMN `dt_log` DATETIME;
end if;
select count(*) from LOG_NSU where dt_log is null into var_find;
if var_find > 0 then 
update LOG_NSU set dt_log = '1900-01-01 00:00:00.000' where dt_log is null;
end if;
END;
##CMD
CALL ADD_LOG_NSU_dt_log ( );
##CMD
DROP PROCEDURE  ADD_LOG_NSU_dt_log;
##CMD


CREATE TABLE IF NOT EXISTS `I_Scheduler` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_job` VARCHAR(400),
`tg_type` VARCHAR(1),
`dt_specific` DATETIME,
`st_daily_hhmm` VARCHAR(4),
`st_weekly_dow` BIGINT UNSIGNED,
`st_weekly_hhmm` VARCHAR(4),
`nu_monthly_day` BIGINT UNSIGNED,
`st_monthly_hhmm` VARCHAR(4),
`dt_last` DATETIME,
`tg_status` VARCHAR(1),
`dt_prev` DATETIME,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Scheduler_st_job;
##CMD

CREATE PROCEDURE ADD_I_Scheduler_st_job ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Scheduler' and column_name = 'st_job' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Scheduler` ADD COLUMN `st_job` VARCHAR(400);
else
ALTER TABLE `I_Scheduler` MODIFY `st_job` VARCHAR(400);
end if;
select count(*) from I_Scheduler where st_job is null into var_find;
if var_find > 0 then 
update I_Scheduler set st_job = '' where st_job is null;
end if;
END;
##CMD
CALL ADD_I_Scheduler_st_job ( );
##CMD
DROP PROCEDURE  ADD_I_Scheduler_st_job;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Scheduler_tg_type;
##CMD

CREATE PROCEDURE ADD_I_Scheduler_tg_type ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Scheduler' and column_name = 'tg_type' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Scheduler` ADD COLUMN `tg_type` VARCHAR(1);
else
ALTER TABLE `I_Scheduler` MODIFY `tg_type` VARCHAR(1);
end if;
select count(*) from I_Scheduler where tg_type is null into var_find;
if var_find > 0 then 
update I_Scheduler set tg_type = '' where tg_type is null;
end if;
END;
##CMD
CALL ADD_I_Scheduler_tg_type ( );
##CMD
DROP PROCEDURE  ADD_I_Scheduler_tg_type;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Scheduler_dt_specific;
##CMD

CREATE PROCEDURE ADD_I_Scheduler_dt_specific ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Scheduler' and column_name = 'dt_specific' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Scheduler` ADD COLUMN `dt_specific` DATETIME;
end if;
select count(*) from I_Scheduler where dt_specific is null into var_find;
if var_find > 0 then 
update I_Scheduler set dt_specific = '1900-01-01 00:00:00.000' where dt_specific is null;
end if;
END;
##CMD
CALL ADD_I_Scheduler_dt_specific ( );
##CMD
DROP PROCEDURE  ADD_I_Scheduler_dt_specific;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Scheduler_st_daily_hhmm;
##CMD

CREATE PROCEDURE ADD_I_Scheduler_st_daily_hhmm ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Scheduler' and column_name = 'st_daily_hhmm' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Scheduler` ADD COLUMN `st_daily_hhmm` VARCHAR(4);
else
ALTER TABLE `I_Scheduler` MODIFY `st_daily_hhmm` VARCHAR(4);
end if;
select count(*) from I_Scheduler where st_daily_hhmm is null into var_find;
if var_find > 0 then 
update I_Scheduler set st_daily_hhmm = '' where st_daily_hhmm is null;
end if;
END;
##CMD
CALL ADD_I_Scheduler_st_daily_hhmm ( );
##CMD
DROP PROCEDURE  ADD_I_Scheduler_st_daily_hhmm;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Scheduler_st_weekly_dow;
##CMD

CREATE PROCEDURE ADD_I_Scheduler_st_weekly_dow ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Scheduler' and column_name = 'st_weekly_dow' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Scheduler` ADD COLUMN `st_weekly_dow` BIGINT;
end if;
select count(*) from I_Scheduler where st_weekly_dow is null into var_find;
if var_find > 0 then 
update I_Scheduler set st_weekly_dow = 0 where st_weekly_dow is null;
end if;
END;
##CMD
CALL ADD_I_Scheduler_st_weekly_dow ( );
##CMD
DROP PROCEDURE  ADD_I_Scheduler_st_weekly_dow;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Scheduler_st_weekly_hhmm;
##CMD

CREATE PROCEDURE ADD_I_Scheduler_st_weekly_hhmm ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Scheduler' and column_name = 'st_weekly_hhmm' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Scheduler` ADD COLUMN `st_weekly_hhmm` VARCHAR(4);
else
ALTER TABLE `I_Scheduler` MODIFY `st_weekly_hhmm` VARCHAR(4);
end if;
select count(*) from I_Scheduler where st_weekly_hhmm is null into var_find;
if var_find > 0 then 
update I_Scheduler set st_weekly_hhmm = '' where st_weekly_hhmm is null;
end if;
END;
##CMD
CALL ADD_I_Scheduler_st_weekly_hhmm ( );
##CMD
DROP PROCEDURE  ADD_I_Scheduler_st_weekly_hhmm;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Scheduler_nu_monthly_day;
##CMD

CREATE PROCEDURE ADD_I_Scheduler_nu_monthly_day ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Scheduler' and column_name = 'nu_monthly_day' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Scheduler` ADD COLUMN `nu_monthly_day` BIGINT;
end if;
select count(*) from I_Scheduler where nu_monthly_day is null into var_find;
if var_find > 0 then 
update I_Scheduler set nu_monthly_day = 0 where nu_monthly_day is null;
end if;
END;
##CMD
CALL ADD_I_Scheduler_nu_monthly_day ( );
##CMD
DROP PROCEDURE  ADD_I_Scheduler_nu_monthly_day;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Scheduler_st_monthly_hhmm;
##CMD

CREATE PROCEDURE ADD_I_Scheduler_st_monthly_hhmm ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Scheduler' and column_name = 'st_monthly_hhmm' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Scheduler` ADD COLUMN `st_monthly_hhmm` VARCHAR(4);
else
ALTER TABLE `I_Scheduler` MODIFY `st_monthly_hhmm` VARCHAR(4);
end if;
select count(*) from I_Scheduler where st_monthly_hhmm is null into var_find;
if var_find > 0 then 
update I_Scheduler set st_monthly_hhmm = '' where st_monthly_hhmm is null;
end if;
END;
##CMD
CALL ADD_I_Scheduler_st_monthly_hhmm ( );
##CMD
DROP PROCEDURE  ADD_I_Scheduler_st_monthly_hhmm;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Scheduler_dt_last;
##CMD

CREATE PROCEDURE ADD_I_Scheduler_dt_last ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Scheduler' and column_name = 'dt_last' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Scheduler` ADD COLUMN `dt_last` DATETIME;
end if;
select count(*) from I_Scheduler where dt_last is null into var_find;
if var_find > 0 then 
update I_Scheduler set dt_last = '1900-01-01 00:00:00.000' where dt_last is null;
end if;
END;
##CMD
CALL ADD_I_Scheduler_dt_last ( );
##CMD
DROP PROCEDURE  ADD_I_Scheduler_dt_last;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Scheduler_tg_status;
##CMD

CREATE PROCEDURE ADD_I_Scheduler_tg_status ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Scheduler' and column_name = 'tg_status' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Scheduler` ADD COLUMN `tg_status` VARCHAR(1);
else
ALTER TABLE `I_Scheduler` MODIFY `tg_status` VARCHAR(1);
end if;
select count(*) from I_Scheduler where tg_status is null into var_find;
if var_find > 0 then 
update I_Scheduler set tg_status = '' where tg_status is null;
end if;
END;
##CMD
CALL ADD_I_Scheduler_tg_status ( );
##CMD
DROP PROCEDURE  ADD_I_Scheduler_tg_status;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Scheduler_dt_prev;
##CMD

CREATE PROCEDURE ADD_I_Scheduler_dt_prev ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Scheduler' and column_name = 'dt_prev' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Scheduler` ADD COLUMN `dt_prev` DATETIME;
end if;
select count(*) from I_Scheduler where dt_prev is null into var_find;
if var_find > 0 then 
update I_Scheduler set dt_prev = '1900-01-01 00:00:00.000' where dt_prev is null;
end if;
END;
##CMD
CALL ADD_I_Scheduler_dt_prev ( );
##CMD
DROP PROCEDURE  ADD_I_Scheduler_dt_prev;
##CMD


CREATE TABLE IF NOT EXISTS `LOG_Transacoes` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_terminal` BIGINT UNSIGNED,
`dt_transacao` DATETIME,
`nu_nsu` BIGINT UNSIGNED,
`fk_empresa` BIGINT UNSIGNED,
`fk_cartao` BIGINT UNSIGNED,
`vr_total` BIGINT UNSIGNED,
`nu_parcelas` BIGINT UNSIGNED,
`nu_cod_erro` BIGINT UNSIGNED,
`tg_confirmada` VARCHAR(1),
`nu_nsuOrig` BIGINT UNSIGNED,
`en_operacao` VARCHAR(10),
`st_msg_transacao` VARCHAR(50),
`tg_contabil` VARCHAR(1),
`fk_loja` BIGINT UNSIGNED,
`vr_saldo_disp` BIGINT UNSIGNED,
`vr_saldo_disp_tot` BIGINT UNSIGNED,
`st_doc` VARCHAR(20),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_fk_terminal;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_fk_terminal ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'fk_terminal' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `fk_terminal` BIGINT;
end if;
select count(*) from LOG_Transacoes where fk_terminal is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set fk_terminal = 0 where fk_terminal is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'fk_terminal' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD INDEX `index_fk_terminal`(fk_terminal);
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_fk_terminal ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_fk_terminal;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_dt_transacao;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_dt_transacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'dt_transacao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `dt_transacao` DATETIME;
end if;
select count(*) from LOG_Transacoes where dt_transacao is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set dt_transacao = '1900-01-01 00:00:00.000' where dt_transacao is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_dt_transacao ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_dt_transacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_nu_nsu;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_nu_nsu ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'nu_nsu' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `nu_nsu` BIGINT;
end if;
select count(*) from LOG_Transacoes where nu_nsu is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set nu_nsu = 0 where nu_nsu is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_nu_nsu ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_nu_nsu;
##CMD

DROP PROCEDURE IF EXISTS DEL_LOG_Transacoes_nu_nsuEntidade;
##CMD
CREATE PROCEDURE DEL_LOG_Transacoes_nu_nsuEntidade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'nu_nsuEntidade' into var_find;
if var_find = 1 then 
ALTER TABLE `LOG_Transacoes` DROP COLUMN `nu_nsuEntidade` ;
end if;
END;
##CMD

CALL DEL_LOG_Transacoes_nu_nsuEntidade ( );
##CMD
DROP PROCEDURE  DEL_LOG_Transacoes_nu_nsuEntidade;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_fk_empresa;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from LOG_Transacoes where fk_empresa is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_fk_cartao;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from LOG_Transacoes where fk_cartao is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_vr_total;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_vr_total ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'vr_total' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `vr_total` BIGINT;
end if;
select count(*) from LOG_Transacoes where vr_total is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set vr_total = 0 where vr_total is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_vr_total ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_vr_total;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_nu_parcelas;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_nu_parcelas ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'nu_parcelas' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `nu_parcelas` BIGINT;
end if;
select count(*) from LOG_Transacoes where nu_parcelas is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set nu_parcelas = 0 where nu_parcelas is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_nu_parcelas ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_nu_parcelas;
##CMD

DROP PROCEDURE IF EXISTS DEL_LOG_Transacoes_st_bin_cartao;
##CMD
CREATE PROCEDURE DEL_LOG_Transacoes_st_bin_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'st_bin_cartao' into var_find;
if var_find = 1 then 
ALTER TABLE `LOG_Transacoes` DROP COLUMN `st_bin_cartao` ;
end if;
END;
##CMD

CALL DEL_LOG_Transacoes_st_bin_cartao ( );
##CMD
DROP PROCEDURE  DEL_LOG_Transacoes_st_bin_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_nu_cod_erro;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_nu_cod_erro ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'nu_cod_erro' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `nu_cod_erro` BIGINT;
end if;
select count(*) from LOG_Transacoes where nu_cod_erro is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set nu_cod_erro = 0 where nu_cod_erro is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_nu_cod_erro ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_nu_cod_erro;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_tg_confirmada;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_tg_confirmada ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'tg_confirmada' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `tg_confirmada` VARCHAR(1);
else
ALTER TABLE `LOG_Transacoes` MODIFY `tg_confirmada` VARCHAR(1);
end if;
select count(*) from LOG_Transacoes where tg_confirmada is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set tg_confirmada = '' where tg_confirmada is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_tg_confirmada ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_tg_confirmada;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_nu_nsuOrig;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_nu_nsuOrig ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'nu_nsuOrig' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `nu_nsuOrig` BIGINT;
end if;
select count(*) from LOG_Transacoes where nu_nsuOrig is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set nu_nsuOrig = 0 where nu_nsuOrig is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_nu_nsuOrig ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_nu_nsuOrig;
##CMD

DROP PROCEDURE IF EXISTS DEL_LOG_Transacoes_nu_nsuEntOrig;
##CMD
CREATE PROCEDURE DEL_LOG_Transacoes_nu_nsuEntOrig ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'nu_nsuEntOrig' into var_find;
if var_find = 1 then 
ALTER TABLE `LOG_Transacoes` DROP COLUMN `nu_nsuEntOrig` ;
end if;
END;
##CMD

CALL DEL_LOG_Transacoes_nu_nsuEntOrig ( );
##CMD
DROP PROCEDURE  DEL_LOG_Transacoes_nu_nsuEntOrig;
##CMD

DROP PROCEDURE IF EXISTS DEL_LOG_Transacoes_dt_transOrig;
##CMD
CREATE PROCEDURE DEL_LOG_Transacoes_dt_transOrig ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'dt_transOrig' into var_find;
if var_find = 1 then 
ALTER TABLE `LOG_Transacoes` DROP COLUMN `dt_transOrig` ;
end if;
END;
##CMD

CALL DEL_LOG_Transacoes_dt_transOrig ( );
##CMD
DROP PROCEDURE  DEL_LOG_Transacoes_dt_transOrig;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_en_operacao;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_en_operacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'en_operacao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `en_operacao` VARCHAR(10);
else
ALTER TABLE `LOG_Transacoes` MODIFY `en_operacao` VARCHAR(10);
end if;
select count(*) from LOG_Transacoes where en_operacao is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set en_operacao = '' where en_operacao is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_en_operacao ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_en_operacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_st_msg_transacao;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_st_msg_transacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'st_msg_transacao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `st_msg_transacao` VARCHAR(50);
else
ALTER TABLE `LOG_Transacoes` MODIFY `st_msg_transacao` VARCHAR(50);
end if;
select count(*) from LOG_Transacoes where st_msg_transacao is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set st_msg_transacao = '' where st_msg_transacao is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_st_msg_transacao ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_st_msg_transacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_tg_contabil;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_tg_contabil ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'tg_contabil' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `tg_contabil` VARCHAR(1);
else
ALTER TABLE `LOG_Transacoes` MODIFY `tg_contabil` VARCHAR(1);
end if;
select count(*) from LOG_Transacoes where tg_contabil is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set tg_contabil = '' where tg_contabil is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_tg_contabil ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_tg_contabil;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_fk_loja;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_fk_loja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'fk_loja' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `fk_loja` BIGINT;
end if;
select count(*) from LOG_Transacoes where fk_loja is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set fk_loja = 0 where fk_loja is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'fk_loja' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD INDEX `index_fk_loja`(fk_loja);
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_fk_loja ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_fk_loja;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_vr_saldo_disp;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_vr_saldo_disp ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'vr_saldo_disp' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `vr_saldo_disp` BIGINT;
end if;
select count(*) from LOG_Transacoes where vr_saldo_disp is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set vr_saldo_disp = 0 where vr_saldo_disp is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_vr_saldo_disp ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_vr_saldo_disp;
##CMD

DROP PROCEDURE IF EXISTS DEL_LOG_Transacoes_vr_saldo_disp_edu;
##CMD
CREATE PROCEDURE DEL_LOG_Transacoes_vr_saldo_disp_edu ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'vr_saldo_disp_edu' into var_find;
if var_find = 1 then 
ALTER TABLE `LOG_Transacoes` DROP COLUMN `vr_saldo_disp_edu` ;
end if;
END;
##CMD

CALL DEL_LOG_Transacoes_vr_saldo_disp_edu ( );
##CMD
DROP PROCEDURE  DEL_LOG_Transacoes_vr_saldo_disp_edu;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_vr_saldo_disp_tot;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_vr_saldo_disp_tot ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'vr_saldo_disp_tot' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `vr_saldo_disp_tot` BIGINT;
end if;
select count(*) from LOG_Transacoes where vr_saldo_disp_tot is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set vr_saldo_disp_tot = 0 where vr_saldo_disp_tot is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_vr_saldo_disp_tot ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_vr_saldo_disp_tot;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Transacoes_st_doc;
##CMD

CREATE PROCEDURE ADD_LOG_Transacoes_st_doc ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Transacoes' and column_name = 'st_doc' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Transacoes` ADD COLUMN `st_doc` VARCHAR(20);
else
ALTER TABLE `LOG_Transacoes` MODIFY `st_doc` VARCHAR(20);
end if;
select count(*) from LOG_Transacoes where st_doc is null into var_find;
if var_find > 0 then 
update LOG_Transacoes set st_doc = '' where st_doc is null;
end if;
END;
##CMD
CALL ADD_LOG_Transacoes_st_doc ( );
##CMD
DROP PROCEDURE  ADD_LOG_Transacoes_st_doc;
##CMD


CREATE TABLE IF NOT EXISTS `T_Parcelas` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`nu_nsu` BIGINT UNSIGNED,
`fk_empresa` BIGINT UNSIGNED,
`fk_cartao` BIGINT UNSIGNED,
`dt_inclusao` DATETIME,
`nu_parcela` BIGINT UNSIGNED,
`vr_valor` BIGINT UNSIGNED,
`nu_indice` BIGINT UNSIGNED,
`tg_pago` VARCHAR(1),
`fk_loja` BIGINT UNSIGNED,
`nu_tot_parcelas` BIGINT UNSIGNED,
`fk_terminal` BIGINT UNSIGNED,
`fk_log_transacoes` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Parcelas_nu_nsuEntidade;
##CMD
CREATE PROCEDURE DEL_T_Parcelas_nu_nsuEntidade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'nu_nsuEntidade' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Parcelas` DROP COLUMN `nu_nsuEntidade` ;
end if;
END;
##CMD

CALL DEL_T_Parcelas_nu_nsuEntidade ( );
##CMD
DROP PROCEDURE  DEL_T_Parcelas_nu_nsuEntidade;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_nu_nsu;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_nu_nsu ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'nu_nsu' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `nu_nsu` BIGINT;
end if;
select count(*) from T_Parcelas where nu_nsu is null into var_find;
if var_find > 0 then 
update T_Parcelas set nu_nsu = 0 where nu_nsu is null;
end if;
END;
##CMD
CALL ADD_T_Parcelas_nu_nsu ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_nu_nsu;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_fk_empresa;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from T_Parcelas where fk_empresa is null into var_find;
if var_find > 0 then 
update T_Parcelas set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_T_Parcelas_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_fk_cartao;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from T_Parcelas where fk_cartao is null into var_find;
if var_find > 0 then 
update T_Parcelas set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_T_Parcelas_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_dt_inclusao;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_dt_inclusao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'dt_inclusao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `dt_inclusao` DATETIME;
end if;
select count(*) from T_Parcelas where dt_inclusao is null into var_find;
if var_find > 0 then 
update T_Parcelas set dt_inclusao = '1900-01-01 00:00:00.000' where dt_inclusao is null;
end if;
END;
##CMD
CALL ADD_T_Parcelas_dt_inclusao ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_dt_inclusao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_nu_parcela;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_nu_parcela ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'nu_parcela' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `nu_parcela` BIGINT;
end if;
select count(*) from T_Parcelas where nu_parcela is null into var_find;
if var_find > 0 then 
update T_Parcelas set nu_parcela = 0 where nu_parcela is null;
end if;
END;
##CMD
CALL ADD_T_Parcelas_nu_parcela ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_nu_parcela;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_vr_valor;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_vr_valor ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'vr_valor' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `vr_valor` BIGINT;
end if;
select count(*) from T_Parcelas where vr_valor is null into var_find;
if var_find > 0 then 
update T_Parcelas set vr_valor = 0 where vr_valor is null;
end if;
END;
##CMD
CALL ADD_T_Parcelas_vr_valor ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_vr_valor;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Parcelas_dt_pagto_parcela;
##CMD
CREATE PROCEDURE DEL_T_Parcelas_dt_pagto_parcela ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'dt_pagto_parcela' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Parcelas` DROP COLUMN `dt_pagto_parcela` ;
end if;
END;
##CMD

CALL DEL_T_Parcelas_dt_pagto_parcela ( );
##CMD
DROP PROCEDURE  DEL_T_Parcelas_dt_pagto_parcela;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_nu_indice;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_nu_indice ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'nu_indice' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `nu_indice` BIGINT;
end if;
select count(*) from T_Parcelas where nu_indice is null into var_find;
if var_find > 0 then 
update T_Parcelas set nu_indice = 0 where nu_indice is null;
end if;
END;
##CMD
CALL ADD_T_Parcelas_nu_indice ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_nu_indice;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_tg_pago;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_tg_pago ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'tg_pago' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `tg_pago` VARCHAR(1);
else
ALTER TABLE `T_Parcelas` MODIFY `tg_pago` VARCHAR(1);
end if;
select count(*) from T_Parcelas where tg_pago is null into var_find;
if var_find > 0 then 
update T_Parcelas set tg_pago = '' where tg_pago is null;
end if;
END;
##CMD
CALL ADD_T_Parcelas_tg_pago ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_tg_pago;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Parcelas_nu_cod_erro;
##CMD
CREATE PROCEDURE DEL_T_Parcelas_nu_cod_erro ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'nu_cod_erro' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Parcelas` DROP COLUMN `nu_cod_erro` ;
end if;
END;
##CMD

CALL DEL_T_Parcelas_nu_cod_erro ( );
##CMD
DROP PROCEDURE  DEL_T_Parcelas_nu_cod_erro;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Parcelas_tg_confirmada;
##CMD
CREATE PROCEDURE DEL_T_Parcelas_tg_confirmada ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'tg_confirmada' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Parcelas` DROP COLUMN `tg_confirmada` ;
end if;
END;
##CMD

CALL DEL_T_Parcelas_tg_confirmada ( );
##CMD
DROP PROCEDURE  DEL_T_Parcelas_tg_confirmada;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_fk_loja;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_fk_loja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'fk_loja' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `fk_loja` BIGINT;
end if;
select count(*) from T_Parcelas where fk_loja is null into var_find;
if var_find > 0 then 
update T_Parcelas set fk_loja = 0 where fk_loja is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'fk_loja' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD INDEX `index_fk_loja`(fk_loja);
end if;
END;
##CMD
CALL ADD_T_Parcelas_fk_loja ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_fk_loja;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_nu_tot_parcelas;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_nu_tot_parcelas ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'nu_tot_parcelas' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `nu_tot_parcelas` BIGINT;
end if;
select count(*) from T_Parcelas where nu_tot_parcelas is null into var_find;
if var_find > 0 then 
update T_Parcelas set nu_tot_parcelas = 0 where nu_tot_parcelas is null;
end if;
END;
##CMD
CALL ADD_T_Parcelas_nu_tot_parcelas ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_nu_tot_parcelas;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_fk_terminal;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_fk_terminal ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'fk_terminal' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `fk_terminal` BIGINT;
end if;
select count(*) from T_Parcelas where fk_terminal is null into var_find;
if var_find > 0 then 
update T_Parcelas set fk_terminal = 0 where fk_terminal is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'fk_terminal' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD INDEX `index_fk_terminal`(fk_terminal);
end if;
END;
##CMD
CALL ADD_T_Parcelas_fk_terminal ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_fk_terminal;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Parcelas_fk_log_transacoes;
##CMD

CREATE PROCEDURE ADD_T_Parcelas_fk_log_transacoes ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'fk_log_transacoes' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD COLUMN `fk_log_transacoes` BIGINT;
end if;
select count(*) from T_Parcelas where fk_log_transacoes is null into var_find;
if var_find > 0 then 
update T_Parcelas set fk_log_transacoes = 0 where fk_log_transacoes is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Parcelas' and column_name = 'fk_log_transacoes' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Parcelas` ADD INDEX `index_fk_log_transacoes`(fk_log_transacoes);
end if;
END;
##CMD
CALL ADD_T_Parcelas_fk_log_transacoes ( );
##CMD
DROP PROCEDURE  ADD_T_Parcelas_fk_log_transacoes;
##CMD


CREATE TABLE IF NOT EXISTS `T_PayFone` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_telefone` VARCHAR(10),
`tg_tipoCelular` VARCHAR(1),
`fk_cartao` BIGINT UNSIGNED,
`fk_terminal` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PayFone_st_telefone;
##CMD

CREATE PROCEDURE ADD_T_PayFone_st_telefone ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PayFone' and column_name = 'st_telefone' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PayFone` ADD COLUMN `st_telefone` VARCHAR(10);
else
ALTER TABLE `T_PayFone` MODIFY `st_telefone` VARCHAR(10);
end if;
select count(*) from T_PayFone where st_telefone is null into var_find;
if var_find > 0 then 
update T_PayFone set st_telefone = '' where st_telefone is null;
end if;
END;
##CMD
CALL ADD_T_PayFone_st_telefone ( );
##CMD
DROP PROCEDURE  ADD_T_PayFone_st_telefone;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PayFone_tg_tipoCelular;
##CMD

CREATE PROCEDURE ADD_T_PayFone_tg_tipoCelular ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PayFone' and column_name = 'tg_tipoCelular' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PayFone` ADD COLUMN `tg_tipoCelular` VARCHAR(1);
else
ALTER TABLE `T_PayFone` MODIFY `tg_tipoCelular` VARCHAR(1);
end if;
select count(*) from T_PayFone where tg_tipoCelular is null into var_find;
if var_find > 0 then 
update T_PayFone set tg_tipoCelular = '' where tg_tipoCelular is null;
end if;
END;
##CMD
CALL ADD_T_PayFone_tg_tipoCelular ( );
##CMD
DROP PROCEDURE  ADD_T_PayFone_tg_tipoCelular;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PayFone_fk_cartao;
##CMD

CREATE PROCEDURE ADD_T_PayFone_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PayFone' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PayFone` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from T_PayFone where fk_cartao is null into var_find;
if var_find > 0 then 
update T_PayFone set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PayFone' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PayFone` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_T_PayFone_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_T_PayFone_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PayFone_fk_terminal;
##CMD

CREATE PROCEDURE ADD_T_PayFone_fk_terminal ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PayFone' and column_name = 'fk_terminal' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PayFone` ADD COLUMN `fk_terminal` BIGINT;
end if;
select count(*) from T_PayFone where fk_terminal is null into var_find;
if var_find > 0 then 
update T_PayFone set fk_terminal = 0 where fk_terminal is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PayFone' and column_name = 'fk_terminal' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PayFone` ADD INDEX `index_fk_terminal`(fk_terminal);
end if;
END;
##CMD
CALL ADD_T_PayFone_fk_terminal ( );
##CMD
DROP PROCEDURE  ADD_T_PayFone_fk_terminal;
##CMD


CREATE TABLE IF NOT EXISTS `T_PendPayFone` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_cartao` BIGINT UNSIGNED,
`fk_terminal` BIGINT UNSIGNED,
`nu_nsu` BIGINT UNSIGNED,
`vr_valor` BIGINT UNSIGNED,
`dt_inclusao` DATETIME,
`en_situacao` VARCHAR(1),
`fk_empresa` BIGINT UNSIGNED,
`fk_loja` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PendPayFone_fk_cartao;
##CMD

CREATE PROCEDURE ADD_T_PendPayFone_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from T_PendPayFone where fk_cartao is null into var_find;
if var_find > 0 then 
update T_PendPayFone set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_T_PendPayFone_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_T_PendPayFone_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PendPayFone_fk_terminal;
##CMD

CREATE PROCEDURE ADD_T_PendPayFone_fk_terminal ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'fk_terminal' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD COLUMN `fk_terminal` BIGINT;
end if;
select count(*) from T_PendPayFone where fk_terminal is null into var_find;
if var_find > 0 then 
update T_PendPayFone set fk_terminal = 0 where fk_terminal is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'fk_terminal' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD INDEX `index_fk_terminal`(fk_terminal);
end if;
END;
##CMD
CALL ADD_T_PendPayFone_fk_terminal ( );
##CMD
DROP PROCEDURE  ADD_T_PendPayFone_fk_terminal;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PendPayFone_nu_nsu;
##CMD

CREATE PROCEDURE ADD_T_PendPayFone_nu_nsu ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'nu_nsu' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD COLUMN `nu_nsu` BIGINT;
end if;
select count(*) from T_PendPayFone where nu_nsu is null into var_find;
if var_find > 0 then 
update T_PendPayFone set nu_nsu = 0 where nu_nsu is null;
end if;
END;
##CMD
CALL ADD_T_PendPayFone_nu_nsu ( );
##CMD
DROP PROCEDURE  ADD_T_PendPayFone_nu_nsu;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PendPayFone_vr_valor;
##CMD

CREATE PROCEDURE ADD_T_PendPayFone_vr_valor ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'vr_valor' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD COLUMN `vr_valor` BIGINT;
end if;
select count(*) from T_PendPayFone where vr_valor is null into var_find;
if var_find > 0 then 
update T_PendPayFone set vr_valor = 0 where vr_valor is null;
end if;
END;
##CMD
CALL ADD_T_PendPayFone_vr_valor ( );
##CMD
DROP PROCEDURE  ADD_T_PendPayFone_vr_valor;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PendPayFone_dt_inclusao;
##CMD

CREATE PROCEDURE ADD_T_PendPayFone_dt_inclusao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'dt_inclusao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD COLUMN `dt_inclusao` DATETIME;
end if;
select count(*) from T_PendPayFone where dt_inclusao is null into var_find;
if var_find > 0 then 
update T_PendPayFone set dt_inclusao = '1900-01-01 00:00:00.000' where dt_inclusao is null;
end if;
END;
##CMD
CALL ADD_T_PendPayFone_dt_inclusao ( );
##CMD
DROP PROCEDURE  ADD_T_PendPayFone_dt_inclusao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PendPayFone_en_situacao;
##CMD

CREATE PROCEDURE ADD_T_PendPayFone_en_situacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'en_situacao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD COLUMN `en_situacao` VARCHAR(1);
else
ALTER TABLE `T_PendPayFone` MODIFY `en_situacao` VARCHAR(1);
end if;
select count(*) from T_PendPayFone where en_situacao is null into var_find;
if var_find > 0 then 
update T_PendPayFone set en_situacao = '' where en_situacao is null;
end if;
END;
##CMD
CALL ADD_T_PendPayFone_en_situacao ( );
##CMD
DROP PROCEDURE  ADD_T_PendPayFone_en_situacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PendPayFone_fk_empresa;
##CMD

CREATE PROCEDURE ADD_T_PendPayFone_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from T_PendPayFone where fk_empresa is null into var_find;
if var_find > 0 then 
update T_PendPayFone set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_T_PendPayFone_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_PendPayFone_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_PendPayFone_fk_loja;
##CMD

CREATE PROCEDURE ADD_T_PendPayFone_fk_loja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'fk_loja' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD COLUMN `fk_loja` BIGINT;
end if;
select count(*) from T_PendPayFone where fk_loja is null into var_find;
if var_find > 0 then 
update T_PendPayFone set fk_loja = 0 where fk_loja is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_PendPayFone' and column_name = 'fk_loja' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_PendPayFone` ADD INDEX `index_fk_loja`(fk_loja);
end if;
END;
##CMD
CALL ADD_T_PendPayFone_fk_loja ( );
##CMD
DROP PROCEDURE  ADD_T_PendPayFone_fk_loja;
##CMD


CREATE TABLE IF NOT EXISTS `LINK_PFAtivacao` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_payfone` BIGINT UNSIGNED,
`dt_ativacao` DATETIME,
`st_ativacao` VARCHAR(50),
`tg_status` VARCHAR(1),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_PFAtivacao_fk_payfone;
##CMD

CREATE PROCEDURE ADD_LINK_PFAtivacao_fk_payfone ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_PFAtivacao' and column_name = 'fk_payfone' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_PFAtivacao` ADD COLUMN `fk_payfone` BIGINT;
end if;
select count(*) from LINK_PFAtivacao where fk_payfone is null into var_find;
if var_find > 0 then 
update LINK_PFAtivacao set fk_payfone = 0 where fk_payfone is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_PFAtivacao' and column_name = 'fk_payfone' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_PFAtivacao` ADD INDEX `index_fk_payfone`(fk_payfone);
end if;
END;
##CMD
CALL ADD_LINK_PFAtivacao_fk_payfone ( );
##CMD
DROP PROCEDURE  ADD_LINK_PFAtivacao_fk_payfone;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_PFAtivacao_dt_ativacao;
##CMD

CREATE PROCEDURE ADD_LINK_PFAtivacao_dt_ativacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_PFAtivacao' and column_name = 'dt_ativacao' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_PFAtivacao` ADD COLUMN `dt_ativacao` DATETIME;
end if;
select count(*) from LINK_PFAtivacao where dt_ativacao is null into var_find;
if var_find > 0 then 
update LINK_PFAtivacao set dt_ativacao = '1900-01-01 00:00:00.000' where dt_ativacao is null;
end if;
END;
##CMD
CALL ADD_LINK_PFAtivacao_dt_ativacao ( );
##CMD
DROP PROCEDURE  ADD_LINK_PFAtivacao_dt_ativacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_PFAtivacao_st_ativacao;
##CMD

CREATE PROCEDURE ADD_LINK_PFAtivacao_st_ativacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_PFAtivacao' and column_name = 'st_ativacao' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_PFAtivacao` ADD COLUMN `st_ativacao` VARCHAR(50);
else
ALTER TABLE `LINK_PFAtivacao` MODIFY `st_ativacao` VARCHAR(50);
end if;
select count(*) from LINK_PFAtivacao where st_ativacao is null into var_find;
if var_find > 0 then 
update LINK_PFAtivacao set st_ativacao = '' where st_ativacao is null;
end if;
END;
##CMD
CALL ADD_LINK_PFAtivacao_st_ativacao ( );
##CMD
DROP PROCEDURE  ADD_LINK_PFAtivacao_st_ativacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_PFAtivacao_tg_status;
##CMD

CREATE PROCEDURE ADD_LINK_PFAtivacao_tg_status ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_PFAtivacao' and column_name = 'tg_status' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_PFAtivacao` ADD COLUMN `tg_status` VARCHAR(1);
else
ALTER TABLE `LINK_PFAtivacao` MODIFY `tg_status` VARCHAR(1);
end if;
select count(*) from LINK_PFAtivacao where tg_status is null into var_find;
if var_find > 0 then 
update LINK_PFAtivacao set tg_status = '' where tg_status is null;
end if;
END;
##CMD
CALL ADD_LINK_PFAtivacao_tg_status ( );
##CMD
DROP PROCEDURE  ADD_LINK_PFAtivacao_tg_status;
##CMD


CREATE TABLE IF NOT EXISTS `LINK_Agenda` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_schedule` BIGINT UNSIGNED,
`fk_empresa` BIGINT UNSIGNED,
`en_atividade` BIGINT UNSIGNED,
`st_emp_afiliada` VARCHAR(20),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_Agenda_fk_schedule;
##CMD

CREATE PROCEDURE ADD_LINK_Agenda_fk_schedule ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Agenda' and column_name = 'fk_schedule' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_Agenda` ADD COLUMN `fk_schedule` BIGINT;
end if;
select count(*) from LINK_Agenda where fk_schedule is null into var_find;
if var_find > 0 then 
update LINK_Agenda set fk_schedule = 0 where fk_schedule is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Agenda' and column_name = 'fk_schedule' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_Agenda` ADD INDEX `index_fk_schedule`(fk_schedule);
end if;
END;
##CMD
CALL ADD_LINK_Agenda_fk_schedule ( );
##CMD
DROP PROCEDURE  ADD_LINK_Agenda_fk_schedule;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_Agenda_fk_empresa;
##CMD

CREATE PROCEDURE ADD_LINK_Agenda_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Agenda' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_Agenda` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from LINK_Agenda where fk_empresa is null into var_find;
if var_find > 0 then 
update LINK_Agenda set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Agenda' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_Agenda` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_LINK_Agenda_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_LINK_Agenda_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_Agenda_en_atividade;
##CMD

CREATE PROCEDURE ADD_LINK_Agenda_en_atividade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Agenda' and column_name = 'en_atividade' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_Agenda` ADD COLUMN `en_atividade` BIGINT;
end if;
select count(*) from LINK_Agenda where en_atividade is null into var_find;
if var_find > 0 then 
update LINK_Agenda set en_atividade = 0 where en_atividade is null;
end if;
END;
##CMD
CALL ADD_LINK_Agenda_en_atividade ( );
##CMD
DROP PROCEDURE  ADD_LINK_Agenda_en_atividade;
##CMD

DROP PROCEDURE IF EXISTS DEL_LINK_Agenda_st_afiliada;
##CMD
CREATE PROCEDURE DEL_LINK_Agenda_st_afiliada ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Agenda' and column_name = 'st_afiliada' into var_find;
if var_find = 1 then 
ALTER TABLE `LINK_Agenda` DROP COLUMN `st_afiliada` ;
end if;
END;
##CMD

CALL DEL_LINK_Agenda_st_afiliada ( );
##CMD
DROP PROCEDURE  DEL_LINK_Agenda_st_afiliada;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_Agenda_st_emp_afiliada;
##CMD

CREATE PROCEDURE ADD_LINK_Agenda_st_emp_afiliada ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Agenda' and column_name = 'st_emp_afiliada' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_Agenda` ADD COLUMN `st_emp_afiliada` VARCHAR(20);
else
ALTER TABLE `LINK_Agenda` MODIFY `st_emp_afiliada` VARCHAR(20);
end if;
select count(*) from LINK_Agenda where st_emp_afiliada is null into var_find;
if var_find > 0 then 
update LINK_Agenda set st_emp_afiliada = '' where st_emp_afiliada is null;
end if;
END;
##CMD
CALL ADD_LINK_Agenda_st_emp_afiliada ( );
##CMD
DROP PROCEDURE  ADD_LINK_Agenda_st_emp_afiliada;
##CMD


CREATE TABLE IF NOT EXISTS `LOG_Fechamento` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_mes` VARCHAR(2),
`st_ano` VARCHAR(4),
`vr_valor` BIGINT UNSIGNED,
`dt_fechamento` DATETIME,
`fk_empresa` BIGINT UNSIGNED,
`fk_loja` BIGINT UNSIGNED,
`fk_cartao` BIGINT UNSIGNED,
`fk_parcela` BIGINT UNSIGNED,
`dt_compra` DATETIME,
`nu_parcela` BIGINT UNSIGNED,
`st_cartao` VARCHAR(14),
`st_afiliada` VARCHAR(20),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_st_mes;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_st_mes ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'st_mes' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `st_mes` VARCHAR(2);
else
ALTER TABLE `LOG_Fechamento` MODIFY `st_mes` VARCHAR(2);
end if;
select count(*) from LOG_Fechamento where st_mes is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set st_mes = '' where st_mes is null;
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_st_mes ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_st_mes;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_st_ano;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_st_ano ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'st_ano' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `st_ano` VARCHAR(4);
else
ALTER TABLE `LOG_Fechamento` MODIFY `st_ano` VARCHAR(4);
end if;
select count(*) from LOG_Fechamento where st_ano is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set st_ano = '' where st_ano is null;
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_st_ano ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_st_ano;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_vr_valor;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_vr_valor ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'vr_valor' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `vr_valor` BIGINT;
end if;
select count(*) from LOG_Fechamento where vr_valor is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set vr_valor = 0 where vr_valor is null;
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_vr_valor ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_vr_valor;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_dt_fechamento;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_dt_fechamento ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'dt_fechamento' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `dt_fechamento` DATETIME;
end if;
select count(*) from LOG_Fechamento where dt_fechamento is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set dt_fechamento = '1900-01-01 00:00:00.000' where dt_fechamento is null;
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_dt_fechamento ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_dt_fechamento;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_fk_empresa;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from LOG_Fechamento where fk_empresa is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_fk_loja;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_fk_loja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'fk_loja' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `fk_loja` BIGINT;
end if;
select count(*) from LOG_Fechamento where fk_loja is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set fk_loja = 0 where fk_loja is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'fk_loja' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD INDEX `index_fk_loja`(fk_loja);
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_fk_loja ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_fk_loja;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_fk_cartao;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from LOG_Fechamento where fk_cartao is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_fk_parcela;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_fk_parcela ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'fk_parcela' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `fk_parcela` BIGINT;
end if;
select count(*) from LOG_Fechamento where fk_parcela is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set fk_parcela = 0 where fk_parcela is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'fk_parcela' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD INDEX `index_fk_parcela`(fk_parcela);
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_fk_parcela ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_fk_parcela;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_dt_compra;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_dt_compra ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'dt_compra' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `dt_compra` DATETIME;
end if;
select count(*) from LOG_Fechamento where dt_compra is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set dt_compra = '1900-01-01 00:00:00.000' where dt_compra is null;
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_dt_compra ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_dt_compra;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_nu_parcela;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_nu_parcela ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'nu_parcela' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `nu_parcela` BIGINT;
end if;
select count(*) from LOG_Fechamento where nu_parcela is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set nu_parcela = 0 where nu_parcela is null;
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_nu_parcela ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_nu_parcela;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_st_cartao;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_st_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'st_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `st_cartao` VARCHAR(14);
else
ALTER TABLE `LOG_Fechamento` MODIFY `st_cartao` VARCHAR(14);
end if;
select count(*) from LOG_Fechamento where st_cartao is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set st_cartao = '' where st_cartao is null;
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_st_cartao ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_st_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Fechamento_st_afiliada;
##CMD

CREATE PROCEDURE ADD_LOG_Fechamento_st_afiliada ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Fechamento' and column_name = 'st_afiliada' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Fechamento` ADD COLUMN `st_afiliada` VARCHAR(20);
else
ALTER TABLE `LOG_Fechamento` MODIFY `st_afiliada` VARCHAR(20);
end if;
select count(*) from LOG_Fechamento where st_afiliada is null into var_find;
if var_find > 0 then 
update LOG_Fechamento set st_afiliada = '' where st_afiliada is null;
end if;
END;
##CMD
CALL ADD_LOG_Fechamento_st_afiliada ( );
##CMD
DROP PROCEDURE  ADD_LOG_Fechamento_st_afiliada;
##CMD


CREATE TABLE IF NOT EXISTS `I_Batch` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_archive` VARCHAR(999),
`dt_start` DATETIME,
`dt_proc_start` DATETIME,
`dt_proc_end` DATETIME,
`tg_processed` VARCHAR(1),
`tg_running` VARCHAR(1),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Batch_st_archive;
##CMD

CREATE PROCEDURE ADD_I_Batch_st_archive ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Batch' and column_name = 'st_archive' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Batch` ADD COLUMN `st_archive` VARCHAR(999);
else
ALTER TABLE `I_Batch` MODIFY `st_archive` VARCHAR(999);
end if;
select count(*) from I_Batch where st_archive is null into var_find;
if var_find > 0 then 
update I_Batch set st_archive = '' where st_archive is null;
end if;
END;
##CMD
CALL ADD_I_Batch_st_archive ( );
##CMD
DROP PROCEDURE  ADD_I_Batch_st_archive;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Batch_dt_start;
##CMD

CREATE PROCEDURE ADD_I_Batch_dt_start ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Batch' and column_name = 'dt_start' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Batch` ADD COLUMN `dt_start` DATETIME;
end if;
select count(*) from I_Batch where dt_start is null into var_find;
if var_find > 0 then 
update I_Batch set dt_start = '1900-01-01 00:00:00.000' where dt_start is null;
end if;
END;
##CMD
CALL ADD_I_Batch_dt_start ( );
##CMD
DROP PROCEDURE  ADD_I_Batch_dt_start;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Batch_dt_proc_start;
##CMD

CREATE PROCEDURE ADD_I_Batch_dt_proc_start ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Batch' and column_name = 'dt_proc_start' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Batch` ADD COLUMN `dt_proc_start` DATETIME;
end if;
select count(*) from I_Batch where dt_proc_start is null into var_find;
if var_find > 0 then 
update I_Batch set dt_proc_start = '1900-01-01 00:00:00.000' where dt_proc_start is null;
end if;
END;
##CMD
CALL ADD_I_Batch_dt_proc_start ( );
##CMD
DROP PROCEDURE  ADD_I_Batch_dt_proc_start;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Batch_dt_proc_end;
##CMD

CREATE PROCEDURE ADD_I_Batch_dt_proc_end ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Batch' and column_name = 'dt_proc_end' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Batch` ADD COLUMN `dt_proc_end` DATETIME;
end if;
select count(*) from I_Batch where dt_proc_end is null into var_find;
if var_find > 0 then 
update I_Batch set dt_proc_end = '1900-01-01 00:00:00.000' where dt_proc_end is null;
end if;
END;
##CMD
CALL ADD_I_Batch_dt_proc_end ( );
##CMD
DROP PROCEDURE  ADD_I_Batch_dt_proc_end;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Batch_tg_processed;
##CMD

CREATE PROCEDURE ADD_I_Batch_tg_processed ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Batch' and column_name = 'tg_processed' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Batch` ADD COLUMN `tg_processed` VARCHAR(1);
else
ALTER TABLE `I_Batch` MODIFY `tg_processed` VARCHAR(1);
end if;
select count(*) from I_Batch where tg_processed is null into var_find;
if var_find > 0 then 
update I_Batch set tg_processed = '' where tg_processed is null;
end if;
END;
##CMD
CALL ADD_I_Batch_tg_processed ( );
##CMD
DROP PROCEDURE  ADD_I_Batch_tg_processed;
##CMD

DROP PROCEDURE IF EXISTS ADD_I_Batch_tg_running;
##CMD

CREATE PROCEDURE ADD_I_Batch_tg_running ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'I_Batch' and column_name = 'tg_running' into var_find;
if var_find = 0 then 
ALTER TABLE `I_Batch` ADD COLUMN `tg_running` VARCHAR(1);
else
ALTER TABLE `I_Batch` MODIFY `tg_running` VARCHAR(1);
end if;
select count(*) from I_Batch where tg_running is null into var_find;
if var_find > 0 then 
update I_Batch set tg_running = '' where tg_running is null;
end if;
END;
##CMD
CALL ADD_I_Batch_tg_running ( );
##CMD
DROP PROCEDURE  ADD_I_Batch_tg_running;
##CMD


CREATE TABLE IF NOT EXISTS `T_Edu_EmpresaVirtual` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_nome` VARCHAR(99),
`st_codigo` VARCHAR(20),
`vr_valorAcao` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_EmpresaVirtual_st_nome;
##CMD

CREATE PROCEDURE ADD_T_Edu_EmpresaVirtual_st_nome ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_EmpresaVirtual' and column_name = 'st_nome' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_EmpresaVirtual` ADD COLUMN `st_nome` VARCHAR(99);
else
ALTER TABLE `T_Edu_EmpresaVirtual` MODIFY `st_nome` VARCHAR(99);
end if;
select count(*) from T_Edu_EmpresaVirtual where st_nome is null into var_find;
if var_find > 0 then 
update T_Edu_EmpresaVirtual set st_nome = '' where st_nome is null;
end if;
END;
##CMD
CALL ADD_T_Edu_EmpresaVirtual_st_nome ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_EmpresaVirtual_st_nome;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_EmpresaVirtual_st_codigo;
##CMD

CREATE PROCEDURE ADD_T_Edu_EmpresaVirtual_st_codigo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_EmpresaVirtual' and column_name = 'st_codigo' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_EmpresaVirtual` ADD COLUMN `st_codigo` VARCHAR(20);
else
ALTER TABLE `T_Edu_EmpresaVirtual` MODIFY `st_codigo` VARCHAR(20);
end if;
select count(*) from T_Edu_EmpresaVirtual where st_codigo is null into var_find;
if var_find > 0 then 
update T_Edu_EmpresaVirtual set st_codigo = '' where st_codigo is null;
end if;
END;
##CMD
CALL ADD_T_Edu_EmpresaVirtual_st_codigo ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_EmpresaVirtual_st_codigo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_EmpresaVirtual_vr_valorAcao;
##CMD

CREATE PROCEDURE ADD_T_Edu_EmpresaVirtual_vr_valorAcao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_EmpresaVirtual' and column_name = 'vr_valorAcao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_EmpresaVirtual` ADD COLUMN `vr_valorAcao` BIGINT;
end if;
select count(*) from T_Edu_EmpresaVirtual where vr_valorAcao is null into var_find;
if var_find > 0 then 
update T_Edu_EmpresaVirtual set vr_valorAcao = 0 where vr_valorAcao is null;
end if;
END;
##CMD
CALL ADD_T_Edu_EmpresaVirtual_vr_valorAcao ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_EmpresaVirtual_vr_valorAcao;
##CMD


CREATE TABLE IF NOT EXISTS `T_Edu_AplicacaoVirtual` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_cartao` BIGINT UNSIGNED,
`fk_empresaVirtual` BIGINT UNSIGNED,
`vr_aplicado` BIGINT UNSIGNED,
`dt_aplic` DATETIME,
`tg_neg` VARCHAR(1),
`vr_fundo_hora` BIGINT UNSIGNED,
`vr_preco_fundo` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_AplicacaoVirtual_fk_cartao;
##CMD

CREATE PROCEDURE ADD_T_Edu_AplicacaoVirtual_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_AplicacaoVirtual' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_AplicacaoVirtual` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from T_Edu_AplicacaoVirtual where fk_cartao is null into var_find;
if var_find > 0 then 
update T_Edu_AplicacaoVirtual set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_AplicacaoVirtual' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_AplicacaoVirtual` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_T_Edu_AplicacaoVirtual_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_AplicacaoVirtual_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_AplicacaoVirtual_fk_empresaVirtual;
##CMD

CREATE PROCEDURE ADD_T_Edu_AplicacaoVirtual_fk_empresaVirtual ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_AplicacaoVirtual' and column_name = 'fk_empresaVirtual' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_AplicacaoVirtual` ADD COLUMN `fk_empresaVirtual` BIGINT;
end if;
select count(*) from T_Edu_AplicacaoVirtual where fk_empresaVirtual is null into var_find;
if var_find > 0 then 
update T_Edu_AplicacaoVirtual set fk_empresaVirtual = 0 where fk_empresaVirtual is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_AplicacaoVirtual' and column_name = 'fk_empresaVirtual' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_AplicacaoVirtual` ADD INDEX `index_fk_empresaVirtual`(fk_empresaVirtual);
end if;
END;
##CMD
CALL ADD_T_Edu_AplicacaoVirtual_fk_empresaVirtual ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_AplicacaoVirtual_fk_empresaVirtual;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_AplicacaoVirtual_vr_aplicado;
##CMD

CREATE PROCEDURE ADD_T_Edu_AplicacaoVirtual_vr_aplicado ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_AplicacaoVirtual' and column_name = 'vr_aplicado' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_AplicacaoVirtual` ADD COLUMN `vr_aplicado` BIGINT;
end if;
select count(*) from T_Edu_AplicacaoVirtual where vr_aplicado is null into var_find;
if var_find > 0 then 
update T_Edu_AplicacaoVirtual set vr_aplicado = 0 where vr_aplicado is null;
end if;
END;
##CMD
CALL ADD_T_Edu_AplicacaoVirtual_vr_aplicado ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_AplicacaoVirtual_vr_aplicado;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Edu_AplicacaoVirtual_vr_fundo;
##CMD
CREATE PROCEDURE DEL_T_Edu_AplicacaoVirtual_vr_fundo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_AplicacaoVirtual' and column_name = 'vr_fundo' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Edu_AplicacaoVirtual` DROP COLUMN `vr_fundo` ;
end if;
END;
##CMD

CALL DEL_T_Edu_AplicacaoVirtual_vr_fundo ( );
##CMD
DROP PROCEDURE  DEL_T_Edu_AplicacaoVirtual_vr_fundo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_AplicacaoVirtual_dt_aplic;
##CMD

CREATE PROCEDURE ADD_T_Edu_AplicacaoVirtual_dt_aplic ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_AplicacaoVirtual' and column_name = 'dt_aplic' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_AplicacaoVirtual` ADD COLUMN `dt_aplic` DATETIME;
end if;
select count(*) from T_Edu_AplicacaoVirtual where dt_aplic is null into var_find;
if var_find > 0 then 
update T_Edu_AplicacaoVirtual set dt_aplic = '1900-01-01 00:00:00.000' where dt_aplic is null;
end if;
END;
##CMD
CALL ADD_T_Edu_AplicacaoVirtual_dt_aplic ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_AplicacaoVirtual_dt_aplic;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_AplicacaoVirtual_tg_neg;
##CMD

CREATE PROCEDURE ADD_T_Edu_AplicacaoVirtual_tg_neg ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_AplicacaoVirtual' and column_name = 'tg_neg' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_AplicacaoVirtual` ADD COLUMN `tg_neg` VARCHAR(1);
else
ALTER TABLE `T_Edu_AplicacaoVirtual` MODIFY `tg_neg` VARCHAR(1);
end if;
select count(*) from T_Edu_AplicacaoVirtual where tg_neg is null into var_find;
if var_find > 0 then 
update T_Edu_AplicacaoVirtual set tg_neg = '' where tg_neg is null;
end if;
END;
##CMD
CALL ADD_T_Edu_AplicacaoVirtual_tg_neg ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_AplicacaoVirtual_tg_neg;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_AplicacaoVirtual_vr_fundo_hora;
##CMD

CREATE PROCEDURE ADD_T_Edu_AplicacaoVirtual_vr_fundo_hora ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_AplicacaoVirtual' and column_name = 'vr_fundo_hora' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_AplicacaoVirtual` ADD COLUMN `vr_fundo_hora` BIGINT;
end if;
select count(*) from T_Edu_AplicacaoVirtual where vr_fundo_hora is null into var_find;
if var_find > 0 then 
update T_Edu_AplicacaoVirtual set vr_fundo_hora = 0 where vr_fundo_hora is null;
end if;
END;
##CMD
CALL ADD_T_Edu_AplicacaoVirtual_vr_fundo_hora ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_AplicacaoVirtual_vr_fundo_hora;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_AplicacaoVirtual_vr_preco_fundo;
##CMD

CREATE PROCEDURE ADD_T_Edu_AplicacaoVirtual_vr_preco_fundo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_AplicacaoVirtual' and column_name = 'vr_preco_fundo' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_AplicacaoVirtual` ADD COLUMN `vr_preco_fundo` BIGINT;
end if;
select count(*) from T_Edu_AplicacaoVirtual where vr_preco_fundo is null into var_find;
if var_find > 0 then 
update T_Edu_AplicacaoVirtual set vr_preco_fundo = 0 where vr_preco_fundo is null;
end if;
END;
##CMD
CALL ADD_T_Edu_AplicacaoVirtual_vr_preco_fundo ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_AplicacaoVirtual_vr_preco_fundo;
##CMD


CREATE TABLE IF NOT EXISTS `LOG_Edu_RendimentoEmpresa` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_empresaVirtual` BIGINT UNSIGNED,
`vr_pct` BIGINT UNSIGNED,
`dt_rend` DATETIME,
`tg_neg` VARCHAR(1),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Edu_RendimentoEmpresa_fk_empresaVirtual;
##CMD

CREATE PROCEDURE ADD_LOG_Edu_RendimentoEmpresa_fk_empresaVirtual ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Edu_RendimentoEmpresa' and column_name = 'fk_empresaVirtual' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Edu_RendimentoEmpresa` ADD COLUMN `fk_empresaVirtual` BIGINT;
end if;
select count(*) from LOG_Edu_RendimentoEmpresa where fk_empresaVirtual is null into var_find;
if var_find > 0 then 
update LOG_Edu_RendimentoEmpresa set fk_empresaVirtual = 0 where fk_empresaVirtual is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Edu_RendimentoEmpresa' and column_name = 'fk_empresaVirtual' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Edu_RendimentoEmpresa` ADD INDEX `index_fk_empresaVirtual`(fk_empresaVirtual);
end if;
END;
##CMD
CALL ADD_LOG_Edu_RendimentoEmpresa_fk_empresaVirtual ( );
##CMD
DROP PROCEDURE  ADD_LOG_Edu_RendimentoEmpresa_fk_empresaVirtual;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Edu_RendimentoEmpresa_vr_pct;
##CMD

CREATE PROCEDURE ADD_LOG_Edu_RendimentoEmpresa_vr_pct ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Edu_RendimentoEmpresa' and column_name = 'vr_pct' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Edu_RendimentoEmpresa` ADD COLUMN `vr_pct` BIGINT;
end if;
select count(*) from LOG_Edu_RendimentoEmpresa where vr_pct is null into var_find;
if var_find > 0 then 
update LOG_Edu_RendimentoEmpresa set vr_pct = 0 where vr_pct is null;
end if;
END;
##CMD
CALL ADD_LOG_Edu_RendimentoEmpresa_vr_pct ( );
##CMD
DROP PROCEDURE  ADD_LOG_Edu_RendimentoEmpresa_vr_pct;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Edu_RendimentoEmpresa_dt_rend;
##CMD

CREATE PROCEDURE ADD_LOG_Edu_RendimentoEmpresa_dt_rend ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Edu_RendimentoEmpresa' and column_name = 'dt_rend' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Edu_RendimentoEmpresa` ADD COLUMN `dt_rend` DATETIME;
end if;
select count(*) from LOG_Edu_RendimentoEmpresa where dt_rend is null into var_find;
if var_find > 0 then 
update LOG_Edu_RendimentoEmpresa set dt_rend = '1900-01-01 00:00:00.000' where dt_rend is null;
end if;
END;
##CMD
CALL ADD_LOG_Edu_RendimentoEmpresa_dt_rend ( );
##CMD
DROP PROCEDURE  ADD_LOG_Edu_RendimentoEmpresa_dt_rend;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Edu_RendimentoEmpresa_tg_neg;
##CMD

CREATE PROCEDURE ADD_LOG_Edu_RendimentoEmpresa_tg_neg ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Edu_RendimentoEmpresa' and column_name = 'tg_neg' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Edu_RendimentoEmpresa` ADD COLUMN `tg_neg` VARCHAR(1);
else
ALTER TABLE `LOG_Edu_RendimentoEmpresa` MODIFY `tg_neg` VARCHAR(1);
end if;
select count(*) from LOG_Edu_RendimentoEmpresa where tg_neg is null into var_find;
if var_find > 0 then 
update LOG_Edu_RendimentoEmpresa set tg_neg = '' where tg_neg is null;
end if;
END;
##CMD
CALL ADD_LOG_Edu_RendimentoEmpresa_tg_neg ( );
##CMD
DROP PROCEDURE  ADD_LOG_Edu_RendimentoEmpresa_tg_neg;
##CMD


CREATE TABLE IF NOT EXISTS `T_Edu_FundoEmpresa` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_cartao` BIGINT UNSIGNED,
`fk_empresaVirtual` BIGINT UNSIGNED,
`vr_fundo` BIGINT UNSIGNED,
`dt_efetivo` DATETIME,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_FundoEmpresa_fk_cartao;
##CMD

CREATE PROCEDURE ADD_T_Edu_FundoEmpresa_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_FundoEmpresa' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_FundoEmpresa` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from T_Edu_FundoEmpresa where fk_cartao is null into var_find;
if var_find > 0 then 
update T_Edu_FundoEmpresa set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_FundoEmpresa' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_FundoEmpresa` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_T_Edu_FundoEmpresa_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_FundoEmpresa_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_FundoEmpresa_fk_empresaVirtual;
##CMD

CREATE PROCEDURE ADD_T_Edu_FundoEmpresa_fk_empresaVirtual ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_FundoEmpresa' and column_name = 'fk_empresaVirtual' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_FundoEmpresa` ADD COLUMN `fk_empresaVirtual` BIGINT;
end if;
select count(*) from T_Edu_FundoEmpresa where fk_empresaVirtual is null into var_find;
if var_find > 0 then 
update T_Edu_FundoEmpresa set fk_empresaVirtual = 0 where fk_empresaVirtual is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_FundoEmpresa' and column_name = 'fk_empresaVirtual' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_FundoEmpresa` ADD INDEX `index_fk_empresaVirtual`(fk_empresaVirtual);
end if;
END;
##CMD
CALL ADD_T_Edu_FundoEmpresa_fk_empresaVirtual ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_FundoEmpresa_fk_empresaVirtual;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_Edu_FundoEmpresa_dt_dia;
##CMD
CREATE PROCEDURE DEL_T_Edu_FundoEmpresa_dt_dia ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_FundoEmpresa' and column_name = 'dt_dia' into var_find;
if var_find = 1 then 
ALTER TABLE `T_Edu_FundoEmpresa` DROP COLUMN `dt_dia` ;
end if;
END;
##CMD

CALL DEL_T_Edu_FundoEmpresa_dt_dia ( );
##CMD
DROP PROCEDURE  DEL_T_Edu_FundoEmpresa_dt_dia;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_FundoEmpresa_vr_fundo;
##CMD

CREATE PROCEDURE ADD_T_Edu_FundoEmpresa_vr_fundo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_FundoEmpresa' and column_name = 'vr_fundo' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_FundoEmpresa` ADD COLUMN `vr_fundo` BIGINT;
end if;
select count(*) from T_Edu_FundoEmpresa where vr_fundo is null into var_find;
if var_find > 0 then 
update T_Edu_FundoEmpresa set vr_fundo = 0 where vr_fundo is null;
end if;
END;
##CMD
CALL ADD_T_Edu_FundoEmpresa_vr_fundo ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_FundoEmpresa_vr_fundo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Edu_FundoEmpresa_dt_efetivo;
##CMD

CREATE PROCEDURE ADD_T_Edu_FundoEmpresa_dt_efetivo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Edu_FundoEmpresa' and column_name = 'dt_efetivo' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Edu_FundoEmpresa` ADD COLUMN `dt_efetivo` DATETIME;
end if;
select count(*) from T_Edu_FundoEmpresa where dt_efetivo is null into var_find;
if var_find > 0 then 
update T_Edu_FundoEmpresa set dt_efetivo = '1900-01-01 00:00:00.000' where dt_efetivo is null;
end if;
END;
##CMD
CALL ADD_T_Edu_FundoEmpresa_dt_efetivo ( );
##CMD
DROP PROCEDURE  ADD_T_Edu_FundoEmpresa_dt_efetivo;
##CMD


CREATE TABLE IF NOT EXISTS `LINK_Edu_FundoEmpresa` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_cartao` BIGINT UNSIGNED,
`fk_empresa` BIGINT UNSIGNED,
`vr_fundo` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_Edu_FundoEmpresa_fk_cartao;
##CMD

CREATE PROCEDURE ADD_LINK_Edu_FundoEmpresa_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Edu_FundoEmpresa' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_Edu_FundoEmpresa` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from LINK_Edu_FundoEmpresa where fk_cartao is null into var_find;
if var_find > 0 then 
update LINK_Edu_FundoEmpresa set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Edu_FundoEmpresa' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_Edu_FundoEmpresa` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_LINK_Edu_FundoEmpresa_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_LINK_Edu_FundoEmpresa_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_Edu_FundoEmpresa_fk_empresa;
##CMD

CREATE PROCEDURE ADD_LINK_Edu_FundoEmpresa_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Edu_FundoEmpresa' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_Edu_FundoEmpresa` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from LINK_Edu_FundoEmpresa where fk_empresa is null into var_find;
if var_find > 0 then 
update LINK_Edu_FundoEmpresa set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Edu_FundoEmpresa' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_Edu_FundoEmpresa` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_LINK_Edu_FundoEmpresa_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_LINK_Edu_FundoEmpresa_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_Edu_FundoEmpresa_vr_fundo;
##CMD

CREATE PROCEDURE ADD_LINK_Edu_FundoEmpresa_vr_fundo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_Edu_FundoEmpresa' and column_name = 'vr_fundo' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_Edu_FundoEmpresa` ADD COLUMN `vr_fundo` BIGINT;
end if;
select count(*) from LINK_Edu_FundoEmpresa where vr_fundo is null into var_find;
if var_find > 0 then 
update LINK_Edu_FundoEmpresa set vr_fundo = 0 where vr_fundo is null;
end if;
END;
##CMD
CALL ADD_LINK_Edu_FundoEmpresa_vr_fundo ( );
##CMD
DROP PROCEDURE  ADD_LINK_Edu_FundoEmpresa_vr_fundo;
##CMD


CREATE TABLE IF NOT EXISTS `T_WebBlock` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_ip` VARCHAR(99),
`fk_cartao` BIGINT UNSIGNED,
`dt_expire` DATETIME,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_WebBlock_st_ip;
##CMD

CREATE PROCEDURE ADD_T_WebBlock_st_ip ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_WebBlock' and column_name = 'st_ip' into var_find;
if var_find = 0 then 
ALTER TABLE `T_WebBlock` ADD COLUMN `st_ip` VARCHAR(99);
else
ALTER TABLE `T_WebBlock` MODIFY `st_ip` VARCHAR(99);
end if;
select count(*) from T_WebBlock where st_ip is null into var_find;
if var_find > 0 then 
update T_WebBlock set st_ip = '' where st_ip is null;
end if;
END;
##CMD
CALL ADD_T_WebBlock_st_ip ( );
##CMD
DROP PROCEDURE  ADD_T_WebBlock_st_ip;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_WebBlock_fk_cartao;
##CMD

CREATE PROCEDURE ADD_T_WebBlock_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_WebBlock' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_WebBlock` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from T_WebBlock where fk_cartao is null into var_find;
if var_find > 0 then 
update T_WebBlock set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_WebBlock' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_WebBlock` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_T_WebBlock_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_T_WebBlock_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_WebBlock_dt_expire;
##CMD

CREATE PROCEDURE ADD_T_WebBlock_dt_expire ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_WebBlock' and column_name = 'dt_expire' into var_find;
if var_find = 0 then 
ALTER TABLE `T_WebBlock` ADD COLUMN `dt_expire` DATETIME;
end if;
select count(*) from T_WebBlock where dt_expire is null into var_find;
if var_find > 0 then 
update T_WebBlock set dt_expire = '1900-01-01 00:00:00.000' where dt_expire is null;
end if;
END;
##CMD
CALL ADD_T_WebBlock_dt_expire ( );
##CMD
DROP PROCEDURE  ADD_T_WebBlock_dt_expire;
##CMD


CREATE TABLE IF NOT EXISTS `T_Faturamento` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_empresa` BIGINT UNSIGNED,
`fk_loja` BIGINT UNSIGNED,
`vr_cobranca` BIGINT UNSIGNED,
`dt_vencimento` DATETIME,
`dt_baixa` DATETIME,
`tg_situacao` VARCHAR(1),
`tg_retBanco` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Faturamento_fk_empresa;
##CMD

CREATE PROCEDURE ADD_T_Faturamento_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Faturamento' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Faturamento` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from T_Faturamento where fk_empresa is null into var_find;
if var_find > 0 then 
update T_Faturamento set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Faturamento' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Faturamento` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_T_Faturamento_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_Faturamento_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Faturamento_fk_loja;
##CMD

CREATE PROCEDURE ADD_T_Faturamento_fk_loja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Faturamento' and column_name = 'fk_loja' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Faturamento` ADD COLUMN `fk_loja` BIGINT;
end if;
select count(*) from T_Faturamento where fk_loja is null into var_find;
if var_find > 0 then 
update T_Faturamento set fk_loja = 0 where fk_loja is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Faturamento' and column_name = 'fk_loja' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Faturamento` ADD INDEX `index_fk_loja`(fk_loja);
end if;
END;
##CMD
CALL ADD_T_Faturamento_fk_loja ( );
##CMD
DROP PROCEDURE  ADD_T_Faturamento_fk_loja;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Faturamento_vr_cobranca;
##CMD

CREATE PROCEDURE ADD_T_Faturamento_vr_cobranca ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Faturamento' and column_name = 'vr_cobranca' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Faturamento` ADD COLUMN `vr_cobranca` BIGINT;
end if;
select count(*) from T_Faturamento where vr_cobranca is null into var_find;
if var_find > 0 then 
update T_Faturamento set vr_cobranca = 0 where vr_cobranca is null;
end if;
END;
##CMD
CALL ADD_T_Faturamento_vr_cobranca ( );
##CMD
DROP PROCEDURE  ADD_T_Faturamento_vr_cobranca;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Faturamento_dt_vencimento;
##CMD

CREATE PROCEDURE ADD_T_Faturamento_dt_vencimento ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Faturamento' and column_name = 'dt_vencimento' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Faturamento` ADD COLUMN `dt_vencimento` DATETIME;
end if;
select count(*) from T_Faturamento where dt_vencimento is null into var_find;
if var_find > 0 then 
update T_Faturamento set dt_vencimento = '1900-01-01 00:00:00.000' where dt_vencimento is null;
end if;
END;
##CMD
CALL ADD_T_Faturamento_dt_vencimento ( );
##CMD
DROP PROCEDURE  ADD_T_Faturamento_dt_vencimento;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Faturamento_dt_baixa;
##CMD

CREATE PROCEDURE ADD_T_Faturamento_dt_baixa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Faturamento' and column_name = 'dt_baixa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Faturamento` ADD COLUMN `dt_baixa` DATETIME;
end if;
select count(*) from T_Faturamento where dt_baixa is null into var_find;
if var_find > 0 then 
update T_Faturamento set dt_baixa = '1900-01-01 00:00:00.000' where dt_baixa is null;
end if;
END;
##CMD
CALL ADD_T_Faturamento_dt_baixa ( );
##CMD
DROP PROCEDURE  ADD_T_Faturamento_dt_baixa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Faturamento_tg_situacao;
##CMD

CREATE PROCEDURE ADD_T_Faturamento_tg_situacao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Faturamento' and column_name = 'tg_situacao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Faturamento` ADD COLUMN `tg_situacao` VARCHAR(1);
else
ALTER TABLE `T_Faturamento` MODIFY `tg_situacao` VARCHAR(1);
end if;
select count(*) from T_Faturamento where tg_situacao is null into var_find;
if var_find > 0 then 
update T_Faturamento set tg_situacao = '' where tg_situacao is null;
end if;
END;
##CMD
CALL ADD_T_Faturamento_tg_situacao ( );
##CMD
DROP PROCEDURE  ADD_T_Faturamento_tg_situacao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Faturamento_tg_retBanco;
##CMD

CREATE PROCEDURE ADD_T_Faturamento_tg_retBanco ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Faturamento' and column_name = 'tg_retBanco' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Faturamento` ADD COLUMN `tg_retBanco` BIGINT;
end if;
select count(*) from T_Faturamento where tg_retBanco is null into var_find;
if var_find > 0 then 
update T_Faturamento set tg_retBanco = 0 where tg_retBanco is null;
end if;
END;
##CMD
CALL ADD_T_Faturamento_tg_retBanco ( );
##CMD
DROP PROCEDURE  ADD_T_Faturamento_tg_retBanco;
##CMD


CREATE TABLE IF NOT EXISTS `T_FaturamentoDetalhes` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_fatura` BIGINT UNSIGNED,
`tg_tipoFat` BIGINT UNSIGNED,
`nu_quantidade` BIGINT UNSIGNED,
`vr_cobranca` BIGINT UNSIGNED,
`tg_desconto` VARCHAR(1),
`st_extras` VARCHAR(100),
`fk_empresa` BIGINT UNSIGNED,
`fk_loja` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_FaturamentoDetalhes_fk_fatura;
##CMD

CREATE PROCEDURE ADD_T_FaturamentoDetalhes_fk_fatura ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_FaturamentoDetalhes' and column_name = 'fk_fatura' into var_find;
if var_find = 0 then 
ALTER TABLE `T_FaturamentoDetalhes` ADD COLUMN `fk_fatura` BIGINT;
end if;
select count(*) from T_FaturamentoDetalhes where fk_fatura is null into var_find;
if var_find > 0 then 
update T_FaturamentoDetalhes set fk_fatura = 0 where fk_fatura is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_FaturamentoDetalhes' and column_name = 'fk_fatura' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_FaturamentoDetalhes` ADD INDEX `index_fk_fatura`(fk_fatura);
end if;
END;
##CMD
CALL ADD_T_FaturamentoDetalhes_fk_fatura ( );
##CMD
DROP PROCEDURE  ADD_T_FaturamentoDetalhes_fk_fatura;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_FaturamentoDetalhes_tg_tipoFat;
##CMD

CREATE PROCEDURE ADD_T_FaturamentoDetalhes_tg_tipoFat ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_FaturamentoDetalhes' and column_name = 'tg_tipoFat' into var_find;
if var_find = 0 then 
ALTER TABLE `T_FaturamentoDetalhes` ADD COLUMN `tg_tipoFat` BIGINT;
end if;
select count(*) from T_FaturamentoDetalhes where tg_tipoFat is null into var_find;
if var_find > 0 then 
update T_FaturamentoDetalhes set tg_tipoFat = 0 where tg_tipoFat is null;
end if;
END;
##CMD
CALL ADD_T_FaturamentoDetalhes_tg_tipoFat ( );
##CMD
DROP PROCEDURE  ADD_T_FaturamentoDetalhes_tg_tipoFat;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_FaturamentoDetalhes_nu_quantidade;
##CMD

CREATE PROCEDURE ADD_T_FaturamentoDetalhes_nu_quantidade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_FaturamentoDetalhes' and column_name = 'nu_quantidade' into var_find;
if var_find = 0 then 
ALTER TABLE `T_FaturamentoDetalhes` ADD COLUMN `nu_quantidade` BIGINT;
end if;
select count(*) from T_FaturamentoDetalhes where nu_quantidade is null into var_find;
if var_find > 0 then 
update T_FaturamentoDetalhes set nu_quantidade = 0 where nu_quantidade is null;
end if;
END;
##CMD
CALL ADD_T_FaturamentoDetalhes_nu_quantidade ( );
##CMD
DROP PROCEDURE  ADD_T_FaturamentoDetalhes_nu_quantidade;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_FaturamentoDetalhes_vr_cobranca;
##CMD

CREATE PROCEDURE ADD_T_FaturamentoDetalhes_vr_cobranca ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_FaturamentoDetalhes' and column_name = 'vr_cobranca' into var_find;
if var_find = 0 then 
ALTER TABLE `T_FaturamentoDetalhes` ADD COLUMN `vr_cobranca` BIGINT;
end if;
select count(*) from T_FaturamentoDetalhes where vr_cobranca is null into var_find;
if var_find > 0 then 
update T_FaturamentoDetalhes set vr_cobranca = 0 where vr_cobranca is null;
end if;
END;
##CMD
CALL ADD_T_FaturamentoDetalhes_vr_cobranca ( );
##CMD
DROP PROCEDURE  ADD_T_FaturamentoDetalhes_vr_cobranca;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_FaturamentoDetalhes_tg_desconto;
##CMD

CREATE PROCEDURE ADD_T_FaturamentoDetalhes_tg_desconto ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_FaturamentoDetalhes' and column_name = 'tg_desconto' into var_find;
if var_find = 0 then 
ALTER TABLE `T_FaturamentoDetalhes` ADD COLUMN `tg_desconto` VARCHAR(1);
else
ALTER TABLE `T_FaturamentoDetalhes` MODIFY `tg_desconto` VARCHAR(1);
end if;
select count(*) from T_FaturamentoDetalhes where tg_desconto is null into var_find;
if var_find > 0 then 
update T_FaturamentoDetalhes set tg_desconto = '' where tg_desconto is null;
end if;
END;
##CMD
CALL ADD_T_FaturamentoDetalhes_tg_desconto ( );
##CMD
DROP PROCEDURE  ADD_T_FaturamentoDetalhes_tg_desconto;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_FaturamentoDetalhes_st_extras;
##CMD

CREATE PROCEDURE ADD_T_FaturamentoDetalhes_st_extras ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_FaturamentoDetalhes' and column_name = 'st_extras' into var_find;
if var_find = 0 then 
ALTER TABLE `T_FaturamentoDetalhes` ADD COLUMN `st_extras` VARCHAR(100);
else
ALTER TABLE `T_FaturamentoDetalhes` MODIFY `st_extras` VARCHAR(100);
end if;
select count(*) from T_FaturamentoDetalhes where st_extras is null into var_find;
if var_find > 0 then 
update T_FaturamentoDetalhes set st_extras = '' where st_extras is null;
end if;
END;
##CMD
CALL ADD_T_FaturamentoDetalhes_st_extras ( );
##CMD
DROP PROCEDURE  ADD_T_FaturamentoDetalhes_st_extras;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_FaturamentoDetalhes_fk_empresa;
##CMD

CREATE PROCEDURE ADD_T_FaturamentoDetalhes_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_FaturamentoDetalhes' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_FaturamentoDetalhes` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from T_FaturamentoDetalhes where fk_empresa is null into var_find;
if var_find > 0 then 
update T_FaturamentoDetalhes set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_FaturamentoDetalhes' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_FaturamentoDetalhes` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_T_FaturamentoDetalhes_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_FaturamentoDetalhes_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_FaturamentoDetalhes_fk_loja;
##CMD

CREATE PROCEDURE ADD_T_FaturamentoDetalhes_fk_loja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_FaturamentoDetalhes' and column_name = 'fk_loja' into var_find;
if var_find = 0 then 
ALTER TABLE `T_FaturamentoDetalhes` ADD COLUMN `fk_loja` BIGINT;
end if;
select count(*) from T_FaturamentoDetalhes where fk_loja is null into var_find;
if var_find > 0 then 
update T_FaturamentoDetalhes set fk_loja = 0 where fk_loja is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_FaturamentoDetalhes' and column_name = 'fk_loja' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_FaturamentoDetalhes` ADD INDEX `index_fk_loja`(fk_loja);
end if;
END;
##CMD
CALL ADD_T_FaturamentoDetalhes_fk_loja ( );
##CMD
DROP PROCEDURE  ADD_T_FaturamentoDetalhes_fk_loja;
##CMD


CREATE TABLE IF NOT EXISTS `T_RetCobranca` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`nu_codBanco` BIGINT UNSIGNED,
`nu_cod` BIGINT UNSIGNED,
`tg_tipoCob` VARCHAR(1),
`st_codMsg` VARCHAR(99),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_RetCobranca_nu_codBanco;
##CMD

CREATE PROCEDURE ADD_T_RetCobranca_nu_codBanco ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_RetCobranca' and column_name = 'nu_codBanco' into var_find;
if var_find = 0 then 
ALTER TABLE `T_RetCobranca` ADD COLUMN `nu_codBanco` BIGINT;
end if;
select count(*) from T_RetCobranca where nu_codBanco is null into var_find;
if var_find > 0 then 
update T_RetCobranca set nu_codBanco = 0 where nu_codBanco is null;
end if;
END;
##CMD
CALL ADD_T_RetCobranca_nu_codBanco ( );
##CMD
DROP PROCEDURE  ADD_T_RetCobranca_nu_codBanco;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_RetCobranca_nu_cod;
##CMD

CREATE PROCEDURE ADD_T_RetCobranca_nu_cod ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_RetCobranca' and column_name = 'nu_cod' into var_find;
if var_find = 0 then 
ALTER TABLE `T_RetCobranca` ADD COLUMN `nu_cod` BIGINT;
end if;
select count(*) from T_RetCobranca where nu_cod is null into var_find;
if var_find > 0 then 
update T_RetCobranca set nu_cod = 0 where nu_cod is null;
end if;
END;
##CMD
CALL ADD_T_RetCobranca_nu_cod ( );
##CMD
DROP PROCEDURE  ADD_T_RetCobranca_nu_cod;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_RetCobranca_tg_tipoCob;
##CMD

CREATE PROCEDURE ADD_T_RetCobranca_tg_tipoCob ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_RetCobranca' and column_name = 'tg_tipoCob' into var_find;
if var_find = 0 then 
ALTER TABLE `T_RetCobranca` ADD COLUMN `tg_tipoCob` VARCHAR(1);
else
ALTER TABLE `T_RetCobranca` MODIFY `tg_tipoCob` VARCHAR(1);
end if;
select count(*) from T_RetCobranca where tg_tipoCob is null into var_find;
if var_find > 0 then 
update T_RetCobranca set tg_tipoCob = '' where tg_tipoCob is null;
end if;
END;
##CMD
CALL ADD_T_RetCobranca_tg_tipoCob ( );
##CMD
DROP PROCEDURE  ADD_T_RetCobranca_tg_tipoCob;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_RetCobranca_st_codMsg;
##CMD

CREATE PROCEDURE ADD_T_RetCobranca_st_codMsg ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_RetCobranca' and column_name = 'st_codMsg' into var_find;
if var_find = 0 then 
ALTER TABLE `T_RetCobranca` ADD COLUMN `st_codMsg` VARCHAR(99);
else
ALTER TABLE `T_RetCobranca` MODIFY `st_codMsg` VARCHAR(99);
end if;
select count(*) from T_RetCobranca where st_codMsg is null into var_find;
if var_find > 0 then 
update T_RetCobranca set st_codMsg = '' where st_codMsg is null;
end if;
END;
##CMD
CALL ADD_T_RetCobranca_st_codMsg ( );
##CMD
DROP PROCEDURE  ADD_T_RetCobranca_st_codMsg;
##CMD


CREATE TABLE IF NOT EXISTS `LOG_NSA` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`dt_log` DATETIME,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_NSA_dt_log;
##CMD

CREATE PROCEDURE ADD_LOG_NSA_dt_log ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_NSA' and column_name = 'dt_log' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_NSA` ADD COLUMN `dt_log` DATETIME;
end if;
select count(*) from LOG_NSA where dt_log is null into var_find;
if var_find > 0 then 
update LOG_NSA set dt_log = '1900-01-01 00:00:00.000' where dt_log is null;
end if;
END;
##CMD
CALL ADD_LOG_NSA_dt_log ( );
##CMD
DROP PROCEDURE  ADD_LOG_NSA_dt_log;
##CMD


CREATE TABLE IF NOT EXISTS `LOG_NS_FAT` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`dt_log` DATETIME,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_NS_FAT_dt_log;
##CMD

CREATE PROCEDURE ADD_LOG_NS_FAT_dt_log ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_NS_FAT' and column_name = 'dt_log' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_NS_FAT` ADD COLUMN `dt_log` DATETIME;
end if;
select count(*) from LOG_NS_FAT where dt_log is null into var_find;
if var_find > 0 then 
update LOG_NS_FAT set dt_log = '1900-01-01 00:00:00.000' where dt_log is null;
end if;
END;
##CMD
CALL ADD_LOG_NS_FAT_dt_log ( );
##CMD
DROP PROCEDURE  ADD_LOG_NS_FAT_dt_log;
##CMD


CREATE TABLE IF NOT EXISTS `T_Chamado` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_loja` BIGINT UNSIGNED,
`tg_fechado` BIGINT UNSIGNED,
`fk_operador` BIGINT UNSIGNED,
`nu_prioridade` BIGINT UNSIGNED,
`nu_categoria` BIGINT UNSIGNED,
`dt_abertura` DATETIME,
`dt_fechamento` DATETIME,
`st_motivo` VARCHAR(900),
`tg_tecnico` BIGINT UNSIGNED,
`fk_oper_criador` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Chamado_fk_loja;
##CMD

CREATE PROCEDURE ADD_T_Chamado_fk_loja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'fk_loja' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD COLUMN `fk_loja` BIGINT;
end if;
select count(*) from T_Chamado where fk_loja is null into var_find;
if var_find > 0 then 
update T_Chamado set fk_loja = 0 where fk_loja is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'fk_loja' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD INDEX `index_fk_loja`(fk_loja);
end if;
END;
##CMD
CALL ADD_T_Chamado_fk_loja ( );
##CMD
DROP PROCEDURE  ADD_T_Chamado_fk_loja;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Chamado_tg_fechado;
##CMD

CREATE PROCEDURE ADD_T_Chamado_tg_fechado ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'tg_fechado' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD COLUMN `tg_fechado` BIGINT;
end if;
select count(*) from T_Chamado where tg_fechado is null into var_find;
if var_find > 0 then 
update T_Chamado set tg_fechado = 0 where tg_fechado is null;
end if;
END;
##CMD
CALL ADD_T_Chamado_tg_fechado ( );
##CMD
DROP PROCEDURE  ADD_T_Chamado_tg_fechado;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Chamado_fk_operador;
##CMD

CREATE PROCEDURE ADD_T_Chamado_fk_operador ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'fk_operador' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD COLUMN `fk_operador` BIGINT;
end if;
select count(*) from T_Chamado where fk_operador is null into var_find;
if var_find > 0 then 
update T_Chamado set fk_operador = 0 where fk_operador is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'fk_operador' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD INDEX `index_fk_operador`(fk_operador);
end if;
END;
##CMD
CALL ADD_T_Chamado_fk_operador ( );
##CMD
DROP PROCEDURE  ADD_T_Chamado_fk_operador;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Chamado_nu_prioridade;
##CMD

CREATE PROCEDURE ADD_T_Chamado_nu_prioridade ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'nu_prioridade' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD COLUMN `nu_prioridade` BIGINT;
end if;
select count(*) from T_Chamado where nu_prioridade is null into var_find;
if var_find > 0 then 
update T_Chamado set nu_prioridade = 0 where nu_prioridade is null;
end if;
END;
##CMD
CALL ADD_T_Chamado_nu_prioridade ( );
##CMD
DROP PROCEDURE  ADD_T_Chamado_nu_prioridade;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Chamado_nu_categoria;
##CMD

CREATE PROCEDURE ADD_T_Chamado_nu_categoria ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'nu_categoria' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD COLUMN `nu_categoria` BIGINT;
end if;
select count(*) from T_Chamado where nu_categoria is null into var_find;
if var_find > 0 then 
update T_Chamado set nu_categoria = 0 where nu_categoria is null;
end if;
END;
##CMD
CALL ADD_T_Chamado_nu_categoria ( );
##CMD
DROP PROCEDURE  ADD_T_Chamado_nu_categoria;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Chamado_dt_abertura;
##CMD

CREATE PROCEDURE ADD_T_Chamado_dt_abertura ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'dt_abertura' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD COLUMN `dt_abertura` DATETIME;
end if;
select count(*) from T_Chamado where dt_abertura is null into var_find;
if var_find > 0 then 
update T_Chamado set dt_abertura = '1900-01-01 00:00:00.000' where dt_abertura is null;
end if;
END;
##CMD
CALL ADD_T_Chamado_dt_abertura ( );
##CMD
DROP PROCEDURE  ADD_T_Chamado_dt_abertura;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Chamado_dt_fechamento;
##CMD

CREATE PROCEDURE ADD_T_Chamado_dt_fechamento ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'dt_fechamento' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD COLUMN `dt_fechamento` DATETIME;
end if;
select count(*) from T_Chamado where dt_fechamento is null into var_find;
if var_find > 0 then 
update T_Chamado set dt_fechamento = '1900-01-01 00:00:00.000' where dt_fechamento is null;
end if;
END;
##CMD
CALL ADD_T_Chamado_dt_fechamento ( );
##CMD
DROP PROCEDURE  ADD_T_Chamado_dt_fechamento;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Chamado_st_motivo;
##CMD

CREATE PROCEDURE ADD_T_Chamado_st_motivo ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'st_motivo' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD COLUMN `st_motivo` VARCHAR(900);
else
ALTER TABLE `T_Chamado` MODIFY `st_motivo` VARCHAR(900);
end if;
select count(*) from T_Chamado where st_motivo is null into var_find;
if var_find > 0 then 
update T_Chamado set st_motivo = '' where st_motivo is null;
end if;
END;
##CMD
CALL ADD_T_Chamado_st_motivo ( );
##CMD
DROP PROCEDURE  ADD_T_Chamado_st_motivo;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Chamado_tg_tecnico;
##CMD

CREATE PROCEDURE ADD_T_Chamado_tg_tecnico ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'tg_tecnico' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD COLUMN `tg_tecnico` BIGINT;
end if;
select count(*) from T_Chamado where tg_tecnico is null into var_find;
if var_find > 0 then 
update T_Chamado set tg_tecnico = 0 where tg_tecnico is null;
end if;
END;
##CMD
CALL ADD_T_Chamado_tg_tecnico ( );
##CMD
DROP PROCEDURE  ADD_T_Chamado_tg_tecnico;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Chamado_fk_oper_criador;
##CMD

CREATE PROCEDURE ADD_T_Chamado_fk_oper_criador ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'fk_oper_criador' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD COLUMN `fk_oper_criador` BIGINT;
end if;
select count(*) from T_Chamado where fk_oper_criador is null into var_find;
if var_find > 0 then 
update T_Chamado set fk_oper_criador = 0 where fk_oper_criador is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Chamado' and column_name = 'fk_oper_criador' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Chamado` ADD INDEX `index_fk_oper_criador`(fk_oper_criador);
end if;
END;
##CMD
CALL ADD_T_Chamado_fk_oper_criador ( );
##CMD
DROP PROCEDURE  ADD_T_Chamado_fk_oper_criador;
##CMD


CREATE TABLE IF NOT EXISTS `LOG_Chamado` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_chamado` BIGINT UNSIGNED,
`fk_operador` BIGINT UNSIGNED,
`st_solucao` VARCHAR(900),
`dt_solucao` DATETIME,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Chamado_fk_chamado;
##CMD

CREATE PROCEDURE ADD_LOG_Chamado_fk_chamado ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Chamado' and column_name = 'fk_chamado' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Chamado` ADD COLUMN `fk_chamado` BIGINT;
end if;
select count(*) from LOG_Chamado where fk_chamado is null into var_find;
if var_find > 0 then 
update LOG_Chamado set fk_chamado = 0 where fk_chamado is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Chamado' and column_name = 'fk_chamado' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Chamado` ADD INDEX `index_fk_chamado`(fk_chamado);
end if;
END;
##CMD
CALL ADD_LOG_Chamado_fk_chamado ( );
##CMD
DROP PROCEDURE  ADD_LOG_Chamado_fk_chamado;
##CMD

DROP PROCEDURE IF EXISTS DEL_LOG_Chamado_st_solution;
##CMD
CREATE PROCEDURE DEL_LOG_Chamado_st_solution ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Chamado' and column_name = 'st_solution' into var_find;
if var_find = 1 then 
ALTER TABLE `LOG_Chamado` DROP COLUMN `st_solution` ;
end if;
END;
##CMD

CALL DEL_LOG_Chamado_st_solution ( );
##CMD
DROP PROCEDURE  DEL_LOG_Chamado_st_solution;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Chamado_fk_operador;
##CMD

CREATE PROCEDURE ADD_LOG_Chamado_fk_operador ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Chamado' and column_name = 'fk_operador' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Chamado` ADD COLUMN `fk_operador` BIGINT;
end if;
select count(*) from LOG_Chamado where fk_operador is null into var_find;
if var_find > 0 then 
update LOG_Chamado set fk_operador = 0 where fk_operador is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Chamado' and column_name = 'fk_operador' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Chamado` ADD INDEX `index_fk_operador`(fk_operador);
end if;
END;
##CMD
CALL ADD_LOG_Chamado_fk_operador ( );
##CMD
DROP PROCEDURE  ADD_LOG_Chamado_fk_operador;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Chamado_st_solucao;
##CMD

CREATE PROCEDURE ADD_LOG_Chamado_st_solucao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Chamado' and column_name = 'st_solucao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Chamado` ADD COLUMN `st_solucao` VARCHAR(900);
else
ALTER TABLE `LOG_Chamado` MODIFY `st_solucao` VARCHAR(900);
end if;
select count(*) from LOG_Chamado where st_solucao is null into var_find;
if var_find > 0 then 
update LOG_Chamado set st_solucao = '' where st_solucao is null;
end if;
END;
##CMD
CALL ADD_LOG_Chamado_st_solucao ( );
##CMD
DROP PROCEDURE  ADD_LOG_Chamado_st_solucao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_Chamado_dt_solucao;
##CMD

CREATE PROCEDURE ADD_LOG_Chamado_dt_solucao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_Chamado' and column_name = 'dt_solucao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_Chamado` ADD COLUMN `dt_solucao` DATETIME;
end if;
select count(*) from LOG_Chamado where dt_solucao is null into var_find;
if var_find > 0 then 
update LOG_Chamado set dt_solucao = '1900-01-01 00:00:00.000' where dt_solucao is null;
end if;
END;
##CMD
CALL ADD_LOG_Chamado_dt_solucao ( );
##CMD
DROP PROCEDURE  ADD_LOG_Chamado_dt_solucao;
##CMD


CREATE TABLE IF NOT EXISTS `T_ExtraGift` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_nome` VARCHAR(40),
`vr_valor` BIGINT UNSIGNED,
`fk_empresa` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_ExtraGift_st_nome;
##CMD

CREATE PROCEDURE ADD_T_ExtraGift_st_nome ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_ExtraGift' and column_name = 'st_nome' into var_find;
if var_find = 0 then 
ALTER TABLE `T_ExtraGift` ADD COLUMN `st_nome` VARCHAR(40);
else
ALTER TABLE `T_ExtraGift` MODIFY `st_nome` VARCHAR(40);
end if;
select count(*) from T_ExtraGift where st_nome is null into var_find;
if var_find > 0 then 
update T_ExtraGift set st_nome = '' where st_nome is null;
end if;
END;
##CMD
CALL ADD_T_ExtraGift_st_nome ( );
##CMD
DROP PROCEDURE  ADD_T_ExtraGift_st_nome;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_ExtraGift_vr_valor;
##CMD

CREATE PROCEDURE ADD_T_ExtraGift_vr_valor ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_ExtraGift' and column_name = 'vr_valor' into var_find;
if var_find = 0 then 
ALTER TABLE `T_ExtraGift` ADD COLUMN `vr_valor` BIGINT;
end if;
select count(*) from T_ExtraGift where vr_valor is null into var_find;
if var_find > 0 then 
update T_ExtraGift set vr_valor = 0 where vr_valor is null;
end if;
END;
##CMD
CALL ADD_T_ExtraGift_vr_valor ( );
##CMD
DROP PROCEDURE  ADD_T_ExtraGift_vr_valor;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_ExtraGift_fk_empresa;
##CMD

CREATE PROCEDURE ADD_T_ExtraGift_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_ExtraGift' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_ExtraGift` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from T_ExtraGift where fk_empresa is null into var_find;
if var_find > 0 then 
update T_ExtraGift set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_ExtraGift' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_ExtraGift` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_T_ExtraGift_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_ExtraGift_fk_empresa;
##CMD


CREATE TABLE IF NOT EXISTS `T_Quiosque` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_empresa` BIGINT UNSIGNED,
`st_nome` VARCHAR(40),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Quiosque_fk_empresa;
##CMD

CREATE PROCEDURE ADD_T_Quiosque_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Quiosque' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Quiosque` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from T_Quiosque where fk_empresa is null into var_find;
if var_find > 0 then 
update T_Quiosque set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Quiosque' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Quiosque` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_T_Quiosque_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_Quiosque_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_Quiosque_st_nome;
##CMD

CREATE PROCEDURE ADD_T_Quiosque_st_nome ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_Quiosque' and column_name = 'st_nome' into var_find;
if var_find = 0 then 
ALTER TABLE `T_Quiosque` ADD COLUMN `st_nome` VARCHAR(40);
else
ALTER TABLE `T_Quiosque` MODIFY `st_nome` VARCHAR(40);
end if;
select count(*) from T_Quiosque where st_nome is null into var_find;
if var_find > 0 then 
update T_Quiosque set st_nome = '' where st_nome is null;
end if;
END;
##CMD
CALL ADD_T_Quiosque_st_nome ( );
##CMD
DROP PROCEDURE  ADD_T_Quiosque_st_nome;
##CMD


CREATE TABLE IF NOT EXISTS `LOG_VendaCartaoGift` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_vendedor` BIGINT UNSIGNED,
`fk_empresa` BIGINT UNSIGNED,
`fk_cartao` BIGINT UNSIGNED,
`tg_tipoPag` BIGINT UNSIGNED,
`dt_compra` DATETIME,
`tg_tipoCartao` BIGINT UNSIGNED,
`st_cheque` VARCHAR(80),
`nu_nsuCartao` BIGINT UNSIGNED,
`vr_carga` BIGINT UNSIGNED,
`tg_adesao` BIGINT UNSIGNED,
`st_codImpresso` VARCHAR(90),
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaCartaoGift_fk_vendedor;
##CMD

CREATE PROCEDURE ADD_LOG_VendaCartaoGift_fk_vendedor ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'fk_vendedor' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD COLUMN `fk_vendedor` BIGINT;
end if;
select count(*) from LOG_VendaCartaoGift where fk_vendedor is null into var_find;
if var_find > 0 then 
update LOG_VendaCartaoGift set fk_vendedor = 0 where fk_vendedor is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'fk_vendedor' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD INDEX `index_fk_vendedor`(fk_vendedor);
end if;
END;
##CMD
CALL ADD_LOG_VendaCartaoGift_fk_vendedor ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaCartaoGift_fk_vendedor;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaCartaoGift_fk_empresa;
##CMD

CREATE PROCEDURE ADD_LOG_VendaCartaoGift_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from LOG_VendaCartaoGift where fk_empresa is null into var_find;
if var_find > 0 then 
update LOG_VendaCartaoGift set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_LOG_VendaCartaoGift_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaCartaoGift_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaCartaoGift_fk_cartao;
##CMD

CREATE PROCEDURE ADD_LOG_VendaCartaoGift_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from LOG_VendaCartaoGift where fk_cartao is null into var_find;
if var_find > 0 then 
update LOG_VendaCartaoGift set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_LOG_VendaCartaoGift_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaCartaoGift_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS DEL_LOG_VendaCartaoGift_dt_venda;
##CMD
CREATE PROCEDURE DEL_LOG_VendaCartaoGift_dt_venda ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'dt_venda' into var_find;
if var_find = 1 then 
ALTER TABLE `LOG_VendaCartaoGift` DROP COLUMN `dt_venda` ;
end if;
END;
##CMD

CALL DEL_LOG_VendaCartaoGift_dt_venda ( );
##CMD
DROP PROCEDURE  DEL_LOG_VendaCartaoGift_dt_venda;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaCartaoGift_tg_tipoPag;
##CMD

CREATE PROCEDURE ADD_LOG_VendaCartaoGift_tg_tipoPag ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'tg_tipoPag' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD COLUMN `tg_tipoPag` BIGINT;
end if;
select count(*) from LOG_VendaCartaoGift where tg_tipoPag is null into var_find;
if var_find > 0 then 
update LOG_VendaCartaoGift set tg_tipoPag = 0 where tg_tipoPag is null;
end if;
END;
##CMD
CALL ADD_LOG_VendaCartaoGift_tg_tipoPag ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaCartaoGift_tg_tipoPag;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaCartaoGift_dt_compra;
##CMD

CREATE PROCEDURE ADD_LOG_VendaCartaoGift_dt_compra ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'dt_compra' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD COLUMN `dt_compra` DATETIME;
end if;
select count(*) from LOG_VendaCartaoGift where dt_compra is null into var_find;
if var_find > 0 then 
update LOG_VendaCartaoGift set dt_compra = '1900-01-01 00:00:00.000' where dt_compra is null;
end if;
END;
##CMD
CALL ADD_LOG_VendaCartaoGift_dt_compra ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaCartaoGift_dt_compra;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaCartaoGift_tg_tipoCartao;
##CMD

CREATE PROCEDURE ADD_LOG_VendaCartaoGift_tg_tipoCartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'tg_tipoCartao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD COLUMN `tg_tipoCartao` BIGINT;
end if;
select count(*) from LOG_VendaCartaoGift where tg_tipoCartao is null into var_find;
if var_find > 0 then 
update LOG_VendaCartaoGift set tg_tipoCartao = 0 where tg_tipoCartao is null;
end if;
END;
##CMD
CALL ADD_LOG_VendaCartaoGift_tg_tipoCartao ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaCartaoGift_tg_tipoCartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaCartaoGift_st_cheque;
##CMD

CREATE PROCEDURE ADD_LOG_VendaCartaoGift_st_cheque ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'st_cheque' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD COLUMN `st_cheque` VARCHAR(80);
else
ALTER TABLE `LOG_VendaCartaoGift` MODIFY `st_cheque` VARCHAR(80);
end if;
select count(*) from LOG_VendaCartaoGift where st_cheque is null into var_find;
if var_find > 0 then 
update LOG_VendaCartaoGift set st_cheque = '' where st_cheque is null;
end if;
END;
##CMD
CALL ADD_LOG_VendaCartaoGift_st_cheque ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaCartaoGift_st_cheque;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaCartaoGift_nu_nsuCartao;
##CMD

CREATE PROCEDURE ADD_LOG_VendaCartaoGift_nu_nsuCartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'nu_nsuCartao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD COLUMN `nu_nsuCartao` BIGINT;
end if;
select count(*) from LOG_VendaCartaoGift where nu_nsuCartao is null into var_find;
if var_find > 0 then 
update LOG_VendaCartaoGift set nu_nsuCartao = 0 where nu_nsuCartao is null;
end if;
END;
##CMD
CALL ADD_LOG_VendaCartaoGift_nu_nsuCartao ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaCartaoGift_nu_nsuCartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaCartaoGift_vr_carga;
##CMD

CREATE PROCEDURE ADD_LOG_VendaCartaoGift_vr_carga ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'vr_carga' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD COLUMN `vr_carga` BIGINT;
end if;
select count(*) from LOG_VendaCartaoGift where vr_carga is null into var_find;
if var_find > 0 then 
update LOG_VendaCartaoGift set vr_carga = 0 where vr_carga is null;
end if;
END;
##CMD
CALL ADD_LOG_VendaCartaoGift_vr_carga ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaCartaoGift_vr_carga;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaCartaoGift_tg_adesao;
##CMD

CREATE PROCEDURE ADD_LOG_VendaCartaoGift_tg_adesao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'tg_adesao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD COLUMN `tg_adesao` BIGINT;
end if;
select count(*) from LOG_VendaCartaoGift where tg_adesao is null into var_find;
if var_find > 0 then 
update LOG_VendaCartaoGift set tg_adesao = 0 where tg_adesao is null;
end if;
END;
##CMD
CALL ADD_LOG_VendaCartaoGift_tg_adesao ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaCartaoGift_tg_adesao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaCartaoGift_st_codImpresso;
##CMD

CREATE PROCEDURE ADD_LOG_VendaCartaoGift_st_codImpresso ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaCartaoGift' and column_name = 'st_codImpresso' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaCartaoGift` ADD COLUMN `st_codImpresso` VARCHAR(90);
else
ALTER TABLE `LOG_VendaCartaoGift` MODIFY `st_codImpresso` VARCHAR(90);
end if;
select count(*) from LOG_VendaCartaoGift where st_codImpresso is null into var_find;
if var_find > 0 then 
update LOG_VendaCartaoGift set st_codImpresso = '' where st_codImpresso is null;
end if;
END;
##CMD
CALL ADD_LOG_VendaCartaoGift_st_codImpresso ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaCartaoGift_st_codImpresso;
##CMD


CREATE TABLE IF NOT EXISTS `LOG_VendaProdutoGift` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_vendaCartao` BIGINT UNSIGNED,
`st_produto` VARCHAR(90),
`vr_valor` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaProdutoGift_fk_vendaCartao;
##CMD

CREATE PROCEDURE ADD_LOG_VendaProdutoGift_fk_vendaCartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaProdutoGift' and column_name = 'fk_vendaCartao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaProdutoGift` ADD COLUMN `fk_vendaCartao` BIGINT;
end if;
select count(*) from LOG_VendaProdutoGift where fk_vendaCartao is null into var_find;
if var_find > 0 then 
update LOG_VendaProdutoGift set fk_vendaCartao = 0 where fk_vendaCartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaProdutoGift' and column_name = 'fk_vendaCartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaProdutoGift` ADD INDEX `index_fk_vendaCartao`(fk_vendaCartao);
end if;
END;
##CMD
CALL ADD_LOG_VendaProdutoGift_fk_vendaCartao ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaProdutoGift_fk_vendaCartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaProdutoGift_st_produto;
##CMD

CREATE PROCEDURE ADD_LOG_VendaProdutoGift_st_produto ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaProdutoGift' and column_name = 'st_produto' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaProdutoGift` ADD COLUMN `st_produto` VARCHAR(90);
else
ALTER TABLE `LOG_VendaProdutoGift` MODIFY `st_produto` VARCHAR(90);
end if;
select count(*) from LOG_VendaProdutoGift where st_produto is null into var_find;
if var_find > 0 then 
update LOG_VendaProdutoGift set st_produto = '' where st_produto is null;
end if;
END;
##CMD
CALL ADD_LOG_VendaProdutoGift_st_produto ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaProdutoGift_st_produto;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_VendaProdutoGift_vr_valor;
##CMD

CREATE PROCEDURE ADD_LOG_VendaProdutoGift_vr_valor ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_VendaProdutoGift' and column_name = 'vr_valor' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_VendaProdutoGift` ADD COLUMN `vr_valor` BIGINT;
end if;
select count(*) from LOG_VendaProdutoGift where vr_valor is null into var_find;
if var_find > 0 then 
update LOG_VendaProdutoGift set vr_valor = 0 where vr_valor is null;
end if;
END;
##CMD
CALL ADD_LOG_VendaProdutoGift_vr_valor ( );
##CMD
DROP PROCEDURE  ADD_LOG_VendaProdutoGift_vr_valor;
##CMD


CREATE TABLE IF NOT EXISTS `T_ChequesGift` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_identificador` VARCHAR(40),
`fk_cartao` BIGINT UNSIGNED,
`dt_efetiva` DATETIME,
`tg_compensado` BIGINT UNSIGNED,
`vr_valor` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_ChequesGift_st_identificador;
##CMD

CREATE PROCEDURE ADD_T_ChequesGift_st_identificador ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_ChequesGift' and column_name = 'st_identificador' into var_find;
if var_find = 0 then 
ALTER TABLE `T_ChequesGift` ADD COLUMN `st_identificador` VARCHAR(40);
else
ALTER TABLE `T_ChequesGift` MODIFY `st_identificador` VARCHAR(40);
end if;
select count(*) from T_ChequesGift where st_identificador is null into var_find;
if var_find > 0 then 
update T_ChequesGift set st_identificador = '' where st_identificador is null;
end if;
END;
##CMD
CALL ADD_T_ChequesGift_st_identificador ( );
##CMD
DROP PROCEDURE  ADD_T_ChequesGift_st_identificador;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_ChequesGift_fk_cartao;
##CMD

CREATE PROCEDURE ADD_T_ChequesGift_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_ChequesGift' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_ChequesGift` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from T_ChequesGift where fk_cartao is null into var_find;
if var_find > 0 then 
update T_ChequesGift set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_ChequesGift' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_ChequesGift` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_T_ChequesGift_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_T_ChequesGift_fk_cartao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_ChequesGift_dt_efetiva;
##CMD

CREATE PROCEDURE ADD_T_ChequesGift_dt_efetiva ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_ChequesGift' and column_name = 'dt_efetiva' into var_find;
if var_find = 0 then 
ALTER TABLE `T_ChequesGift` ADD COLUMN `dt_efetiva` DATETIME;
end if;
select count(*) from T_ChequesGift where dt_efetiva is null into var_find;
if var_find > 0 then 
update T_ChequesGift set dt_efetiva = '1900-01-01 00:00:00.000' where dt_efetiva is null;
end if;
END;
##CMD
CALL ADD_T_ChequesGift_dt_efetiva ( );
##CMD
DROP PROCEDURE  ADD_T_ChequesGift_dt_efetiva;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_ChequesGift_tg_compensado;
##CMD

CREATE PROCEDURE ADD_T_ChequesGift_tg_compensado ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_ChequesGift' and column_name = 'tg_compensado' into var_find;
if var_find = 0 then 
ALTER TABLE `T_ChequesGift` ADD COLUMN `tg_compensado` BIGINT;
end if;
select count(*) from T_ChequesGift where tg_compensado is null into var_find;
if var_find > 0 then 
update T_ChequesGift set tg_compensado = 0 where tg_compensado is null;
end if;
END;
##CMD
CALL ADD_T_ChequesGift_tg_compensado ( );
##CMD
DROP PROCEDURE  ADD_T_ChequesGift_tg_compensado;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_ChequesGift_vr_valor;
##CMD

CREATE PROCEDURE ADD_T_ChequesGift_vr_valor ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_ChequesGift' and column_name = 'vr_valor' into var_find;
if var_find = 0 then 
ALTER TABLE `T_ChequesGift` ADD COLUMN `vr_valor` BIGINT;
end if;
select count(*) from T_ChequesGift where vr_valor is null into var_find;
if var_find > 0 then 
update T_ChequesGift set vr_valor = 0 where vr_valor is null;
end if;
END;
##CMD
CALL ADD_T_ChequesGift_vr_valor ( );
##CMD
DROP PROCEDURE  ADD_T_ChequesGift_vr_valor;
##CMD


CREATE TABLE IF NOT EXISTS `LOG_GiftRanges` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_empresa` BIGINT UNSIGNED,
`nu_inicio` BIGINT UNSIGNED,
`nu_fim` BIGINT UNSIGNED,
`dt_requisicao` DATETIME,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_GiftRanges_fk_empresa;
##CMD

CREATE PROCEDURE ADD_LOG_GiftRanges_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_GiftRanges' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_GiftRanges` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from LOG_GiftRanges where fk_empresa is null into var_find;
if var_find > 0 then 
update LOG_GiftRanges set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_GiftRanges' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_GiftRanges` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_LOG_GiftRanges_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_LOG_GiftRanges_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_GiftRanges_nu_inicio;
##CMD

CREATE PROCEDURE ADD_LOG_GiftRanges_nu_inicio ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_GiftRanges' and column_name = 'nu_inicio' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_GiftRanges` ADD COLUMN `nu_inicio` BIGINT;
end if;
select count(*) from LOG_GiftRanges where nu_inicio is null into var_find;
if var_find > 0 then 
update LOG_GiftRanges set nu_inicio = 0 where nu_inicio is null;
end if;
END;
##CMD
CALL ADD_LOG_GiftRanges_nu_inicio ( );
##CMD
DROP PROCEDURE  ADD_LOG_GiftRanges_nu_inicio;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_GiftRanges_nu_fim;
##CMD

CREATE PROCEDURE ADD_LOG_GiftRanges_nu_fim ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_GiftRanges' and column_name = 'nu_fim' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_GiftRanges` ADD COLUMN `nu_fim` BIGINT;
end if;
select count(*) from LOG_GiftRanges where nu_fim is null into var_find;
if var_find > 0 then 
update LOG_GiftRanges set nu_fim = 0 where nu_fim is null;
end if;
END;
##CMD
CALL ADD_LOG_GiftRanges_nu_fim ( );
##CMD
DROP PROCEDURE  ADD_LOG_GiftRanges_nu_fim;
##CMD

DROP PROCEDURE IF EXISTS ADD_LOG_GiftRanges_dt_requisicao;
##CMD

CREATE PROCEDURE ADD_LOG_GiftRanges_dt_requisicao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LOG_GiftRanges' and column_name = 'dt_requisicao' into var_find;
if var_find = 0 then 
ALTER TABLE `LOG_GiftRanges` ADD COLUMN `dt_requisicao` DATETIME;
end if;
select count(*) from LOG_GiftRanges where dt_requisicao is null into var_find;
if var_find > 0 then 
update LOG_GiftRanges set dt_requisicao = '1900-01-01 00:00:00.000' where dt_requisicao is null;
end if;
END;
##CMD
CALL ADD_LOG_GiftRanges_dt_requisicao ( );
##CMD
DROP PROCEDURE  ADD_LOG_GiftRanges_dt_requisicao;
##CMD


CREATE TABLE IF NOT EXISTS `T_RepasseLoja` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_loja` BIGINT UNSIGNED,
`tg_opcao` BIGINT UNSIGNED,
`vr_valor` BIGINT UNSIGNED,
`st_ident` VARCHAR(90),
`dt_efetiva` DATETIME,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_RepasseLoja_fk_loja;
##CMD

CREATE PROCEDURE ADD_T_RepasseLoja_fk_loja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_RepasseLoja' and column_name = 'fk_loja' into var_find;
if var_find = 0 then 
ALTER TABLE `T_RepasseLoja` ADD COLUMN `fk_loja` BIGINT;
end if;
select count(*) from T_RepasseLoja where fk_loja is null into var_find;
if var_find > 0 then 
update T_RepasseLoja set fk_loja = 0 where fk_loja is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_RepasseLoja' and column_name = 'fk_loja' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_RepasseLoja` ADD INDEX `index_fk_loja`(fk_loja);
end if;
END;
##CMD
CALL ADD_T_RepasseLoja_fk_loja ( );
##CMD
DROP PROCEDURE  ADD_T_RepasseLoja_fk_loja;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_RepasseLoja_tg_opcao;
##CMD

CREATE PROCEDURE ADD_T_RepasseLoja_tg_opcao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_RepasseLoja' and column_name = 'tg_opcao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_RepasseLoja` ADD COLUMN `tg_opcao` BIGINT;
end if;
select count(*) from T_RepasseLoja where tg_opcao is null into var_find;
if var_find > 0 then 
update T_RepasseLoja set tg_opcao = 0 where tg_opcao is null;
end if;
END;
##CMD
CALL ADD_T_RepasseLoja_tg_opcao ( );
##CMD
DROP PROCEDURE  ADD_T_RepasseLoja_tg_opcao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_RepasseLoja_vr_valor;
##CMD

CREATE PROCEDURE ADD_T_RepasseLoja_vr_valor ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_RepasseLoja' and column_name = 'vr_valor' into var_find;
if var_find = 0 then 
ALTER TABLE `T_RepasseLoja` ADD COLUMN `vr_valor` BIGINT;
end if;
select count(*) from T_RepasseLoja where vr_valor is null into var_find;
if var_find > 0 then 
update T_RepasseLoja set vr_valor = 0 where vr_valor is null;
end if;
END;
##CMD
CALL ADD_T_RepasseLoja_vr_valor ( );
##CMD
DROP PROCEDURE  ADD_T_RepasseLoja_vr_valor;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_RepasseLoja_st_ident;
##CMD

CREATE PROCEDURE ADD_T_RepasseLoja_st_ident ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_RepasseLoja' and column_name = 'st_ident' into var_find;
if var_find = 0 then 
ALTER TABLE `T_RepasseLoja` ADD COLUMN `st_ident` VARCHAR(90);
else
ALTER TABLE `T_RepasseLoja` MODIFY `st_ident` VARCHAR(90);
end if;
select count(*) from T_RepasseLoja where st_ident is null into var_find;
if var_find > 0 then 
update T_RepasseLoja set st_ident = '' where st_ident is null;
end if;
END;
##CMD
CALL ADD_T_RepasseLoja_st_ident ( );
##CMD
DROP PROCEDURE  ADD_T_RepasseLoja_st_ident;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_RepasseLoja_dt_efetiva;
##CMD

CREATE PROCEDURE ADD_T_RepasseLoja_dt_efetiva ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_RepasseLoja' and column_name = 'dt_efetiva' into var_find;
if var_find = 0 then 
ALTER TABLE `T_RepasseLoja` ADD COLUMN `dt_efetiva` DATETIME;
end if;
select count(*) from T_RepasseLoja where dt_efetiva is null into var_find;
if var_find > 0 then 
update T_RepasseLoja set dt_efetiva = '1900-01-01 00:00:00.000' where dt_efetiva is null;
end if;
END;
##CMD
CALL ADD_T_RepasseLoja_dt_efetiva ( );
##CMD
DROP PROCEDURE  ADD_T_RepasseLoja_dt_efetiva;
##CMD


CREATE TABLE IF NOT EXISTS `LINK_RepasseParcela` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_repasseLoja` BIGINT UNSIGNED,
`fk_parcela` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_RepasseParcela_fk_repasseLoja;
##CMD

CREATE PROCEDURE ADD_LINK_RepasseParcela_fk_repasseLoja ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_RepasseParcela' and column_name = 'fk_repasseLoja' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_RepasseParcela` ADD COLUMN `fk_repasseLoja` BIGINT;
end if;
select count(*) from LINK_RepasseParcela where fk_repasseLoja is null into var_find;
if var_find > 0 then 
update LINK_RepasseParcela set fk_repasseLoja = 0 where fk_repasseLoja is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_RepasseParcela' and column_name = 'fk_repasseLoja' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_RepasseParcela` ADD INDEX `index_fk_repasseLoja`(fk_repasseLoja);
end if;
END;
##CMD
CALL ADD_LINK_RepasseParcela_fk_repasseLoja ( );
##CMD
DROP PROCEDURE  ADD_LINK_RepasseParcela_fk_repasseLoja;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_RepasseParcela_fk_parcela;
##CMD

CREATE PROCEDURE ADD_LINK_RepasseParcela_fk_parcela ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_RepasseParcela' and column_name = 'fk_parcela' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_RepasseParcela` ADD COLUMN `fk_parcela` BIGINT;
end if;
select count(*) from LINK_RepasseParcela where fk_parcela is null into var_find;
if var_find > 0 then 
update LINK_RepasseParcela set fk_parcela = 0 where fk_parcela is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_RepasseParcela' and column_name = 'fk_parcela' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_RepasseParcela` ADD INDEX `index_fk_parcela`(fk_parcela);
end if;
END;
##CMD
CALL ADD_LINK_RepasseParcela_fk_parcela ( );
##CMD
DROP PROCEDURE  ADD_LINK_RepasseParcela_fk_parcela;
##CMD


CREATE TABLE IF NOT EXISTS `T_EmpresaAfiliada` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_nome` VARCHAR(20),
`fk_empresa` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_EmpresaAfiliada_st_nome;
##CMD

CREATE PROCEDURE ADD_T_EmpresaAfiliada_st_nome ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_EmpresaAfiliada' and column_name = 'st_nome' into var_find;
if var_find = 0 then 
ALTER TABLE `T_EmpresaAfiliada` ADD COLUMN `st_nome` VARCHAR(20);
else
ALTER TABLE `T_EmpresaAfiliada` MODIFY `st_nome` VARCHAR(20);
end if;
select count(*) from T_EmpresaAfiliada where st_nome is null into var_find;
if var_find > 0 then 
update T_EmpresaAfiliada set st_nome = '' where st_nome is null;
end if;
END;
##CMD
CALL ADD_T_EmpresaAfiliada_st_nome ( );
##CMD
DROP PROCEDURE  ADD_T_EmpresaAfiliada_st_nome;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_EmpresaAfiliada_fk_empresa;
##CMD

CREATE PROCEDURE ADD_T_EmpresaAfiliada_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_EmpresaAfiliada' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_EmpresaAfiliada` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from T_EmpresaAfiliada where fk_empresa is null into var_find;
if var_find > 0 then 
update T_EmpresaAfiliada set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_EmpresaAfiliada' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_EmpresaAfiliada` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_T_EmpresaAfiliada_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_EmpresaAfiliada_fk_empresa;
##CMD


CREATE TABLE IF NOT EXISTS `T_BoletoEdu` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`dt_emissao` DATETIME,
`vr_imediato` BIGINT UNSIGNED,
`vr_educacional` BIGINT UNSIGNED,
`fk_cartao` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_BoletoEdu_dt_emissao;
##CMD

CREATE PROCEDURE ADD_T_BoletoEdu_dt_emissao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_BoletoEdu' and column_name = 'dt_emissao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_BoletoEdu` ADD COLUMN `dt_emissao` DATETIME;
end if;
select count(*) from T_BoletoEdu where dt_emissao is null into var_find;
if var_find > 0 then 
update T_BoletoEdu set dt_emissao = '1900-01-01 00:00:00.000' where dt_emissao is null;
end if;
END;
##CMD
CALL ADD_T_BoletoEdu_dt_emissao ( );
##CMD
DROP PROCEDURE  ADD_T_BoletoEdu_dt_emissao;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_BoletoEdu_vr_imediato;
##CMD

CREATE PROCEDURE ADD_T_BoletoEdu_vr_imediato ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_BoletoEdu' and column_name = 'vr_imediato' into var_find;
if var_find = 0 then 
ALTER TABLE `T_BoletoEdu` ADD COLUMN `vr_imediato` BIGINT;
end if;
select count(*) from T_BoletoEdu where vr_imediato is null into var_find;
if var_find > 0 then 
update T_BoletoEdu set vr_imediato = 0 where vr_imediato is null;
end if;
END;
##CMD
CALL ADD_T_BoletoEdu_vr_imediato ( );
##CMD
DROP PROCEDURE  ADD_T_BoletoEdu_vr_imediato;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_BoletoEdu_vr_educacional;
##CMD

CREATE PROCEDURE ADD_T_BoletoEdu_vr_educacional ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_BoletoEdu' and column_name = 'vr_educacional' into var_find;
if var_find = 0 then 
ALTER TABLE `T_BoletoEdu` ADD COLUMN `vr_educacional` BIGINT;
end if;
select count(*) from T_BoletoEdu where vr_educacional is null into var_find;
if var_find > 0 then 
update T_BoletoEdu set vr_educacional = 0 where vr_educacional is null;
end if;
END;
##CMD
CALL ADD_T_BoletoEdu_vr_educacional ( );
##CMD
DROP PROCEDURE  ADD_T_BoletoEdu_vr_educacional;
##CMD

DROP PROCEDURE IF EXISTS DEL_T_BoletoEdu_fk_dadosProprietario;
##CMD
CREATE PROCEDURE DEL_T_BoletoEdu_fk_dadosProprietario ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_BoletoEdu' and column_name = 'fk_dadosProprietario' into var_find;
if var_find = 1 then 
ALTER TABLE `T_BoletoEdu` DROP COLUMN `fk_dadosProprietario` ;
end if;
END;
##CMD

CALL DEL_T_BoletoEdu_fk_dadosProprietario ( );
##CMD
DROP PROCEDURE  DEL_T_BoletoEdu_fk_dadosProprietario;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_BoletoEdu_fk_cartao;
##CMD

CREATE PROCEDURE ADD_T_BoletoEdu_fk_cartao ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_BoletoEdu' and column_name = 'fk_cartao' into var_find;
if var_find = 0 then 
ALTER TABLE `T_BoletoEdu` ADD COLUMN `fk_cartao` BIGINT;
end if;
select count(*) from T_BoletoEdu where fk_cartao is null into var_find;
if var_find > 0 then 
update T_BoletoEdu set fk_cartao = 0 where fk_cartao is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_BoletoEdu' and column_name = 'fk_cartao' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_BoletoEdu` ADD INDEX `index_fk_cartao`(fk_cartao);
end if;
END;
##CMD
CALL ADD_T_BoletoEdu_fk_cartao ( );
##CMD
DROP PROCEDURE  ADD_T_BoletoEdu_fk_cartao;
##CMD


CREATE TABLE IF NOT EXISTS `LINK_UsuarioTerminal` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`fk_user` BIGINT UNSIGNED,
`fk_term` BIGINT UNSIGNED,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_UsuarioTerminal_fk_user;
##CMD

CREATE PROCEDURE ADD_LINK_UsuarioTerminal_fk_user ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_UsuarioTerminal' and column_name = 'fk_user' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_UsuarioTerminal` ADD COLUMN `fk_user` BIGINT;
end if;
select count(*) from LINK_UsuarioTerminal where fk_user is null into var_find;
if var_find > 0 then 
update LINK_UsuarioTerminal set fk_user = 0 where fk_user is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_UsuarioTerminal' and column_name = 'fk_user' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_UsuarioTerminal` ADD INDEX `index_fk_user`(fk_user);
end if;
END;
##CMD
CALL ADD_LINK_UsuarioTerminal_fk_user ( );
##CMD
DROP PROCEDURE  ADD_LINK_UsuarioTerminal_fk_user;
##CMD

DROP PROCEDURE IF EXISTS ADD_LINK_UsuarioTerminal_fk_term;
##CMD

CREATE PROCEDURE ADD_LINK_UsuarioTerminal_fk_term ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_UsuarioTerminal' and column_name = 'fk_term' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_UsuarioTerminal` ADD COLUMN `fk_term` BIGINT;
end if;
select count(*) from LINK_UsuarioTerminal where fk_term is null into var_find;
if var_find > 0 then 
update LINK_UsuarioTerminal set fk_term = 0 where fk_term is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'LINK_UsuarioTerminal' and column_name = 'fk_term' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `LINK_UsuarioTerminal` ADD INDEX `index_fk_term`(fk_term);
end if;
END;
##CMD
CALL ADD_LINK_UsuarioTerminal_fk_term ( );
##CMD
DROP PROCEDURE  ADD_LINK_UsuarioTerminal_fk_term;
##CMD


CREATE TABLE IF NOT EXISTS `T_MensagemEdu` (
`i_unique` BIGINT UNSIGNED AUTO_INCREMENT,
`st_mens` VARCHAR(900),
`fk_empresa` BIGINT UNSIGNED,
`dt_ini` DATETIME,
`dt_fim` DATETIME,
PRIMARY KEY (`i_unique`)
)
ENGINE = InnoDB;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_MensagemEdu_st_mens;
##CMD

CREATE PROCEDURE ADD_T_MensagemEdu_st_mens ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_MensagemEdu' and column_name = 'st_mens' into var_find;
if var_find = 0 then 
ALTER TABLE `T_MensagemEdu` ADD COLUMN `st_mens` VARCHAR(900);
else
ALTER TABLE `T_MensagemEdu` MODIFY `st_mens` VARCHAR(900);
end if;
select count(*) from T_MensagemEdu where st_mens is null into var_find;
if var_find > 0 then 
update T_MensagemEdu set st_mens = '' where st_mens is null;
end if;
END;
##CMD
CALL ADD_T_MensagemEdu_st_mens ( );
##CMD
DROP PROCEDURE  ADD_T_MensagemEdu_st_mens;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_MensagemEdu_fk_empresa;
##CMD

CREATE PROCEDURE ADD_T_MensagemEdu_fk_empresa ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_MensagemEdu' and column_name = 'fk_empresa' into var_find;
if var_find = 0 then 
ALTER TABLE `T_MensagemEdu` ADD COLUMN `fk_empresa` BIGINT;
end if;
select count(*) from T_MensagemEdu where fk_empresa is null into var_find;
if var_find > 0 then 
update T_MensagemEdu set fk_empresa = 0 where fk_empresa is null;
end if;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_MensagemEdu' and column_name = 'fk_empresa' and column_key = 'MUL' into var_find;
if var_find = 0 then 
ALTER TABLE `T_MensagemEdu` ADD INDEX `index_fk_empresa`(fk_empresa);
end if;
END;
##CMD
CALL ADD_T_MensagemEdu_fk_empresa ( );
##CMD
DROP PROCEDURE  ADD_T_MensagemEdu_fk_empresa;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_MensagemEdu_dt_ini;
##CMD

CREATE PROCEDURE ADD_T_MensagemEdu_dt_ini ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_MensagemEdu' and column_name = 'dt_ini' into var_find;
if var_find = 0 then 
ALTER TABLE `T_MensagemEdu` ADD COLUMN `dt_ini` DATETIME;
end if;
select count(*) from T_MensagemEdu where dt_ini is null into var_find;
if var_find > 0 then 
update T_MensagemEdu set dt_ini = '1900-01-01 00:00:00.000' where dt_ini is null;
end if;
END;
##CMD
CALL ADD_T_MensagemEdu_dt_ini ( );
##CMD
DROP PROCEDURE  ADD_T_MensagemEdu_dt_ini;
##CMD

DROP PROCEDURE IF EXISTS ADD_T_MensagemEdu_dt_fim;
##CMD

CREATE PROCEDURE ADD_T_MensagemEdu_dt_fim ( ) 
BEGIN
DECLARE var_find INT default 0;
select count(*) from information_schema.`COLUMNS` where table_name = 'T_MensagemEdu' and column_name = 'dt_fim' into var_find;
if var_find = 0 then 
ALTER TABLE `T_MensagemEdu` ADD COLUMN `dt_fim` DATETIME;
end if;
select count(*) from T_MensagemEdu where dt_fim is null into var_find;
if var_find > 0 then 
update T_MensagemEdu set dt_fim = '1900-01-01 00:00:00.000' where dt_fim is null;
end if;
END;
##CMD
CALL ADD_T_MensagemEdu_dt_fim ( );
##CMD
DROP PROCEDURE  ADD_T_MensagemEdu_dt_fim;
##CMD

