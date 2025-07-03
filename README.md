# 🧩 TaskManager - CRUD em .NET Core com Azure SQL

## 📌 Sobre o Projeto

O objetivo deste projeto é desenvolver uma aplicação **CRUD** utilizando **.NET Core**, com **integração a um banco de dados no Azure SQL**, seguindo as **melhores práticas de desenvolvimento de software**, como Clean Architecture, princípios **SOLID** e separação de responsabilidades.

---

## 🚀 Tecnologias Utilizadas

- ⚙️ .NET Core
- 🛠️ Entity Framework Core
- ☁️ Azure SQL Database
- 🧠 C#
- 🗃️ Migrations
- 🧱 Arquitetura em Camadas / Clean Architecture

## 🎯 Funcionalidades

- ✅ Criar registros (**Create**)
- ✅ Listar registros (**Read**)
- ✅ Atualizar dados (**Update**)
- ✅ Remover registros (**Delete**)
- ✅ Integração com banco de dados na nuvem (**Azure SQL**)
- ✅ Autenticação e Autorização
- 🧪 Testes unitários *(em breve)*
- 🚀 Deploy com CI/CD *(em breve)*

---

## 📁 Estrutura do Projeto

```bash
/TaskManager
├── Domain           # Entidades e regras de negócio
├── Application      # Interfaces, DTOs e casos de uso
├── Infrastructure   # Implementações de repositórios, serviços e contexto de banco
├── API              # Camada de apresentação (Controllers e Program.cs)
