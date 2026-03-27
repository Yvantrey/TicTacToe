# Tic-Tac-Toe Game

A classic Tic-Tac-Toe game built with Unity, featuring both Human vs Human and Human vs AI game modes.

## Features

- **Two Game Modes:**
  - Human vs Human: Play with a friend locally
  - Human vs AI: Play against the computer
- **Settings Menu:**
  - Toggle between game modes
  - Adjust difficulty (for AI mode)
  - Sound on/off control
- **Win Detection:** Automatically detects wins with visual strike-through lines
- **Draw Detection:** Detects when the game ends in a draw
- **Background Music:** Persistent music across all scenes with toggle control

## Project Structure

```
Tic-Tac-Toe Game/
├── Assets/
│   ├── Scenes/
│   │   ├── MainMenu.unity      # Main menu scene
│   │   ├── Setting.unity       # Settings scene
│   │   └── Game.unity          # Game scene
│   └── Scripts/
│       ├── MainMenuController.cs    # Main menu logic
│       ├── SettingsController.cs    # Settings menu logic
│       ├── GameController.cs        # Game logic and AI
│       ├── GameSettings.cs          # Persistent settings storage
│       ├── AudioManager.cs          # Music controller (deprecated)
│       ├── MusicController.cs       # Alternative music controller
│       └── SimpleMusic.cs           # Simple music controller
```

## Setup Instructions

### Unity Setup

1. **Unity Version:** This project requires Unity 2020.3 or later
2. **Open Project:** Open the project folder in Unity Hub
3. **Scene Order:** Ensure scenes are in Build Settings in this order:
   - MainMenu (index 0)
   - Setting (index 1)
   - Game (index 2)

### Game Scene Setup

#### GameController Setup:
1. Select the **GameController** GameObject in the Game scene
2. In the Inspector, assign the following:
   - **X Texts (9):** Drag all 9 "X" text objects from Button(0) through Button(8)
   - **O Texts (9):** Drag all 9 "O" text objects from Button(0) through Button(8)
   - **Title Text:** Drag the "Tic Tac Toe" TextMeshPro component
   - **Strike Lines (8):** Drag strike line GameObjects in this order:
     - Index 0: Top row horizontal line
     - Index 1: Middle row horizontal line
     - Index 2: Bottom row horizontal line
     - Index 3: Left column vertical line
     - Index 4: Middle column vertical line
     - Index 5: Right column vertical line
     - Index 6: Diagonal (top-left to bottom-right)
     - Index 7: Anti-diagonal (top-right to bottom-left)
   - **Reload Button:** Drag the RELOAD button GameObject

#### Button Setup:
For each Button (0-8):
1. Select the button in the hierarchy
2. In the Button component's **OnClick()** event:
   - Click the **+** button
   - Drag the **GameController** GameObject
   - Select **GameController → OnCellClick(int)**
   - Set the parameter to the button's index (0 for Button, 1 for Button(1), etc.)

#### RELOAD Button Setup:
1. Select the RELOAD button
2. In the Button component's **OnClick()** event:
   - Add **GameController → ReloadGame()**
3. Disable the RELOAD button by default (uncheck it in the hierarchy)

#### BACK Button Setup:
1. Select the BACK button
2. In the Button component's **OnClick()** event:
   - Add **GameController → BackToMenu()**

#### AI Button Setup:
1. Select the AI button
2. In the Button component's **OnClick()** event:
   - Add **GameController → ToggleAI()**

### Music Setup

1. Create an empty GameObject in the MainMenu scene named "AudioManager"
2. Add the **SimpleMusic** script to it
3. Add an **Audio Source** component
4. In the Audio Source:
   - Drag your music file into the **AudioClip** field
   - **Uncheck** "Play On Awake"
   - **Check** "Loop"

### Settings Scene Setup

#### Dropdown Setup:
1. Select the dropdown for game mode
2. In the Dropdown component's **OnValueChanged()** event:
   - Add **SettingsController → SetGameMode(int)**

#### Difficulty Slider Setup:
1. Select the difficulty slider
2. In the Slider component's **OnValueChanged()** event:
   - Add **SettingsController → SetDifficulty(float)**

#### Sound Toggle Setup:
1. Select the Sound ON toggle
2. In the Toggle component's **OnValueChanged()** event:
   - Add **SettingsController → SetSound(bool)**

#### BACK Button Setup:
1. Select the BACK button
2. In the Button component's **OnClick()** event:
   - Add **SettingsController → GoBack()**

### Main Menu Setup

#### PLAY Button Setup:
1. Select the PLAY button
2. In the Button component's **OnClick()** event:
   - Add **MainMenuController → PlayGame()**

#### SETTINGS Button Setup:
1. Select the SETTINGS button
2. In the Button component's **OnClick()** event:
   - Add **MainMenuController → OpenSettings()**

## How to Play

### Starting the Game
1. Launch the game from the MainMenu scene
2. Click **PLAY** to start a game
3. Click **SETTINGS** to configure game options

### Gameplay
- Players take turns clicking on empty cells
- Player X always goes first
- Player O goes second
- In AI mode, the computer automatically plays as Player O
- The first player to get 3 in a row (horizontally, vertically, or diagonally) wins
- If all cells are filled with no winner, the game is a draw

### Game Controls
- **RELOAD:** Restart the current game
- **BACK:** Return to the main menu
- **AI:** Toggle between Human vs Human and Human vs AI modes

### Settings
- **Game Mode Dropdown:** Select Human vs Human or Human vs AI
- **Difficulty Slider:** Adjust AI difficulty (currently not implemented)
- **Sound ON Toggle:** Enable/disable background music
- **BACK:** Return to the main menu

## Scripts Overview

### GameController.cs
Main game logic including:
- Turn management (X and O alternation)
- Win detection (8 possible winning combinations)
- Draw detection
- AI move execution
- UI updates

### GameSettings.cs
Persistent settings storage using Unity's PlayerPrefs:
- `isAI`: Boolean for game mode
- `difficulty`: Float for AI difficulty
- `soundOn`: Boolean for music toggle

### SettingsController.cs
Handles settings menu interactions:
- Game mode selection
- Difficulty adjustment
- Sound toggle
- Navigation back to main menu

### MainMenuController.cs
Handles main menu navigation:
- Start game
- Open settings

### SimpleMusic.cs
Simple background music controller:
- Persists across scenes using DontDestroyOnLoad
- Responds to sound settings in real-time
- Automatically plays/stops based on GameSettings.soundOn

## Known Issues

- AI currently uses simple logic (picks first available cell)
- Difficulty slider doesn't affect AI behavior yet
- Strike lines must be manually positioned in Unity Editor

## Future Improvements

- Implement smart AI with minimax algorithm
- Add difficulty levels (Easy, Medium, Hard)
- Add score tracking across multiple games
- Add player name input
- Add sound effects for moves and wins
- Add animations for X and O placement
- Add online multiplayer support

## Credits

Developed as a Unity AR/VR class project.

## License

This project is for educational purposes.
