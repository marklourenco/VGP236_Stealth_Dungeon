# Stealth Game - Unity Project

## Overview
This is a stealth-based game built using the Unity engine. The game features an isometric camera view and focuses on player movement, enemy AI, and environment. The main objective is to avoid detection by patrolling enemies, making use of the environment, and managing your movement carefully to avoid triggering their awareness.

The project was created to practice implementing AI behaviors and working with lighting in Unity. It uses asset store art assets for the game's visuals, allowing the development focus to remain on gameplay mechanics.

## Features
- **Isometric View**: The game is viewed from an isometric perspective, giving the player a clear overview of the environment.
- **Player Movement**: Players can move the character using the standard WASD keys.
- **Enemy AI**:
  - **Patrol AI**: Enemies patrol a set path, looking for potential intruders.
  - **Chasing AI**: Enemies chase the player once they spot them.
  - **Random Movement**: Some enemies move randomly within a defined area to increase unpredictability.
  - **Persistent Chase**: Some enemies will chase the player continuously until they are either out of range or caught.
  
## Game Mechanics
- **WASD Movement**: The player can navigate the environment using the WASD keys.
- **Enemy Detection**: Enemies have a detection range. If they see the player, they will begin to chase.
- **Patrolling & Chasing**: When patrolling, enemies follow a fixed path. Once the player is detected, the enemy switches to a chasing behavior.
- **Lighting & Shadows**: The game uses dynamic lighting and shadows to create a more immersive environment and aid the stealth mechanics. Areas of the map can be dark, and players may use walls to hide from enemies.
- **Texturing**: Textures have been applied to the environment and objects to enhance visual aesthetics and immersion.

## Art Assets
The art assets used in this project were sourced from the **Unity Asset Store**. These assets include:
- Environment models (e.g., walls, floors, props)
- Characters and enemies
- Textures and materials

## Project Structure
- **Scenes**: Contains the main game scene with environment and enemy AI.
- **Scripts**: Contains all scripts applied on the game.
- **Prefabs**: All assets used in the game are stored as prefabs for easy scene setup.
- **Materials**: All textures and materials are applied here for the environment, characters, and enemies.

## Setup Instructions
1. **Clone the Repository**: 
   - Clone the project repository to your local machine or download the project files directly.

2. **Open in Unity**: 
   - Open Unity Hub, and open the project folder where you saved the game files.

3. **Install Dependencies**:
   - Ensure you have the appropriate version of Unity installed.
   - The project uses assets from the Unity Asset Store, so make sure you have the necessary licenses or assets imported for them to work correctly.

4. **Play the Game**:
   - After opening the project in Unity, click on the main scene.
   - Press `Play` to test the game and start practicing the stealth mechanics.

## Controls
- **W, A, S, D**: Move the player character in the game world.

## Notes
- This project is designed as a learning tool to practice implementing AI in Unity. Some features, like advanced enemy behavior or more complex environments, could be expanded upon.
- The AI is set up for basic detection and chasing, but you could add more advanced logic (e.g., hiding, cover mechanics, or alarms) to increase the depth of gameplay.
