# MSc Dissertation Kent 2023

# Assets
* Zombies - Romero from mixamo
* Ammo Box - Unity Asset Store https://assetstore.unity.com/packages/3d/props/weapons/ammo-box-7701#content


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
