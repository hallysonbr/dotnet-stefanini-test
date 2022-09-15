# Teste técnico Stefanini

## 1. Descrição

O teste técnico Stefanini consiste em uma aplicação Web Api em .Net Core, na versão 6.0, que implementa um CRUD básico das Entidades Pessoa e Cidade.


## 2. Arquitetura

A arquitetura usada neste projeto foi a mesma disponibilizada pela empresa. O projeto está dividido em camadas(Domain, Infra, Application, API), usando como banco de dados o SQL Server e a criação do Banco e Tabelas realizados através de migrations, com Entity Framework Core.

Dentro do projeto, há um projeto docker-compose configurado e pronto disponibilizado pela empresa para a execução do projeto dentro de um container Docker. Porém, devido algumas limitações na máquina usada pra codificar o projeto, não foi possível executá-lo em ambiente Docker. Portanto, o projeto foi executado e testado em ambiente local(Aplicação e Banco de Dados).
