# Game Design Document (GDD) – "Caçador de Nosferatu"

![image](https://github.com/user-attachments/assets/b0d1bebb-3583-49b0-961b-97be88e6e274)

## 1. Visão Geral

- **Nome do jogo:** Caçador de Nosferatu
- **Gênero:** Ação / Sobrevivência
- **Plataforma:** PC
- **Estilo gráfico:** 2D (top-down)
- **Resumo:** O jogador explora uma fase infestada de mortos-vivos, coletando três itens essenciais para invocar e enfrentar o Nosferatu, o chefe final.

## 2. Mecânicas de Jogo

### 2.1. Personagem do Jogador

- **Movimentação:** O jogador pode se mover livremente pela fase (WASD ou setas direcionais).
- **Ataque:** Pressionar **Barra de Espaço** lança uma **bola de fogo** reta na frente do personagem.
- **Vida:** O jogador tem **3 pontos de vida** (configurável).
- **Munição:** **Ilimitada**.

### 2.2. Inimigos - Mortos-Vivos

- **Comportamento:** Patrulham a fase e perseguem o jogador ao vê-lo.
- **Dano:** Se encostarem no jogador, causam dano.
- **Morte:** Morrem ao serem atingidos pela bola de fogo.

### 2.3. Itens e Interação

- **Baus:** Espalhados pelo cenário. O jogador deve abrir os baús para coletar **3 itens mágicos**.
- **Objetivo:** Somente após coletar os três itens o jogador pode invocar Nosferatu.

### 2.4. O Altar e a Invocação do Nosferatu

- **Localização:** No final da fase.
- **Interação:** Quando o jogador pisa no altar com os 3 itens, o **Nosferatu aparece** e inicia o confronto final.

### 2.5. Chefe – Nosferatu

- **Ataque:** Também lança **bolas de fogo**.
- **Movimentação:** Patrulha e persegue o jogador.
- **Dano:** Se encostar no jogador, causa dano.
- **Morte:** O jogador deve atingi-lo várias vezes com bolas de fogo para derrotá-lo.

![image](https://github.com/user-attachments/assets/efcc75c7-fb9d-41ed-a403-4e1554628d9a)

## 3. Interface e Feedback ao Jogador

- HUD:
  - Indicador de vida (exemplo: 3 corações).
  - Quantidade de itens coletados para invocação.
- Efeitos visuais:
  - Impacto das bolas de fogo nos inimigos.
  - Piscar vermelho ao tomar dano.
- Som:
  - Efeitos para ataques, dano e abertura de baús.
  - Música de fundo tensa e som especial para a luta contra Nosferatu.

## 4. Condições de Vitória e Derrota

- **Vitória:** O jogador derrota Nosferatu.
- **Derrota:** O jogador perde toda a vida ao ser atingido por inimigos ou Nosferatu.

![image](https://github.com/user-attachments/assets/95dc87ab-7888-4c35-82e3-14c2c44c4a36)
