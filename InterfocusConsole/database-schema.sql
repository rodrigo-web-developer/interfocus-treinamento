
create table alunos(
	codigo integer not null,
	nome varchar(100),
	datanascimento date,
	email varchar(200)
);

create sequence cursos_seq;
create sequence inscricao_seq;

create table cursos(
	id integer not null default nextval('cursos_seq'),
	nome varchar(50),
	descricao text,
	nivel integer not null,
	duracao integer not null,
	primary key (id)
);

create table inscricao(
	id integer not null default nextval('inscricao_seq'),
	alunocodigo integer,
	cursoid integer,
	data timestamp default now()
);

alter table inscricao 
add constraint fk_inscricao_aluno foreign key (alunocodigo)
references alunos(codigo);

alter table inscricao 
add constraint fk_inscricao_curso foreign key (cursoid)
references cursos(id);


create sequence alunos_seq;

alter table alunos
add primary key (codigo);

alter table alunos
alter column codigo set default nextval('alunos_seq');