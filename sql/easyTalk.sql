create database easyTalk;
use easyTalk;
create table categoria(
	id_categoria int identity primary key not null,
	nome_categoria varchar(50)
)

create table eventos(
	id_evento int identity primary key not null,
	nome_evento varchar(100),
	descricao varchar(500),
	data_evento DateTime,
	data_criacao DateTime,
	ativo int,
	localizacao varchar(100),
	id_categoria int foreign key references categoria(id_categoria)
)

create table tipo_usuario(
	id_tipo int identity primary key not null,
	nome_tipo_usuario varchar(50)
)

create table usuario(
	id_usuario int identity primary key not null, 
	nome_usuario varchar(50),
	email varchar(100) unique,
	senha varchar(100),
	telefone_fixo varchar(20),
	telefone_movel varchar(20),
	id_tipo int foreign key references tipo_usuario(id_tipo)
)

create table endereco(
	id_endereco int identity primary key not null, 
	cep int,
	rua varchar(50),
	numero int,
	cidade varchar(50),
	estado varchar(50)
);

alter table usuario	add id_endereco int foreign key references endereco(id_endereco);

create table usuario_externo(
	id_usuario_exerno int identity primary key not null,
	nome varchar(50),
	rg varchar(20),
	email varchar(100)
);

create table evento_usuario_externo(
	id_usuario_exerno int foreign key references usuario_externo(id_usuario_exerno),
	id_evento int foreign key references evento(id_evento)
	
);

create table evento_usuario(
	id_usuario int foreign key references usuario(id_usuario),
	id_evento int foreign key references eventos(id_evento)
);