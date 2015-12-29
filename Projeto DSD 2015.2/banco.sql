if db_id('lojadb') is not null
	begin
		use master
		drop database lojadb
	end
go

create database lojadb

go

use lojadb;

go

create table funcionarios 
(	
	id_funcionario    int  constraint pk_funcionario not null primary key,
	nome_funcionario  varchar(200)      not null,
	cargo_funcionario varchar(200)      not null,
	rg_funcionario    char(9)          not null, -- usaremos textbox mascarado(_.___.___)
	cpf_funcionario   char(15)          not null --usaremos textbox mascarado(___.___.___-__)	
);
go

create table clientes
(	
	id_cliente         int  constraint pk_cliente  not null primary key,
	nome_cliente       varchar(200)    not null,
	cpf_cliente        char(15)        not null,
	rg_cliente         char(9)        not null,
	tel_cliente        varchar(20)     not null, --Pode ser celular,pode ser fixo,pode ser do mesmo estado,ou não...
	logradouro_cliente varchar(100)    not null,
	email_cliente      varchar(100) --Não obrigatório!
);
go

create table produtos
(
	id_produto      int  constraint pk_produto  not null primary key,
	nome_produto    varchar(200)	  not null,
	marca_produto   varchar(200)      not null,
	tipo_produto    varchar(200)      not null,
	valor_produto   decimal(12,2)     not null, --Valor Unitário
	estoque_produto int 	          not null,
	detalhe_produto varchar(1000)	  not null
);
go

create table formapag
(
	id_formapag   int  constraint pk_formapag not null primary key,
	tipo_formapag varchar(200)      not null
);
go
create table venda
(
	id_venda        int constraint pk_venda not null primary key,
	data_venda      char(19)            	not null,
	valor_venda		decimal(12,2)		    not null,
	id_funcionario  int constraint fk_funcionarios foreign key references funcionarios(id_funcionario) 	ON DELETE CASCADE not null, 
	id_cliente      int constraint fk_clientes     foreign key references clientes(id_cliente) 	ON DELETE CASCADE not null,
	id_formapag     int constraint fk_formapag     foreign key references formapag(id_formapag) ON DELETE CASCADE not null
);
go

create table produto_venda
(
	id_sequencial            int identity(1,1)  constraint pk_produtovenda primary key,
	qtd_produtovenda 		 int            not null,
	vu_produtovenda          decimal(12,2)  not null,
	--vt_produtovenda          decimal (12,2) not null,
	id_produto     			 int constraint fk_produto foreign key references produtos(id_produto) 	ON DELETE CASCADE not null,
	id_venda       			 int constraint fk_venda   foreign key references venda(id_venda) 	ON DELETE CASCADE not null
);
go
create table troca
(
	id_troca               int constraint pk_troca not null primary key,
	data_troca             char(19) not null,
	id_prod_venda          int constraint fk_vendatroca      foreign key references produto_venda(id_sequencial) 	ON DELETE CASCADE not null, -- venda armazena produto_venda
	--id_produtovendido    int constraint fk_produtovendido  foreign key references produto_venda(fk_produto)    not null, -- como foreign key,não pega na tabela troca
	id_produtotroca         int constraint fk_produtotroca   foreign key references produtos(id_produto) null
);

/*create table produto_venda__troca(
	id_troca       int identity(1,1) not null primary key,
	id_prodvenda   int constraint FK_PRODVENDIDO foreign key references produtos(id_produto) NOT NULL,
	id_prodtroca    int constraint FK_PRODTROCADO foreign key references produtos(id_produto) NULL,
	FK_VENDA NOT NULL
	FK_TROCA NULL
);*/

/*by uncle Melo*/
create table codigos
(
	venda        int not null,
	funcionario  int not null,
	cliente      int not null,
	formapag     int not null,
	produto      int not null
);
--delete from codigos;
insert into codigos values(1,13,4,4,109);

/*select venda from codigos;
update codigos set venda = venda + 1;*/