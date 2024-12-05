# Pixel-Plumbers-Fall-2024

Mario Game 
Sprint 4
Pixel-Plumbers

This is a replica of Mario written in C# using monogame. 

MARIO CONTROLS:
    - WASD and arrow keys for movement
        - W / Up to jump
        - A / Left to go left
        - D / Right to go right
        - S / Down to crouch

        - 1 to go up in mario state (small -> big -> fire)
        - 2 to go down in mario state (fire -> big -> small -> "died")
        - Left Shift to shoot fireballs while in fire mode
        - Right Shift to give mario a star

GAME CONTROLS:
     - Click on "1 player" or "2 player" to start the game.
     - Click on the table in the bottom left to enter a Blackjack minigame.
     - Press R to reset the game
     - press P to pause the game. (Also pauses music)
     - Press Q to quit the game
     - Press M to play music. Press again to play another song.
     - Press Z to mute everything.

KNOWN BUGS:
    - Some of the hitboxes are a bit clunky
≈    - Goomba2 and GoombaStateMaåchine2 are temporary.
    - For the MarioOBlock and MarioObstacle Interaction, the gravity is not applied to the mario when mario is on the top of the obstalce/block without jumping.
    - The click boxes for "level screen" and "main menu" are presistent.
    - Sometimes when mario is colliding with a obstacle from the left or right, he will fall through the ground