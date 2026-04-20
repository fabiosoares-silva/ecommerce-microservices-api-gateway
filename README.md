# 🚀 ecommerce-microservices-api-gateway

> Projeto focado na implementação de uma arquitetura distribuída utilizando .NET 8, explorando escalabilidade, segurança e comunicação assíncrona.

## 📌 Sobre o Projeto
Este projeto simula um cenário real de e-commerce, onde a gestão de inventário e o processamento de pedidos operam de forma independente. A arquitetura foi desenhada para aplicar conceitos de **DDD**, desacoplamento via mensageria com **RabbitMQ** e centralização de acessos através de um **API Gateway**.

## 🛠️ Tecnologias e Conceitos
* **Back-end:** .NET 8 (C#)
* **ORM:** Entity Framework Core
* **Banco de Dados:** SQL Server (Estratégia de base de dados por serviço)
* **API Gateway:** Ocelot
* **Mensageria:** RabbitMQ (Para notificações de vendas e atualização de estoque)
* **Segurança:** AuthService com Autenticação JWT
* **Práticas:** SOLID, Clean Code e Migrations para versionamento de base de dados

## 🏗️ Estrutura da Solução
A solução está organizada nos seguintes projetos:
1. **Estoque:** Responsável pelo catálogo de produtos, gestão de quantidades e validação de disponibilidade.
2. **Vendas:** Orquestração de pedidos e integração com o serviço de estoque.
3. **AuthService:** Microserviço dedicado à autenticação e geração de tokens JWT.
4. **ApiGateway:** Ponto de entrada único que utiliza o Ocelot para rotear as chamadas aos serviços internos.

## 🚧 Status do Desenvolvimento
- [x] Estrutura da Solução e Criação dos Projetos
- [x] Configuração inicial do API Gateway (Ocelot)
- [x] Definição dos Modelos e Contextos (EF Core)
- [ ] Implementação da Lógica de Mensageria com RabbitMQ
- [ ] Finalização dos fluxos de Autenticação JWT
- [ ] Testes Unitários e de Integração

---
*Projeto em constante evolução como parte do meu plano de especialização em arquitetura distribuída.*
