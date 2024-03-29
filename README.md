# MSc Dissertation Kent 2023 - Masters of Dungeons

## What is Master of Dungeons?
Master of Dungeons is a game developed in Unity that contains both elements of Procedurally Generated Content (PCG) and Dynamic Difficulty Adjustment (DDA).

The game has two stages. The first stage of the game is a PCG puzzle maze and the player may choose one of the four pre-defined algorithms for generating different maze layouts. To reach the second stage, the player has to find 3 color coded numbers littered around the maze and input the numbers according to their color code at the exit of the maze. Additionally, the maze will always spawn two zombies that constantly chases the player.

The second stage of the game is a DDA First Person Shooter (FPS). The aim of the second stage is to stay alive and kill as many zombies as possible. Killing enemies will have a chance to spawn 3 different pickups, health, ammo and damage upgrade. The second stage of the game takes into account the fitness of the enemies and the player which is then used to dynamically adjust the difficulty of the game.

The player will receive a score at the end of the game which depends on the player's performance in both stage one and stage two.

## How does scoring work?
At the first stage of the game, the scoring is inversely related to time taken to complete the maze.
At the second stage of the game, every zombie kill grants one score. The final score will score of stage 1 + score of stage 2.

## Dependencies
Unity - 2022.3.1f1
Text Mesh Pro - 3.0.6
Newsoft.json - 13.0.6
UnityEngine.AI (NavMesh)

# Assets
* Zombies - Romero from mixamo - https://www.mixamo.com/#/?page=1&query=romero&type=Character
* Animations - https://www.mixamo.com/:
   - Dying Backwards
   - Orc Idle
   - Walking
   - Zombie Attack
* Ammo Box - Unity Asset Store https://assetstore.unity.com/packages/3d/props/weapons/ammo-box-7701#content
* Torture Tools [Open Dugeons] - https://opengameart.org/content/torture-tools-open-dungeons
   - TortureRoom1 - Mesh CC0 by Eugene Loza
     Textures used:
     wood-texture-1385971795zJs_CC0_by_Petr_Kovar.jpg
     iron_Medieval_CC0_by_Nobiax_diffuse.tga
     Other texture elements by Eugene Loza (CC0)
   - TortureRoom2 - Mesh CC0 by Eugene Loza
     Texture CC0 by Eugene Loza DSCF6355_1024_notseamless.png
* Bed - by OrbitStudios, Fernando Ferreira - https://opengameart.org/content/old-metal-bed-with-blend
* Wooden Furniture - by Enetheru - https://opengameart.org/content/wooden-furniture
   - bench
   - chair
   - table
   - table0
* Broom Tall - by Rakshi Games - https://opengameart.org/content/free-broom-tall
* Medieval Furniture - by Mev Lyshkin - https://opengameart.org/content/medieval-furniture
* Numbers - by TMPxyz - https://opengameart.org/content/numbers
* Textures - https://www.textures.com/
* Skybox - "sunsetflat" by LedIris (07/08/2009) - https://opengameart.org/content/red-eclipse-skyboxes
* Sound Effects and Background Music
   - Gunshot by snapsound - https://freesound.org/people/snapssound/sounds/536630/
   - Zombie Sound Pack - by artisticdude - https://opengameart.org/content/zombies-sound-pack
   - Hurt / Death Sound Effect For Character - by Badre-Eddine - https://opengameart.org/content/hurt-death-sound-effect-for-character
   - Background Music - CrEEP by TokyoGeisha - https://opengameart.org/content/creepy
   - Door Open Door Close Set - by qubodup - https://opengameart.org/content/door-open-door-close-set


# Miscellaeneous
- Hurt/Damaged UI/UX
- Do not pick health up if health is full
- Attack frame damage?
  * Important that the game "feels" right
- Enemy AIs pushing into the player
- Sound effects when picking up items
- UI/UX effect of picking up items
- UI/UX sound effects when clicking & hovering on UI buttons
- Loading screen
- Collider object on gun
- Simple tutorial/popup explaining basic concepts and door interaction
- Look into performance of the app
- Database for storign info
- Non-gamebreaking bug: When settings agent.isStopped = false which resumes the pathfinding. The object might be in the process of being destroyed which have already deleted the navmesh agent before the game object is destroyed
  * AttackingState/<Attack>d__7:MoveNext () (at Assets/Scripts/Enemy AI/Enemy State/AttackingState.cs:76)
- Loading just scene 1 won't hve certain audio elements loaded

# Scripts & Functions
* SceneController
  * Contains: Fixed enemy spawn locations, enemyPrefab
  * Function: Spawns enemies at fixed locations
* ChasingEnemy
  * Contains: NavMesh Agent, GameObject player, Animator animator
  * Function: Pathfinding to player, Animation of walking & attacking, implementation of alive/dead, implementation of damaging player
* DoorOperator
  * Contains: 2 OpeningDoor Serialized objects
  * Function: Implementation of one door opening leading to another closing
* FPSInput
  * Contains: Speed of character, gravity of character, Charactercontroller object
  * Function: Moves the player around and have it grounded
* MouseLook
  * Contains: Mouse Sensitivitiy variables, fixed mix and max vertical angle rotation
  * Function: Controls the camera view of the player
* OpeningDoor
  * Contains: offset variable
  * Function: Implementation of opening and closing doors via an offset (transforming the location of the doors to simulate opening and closing)
* OperateDevice
  * Contains: radius variable
  * Function: Listen to keypress of character 'c' so that it triggers the operate function of DoorOperator
* PlayerCharacter
  * Contains: health and ammo variable, connection to UIcontroller
  * Function: Updates the interaction of ammo and health variable of a character
* Shoot
  * Contains: Game objects bloodParticle & bulletHole, Audio of gunshots, connection to PlayerCharacter
  * Function: Implements the crosshair on the screen/camera, handles the shooting function of enemies and non enemies, logic of ammo consumption
* Target Enemy
  * Contains: health variable, animator, healthpickup prefab, ammopickup prefab, and ui controller
  * Function: Instantiate health, implement damage logic of enemies (brining their health down), Dying logic & animation, Spawn collectible Items
* UIController
  * Contains: contain UI labels (score, health & ammo), connected to Settings and EndgamePopup, score variable
  * Function: Logic of updating UI display of score, health and ammo, opens and closes popupasdf
* Collectible Item (Parent Class)
  * Contains: contains player, string item name
  * Function: An ontriggerenter method that applies specific effect based on the pickup
  * Child Class: Healthpickup/prefab & Ammopickup/prefab
