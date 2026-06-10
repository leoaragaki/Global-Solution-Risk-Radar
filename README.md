📌 Sobre o Projeto

O Risk Radar é uma plataforma inteligente desenvolvida para monitoramento, registro e gerenciamento de desastres naturais, permitindo a identificação rápida de pessoas afetadas e a geração automática de alertas de emergência.

O objetivo da solução é reduzir o tempo de resposta em situações críticas, auxiliando órgãos públicos, equipes de emergência e comunidades vulneráveis através da centralização de informações em uma única plataforma.

Este projeto foi desenvolvido para a Global Solution FIAP 2026, alinhado aos desafios de prevenção e resposta a desastres naturais por meio da tecnologia.

🎯 Problema

Desastres naturais como:

🌧️ Enchentes
🔥 Queimadas
⛰️ Deslizamentos
⛈️ Tempestades severas

causam perdas humanas e prejuízos econômicos significativos todos os anos.

Os principais desafios identificados são:

Falta de monitoramento integrado
Baixa velocidade na comunicação de emergências
Dificuldade em identificar pessoas afetadas
Resposta tardia das equipes de resgate
💡 Solução

O Risk Radar permite:

✅ Cadastro de pessoas afetadas

✅ Registro de desastres

✅ Emissão automática de alertas

✅ Associação entre vítimas e ocorrências

✅ Consulta em tempo real das informações

✅ Integração futura com sensores IoT e sistemas de monitoramento espacial

⚙️ Tecnologias Utilizadas
Backend
ASP.NET Core Web API (.NET 8)
C#
Entity Framework Core
Swagger/OpenAPI
Banco de Dados
Oracle Database
Integrações Futuras
Java
IoT (Internet of Things)
Sensores Inteligentes
Satélites de Monitoramento
🏗️ Arquitetura do Projeto
RiskRadar
│
├── Controllers
│   ├── PessoasController.cs
│   ├── DesastresController.cs
│   └── AlertasController.cs
│
├── Models
│   ├── PessoaAfetada.cs
│   ├── Desastre.cs
│   └── Alerta.cs
│
├── Data
│   └── AppDbContext.cs
│
├── Services
│   └── AlertaService.cs
│
├── Program.cs
└── appsettings.json
📊 Modelo de Negócio
Entidades Principais
Pessoa Afetada

Representa os cidadãos impactados por um desastre.

Desastre

Representa eventos como enchentes, queimadas e deslizamentos.

Alerta

Representa notificações automáticas geradas pelo sistema.

🔄 Fluxo da Aplicação
Pessoa Afetada
       │
       ▼
Cadastro no Sistema
       │
       ▼
Registro de Desastre
       │
       ▼
Análise da Gravidade
       │
       ▼
Gravidade CRÍTICA?
       │
   Sim ▼
       │
Geração Automática de Alerta
       │
       ▼
Associação com Pessoa Afetada
       │
       ▼
Consulta pelas Equipes de Emergência
🚨 Regra de Negócio Principal

Quando um desastre é registrado com gravidade:

CRÍTICA

o sistema:

Ativa automaticamente o alarme.
Cria um alerta.
Associa o alerta à pessoa afetada.
Disponibiliza a informação para consulta via API.
🔌 Endpoints Disponíveis
Pessoas
Método	Endpoint
GET	/api/Pessoas
GET	/api/Pessoas/{id}
POST	/api/Pessoas
PUT	/api/Pessoas/{id}
DELETE	/api/Pessoas/{id}
Desastres
Método	Endpoint
GET	/api/Desastres
GET	/api/Desastres/{id}
POST	/api/Desastres
PUT	/api/Desastres/{id}
DELETE	/api/Desastres/{id}
Alertas
Método	Endpoint
GET	/api/Alertas
GET	/api/Alertas/{id}


POST	/api/Alertas
PUT	/api/Alertas/{id}
DELETE	/api/Alertas/{id}
