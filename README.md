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
Para testes, utilize os seguintes dados de Usuário e Senha: <br/><br/>
<pre>
  Tech Leader - Usuário: 4455667788 | Senha: 123456  <br/>
  Desenvolvedor - Usuário: 0123456789 | Senha: 000000  <br/> 
  Administrador - Usuário: 34512367809 | Senha: 123456  <br/> 
</pre>

 ### Administrador
 Na tela principal de administrador há três botões: dois relacionados ao cadastro e outro para remoção de usuários (Desenvolvedor ou Tech Leader). <br/>

 <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaAdministrador.png" width="400"> <br/>
  Figura 2: Tela Principal de Administrador <br/><br/><br/>
  </p>
  
**CADASTRAR DESENVOLVEDOR**: Abre uma nova janela para cadastrar novos usuários do tipo desenvolvedor no sistema (campos: senha, nome, cpf, email). <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaCadastrarDesenvolvedor.png" width="400"> <br/>
  Figura 3: Tela Cadastramento de Desenvolvedor em Administrador<br/><br/>
  </p>       
  
**CADASTRAR TECH LEADER**: Abre uma nova janela para cadastrar novos usuários do tipo tech leader no sistema (campos: senha, nome, cpf, email). <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaCadastrarTech.png" width="400"> <br/>
  Figura 4: Tela Cadastramento de Tech Leader em Administrador<br/><br/>
  </p>

  **REMOVER USUÁRIOS**: Abre uma nova janela para Remoção de usuários do sistema. Escolhe o nome do usuário que deseja remover, após isso o usuário será removido do sistema. <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaRemoverUsuario.png" width="400"> <br/>
  Figura 5: Tela Remoção de Usuários em Administrador<br/><br/>
  </p>     
  
### Tech Leader
 
 Na tela principal de Tech Leader há sete botões: um botão relacionado a criação de novas tarefas, dois relacionados a visualização (estatísticas das tarefas e outro para observar as tarefas ativas/desativadas), dois botões relacionados a alterações de tarefas (status ou do responsável), um botão para aprovar/reprovar tarefas pendentes ou em análise e uma opção para adicionar usuários desenvolvedores. <br/>

 <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaTechLeader.png" width="400"> <br/>
  Figura 6: Tela Principal de Tech Leader <br/><br/><br/>
  </p>
  
**CRIAR TAREFA**: Abre uma nova janela para cadastrar novas tarefas no sistema (campos: título, descrição, data de inicio, data de finalização, tamanho, prioridade, responsável e tarefas relacionadas). Para opção de escolha em responsável, serão mostrados todos os usuários (Tech Leader ou Desenvolvedor). Assim que finalizar o cadastramento, a tarefa será classificada como "Em andamento" ou "Atrasada", dependendo da sua data de início.<br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaCriarTarefa.png" width="400"> <br/>
  Figura 7: Tela de Criação de tarefa em TechLEader<br/><br/>
  </p>     
  
**VISUALIZAR TAREFAS**: Abre uma nova janela para escolher quais tarefas serão visualizadas, podendo ser ativas (Em andamento, Atrasadas, Análise ou com Impedimento) ou desativadas (Concluídas, Abandonadas ou Pendente). <br/>
<p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/MessageVisualizarTarefas.png" width="400"> <br/>
  Figura 8: Tela de Decisão sobre Visualização da Tarefa<br/><br/>
  </p>
    
Após a decisão, serão mostradas todas as tarefas cadastradas no sistema para visualização. <br/>

    <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaVisualizarTarefasAtivas.png" width="400">  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaVisualizarTarefasDesativadas.png" width="400"> <br/>
  Figura 9: Tela Visualização de Tarefas em Tech Leader<br/><br/>
  </p>
  
  **ESTATÍSTICAS**: Abre uma nova janela para visualizar as estatísticas de cada tarefa, mostrando a quantidade de tarefas com seus respectivos status. Além disso, ao lado de cada estatísticas há um botão para observar quais as tarefas que possuem aquele status. <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaEstatisticas.png" width="400"> <br/>
  Figura 10: Tela com Estatísicas de tarefas em Tech Leader<br/><br/>
  </p>     
  
  **ALTERAR STATUS**: Abre uma nova janela para alterar o status de uma tarefa no sistema. Escolhe a tarefa que será alterada e o seu novo status(Apenas permite colocar para Análise, Impedimento, Abandonada e EmAndamento). Não é permitido converter uma tarefa de atrasada para em andamento. <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaAltStatusTech.png" width="400"> <br/>
  Figura 11: Tela para Alterar Status da Tarefa em Tech Leader<br/><br/>
  </p>  
  
   **ALTERAR RESPONSÁVEL**: Abre uma nova janela para alterar o responsável de uma tarefa no sistema. Escolhe a tarefa que será alterada e o seu novo responsável, podendo ser tech leadr ou desenvolvedor. <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaAltResponsavel.png" width="400"> <br/>
  Figura 12: Tela para Alterar Responsável da Tarefa em Tech Leader<br/><br/>
  </p>  
  
  **APROVAR TAREFA**: Abre uma nova janela para escolher entre aprovar e reprovar tarefas pendentes ou em análise. Análise - Aprovada: Muda de status para Concluída | Reprovada: Muda de status para EmAndamento ou Atrasada. Pendente - Aprovada: Muda de status para EmAndamento ou Atrasada | Reprovada: Tarefa é excluída.<br/>
  
<p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/MessageAprovarTarefa.png" width="400"> <br/>
  Figura 13: Tela de Decisão sobre Tipo da Tarefa para Aprovar<br/>
  </p>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaAprovarTarefa.png" width="400"> <br/>
  Figura 14: Tela para Alterar Responsável da Tarefa em Tech Leader<br/><br/>
  </p>  

 **CADASTRAR DESENVOLVEDOR**: Abre uma nova janela para cadastrar novos usuários do tipo desenvolvedor no sistema (campos: senha, nome, cpf, email). <br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaCadastrarDesenvolvedor.png" width="400"> <br/>
  Figura 15: Tela de Cadastramento de Desenvolvedor em Tech Leader<br/><br/>
  </p>  
 
 ### Desenvolvedor
 
 Na tela principal de Desenvolvedor há 3 botões: um botão relacionado a criação de novas tarefas, outro relacionados a visualização das tarefas ativas/desativadas e um que altera o status da tarefa desejada. <br/>

 <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaDesenvolvedor.png" width="400"> <br/>
  Figura 16: Tela Principal de Desenvolvedor <br/><br/><br/>
  </p>
  
**CRIAR TAREFA**: Abre uma nova janela para cadastrar novas tarefas no sistema (campos: título, descrição, data de inicio, data de finalização, tamanho, prioridade, responsável e tarefas relacionadas). Para opção de escolha em responsável, será mostrado apenas o nome do próprio desenvolvedor. Assim que finalizar o cadastramento, a tarefa será classificada como "Pendente", na qual só poderá avançar com a permissão do Tech Leader.<br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaCriarTarefaDev.png" width="400"> <br/>
  Figura 17: Tela de Criação de tarefa em Desenvolvedor<br/><br/>
  </p>     
  
**VISUALIZAR TAREFAS**: Abre uma nova janela para escolher quais tarefas serão visualizadas, podendo ser ativas (Em andamento, Atrasadas, Análise ou com Impedimento) ou desativadas (Concluídas, Abandonadas ou Pendente).<br/>
     <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/MessageVisualizarTarefas.png" width="400"> <br/>
  Figura 18: Tela de Decisão sobre Visualização da Tarefa<br/><br/>
  </p>
  
Após a decisão, serão mostradas as tarefas que pertencem ao desenvolvedor para visualização. <br/>

    <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaVisualizarTarefasAtivas.png" width="400">  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaViusualizarDesativadaDev.png" width="400"> <br/>
  Figura 19: Tela Visualização de Tarefas em Desenvolvedor<br/><br/>
  </p>

  **ALTERAR STATUS**: Abre uma nova janela para alterar o status de uma tarefa no sistema. Escolhe a tarefa que será alterada e o seu novo status (Apenas permite colocar para Análise, Impedimento e EmAndamento). Tarefas atrasadas não podem ter seu status alterado para EmAndamento.<br/>
      <p align="center">
  <img src="https://github.com/lauradefaria/GerenciadorTarefas/blob/master/imgs/TelaAltStatusDev.png" width="400"> <br/>
  Figura 20: Tela para Alterar Status da Tarefa em Desenvolvedor<br/><br/>
  </p>  

---

## Dados

Os dados iniciais referentes aos Usuários (Tech Leader, Desenvolvedor e Administrador) e Tarefas estão contidos dentro de arquivos txt. Eles estão localizados na pasta "Data" e poderão ser alterados no decorrer do programa. Para alterar o caminho do arquivo de acordo com a sua máquina, coloque o caminho do aquivo na variável "FILE_PATH" presente em "TarefasData" e "UsuariosData" (DataBusiness). <br/>

---

## Itens Obrigatórios

**GERAIS**
- [X] Existem apenas dois vínculos: tech leader e desenvolvedores. <br/>
- [X] Para entrar no sistema, todos precisam de uma chave de acesso<br/><br/>

**TECH LEADER**
- [X] Podem ver as tarefas de todos<br/>
- [X] Podem criar tarefas<br/>
- [X] Podem assumir tarefas<br/>
- [X] Permitir acesso a estatísticas como: tarefas em atraso, tarefas concluídas, tarefas abandonadas, tarefas com impedimento, tarefas em análise (se foram mesmo concluídas ou se retornam - o tech leader que decide), e tarefas a serem aprovadas para inicio (tarefas que não foram feitas pelo tech leader e precisam de autorização para começar)<br/>
- [X] Colocar um responsável pela tarefa que não seja o criador dela, ou mudar o responsável pela tarefa (APENAS ELE) <br/>
- [X] Leitura dos dados por txt
- [ ] Atualizar desenvolvedores por json <br/>
- [X] As tarefas podem ter relação quando fazem funções diferentes mas no mesmo local, como: criação da classe de produtos e criação do formulário de criação de produtos (mesmo que não tenham o mesmo responsável) <br/><br/>

**DESENVOLVEDORES**
- [X] Podem criar tarefas (e automaticamente são os responsáveis por ela), o tempo da tarefa fica em aberto a ser definido pelo tech leader<br/>
- [X] Os desenvolvedores veem apenas suas tarefas ou tarefas que tenham relação com a sua<br/>
- [X] A tarefa só pode ser iniciada com a autorização do tech leader<br/>

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
