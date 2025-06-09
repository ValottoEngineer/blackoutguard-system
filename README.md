# 🛡️ BlackoutGuard – Sistema de Monitoramento e Resposta a Falhas Elétricas

Projeto desenvolvido no contexto do programa **Global Solution - FIAP (2025)**, com foco em integração interdisciplinar frente ao tema **Eventos Climáticos Extremos – Falta de Energia**.

---
### 👨‍🎓 Integrantes:

RM 551445 - **Pedro Oliveira Valotto**

RM97877 - **Pedro Henrique Pedrosa Tavares**

RM97974 - **Guilherme Rocha Bianchini**

## 📌 Descrição do Projeto

O **BlackoutGuard** é uma aplicação desktop desenvolvida em C# (.NET) que permite o **registro de falhas elétricas**, **disparo de alertas automáticos**, **simulação de incidentes** e **geração de relatórios** em ambientes urbanos mistos (residencial + coworking).

---

## 🧠 Objetivo

Auxiliar síndicos, técnicos e administradores durante apagões ou incidentes críticos, centralizando informações e gerando alertas automáticos com base em regras de impacto.

---

## ⚙️ Tecnologias Utilizadas

- 💻 Linguagem: **C#**
- 🧱 Arquitetura: **Programação Orientada a Objetos (POO)**
- 🧪 Estrutura: **Validações e Try-Catch para entradas inválidas**
- 🗃️ Armazenamento: **JSON local**
- 🔒 Autenticação simples via console
- ✅ Compatível com **.NET 6.0** e **Visual Studio 2019+**

---

## 🔑 Funcionalidades

### Funcionalidades principais:
- 📝 Registro manual de incidentes
- ⚙️ Simulação aleatória de falhas elétricas
- 🚨 Geração de alertas com base no impacto (visual + lógica)
- 📊 Listagem do histórico completo de falhas
- 📤 Exportação de relatório em CSV (pasta `arquivos`)

### Funcionalidades complementares:
- 🔐 Login com autenticação básica via console
- 🛡️ Validação e tratamento de erros de entrada
- 🧪 Uso de `try-catch` e mensagens de erro amigáveis

---

## 🧪 Como Executar

🧪 Como Executar
Para executar o sistema BlackoutGuard corretamente, siga os passos abaixo:

1. Clone o repositório:

https://github.com/ValottoEngineer/blackoutguard-system.git

2. Abra o projeto no Visual Studio (versão 2019 ou superior):

    - Navegue até a pasta Blackoutguard-System.

    - Localize o arquivo .sln (solução) e abra com o Visual Studio.

3. Compile a aplicação:

    - No menu superior, clique em Build > Build Solution (ou pressione Ctrl + Shift + B).

    - Verifique se a compilação foi bem-sucedida no painel inferior.

4. Execute a aplicação:

    - Pressione F5 ou clique em Start para iniciar o programa.

    - O terminal será aberto com a tela de login.

5. Faça login utilizando o usuário padrão:

usuário: operador
senha: energia2025

6. Utilize o menu interativo para testar as funcionalidades:

    - Registrar novo incidente

    - Simular falha crítica

    - Listar histórico de incidentes

    - Exportar relatório em formato CSV

ℹ️ O sistema armazena os dados localmente no arquivo incidentes.json, que será atualizado automaticamente após o primeiro registro.

🎥 Vídeo Pitch
Apresentação da aplicação no YouTube:
🔗 https://youtu.be/SEU-LINK-AQUI
