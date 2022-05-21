Tecnologias utilizadas:
(pegar no GitHub o gráfico)


Instação do ambiente:
Compilador Visual Studio 2022
Pacotes instalados:
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL

Banco de dados: PostgreSQL

1)- Baixar o projeto
2)- executar a solution (WebGerenciamento.sln)
3)- instalar os pacotes adicionais acima citados

Executar estes comandos no terminal:
Add-Migration Criacao-Inicial -Context Contexto
Update-database -Context Contexto

Play na aplicação
