# Pixel-Plumbers-Fall-2024

Mario Game 
Sprint 3
Pixel-Plumbers

This is a replica of Mario written in C# using monogame. 

MARIO CONTROLS:
    - WASD and arrow keys for movement
        - W / Up to jump
        - A / Left to go left
        - D / Right to go write
        - S / Down to crouch

        - 1 to go up in mario state (small -> big -> fire)
        - 2 to go down in mario state (fire -> big -> small -> "died")
        - Shift to shoot fireballs while in fire mode

GAME CONTROLS:
     - Click on "1 player" or "2 player" to start the game. or press 9.
     - Press R to reset the game
     - press 3 to pause the game
     - Press Q to quit the game

ENEMIES CONTROLS:
    - O and P keys to switch enemies

KNOWN BUGS:
    - Some of the hitboxes are a bit clunky
    - Mario will not fall down unless jumping
    - As of now, mario does not have the turning animation
    - Goomba2 and GoombaStateMaåchine2 are temporary.
    - For the MarioOBlock and MarioObstacle Interaction, the gravity is not applied to the mario when mario is on the top of the obstalce/block without jumping.
    - A death animation/death state is not implemented yet
