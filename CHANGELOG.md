# Changelogs


## [5.2.1] - [12/02/26] (Não commitado)

### Adicionado
- **KeyboardHook.cs**: Sistema de rastreamento de teclas físicas
  - `ConcurrentDictionary` para armazenar timestamps de teclas físicas
  - Método `WasKeyPressedAfter()` para detecção de acionamentos manuais
  - Diferenciação entre teclas físicas (hook) e automatizadas (PostMessage)

### Corrigido
- **AutoSwitch.cs**: Correção completa do sistema de pet skills (Item/NextItem)
  - **Máquina de estados determinística**: Substituídas flags booleanas (`equipedPet`, `procPet`, `contPet`) por enum `PetState` (IDLE → SKILL_USED → BUFF_ACTIVE)
  - **Bug #1 - Troca prematura**: Sistema agora aguarda buff aparecer antes de pressionar Next Item
  - **Bug #2 - Troca e volta sozinho**: Implementado debounce de 3 leituras consecutivas para confirmar expiração de buff
  - **Bug #3 - Não re-invoca após expiração**: Corrigida transição `BUFF_ACTIVE → IDLE` quando buff expira
  - **Bug #4 - Não recupera após morte**: Detecção de HP=0 reseta estado para IDLE (re-invoca pet na ressurreição)
  - **Bug #5 - NullReferenceException**: Método `findSkillConfig()` busca em ambos os mappings (exclusivo e genérico)
  - **Bug #6 - Interferência manual**: Recuperação ao religar programa via verificação inicial (`isFirstRun`)
  - Removido método `preventErrorsPet()` (solução paliativa de 100 iterações)
  - Adicionado método `detectManualPetKeyPress()` para detecção via keyboard hook

### Melhorado
- **AutoSwitch.cs**: Arquitetura de código robusta e manutenível
  - Máquina de estados com 3 estados bem definidos
  - Sem timeouts em `SKILL_USED` (aguarda buff indefinidamente)
  - Debounce de 3 leituras para evitar falsos positivos
  - Comentários detalhados explicando cada transição de estado


## [5.2.0] - [07/02/26] (Organização e Expansão Completa) (Não commitado)

### Adicionado
- **Novas Skills - Archer**: 7 habilidades adicionadas
  - Assovio
  - Beijo da Sorte
  - Crepúsculo Sangrento
  - Dança Cigana
  - Holofote
  - Maçãs de Idun
  - Sibilo

- **Novo Autobuff-Stuffs**:
  - Poção do Leviathan (LEVIATHAN)

- **Novos IDs Mapeados**:
  - 50% Acima do Peso
  - Acesso VIP
  - Anel do Treinador
  - Botas de Atlas
  - Flecha Dourada
  - Força Heróica
  - Relógio Rekenber
  - Proteção Química Total

### Melhorado
- **Reorganização Completa de Todas as Skills por Ordem Alfabética**
  - **Archer Skills**: 19 habilidades organizadas
  - **Swordsman Skills**: 24 habilidades organizadas
  - **Mage Skills**: 11 habilidades organizadas
  - **Merchant Skills**: 15 habilidades organizadas
  - **Thief Skills**: 11 habilidades organizadas
  - **Acolyte Skills**: 18 habilidades organizadas
  - **Ninja Skills**: 5 habilidades organizadas
  - **Taekwon Skills**: 20 habilidades organizadas
  - **Gunslinger Skills**: 6 habilidades organizadas
  - Total: **129+ habilidades** organizadas em ordem alfabética por nome em português

- **EffectStatusIDs.cs**: Documentação completa e organizada
  - Todas as skills com descrições em português
  - Organização por categorias:
    - Skills (por classe)
    - Elemental Converters
    - Potions
    - Foods (Basic e 3RD)
    - Boxes
    - Scrolls
    - Rune Knight Runes
    - Status Effects
    - Others (VIP, Competitive, etc)
    - Debuffs
    - Pergaminhos Cheffenia
  - Melhor manutenibilidade com comentários de seção

- **Buff.cs**: Estrutura otimizada
  - Métodos estáticos para cada categoria de buffs
  - Categorização melhorada de Stuffs:
    - GetPotionsBuffs() - 18 poções
    - GetElementalsBuffs() - 11 conversores elementais
    - GetFoodBuffs() - 23 comidas
    - GetBoxesBuffs() - 12 caixas e poções especiais
    - GetScrollBuffs() - 10 pergaminhos
    - GetETCBuffs() - 11 itens diversos

- **Nomes Traduzidos e Padronizados**
  - "Shield Spell" → "Aegis Domini"
  - "Prestige" → "Prestígio Divino"
  - "Firm Faith" e "Powerful Faith" mantidos em inglês (nomes oficiais)
  - Todas as descrições em português para melhor UX

- **Código mais Limpo e Manutenível**
  - Estrutura consistente em todos os métodos Get*Skills()
  - Melhor organização facilita adição de novas skills
  - Comentários de seção para navegação rápida
  - IDs documentados com nomes descritivos


## [5.1.0] - 05/02/2026 (Não commitado)

### Adicionado
- Tooltips informativos em DEBUFFS mostrando itens e habilidades que removem cada debuff
- Configuração estendida do ToolTip para melhor legibilidade (10s de duração)
- **EffectStatusIDs**: 9 novos debuffs na enumeração
  - BLIND (Cegueira)
  - CRYSTALIZE (Cristalização)
  - DEADLY_POISON (Envenenamento Mortal)
  - FEAR (Medo)
  - FROZEN (Congelamento)
  - HALLUCINATION (Alucinação)
  - SLEEP (Sono)
  - STONE (Petrificação)
  - UNDEAD (Zumbificação)
- **Buff.GetDebuffs**: Lista completa de debuffs com ícones
- **Novas Skills**: 10 novas habilidades com ícones
  - Planta Sanguessuga (BLOOD_SUCKER_PLANT)
  - Adaga de Arremesso (BOOMERANG_DAGGER)
  - Punho Embriagado (DRUNK_PUNCH)
  - Mestre dos Elementos (ELEMENT_MASTER)
  - Justa (JUSTA)
  - Superaquecimento (OVERHEATING)
  - Banho de Toxinas (POISON_SHOWER)
  - Clone das Sombras (SHADOW_CLONE)
  - Projeção Espiritual (SOUL_PROJECTION)
  - Estilo Yin/Yang (YINYANG_STYLE)
  - **Autoconnect RagnaTales**: Conexão automática ao processo rtales.bin
  - Detecta automaticamente o processo no carregamento
  - Funciona no carregamento inicial e no refresh da lista
  - Elimina necessidade de conexão manual
- **Sistema de Rédea Automática Completo** (AutoRein.cs)
  - Detecção automática de desmonte manual
  - Contador de células percorridas com validação
  - Sistema de cache de coordenadas (20ms) para otimização
  - Validação de passos adjacentes (ignora teleporte)
- **Novos Debuffs** com ícones (9 imagens PNG)
  - blind, crystallization, deadly_poison, fear, frozen
  - hallucination, sleep, stone, undead
- **ConfigForm**: Sistema de rédea automática configurável
  - CheckBox para ativar/desativar
  - NumericUpDown para quantidade de células
  - TextBox para tecla de atalho da rédea

### Corrigido
- Lógica incorreta no AutoSwitch que causava troca prematura de itens exclusivos
- Sistema agora aguarda confirmação do buff antes de trocar para o próximo item
- Ajuste nos delays recomendados (switchEquipDelay: 1000-1500ms)
- Tooltips no AutoBuffStatusForm que paravam de funcionar ao adicionar múltiplos debuffs
- **ConfigForm**: CheckBoxes e TextBoxes agora salvam e carregam valores corretamente ao trocar de perfil
  - Eventos desvinculados durante carregamento para evitar salvamentos prematuros
  - Adicionada notificação PROFILE_CHANGED após carregar perfil inicial
- **MacroSongForm**: Correção no salvamento de teclas de macro
  - Implementado sistema de desvinculação/reconexão de eventos durante atualização
  - TextBoxes vazios agora salvam corretamente como Key.None
  - Keys ausentes não exibem mais "None", aparecem vazias como esperado
- **Profile.SetConfiguration**: Corrigida serialização dupla de JSON
  - Configurações agora são deserializadas antes de salvar no arquivo
  - Evita salvamento incorreto de strings JSON dentro de strings
- **FormUtils.ToDescriptionString**: Corrigido NullReferenceException
  - Adicionada verificação de null antes de acessar campos do enum
  - Tratamento seguro para enums com valores duplicados ou inválidos
  - **AutobuffSkill & AutobuffStuff**: Ajustada lógica de uso de buffs em cidades
  - Melhor controle de quando pausar buffs automáticos
  - **Container.cs**: Método `tabPageAutopot_Click()` faltante (erro CS1061)
- **AutoRein**: Montaria após apertar key no manual
  - Flag `autoReinInProgress` controla estado de uso automático
  - Desmonte manual detectado e rastreado corretamente
- **AutoRein**: Montaria após utilizar teleporte
  - Distância Chebyshev > 1 identificada como teleporte
  - Teleportes não incrementam contador de células
  - Apenas passos adjacentes (distância = 1) são contabilizados
- **Client.ProcessAutoRein**: Validação de desmonte manual
  - Sistema suspende rédea automática após desmonte manual
  - Reativa apenas após andar quantidade configurada de células
  - Cooldown de 2 segundos entre usos automáticos
- **UserPreferences**: Opção "Pausar Tools com chat aberto"
  - Implementada verificação `stopWithChat` em todos os módulos:
    - AutobuffSkill, AutobuffStuff, AHK, AutoSwitch
    - AutoSwitchHeal, Macro, Custom, ATKDEFMode
  - Chat aberto agora pausa corretamente todas as funções

### Melhorado
- Classe Buff agora suporta descrições customizadas via parâmetro opcional
- Experiência do usuário com informações mais claras e acessíveis
- Sistema de tooltips mais robusto com limpeza adequada (RemoveAll) antes de recriar controles
- **EffectStatusIDs (DEBUFFS)**: Lista organizada em ordem alfabética por nome em inglês
- **IDs temporários corrigidos**: STONE, CRYSTALIZE, SLEEP, UNDEAD receberam valores únicos
- **Buff.cs**: Suporte a 23 debuffs diferentes (anteriormente 14)
- Tratamento de erros aprimorado em métodos de extensão de enum
- **Tema Escuro**: Implementação completa em todos os formulários (32 arquivos)
  - Container.cs: Cor do MDI Client alterada para Color.Black
  - AutoSwitchRenderer.cs, BuffRenderer.cs, DebuffRenderer.cs: BackColor dos TextBoxes para Color.Black
  - ToggleApplicationStateForm: Ajuste de cores para melhor contraste
  - Cores cinzas RGB(49,51,56) removidas dos campos 'None'
  - Melhor contraste e consistência visual em todas as abas
- **Client.cs**: Performance otimizada
  - Cache de coordenadas reduz leituras de memória
  - Intervalo de verificação ajustado para 50ms
  - Sistema de cooldown entre usos automáticos (2000ms)
  - Detecção precisa de movimento em células
- **Rastreamento de Movimento**:
  - `HasPlayerMovedCells()`: Conta apenas passos válidos
  - `HasPlayerMoved()`: Ignora saltos/teleportes
  - `ResetMoveCounter()`: Limpa histórico completo
  - `DetectManualDismount()`: Detecta desmonte sem ação automática
- **Profile.cs e Model/**: Serialização JSON corrigida
- **MacroSongForm**: Sistema de eventos otimizado
- **Buff.cs**: Suporte a descrições customizadas
- **FormUtils.cs**: Tratamento seguro de enums


## v[1.0.0] - 25/02/2022 (First Stable Version)
- Autopot (HP/SP with delay customization)
- Autobuff Status (Only for Poison, Silence, Blind, Confusion, Curse, Hallucinationwalk)
- Autoclick (Skill Spammer with delay customization) 
- Profiles Support (How many profiles you want)
- Ingame ON/OFF Button (End Key), you don't need to minimize your game screen.


## [v1.1.0] - 2022-02-26
### Added
- Auto-Refresh Spammer
- Auto status. Removes Poison, silence, blind, confusion, curse and hallucination automatically using Panacea, Green Potion or Royal Jelly
- New UI to manager profiles

### Fixed
- Fixed a bug where AHK was consuming more than 5% of CPU. Now the consumer of the CPU is under of 1%.
- Always request execution level as administrator


## [v1.2.0] - 2022-02-28
### Added
- Autobuff for Stuffs
- Added new keys (Space, Page UP, Page Down, Insert, Delete)

### Fixed
- On change profile not start threads anymore.
- App don't crash anymore with a invalid json profile.
