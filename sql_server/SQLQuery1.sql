USE gufuuus_bd;

CREATE TABLE Tipo_usuario(
	Tipo_usuario_id INT IDENTITY PRIMARY KEY,
	Titulo VARCHAR(255) UNIQUE NOT NULL
);

CREATE TABLE Usuario(
	Usuario_id INT IDENTITY PRIMARY KEY,
	Nome VARCHAR(255) NOT NULL,
	Email VARCHAR(255) UNIQUE NOT NULL,
	Senha VARCHAR(255) NOT NULL,
	Tipo_usuario_id INT FOREIGN KEY REFERENCES Tipo_usuario(Tipo_usuario_id)
);

CREATE TABLE Localizacao(
	Localizacao_id INT IDENTITY PRIMARY KEY,
	CNPJ CHAR(14) UNIQUE NOT NULL,
	Razao_social VARCHAR(255) UNIQUE NOT NULL,
	Endereco VARCHAR(255) NOT NULL
);

CREATE TABLE Categoria(
	Categoria_id INT IDENTITY PRIMARY KEY,
	Titulo VARCHAR(255) UNIQUE NOT NULL
);

CREATE TABLE Evento(
	Evento_id INT IDENTITY PRIMARY KEY,
	Titulo VARCHAR(255) NOT NULL,
	Categoria_id INT FOREIGN KEY REFERENCES Categoria(Categoria_id),
	Acesso_livre BIT DEFAULT(1) NOT NULL,
	Data_evento DATETIME NOT NULL,
	Localizacao_id INT FOREIGN KEY REFERENCES Localizacao(Localizacao_id)
);

CREATE TABLE Presenca(
	Presenca_id INT IDENTITY PRIMARY KEY,
	Evento_id INT FOREIGN KEY REFERENCES Evento(Evento_id),
	Usuario_id INT FOREIGN KEY REFERENCES Usuario(Usuario_id),
	Presenca_status VARCHAR(255) NOT NULL
);



/* INSERIR DADOS */

INSERT INTO Tipo_usuario	(Titulo)
VALUES						('Administrador'),
							('Aluno')

INSERT INTO Usuario (Nome, Email, Senha, Tipo_usuario_id)
VALUES				('Administrador', 'adm@adm.com', '123',1),
					('Ariel', 'ariel@email.com', '123', 2)

INSERT INTO Localizacao (CNPJ, Razao_social, Endereco)
VALUES					('12345678912345',
						'Escola SENAI de Informática',
						'Al. Barão de Limeira, 539')

INSERT INTO Categoria	(Titulo)
VALUES					('Desenvolvimento'),
						('HTML + CSS'),
						('Marketing')

INSERT INTO Evento	(Titulo, Categoria_id, Acesso_livre, Data_evento, Localizacao_id)
VALUES				('C#', 2, 0, '2019-08-07T18:00:00', 1),
					('Estrutura Semântica', 2, 1, GETDATE(), 1)

INSERT INTO Presenca	(Evento_id, Usuario_id, Presenca_status)
VALUES					(1, 2, 'AGUARDANDO'),
						(1, 1, 'CONFIRMADO');


SELECT * FROM Categoria;

SELECT * FROM Evento;