## SOBRE O PROJETO
---
Este é o projeto de uma _**API**_ desenvolvida utilizando o **NET 8.0**  e _**Domain Driven Design (DDD)**_ para oferecer o básico da gestão de faturamento para uma barbearia. O objetivo principal é permitir que os gestores sejam capazes de cadastrar, consultar, editar e deletar faturamentos, além de poder gerar relatórios mensais e semanais, em formato pdf e planilha.

A arquitetura da API se baseia em _**REST**_, com métodos _**HTTP**_ padrões para comunicação. Além disso, é complementada pela documentação _**Swagger**_, que dispõe uma interface gráfica intuitiva para que seja possível explorar e testar os endpoints da aplicação de maneira fácil.

Avaliando os pacotes _**NuGet**_ utilizados, o _**AutoMapper**_ v.13.0.1 foi o responsável pelo mapeamento entre os objetos do domínio e as requisições/respostas da API. O _**FluentAssertion**_ v.6.12.0 foi utilizado nos testes unitários, visando uma maior legibilidade e construção de testes claros e objetivos. Nas validações das regras de negócio para as classes de requisições, o _**FluentValidation**_ v.11.9.0 foi utilizado para validar de maneira simples e intuitiva. Por fim, o _**EntityFramework**_ atua como o _**ORM**_ (Object-Relational Mapper) que simplifica as interações entre os objetos .NET e as tabelas do banco de dados _**MySql**_, possibilitando manipular diretamente os dados, sem a necessidade de consulta puramente SQL.

![imagem-sistema]

### FEATURES
* **Domain-Driven Design (DDD)**: Estrutura modular que facilita o entendimento e a manutenção do domínio da aplicação.
* **Testes de Unidade**: Testes abrangentes com FluentAssertion que garantem funcionalidade e segurança;
* **RESTful API com documentação Swagger**: Interface documentada que facilita a integração e testes pelos desenvolvedores.

### CONSTUÍDO COM

![badge-.NET-Badge]
![badge-GitHub]
![badge-visual-studio]
![badge-mySql]
![badge-swagger]

### GETTING STARTED
Para obter uma cópia local funcional, siga estes passos:
* Visual Studio v.2022+ instalado;
* Windows 10+ ou Linux/MacOS com [.NET 8.0 SDK] [link-download-.net8-SDK]instalado;
*  [MySql Server v.8.0.46+] [link-download-mySqlServer] instalado;

### Instalação
1. Clone este repositório (ou faça o download do projeto): 
```
LINK REPOSITÓRIO AQUI
```
2. Preencha as informações no arquivo `BarberShop.API/appsettings.Development.json` com a _connection string_ do seu banco de dados já criado.
```
{
  "ConnectionStrings": {
    "Connection": "Server=localhost;Database=SUA_DATABASE_AQUI;Uid=SEU_UID_AQUI;Pwd=SUA_SENHA_AQUI;"
  }
}
```
   * Atente-se para a necessidade de **criar seu banco de dados antes de utilizar este repositório**. Ele funciona baseado na ideia de que o banco de dados já exite previamente. Caso seja necessário, abaixo o código sql que gera uma base de dados _barbershopdb_ e a estrutura da tabela _billings_, já com alguns registros:
   ```
   -- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
    --
    -- Host: localhost    Database: barbershopdb
    -- ------------------------------------------------------
    -- Server version	8.0.46

    /*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
    /*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
    /*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
    /*!50503 SET NAMES utf8 */;
    /*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
    /*!40103 SET TIME_ZONE='+00:00' */;
    /*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
    /*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
    /*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
    /*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

    --
    -- Table structure for table `billings`
    --
    CREATE DATABASE barbershopdb;
    DROP TABLE IF EXISTS `billings`;
    /*!40101 SET @saved_cs_client     = @@character_set_client */;
    /*!50503 SET character_set_client = utf8mb4 */;
    CREATE TABLE `billings` (
    `Id` char(36) NOT NULL,
    `Date` datetime NOT NULL,
    `BarberName` varchar(80) NOT NULL,
    `ClientName` varchar(120) NOT NULL,
    `ServiceName` varchar(120) NOT NULL,
    `Amount` decimal(10,2) NOT NULL,
    `PaymentMethod` int NOT NULL,
    `Status` int NOT NULL,
    `Notes` varchar(500) DEFAULT NULL,
    `CreatedAt` datetime NOT NULL,
    `UpdatedAt` datetime NOT NULL,
    PRIMARY KEY (`Id`)
    ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
    /*!40101 SET character_set_client = @saved_cs_client */;

    --
    -- Dumping data for table `billings`
    --

    LOCK TABLES `billings` WRITE;
    /*!40000 ALTER TABLE `billings` DISABLE KEYS */;
    INSERT INTO `billings` VALUES ('08ded156-2466-4e18-840d-3bc60447e24e','2026-06-23 00:00:00','LUCIANO','LUCIANO 2','Corte moicano',40.00,2,1,'Demorou muito','2026-06-23 18:34:12','2026-06-23 18:34:12'),
    ('08ded156-9623-4d40-8c0c-adadc44dc86f','2026-06-23 00:00:00','Luiz','Gustavo','Barba',0.00,0,0,'','2026-06-23 18:37:36','2026-06-23 18:37:36'),
    ('08ded1f4-cc33-45eb-8e33-d3d42b42a615','2026-06-24 00:00:00','Luciano1','Luciano1','Corte1',40.00,4,1,'Pago','2026-06-24 13:30:45','2026-06-24 13:30:45'),
    ('08ded1f4-f624-4fed-8830-c4855f92fe89','2026-06-24 00:00:00','Luciano2','Luciano2','Corte2',40.00,4,1,'Pago','2026-06-24 13:31:56','2026-06-24 13:31:56'),
    ('08ded1f6-8470-4af9-8e05-759e7a30b5fe','2026-06-25 00:00:00','Luciano3 Updated','string','string',0.00,4,0,'Cancelado Updated','2026-06-24 13:43:04','2026-06-25 13:17:51'),
    ('08ded6ac-c1b7-44bf-8156-d9ec6b4208a7','2026-04-30 13:36:08','teste','teste','teste',50.00,1,1,'teste','2026-06-30 13:37:40','2026-06-30 13:37:40'),
    ('08ded6ac-d415-44c0-8590-ebecf58e7d83','2026-04-30 13:36:08','teste1','teste1','teste1',200.00,2,1,'teste1','2026-06-30 13:38:11','2026-06-30 13:38:11'),
    ('08ded6ac-e17c-43a2-83ef-07bf9a2632ec','2026-04-30 13:36:08','teste2','teste2','teste2',40.00,3,1,'teste3','2026-06-30 13:38:34','2026-06-30 13:38:34'),
    ('08ded6b3-1e73-4dd3-880d-6ebc1530b568','2026-04-30 14:20:09','teste3','teste3','teste3',0.00,0,0,'cancelado','2026-06-30 14:23:12','2026-06-30 14:23:12'),
    ('08ded6b3-70d2-4d5a-8f96-da29a270dde8','2026-04-30 00:00:00','teste4','teste4','teste4',15.00,1,1,'teste4','2026-06-30 14:25:31','2026-06-30 14:25:31'),
    ('08ded6d3-9f4b-4bb8-8a89-c341523f51a2','2026-06-30 18:15:13','teste5','teste5','teste5',50.00,4,1,'teste5','2026-06-30 18:15:53','2026-06-30 18:15:53'),
    ('08ded6d3-af7a-48e5-8fbb-eb322fd2de97','2026-06-29 18:15:13','teste6','teste6','teste6',40.00,4,1,'teste6','2026-06-30 18:16:20','2026-06-30 18:16:20'),
    ('08ded6d3-bf6a-4c89-8257-67625a5da130','2026-06-30 18:42:41','teste7 UPDATED','teste7 UPDATED','teste7 UPDATED',55.00,4,1,'teste7 UPDATED','2026-06-30 18:16:47','2026-06-30 18:43:34'),
    ('08ded6d7-4276-4d61-8a91-e84b91262aa8','2026-06-30 18:41:20','teste8','teste8','teste8',35.00,3,1,'teste8','2026-06-30 18:41:55','2026-06-30 18:41:55'),
    ('08ded83a-a7e0-4b9b-8d1a-c4e5bb33677f','2026-06-02 13:04:03','teste8','teste8','teste8',50.00,3,1,'teste8','2026-07-02 13:05:56','2026-07-02 13:05:56');

    /*!40000 ALTER TABLE `billings` ENABLE KEYS */;
    UNLOCK TABLES;
    /*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

    /*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
    /*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
    /*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
    /*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
    /*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
    /*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
    /*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
   ```

3. Execute a API.

<!--ALIASES-->
[link-download-.net8-SDK]: https://dotnet.microsoft.com/pt-br/download/dotnet/8.0
[link-download-mySqlServer]:https://dev.mysql.com/downloads/mysql/8.0.html
[imagem-sistema]: images/systemFeatures.png
[badge-.NET-Badge]: https://img.shields.io/badge/.NET-512BD4?logo=dotnet&logoColor=fff&style=for-the-badge
[badge-GitHub]: https://img.shields.io/badge/GitHub-181717?logo=github&logoColor=fff&style=for-the-badge
[badge-visual-studio]: https://img.shields.io/badge/Visual%20Studio-5C2D91?logo=visualstudio&logoColor=fff&style=for-the-badge
[badge-mySql]: https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=fff&style=for-the-badge
[badge-swagger]: https://img.shields.io/badge/Swagger-85EA2D?logo=swagger&logoColor=000&style=flat