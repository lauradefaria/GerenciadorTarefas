[![author](https://img.shields.io/badge/author-lauradefaria-blue.svg)](https://github.com/lauradefaria)
# GerenciadorTarefas
O projeto tem como objetivo elaborar um sistema de gerenciamento de tarefas. Nele, será possível organizar e identificar as tarefas dos desenvolvedores. O projeto tem como intuito aplicar os conceitos de POO e Lógica de Programação em C#, no qual foram adquiridos durante os módulos 1 e 2 do curso DiverseDEV organizado pelas instituições: ADA Tech e Mercado Eletrônico. <br/>

---

## Tabela de conteúdos
- [Organização do Sistema](#organizacao-do-sistema)
- [Interface dos Usuários](#interface-dos-usuarios)
- [Dados](#dados)
- [Clonar Respositório](#clonar-repositorio)
- [Autor](#autor)

---

## Organização do Sistema

### Usuários

Como usuários do sistemas temos o Tech Leader e o Desenvolvedor.<br/>
<pre>
  Descrição:<br/>
  - Administradores: Podem adicionar ou remover usuários do sistema.
  - Tech Leader: Podem ver as tarefas de todos, podem criar tarefas e também assumir tarefas, possuem também acesso a estatísticas. Além disso, pode colocar um responsável pela tarefa que não seja o criador dela, ou mudar o responsável pela tarefa. Por fim, ele também define o tempo da tarefa fica em aberta, autoriza o início da tarefa e designar correlações entre tarefas.
  - Desenvolvedor: Podem criar tarefas (e automaticamente são os responsáveis por ela). Os desenvolvedores veem apenas suas tarefas ou tarefas que tenham relação com a sua.<br/>
</pre>

### Tarefas

As tarefas podem ser classificadas dos seguintes tipos: Tarefa em Atraso; Tarefa Concluída, Tarefa Abandonada, Tarefas com Impedimento, Tarefas em análise, Tarefas Aguardando Aprovação. <br/>
<pre>
  Descrição Tarefas Ativas:<br/>
  - Tarefa Concluída: Tarefa já foi finalizada pelo desenvolvedor. <br/>
  - Tarefa Em Andamento: Tarefa que está sendo desenvolvida (se encontra dentro do seu limite de prazo). <br/>
  - Tarefa Atrasada: Tarefa que está sendo desenvolvida, porém ultrapassou a data final da entrega. <br/>
  - Tarefa Com Impedimento: Tarefa que não pode progredir ou ser concluída devido a algum tipo de obstáculo, problema ou bloqueio<br/>

  Descrição Tarefas Desativadas:<br/>
  - Tarefa Abandonada: Tarefa que foi iniciada, mas, por algum motivo, não foi concluída ou não está mais em andamento<br/>
  - Tarefas em análise: Tarefas que precisam da verificação se foram mesmo concluídas ou se retornam - o tech leader que decide. <br/>
  - Tarefas Com Aprovação Pendente: Tarefas que não foram feitas pelo tech leader e precisam de autorização para começar. <br/>
</pre>

---

## Interface dos Usuários

### Geral

O sistema inicia com a tela de login, na qual sera digitado o código de login do usuário e a senha, além de escolher entre o tipo de usuário, podendo ser:Tech Leader ou Desenvolvedor. <br/>

<p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaLogin.png" width="400"> <br/>
  Figura 1: Tela de Login     <br/>
</p>
Para testes, utilize os seguintes dados de Usuário e Senha: <br/>


 ### Administrador
 Na tela principal de administrador há três botões: dois relacionados ao cadastro ou remoção de usuários (Desenvolvedor ou Tech Leader) e outro relacionado a visualização dos usuários ativos no sistema. <br/>

 <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaAtendente.png" width="400"> <br/>
  Figura 2: Tela Principal de Administrador <br/><br/><br/>
  </p>
  
**CADASTRAR USUÁRIOS**: Abre uma nova janela para cadastrar novos usuários no sistema (campos: senha, nome, cpf, email). <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaCadastrarUsuarios.png" width="400"> <br/>
  Figura 3: Tela Cadastramento de Usuários em Administrador<br/><br/>
  </p>     

  **REMOVER USUÁRIOS**: Abre uma nova janela para Remoção de usuários do sistema. Escolhe o tipo do usuário que deseja remover e depois o seu nome, após isso o usuário será removido do sistema. <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaRemoverUsuarios.png" width="400"> <br/>
  Figura 4: Tela Remoção de Usuários em Administrador<br/><br/>
  </p>     
  
**VISUALIZAR USUÁRIOS**: Abre uma nova janela para a visualização das usuários ativos no sistema. <br/>
      <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarUsuarios.png" width="400"> <br/>
  Figura 5: Tela Visualização de Usuários em Administrador<br/><br/>
  </p>
  
### Tech Leader
 
 Na tela principal de Tech Leader há cinco botões: um botão relacionado a criação de novas tarefas, dois relacionados a visualização (estatísticas das tarefas e outro para observar as tarefas ativas/desativadas) e dois botões relacionados a alterações de tarefas (status ou do responsável). <br/>

 <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaTechLeader.png" width="400"> <br/>
  Figura 6: Tela Principal de Tech Leader <br/><br/><br/>
  </p>
  
**CRIAR TAREFA**: Abre uma nova janela para cadastrar novas tarefas no sistema (campos: título, descrição, data de inicio, data de finalização, tamanho, prioridade, responsável e tarefas relacionadas). Para opção de escolha em responsável, serão mostrados todos os usuários (Tech Leader ou Desenvolvedor). Assim que finalizar o cadastramento, a tarefa será classificada como "Em andamento" ou "Atrasada", dependendo da sua data de início.<br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaCriarTarefas.png" width="400"> <br/>
  Figura 7: Tela de Criação de tarefa em TechLEader<br/><br/>
  </p>     
  
**VISUALIZAR TAREFAS**: Abre uma nova janela para escolher quais tarefas serão visualizadas, podendo ser ativas (Em andamento, Atrasadas, Análise ou com Impedimento) ou desativadas (Concluídas, Abandonadas ou Pendente). <br/>
      <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarTarefas.png" width="400"> <br/>
  Figura 8: Tela Visualização de Tarefas em Tech Leader<br/><br/>
  </p>
  
  **ESTATÍSTICAS**: Abre uma nova janela para visualizar as estatísticas de cada tarefa, mostrando a quantidade de tarefas com seus respactivos status. <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaEstatisticas.png" width="400"> <br/>
  Figura 10: Tela com Estatísicas de tarefas em Tech Leader<br/><br/>
  </p>     
  
  **ALTERAR STATUS**: Abre uma nova janela para alterar o status de uma tarefa no sistema. Escolhe a tarefa que será alterada e o seu novo status. <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaAlterarStatus.png" width="400"> <br/>
  Figura 11: Tela para Alterar Status da Tarefa em Tech Leader<br/><br/>
  </p>  
  
   **ALTERAR RESPONSÁVEL**: Abre uma nova janela para alterar o responsável de uma tarefa no sistema. Escolhe a tarefa que será alterada e o seu novo responsável. <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaAlterarResponsavel.png" width="400"> <br/>
  Figura 12: Tela para Alterar Responsável da Tarefa em Tech Leader<br/><br/>
  </p>  
 
 ### Desenvolvedor
 
 Na tela principal de Desenvolvedor há 2 botões: um botão relacionado a criação de novas tarefas e outro relacionados a visualização das tarefas ativas/desativadas. <br/>

 <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaDesenvolvedor.png" width="400"> <br/>
  Figura 13: Tela Principal de Desenvolvedor <br/><br/><br/>
  </p>
  
**CRIAR TAREFA**: Abre uma nova janela para cadastrar novas tarefas no sistema (campos: título, descrição, data de inicio, data de finalização, tamanho, prioridade, responsável e tarefas relacionadas). Para opção de escolha em responsável, será mostrado apenas o nome do próprio desenvolvedor. Assim que finalizar o cadastramento, a tarefa será classificada como "Pendente", na qual só poderá avançar com a permissão do Tech Leader.<br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaCriarTarefas.png" width="400"> <br/>
  Figura 14: Tela de Criação de tarefa em Desenvolvedor<br/><br/>
  </p>     
  
**VISUALIZAR TAREFAS**: Abre uma nova janela para escolher quais tarefas serão visualizadas, podendo ser ativas (Em andamento, Atrasadas, Análise ou com Impedimento) ou desativadas (Concluídas, Abandonadas ou Pendente). Apenas serão mostradas as tarefas relacionadas ao próprio desenvolvedor. <br/>
      <p align="center">
  <img src="https://github.com/tauanyfeitosa/AdaTech.ProjetoFinal/blob/master/imgs/TelaVisualizarTarefas.png" width="400"> <br/>
  Figura 15: Tela Visualização de Tarefas em Desenvolvedor<br/><br/>
  </p>

---

## Dados

Os dados iniciais referentes aos Usuários (Tech Leader, Desenvolvedor e Administrador) e Tarefas estão sendo inicializados dentro do código. Futuramente será adaptado para serem lidos de arquivos TXT localizados na pasta "Data", eles poderão ser alterados no decorrer do programa, sendo sempre atualizados.<br/>

---

## Itens Obrigatórios

**GERAIS**
- [X] Existem apenas dois vínculos: tech leader e desenvolvedores. <br/>
- [X] Para entrar no sistema, todos precisam de uma chave de acesso<br/><br/>

**TECH LEADER**
- [X] Podem ver as tarefas de todos<br/>
- [X] Podem criar tarefas<br/>
- [X] Podem assumir tarefas<br/>
- [ ] Permitir acesso a estatísticas como: tarefas em atraso, tarefas concluídas, tarefas abandonadas, tarefas com impedimento, tarefas em análise (se foram mesmo concluídas ou se retornam - o tech leader que decide), e tarefas a serem aprovadas para inicio (tarefas que não foram feitas pelo tech leader e precisam de autorização para começar)<br/>
- [X] Colocar um responsável pela tarefa que não seja o criador dela, ou mudar o responsável pela tarefa (APENAS ELE) <br/>
- [ ] Atualizar desenvolvedores por txt ou json
- [X] As tarefas podem ter relação quando fazem funções diferentes mas no mesmo local, como: criação da classe de produtos e criação do formulário de criação de produtos (mesmo que não tenham o mesmo responsável) <br/><br/>

**DESENVOLVEDORES**
- [X] Podem criar tarefas (e automaticamente são os responsáveis por ela), o tempo da tarefa fica em aberto a ser definido pelo tech leader<br/>
- [X] Os desenvolvedores veem apenas suas tarefas ou tarefas que tenham relação com a sua<br/>
- [ ] A tarefa só pode ser iniciada com a autorização do tech leader<br/>

---

## Clonar Repositório

- Clone esse repositório na sua máquila local utilizando
    > https://github.com/lauradefaria/GerenciadorTarefas.git

---
## Autor
|<a href="https://www.linkedin.com/in/lauradefaria/" target="_blank">**Laura de Faria**</a> | 
|:-----------------------------------------------------------------------------------------:|
|                   <img src="imgs/laura.png" width="200px"> </img>                            |
|               <a href="http://github.com/lauradefaria" target="_blank">`github.com/lauradefaria`</a>      |
