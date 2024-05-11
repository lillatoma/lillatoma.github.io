+++
title = 'DaiCastle'
date = 2021-08-18T15:47:30+02:00
draft = true
+++


DaiCastle is a singleplayer, 100-player battle-royale game with a huge map, complex AI, inventory system, unlockable item system, replay system, and many more.

This project was started in 2019, most of the core things were done back then such as the way the map is shown, and stored, hit-reg calculations, movements, but then I had to discontinue this project unfortunately.

In 2021, I revisited the project, and started adding many new features, that now makes the game full. 

To briefly display, what the game has to offer, here are a few links:
- [Short videos on Imgur.com](https://imgur.com/a/ILUIHUQ)
- [GitHub repository](https://github.com/lillatoma/CPP-SFML-DaiCastle2D)

As you can see from the videos, this game is quite complex.

With so many things in the game, and not remembering the order of updates done, it's difficult to summarize into bullet points, but let's give it a try:
- The project
- Map
- Hit scanning
- Items & Inventory
- Moving storms
- The generation of bus routes
- Air drops
- The AI
- The replay system
- The main menu

## The project

DaiCastle was one of my earliest video game projects. It was entirely made on my own, using C++ as its language with the help of the multimedia library called SFML. I can freely say that I got motivated by one of the most popular battle-royale games of the time, Fortnite. I was really motivated during the project, I will be honest, I even skipped some classes when I got to it the second time (it was during Covid), because I just wanted to work on the project, add more features, fix bugs, or just play and test things. 

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

As time progresses in the game, we have to restrict the playfield so players would have to engage each other in order to win. The storm is a circle that has an eye, that gradually shrinks over time. The eye of the storm is the safe zone, the zone outside of it damages the players. The zone works in the following way:
- Let's assume, currently we have no storm. That assumption is false, there is just a big enough storm circle, that is big enough to not affect any areas of the map. The very center of the storm lays right in the middle of the map.
- As the storm shrinks, we select a new point inside the previous storm circle, and we want all of the new storm to be inside the previous one. If the radius of big circle is `R`, and the radius of the small circle is `r`, the centers similarly `C` and `c`, then we randomly generate our new `c` point at maximum `R-r` distance from `C`. This way the entirety of the new, smaller storm circle will be in the old one.
- Later on, we want to have **moving storm**, which means, if the circle is small enough, we don't generate a point inside the previous zone, we set a maximum distance, how far it can from the previous zone, and it will generate zones that might entirely be outside of the previous one. (Note: we can also apply minimum distance too, if we want it to be always outside.) 

## The generation of bus routes

The bus routes are generated in a terribly simple way. A simple line, with a random distance from the spawn, with a random angle. Simple.

## Air drops

During the game, air drops spawn high-tier weapons that might catch interest of the players. These are generated a few minutes after the game starts, and will drop randomly after.

## The AI

The AI of this game is probably the most complex part of it all. They have to be able to interact with the world just like a human player would, and since there are 99 of them in the game, I put a high emphasis on making them work right. The logic is pretty simple on it's own. It is basically just a bunch of condition checks, and some permanently stored information that makes up the bot, and makes it decide what to do.

When the game starts, every bot will get its own profile, which contains random parameters that determine how good the bot should be. (We're talking about things like accuracy, turning speed, reaction time, etc.) Then, it will decide a drop spot. The drop spot will be always near a chest, and this randomly chosen chest is usually closer to where the bus starts than where the bus ends. What I try to say is, bots tend to jump early, and only a few of them waits to drop at the end. Bots with higher difficulties will jump at a close to perfect time, while easier bots may jump very late or too early.

After landing, the bots will try to open chests, collect loot, and healing items, and once they are satisfied, they will start exploring the world randomly. This satisfactory condition is made up of a few things:
- if the bot has good enough items. Some might want legendary loot, some is fine with the basic things.
- if the bot has enough health and shields.
- if the bot has enough healing items in its inventory

Bots try to go to the storm, and stay in it, but easier bots might miss the timing, and get damaged, or even get eliminated to the storm. When a bot finds better loot, even though it is satisfied with what it currently has, it will try to swap, too. When one of the conditions mentioned above change (the loot will not get worse), then the bot might start to seek chests again. The bot's memory keeps track of chests that it has seen opened, and will try to go to a chest that it thinks is unopened. (These chests are either seen unopened, or have never been seen.)
For navigation, and finding path between walls, the bot's use the A* algorithm.

## The replay system

If it is ticked in the settings, the game will save the replays of the matches played. When they are saved, the game creates snapshots quite often every second about the state of the game. (These are where players are positioned, their health, inventory, chests opened, loot dropped, basically the entire state of the game.) On a second thread, a process stores the latest snapshot, and compares it to the new one. Any changes will be saved in the raw replay file, that will be saved when the game ends. Then the replays can be watched in a similarly styled game window, however it has some extra functions as well. These extra functions are a free camera mode to freely navigate on the map, and we can select every player who is on the map, we can see when they eliminate other players, and if they get eliminated. 

## The main menu

The main menu of the game contains the base UI, where the player can input their user name, select from the game modes, customize their looks, and see the challenges they can complete, or have already completed.

# Conclusion

This is shortly my summary of my previous game project, DaiCastle. I have no idea how to summarize it, since this entire post is a summary... But probably the best way is, if you try it out. ;)

This page will most likely be updated in the future.


