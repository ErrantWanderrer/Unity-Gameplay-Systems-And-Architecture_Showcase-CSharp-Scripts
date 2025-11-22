# Unity Gameplay Systems Showcase

A curated collection of advanced C# scripts from a released mobile game, demonstrating robust architecture and solutions for complex gameplay problems in Unity.

## 🚀 About This Repository

This repository contains production-ready C# scripts developed for Asteroid's Assault, a mobile game built with Unity. The code showcases solutions to complex problems such as dynamic object management, performance optimization, and modular game architecture.

## 🛠️ Featured Systems

### BackgroundControllerMain
- **Dynamic Tile-Based Background System**: Implements an advanced, camera-relative background spawning system that dynamically loads and unloads tiles based on player movement.
- **Key Features**: Intelligent memory management using `Dictionary<Vector2Int, GameObject>`, viewport culling based on camera parameters, efficient tile recycling.

### GameObjectsCreator  
- **Complex Object Spawning & Physics**: Manages the creation and lifecycle of gameplay objects with integrated gravitational systems.
- **Key Features**: Object pooling for performance, custom gravity calculations between celestial bodies, event-driven architecture for spawn management.

### PlayerController
- **Advanced Player Mechanics**: Handles complex input systems (touch, joystick, gyro), physics-based movement, and state management.
- **Key Features**: Multiple control schemes, custom physics interactions, shield and ability systems.

### NPCasteroidBehaviour
- **Procedural Generation & AI**: Generates unique asteroid meshes at runtime and manages their behavior and destruction.
- **Key Features**: Procedural mesh generation, particle effect management, custom collision responses.

### MainScript
- **Core Game Management**: Central controller for game state, settings, and systems integration.
- **Key Features**: Modular architecture, post-processing control, save/load systems.
