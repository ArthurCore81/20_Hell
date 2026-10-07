# Vinte e Um: Fuga do Inferno

Um pequeno jogo de terminal inspirado em **21 / Blackjack**, feito em C#.

Você apostou sua alma contra o demônio… e perdeu. Agora, para escapar do inferno, será preciso enfrentar uma sequência de dealers demoníacos em partidas de Vinte e Um.

## Objetivo

Chegue o mais perto possível de 21 pontos sem ultrapassar esse valor.

Durante a partida, o jogador pode:

- Comprar cartas;
- Ver suas próprias cartas;
- Ver a carta visível do dealer;
- Parar e deixar o dealer jogar.

Se sua pontuação passar de 21, você perde a rodada. Caso empate com o dealer, os naipes podem ser usados como critério de desempate.

## Tecnologias

- C#
- .NET
- Aplicação de console

## Como executar

Abra o terminal na pasta do projeto e execute:

```powershell
dotnet run
```

## Estrutura do projeto

- `Carta`: representa uma carta e cria/embaralha o baralho.
- `Participante`: contém comportamentos compartilhados entre jogador e dealer.
- `Jogador`: representa quem está jogando.
- `Dealer`: controla as ações do adversário.
- `Jogar`: organiza as regras e o andamento da partida.
- `Interface`: mostra mensagens, menus e recebe as escolhas do jogador.

## Status

Projeto em desenvolvimento.
