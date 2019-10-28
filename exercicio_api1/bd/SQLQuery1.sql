USE registro;

CREATE TABLE tarefa_tbl(
id_tarefa INT IDENTITY PRIMARY KEY NOT NULL,
nome_tarefa VARCHAR(50),
descricao_tarefa VARCHAR(50),
data_tarefa DATE
);

/*DROP TABLE tarefa_tbl; */


INSERT INTO tarefa_tbl(nome_tarefa, descricao_tarefa, data_tarefa)
VALUES('Guarda', 'Realizar a limpeza do estabelecimento', '2019/09/10');

SELECT * FROM tarefa_tbl;