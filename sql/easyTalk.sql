create database easyTalk;
use easyTalk;
create table categoria(
	id_categoria int identity primary key not null,
	nome_categoria varchar(50)
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
	telefone_movel varchar(20),
	id_tipo int foreign key references tipo_usuario(id_tipo)
)

create table eventos(
	id_evento int identity primary key not null,
	nome_evento varchar(100),
	descricao text,
	data_evento DateTime,
	data_criacao DateTime,
	ativo int,
	localizacao varchar(100),
	id_categoria int foreign key references categoria(id_categoria),
	id_usuario int foreign key references usuario(id_usuario),
	id_responsavel int foreign key references usuario(id_usuario)
)