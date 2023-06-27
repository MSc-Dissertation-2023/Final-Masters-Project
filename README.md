# Final-Masters-Project

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
  * Contains: contain UI labels (score, health & ammo), connected to SEttingsPopup and EndgamePopup, score variable
  * Function: Logic of updating UI display of score, health and ammo, opens and closes popup