+++
title = 'Cell Wars'
date = 2022-06-07T15:47:30+02:00
draft = true
+++

Cell Wars was basically my first game project, written in C++, based on the concept of the game called Phage Wars.
Cell Wars is a singleplayer, territory-control strategy game where the players goal is to be the only "organism" in the cells presented on the playfield.

This project was started and finished in 2019, in roughly 1 or 2 weeks, I don't remember exactly.

To briefly display, what the game has to offer, here are a few links:
- [Short videos on Imgur.com](https://imgur.com/a/qzHgXpv)
- [GitHub repository](https://github.com/lillatoma/CPP-SFML-CellWars)
- [GitHub repository (Remake)](https://github.com/lillatoma/Cell-Wars-Remake)

Cell Wars has a pretty simple AI system, it works with a few parameters, and makes a random decision based on that. These parameters include "time until first action", "time between actions", and some difficulty variables. Because of the game's own simplicity, the AI is also not complex in decision making, basically it will just try to extend on empty cells and sometimes attack other targets too, to control the entire area.

Every cell has their own parameters, like the owner, how powerful the cell at start, the capacity of the cell, and the regeneration in it, also, there are speed multiplier of the cells and strength multiplier in some of the maps. When a cell attacks another cell, it sends 50% of its current little organisms, which travel with randomized speed, so they don't reach at the exact same time. If an organism lands, and the cell reaches negative "organism count", the new owner will be the one who sent those organisms. And if the cells are from the same player, then it counts as reinforcement, and can overfill too. If overfill happens, the organisms in the cell die slowly.
Every level in the game is pre-generated, so they will always be the same.

When only one type of organism stays alive, they become the winner. After this, the game will show the power-timeline during the game.

# Remake

In 2021, i started working on a remake of this project with the Unity game engine. The concept remained the same as it was, there were rarely any changes in the features mentioned above. However there are a few little additions to the game now:
- The most noticable, it has some music
- There is a skill system
- There are more maps
- After all the maps are finished, a randomly generated map will be made, that can be assymetric, or symmetric in one or two dimensions.




