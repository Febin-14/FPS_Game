# FPS Prototype

A first-person shooter prototype developed in Unity and C# as a learning and prototyping project.

The project focuses on building gameplay systems from scratch while experimenting with Unity's component-based architecture, events, the Input System, inventory systems, and weapon systems.

## Current Features

- Player movement
- Shooting and raycast-based hit detection
- Enemy damage system
- Weapon equip/unequip system
- Inventory system
- Item inspection system
- Ammo and reload system
- Ammo UI
- Input System integration
- Weapon Manager
- Event-driven UI updates
- Interactive objects
- Basic enemy systems

## Weapon System

The weapon system currently supports:

- Weapon pickup and equipping
- Weapon unequipping
- Shooting using raycasts
- Hit detection
- Enemy damage
- Magazine ammunition
- Reserve ammunition
- Reloading
- Ammo UI
- Weapon inspection
- Weapon bobbing

### Weapon Gameplay

![Gun Shoot](Media/Gun%20Shoot%20.png)

![Gun Equip and UI](Media/Gun%20Equip%20and%20UI.png)

![Interactive Gun System](Media/Interactive%20Gun%20system%20%282%29.png)

![Gun Inspect](Media/Gun%20Inspect.png)

## Inventory System

The inventory system currently supports:

- Item storage
- Multiple item slots
- Item inspection
- Empty inventory state
- Inventory UI
- Interactive item management

### Inventory Screenshots

![Empty Inventory](Media/Inventory%28Empty%29.png)

![Inventory With Item](Media/Inventory%28With%20item%29.png)

![Storing Multiple Items](Media/Storing%20Multiple%20items.png)

![Interactive Inspect System](Media/Interactive%20Inspect%20system.png)

## Enemy System

The prototype includes basic enemy interaction and damage systems.

![Enemy Attack](Media/Enemy%20Attack.png)

![Enemy and Prototype Environment](Media/Enemy%20and%20Prototype%20environment.png)

## Other Systems

The project also contains interactive objects and UI systems being developed alongside the core gameplay systems.

![Documents](Media/Documents.png)

![Documents Reading](Media/Documents%28Reading%29.png)

![Start Menu](Media/StartMenu.png)

## Architecture

Some of the systems currently being experimented with include:

- `WeaponManager` — manages the currently equipped weapon.
- `GunController` — handles weapon-specific shooting, ammunition and reloading.
- `AmmoUI` — displays ammunition information.
- `InventoryManager` — manages inventory data.
- `InventoryUI` — handles inventory presentation.
- C# events — used to notify other systems when weapon state changes.

For example, the weapon system uses an event-driven approach for ammunition updates rather than having the UI constantly check the gun's ammunition.

## Currently Working On

- Weapon systems
- Enemy AI
- Improving architecture
- Expanding gameplay systems

## Tech

- Unity
- C#
- Unity Input System
- TextMeshPro

## Work In Progress

This project is actively being developed as a learning and prototyping project.

The goal is to gradually build a complete FPS prototype while improving my understanding of gameplay programming, Unity architecture, and C#.

## Screenshots

Additional development screenshots can be found in the [`Media`](Media/) folder.
