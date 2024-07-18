+++
title = 'Chain Reaction'
date = 2022-08-10T16:10:30+02:00
draft = true
+++

Flat Chain Reaction is a remake of an Android game called Chain Reaction.
The reason I wanted it to be remade is because the game used an interesting 3D grid that sometimes didn't detect clicks properly, and I remade it in flat.

The GitHub repository of the game can be found here:
- [GitHub repository](https://github.com/lillatoma/Flat-Chain-Reaction)

The game is a multiplayer strategy game, that people can play against friends.
A player places little orbs on the map. A tile has `n` neighboring tiles, and once it has `n-1` orbs, it will be charging fastly, and when getting another orb, it will send an orb to all neighboring tiles, taking control over them (and as the name suggests, if a tile gets full, it will fire again, resulting in a chain reaction.)
In order to win, the player has to eliminate all other players from the game.
c
{{< unity-webgl-player 
    gameTitle=""
    width="576" 
    height="1024"
    buildURL="Flat Chain Reaction/Build" 
    buildFileName="Flat Chain Reaction"
    playerID=""  >}}

