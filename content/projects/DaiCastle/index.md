+++
title = 'Welcome to my website'
date = 2024-04-30T15:47:30+02:00
draft = true
+++

# DaiCastle

DaiCastle is a singleplayer, 100-player battle-royale game with a huge map, complex AI, inventory system, unlockable item system, replay system, and many more.

This project was started in 2019, most of the core things were done back then such as the way the map is shown, and stored, hit-reg calculations, movements, but then I had to discontinue this project unfortunately.
In 2021, I revisited the project, and started adding many new features, that now makes the game full. 

To briefly display, what the game has to offer, here are a few links:
- [Short videos on Imgur.com](https://imgur.com/a/ILUIHUQ)
- [GitHub repository](https://github.com/lillatoma/CPP-SFML-DaiCastle2D)

As you can see from the videos, this game is quite complex.

With so many things in the game, and not remembering the order of updates done, it's difficult to summarize into bullet points, but let's give it a try:
- Map
- Hit scanning
- Items & Inventory
- Moving storms
- The generation of bus routes
- Air drops
- The AI
- The replay system
- The main menu

## Map
The map is a 1000x1000 array of tile-blocks, and every tile-block can have a wall on its East, and North directions. The map also has an array of chest positions, and labels. There are several points of interests on the map, consisting a lot of chests stacked closely together that can attract players. There are a few unnamed locations on the map too, that have a lot of chests.
There is a map editor program included with the game, that can let the user freely edit the map as they like. It has several tools.
More information can be found here: [Map Editor](https://github.com/lillatoma/CPP-SFML-DaiCastle2D/blob/main/doc/map-editor.md)

## Hit scanning
The hit scanning algorithm helps decide if a shot that was just taken will hit a player or a wall, or just travel without anything in its way. Every weapon in the game has a maximum travel range. The map is divided into smaller map-chunks to make the hitscan faster. If the bullet travels from (0,0) to (0,100), we will not need the entire map with all the existing walls, since it would slow down the process, and it's the last thing we would want. The algorithm only takes the walls into calculation that are affected by the bullet's travel, so basically, the chunks that the bullet travels through. The algorithm first goes through the list of walls, and then the list of players, and every time it would hit something that is closer to the start point, it updates the end point. The game, based on the end point, damages the hit player, damages the hit wall, or does nothing.
Mathematically taken, the algorithm works this way: [Trace ray](https://github.com/lillatoma/CPP-SFML-DaiCastle2D/blob/main/doc/gameplay-traceray.md)

## Items & Inventory

The game has a bunch of items, that can be categorized into two main categories:
- Weapons
- Healing items
Also items, can be either consumables, or non-consumables.
Weapons can be single-shot weapons, multi-shot weapons, projectile weapons, or explosive weapons.
Healing items can heal the: 
- health of the player, indicated by the green bar, 
- the shield of the player, indicated by the blue bar,
- or both, and if this is the case, it heals slowly overtime.
All weapons have different parameters for how they work. More information about it is here: [Items](https://github.com/lillatoma/CPP-SFML-DaiCastle2D/blob/main/doc/gameplay-items.md)

The inventory can contain 5 different items for the player. Consumable items might be stacked until they reach their max stack-size.
The player can drop an item, pick up a non-consumable, pick up a consumable, swap two items, or stack them together (if they are the same consumable items).

## Moving storms

## The generation of bus routes

## Air drops

## The AI

## The replay system

## The main menu

# Conclusion

This page will most likely be updated in the future.


