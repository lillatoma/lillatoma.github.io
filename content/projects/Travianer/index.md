+++
title = 'Travianer'
date = 2024-07-15T15:47:30+02:00
draft = true
+++

This is a **Unity game project** made with Unity 2022.3.13f1. This project was done with the collaboration of Viktória Horváth, who helped in many graphical, and coding assets of the project.
The project is based on the web browser, war strategy game, Travian by Travian Games GmbH. Assets are reused from the original Travian project, and we do not own any of them. They are the intellectual property of Travian Games GmbH.
The game was originally made for PC, and this WebGL version below is not optimized, and some assets might have different scaling because of it. I recommend playing it in 1920x1080 fullscreen.
Note: all other players in the game are controlled by bots.

{{< unity-webgl-player 
    gameTitle=""
    width="1024" 
    height="576"
    buildURL="Travianer/Build" 
    buildFileName="BuildWebGL"
    playerID=""  >}}

# What's in the game?

Currently, the goal of the game is just build, and fight. There is no further goal, you can set whatever you want. To be the biggest player in the gameworld (that has bots), get medals, have the biggest army, destroy other bots, etc. You name it.

## Buildings

Most buildings from the original game exist and are functional, except Wonder of the World and Treasury. Buildings can be built if there is enough resource, which are produced by the resource fields in the outer village, the resource production bonus buildings in the inner village, the captured oases, and the hero. There is also a premium option which the player can activate to have bigger production. (It costs in game gold, which is free, don't worry.) It is advised to build resource production to as high as possible. Every building has a different purpose:
- **Woodcutter**: increases lumber production
- **Clay Pit**: increases clay production
- **Iron Mine**: increases iron production
- **Cropland**: increases crop production
- **Main Building**: reduces building time
- **(Great) Warehouse**: increases storage of lumber, clay, and iron.
- **(Great) Granary**: increases storage of crop
- **Sawmill**: increases lumber production (5% per level) 
- **Brickyard**: increases clay production (5% per level) 
- **Iron Foundry**: increases iron production (5% per level) 
- **Grainmill**: increases crop production (5% per level) 
- **Bakery**: increases crop production (5% per level) 
- **Embassy**: increases alliance player limit by 3 per level
- **Marketplace**: increases the number of merchants that can carry resources to other villages
- **City Wall, Palisade, Earth Wall, Stone Wall, Makeshift Wall, Defensive Wall**: increases the static defense of the town, and also increases the power of the defensive force inside
- **Cranny**: hides an amount of resources from raiders
- **Palace**: opens an expansion slot at 10, 15, 20, can train settlers & commanders, adds the possibility to change capital
- **Residence**: opens an expansion slot at 10, 20, can train settlers & commanders
- **Command Center**: opens an expansion slot at 10, 15, 20, can train settlers & commanders (can only be built by Huns)
- **Rally Point**: opens target options for catapults, shows the number of attackers if they are numbered below the level of the rally point
- **Barracks**: can train infantry soldiers and infantry spies, the higher the level, the faster the training of troops
- **Academy**: can research infantry and cavalry that are not yet researched
- **Tournament Square**: increases movement speed of troops by 20% per level if the distance is over 20.
- **Smithy**: can increase the power of researched troopers, the higher the smithy, the faster the upgrades are. Upgrades have levels, and smithy can only upgrade as high as its level.
- **Hero's Mansion**: unlocks an oasis slot at 10, 15 and 20. Oases can be captured to increase production. Adventures spawn near villages that have hero's mansion (and the capital).
- **Town Hall**: can run celebrations (small from level 1, large from level 10). The higher its level, the faster the celebrations are.
- **Stable**: can train cavalry soldiers and cavalry spies, the higher the level, the faster the training of troops
- **Great Barracks and Great Stable**: works the same as their "non-great" equivalents, but troops cost 3x as much
- **Workshop**: can produce rams and catapults, the higher the level, the faster the training of troops
- **Trade Office**: increases the capacity of merchants by 20% per level. (40% for Romans).
- **Horse Drinking Trough**: Roman only building, increases training speed of cavalries, while decreasing their crop consumption.
- **Waterworks**: Egyptian only building, increases production bonus of oases.
- **Trapper**: Gauls only building, can produce traps that can capture attackers on the village.
- **Stonemason**: Capital only building, increases building stability
- **Hospital**: If the village has hospital, 40% of lost troops in battles become injured, and they can be healed in the hospital. (Healing costs the same as producing troops, but takes half as much time.)
- **Asclepeion**: Hospital that can be built by Spartans only. The 40% injured ratio becomes 60%.
- **Brewery**: Teuton and capital only building. Can run celebrations that increase the attack power of all troops.

## Attacking oases:

The player can attack oases at any given time. Oases have a set of animals they spawn with, and they spawn a larger amount when the initial beginner's protection of the world ends. If they have been cleaned once, they will produce animals regularly. Killing animals gives resources to the hero's inventory, so it is a viable tactic to attack them, if you would gain more resources than what you used to train the lost troops. Oases also produce resources and have a capacity how much they can store, however they only start producing once they have been cleaned.
Oases can be captured if the hero's mansion is big enough, and the oases have been cleaned from animals. For this to happen, the player has to attack it with hero.
If the oasis attacked has been captured by a previous player, animals will not spawn there anymore, and the attacker will fight the village that the oasis belongs to (or rather the troops sent to the oasis.), and if the attacker robs resources, they are from that village. (Resources in the oasis are 10% of what the village has, and robbing the oasis robs directly from the village.)

## Attacking other villages:

When the beginner's protection of both players are over, they can attack each other. When an attack happens, the troops that have been sent by the attacker will fight with all troops that are in the defender's village. Raid attack means that if the attacker loses `n%` and the defender loses `m%`, then `n + m` will be `100%`. Normal attack or attack means that the fight goes on until either the attacker or the defender loses all their troops. These fights happen immediately. If the attacker has surviving troops, they can steal resources from the village, so it is a viable tactic to rob resources from players who don't defend them.
In order to destroy wall and buildings in the village, or conquer them, the attack has to be normal (not raid).

## Battle simulation:

Unfortunately, we didn't develop an ingame battle simulator yet. In order to simulate a battle, please use this site:
[Kirilloid](http://travian.kirilloid.ru/warsim2.php) (4.6 version)

## Time management in the game:

In the game, time is static and is not going with real time. The player can manage their time and when they want to jump into the future (until a building built, training done, troop movement done, etc, or freely in the Events menu.) This is a unique mechanic that is not present in the original Travian game, and is done so the player can maximize their potential (by being second perfect at it).
The events (building built, attacks, etc) that are scheduled to happen at a given time would fire if the given time is before the time jump ends. (So let's say, cropland builds at 02:00, but you jump until 05:00 where an attack happens, both events will be fired.)

## Hero

The hero is a unique troop of every player, that can level up, and has points that can go on power, attack bonus, defense bonus and production. The hero starts with a set of 3 adventures, and will get more adventures overtime. The first 10 adventures have a fixed set of rewards, and adventures later will get rewards randomly. These rewards can be:
- resources (most common)
- silver (can be used in auctions)
- troops
- consumable items (ointments, cages, small bandages, bandages, tablets of law, books of wisdom, artwork and bucket)
- other items (helmets, armors, boots, weapons, utilities, and horses)

It is possible to bid on auctions to get items from other players who are selling them. It is not possible to see the seller, however the highest bidder is always visible. Once the auction's timer go off, the highest bidder will receive the item, get their extra silver back, and the seller will get the final silver amount that was bid on the item.

## Hero items

### Helmets:

- **Helmet of Regeneration (and other healing helmets)**: increases healing speed of hero
- **Helmet of the Gladiator (and other cp helmets)**: produces culture points
- **Helmet of Awareness (and other xp helmets)**: increases experience gain of the hero
- **Helmet of the Mercenary (and other infantry helmets)**: increases training speed of infantries where the hero is located
- **Helmet of the Cavalry (and other cavalry helmets)**: increases training speed of cavalries where the hero is located

### Armors:

- **Armor of Regeneration (and other healing armors)**: increases healing speed of hero
- **Breastplate (and other power armors)**: increases power of hero
- **Scale armor (and other scale armors)**: increases healing speed of hero and decreases damage
- **Segmented armor (and other scale armors)**: increases power of hero and decreases damage

### Boots:
- **Boots of Regeneration (and other healing boots)**: increases healing speed of the hero
- **Boots of the Mercenary (and other army boots)**: increases travel speed of troops traveling with hero if the distance is over 20 fields
- **Spurs (and other speed boots)**: increases travel speed of a mounted hero

### Weapons:

- Increases the power of the hero and attacking and defending power of all troops (mentioned in the description of the weapon) with the hero

### Horses:

- Increases the travel speed of the hero

### Utilites

- **Maps**: increases the return speed of troops traveling with the hero
- **Shields**: increases the power of the hero
- **Bags**: increases capacity that troops can steal from enemy crannies (if they are with the hero)
- **Horns of the Natarian**: currently does nothing. Later it will increase attack power against Natarians.
- **Standards**: increases travel speed between alliance members (with hero)
- **Pennants**: increases travel speed between own villages (with hero)

## Quests

There are daily quests with a certain of set of rewards in the game, that can be collected daily based on a number of activities that give points.
There are also tutorial quests, that include building a certain building or buildings to a certain level, and then can be collected later for hero experience and resources to the hero's inventory.
Quests in the game currently are not related to any previous Travian task system. The amount of rewards grow overtime (on 1x, a week later 20% more rewards are added to make new player's get a fairer game).

## Founding and Conquering new villages

When the player unlocks a new Expansion slot in any of their villages, and has enough Culture points (that are produced by buildings and town hall celebrations) for a new village, they can:
- settle a new village to any location with 3 settlers and starting resources of a village (750 of each by default). The settling (in this game takes 8 hours on 1x.) happens on a first gets, first wins basis, so if someone settles to a place, and gets beaten by another player, their settlers will go home with no new village.
- conquer a village from another player. In order for it to happen, the player has to lower the loyalty of a non-capital village to 0, with normal attacking with commanders. Once the loyalty becomes 0, the new owner of the village will be the attacker.

## Alliances

The player can create a new alliance or join an existing one if they get an invitation. An alliance comes with a number of advantages:
- You can get help from alliance members and organize attack calls on targeted enemies
- There are certain alliance bonuses that can help develop faster

Alliance bonuses:
- **Recruitment**: makes training speed of troops faster
- **Philosophy**: increases passive culture point production (helps with getting to the next culture point requirement faster)
- **Metallurgy**: increases attack and defense power of all units
- **Commerce**: increases merchant capacity

## Medals and top 10 players (alliances) of the week

Each player gets points for certain actions in the game:

- Climbers: ranks gained in population
- PVP: troops killed in attack
- PVE: animals killed in oases
- Defensive: troops killed in defense
- Robbers: resources stolen from other players and oases (and animals killed)

## Settings

When making a new game world, the player can set certain settings to their liking.

### Quick settings:

Quick settings quickly set up the world to be a certain size and speed. Clicking on these buttons will override any settings made in the other tabs.

### Game settings:

- **Production speed**: increases the production speed of resources and culture points
- **Building speed**: increases the building speed of buildings (reduces building time)
- **Population consumption**: crop consumption multiplier of population
- **Army consumption**: crop consumption multiplier of troops
- **Training speed**: increases the training speed of troops (reduces training time)
- **Celebration speed**: decreases the time celebrations take
- **Celebration CP Multiplier**: increases the culture point amount a celebration gives
- **Animal speeds**: increases the speed of animal spawns
- **Travel speed**: increases the travel speed of troopers and merchants
- **Merchant carriage**: increases the capacity of merchants
- **Hero regen speed**: increases the regeneration speed of the hero
- **Village founding speed**: decreases the village founding time
- **Quest bonus (% / week)**: increases the % extra rewards the tutorial quests give. If it is 20%, rewards will increase by 20% every week.

### World settings:
- **Map size (X)**: defines the width of the map. Be careful with large numbers as it can make the game slower.
- **Map size (Y)**: defines the height of the map. Be careful with large numbers as it can make the game slower.
- **Center dark radius**: defines the gray area in the middle of the map
- **Center empty radius**: defines the radius where no players spawn
- **Oasis spawn rate**: Defines the chance of a tile to become oasis
- **50% spawns outside of dark**: defines if +50% wood, clay and iron oasis can spawn outside the gray zone.
- **Animal kill wood, clay, iron, wheat**: defines the amount of resources an animal kill grants

### Player settings:
- **Player count**: defines the amount of bot controlled players
- **AI control chance**: defines the chance that a bot will be controlled or idle
- **Easy chance**: defines the entries of easy bots for generating bot controllers
- **Medium chance**: defines the entries of medium bots for generating bot controllers
- **Hard chance**: defines the entries of hard bots for generating bot controllers
- **Beginner's protection days**: defines the length of beginner's protection in days
- **Protection extend days**: defines the length that the beginner's protection can be extended in days
- **Default wood, clay, iron, wheat**: defines the default resources each village spawns with (and needed to found new villages)
- **Player register endtime (days)**: defines the latest time a player can register
- **Default storage (warehouse, granary)**: defines the default storage a village has
- **Storage multiplier**: multiplies the storage amounts
- **Keeps default storage**: defines if the default storage will be kept if a storage building is built
- **Tribes**: it is possible to allow/disallow certain tribes, by default all are enabled. The numbers are the entries for the bots. (Higher means higher amount of players using the tribe)


## Saving and loading

It is possible to save games and reload them.
- **Saving**: It is possible to save the game clicking in the Hero's menu (top left corner), and the button in the top right corner.
- **Autosaving**: In the same menu, it is possible to make the game automatically save. Autosaves are saved under the name `autosave`.
- **Loading**: You can reload any preiously saved game in the **Load previous game** menu. It is also possible to delete previous games that are not needed anymore.

## Bots

Bots are generated for every player that is not controlled by uh, the player.
They can have difficulties that define how well and how fast they play, and what actions they take
- **Throwaway**: idle bots that just build their village without doing anything
- **Easy**: easy bots
- **Medium**: medum bots
- **Hard**: medum bots

The actions bot can do:
- Build buildings
- Make troops
- Look for farmable players
- Move hero to other villages
- Found new villages
- Conquer villages
- Occupy oases for villages
- Send resources to other villages
- Send resources to other players in the same alliance (if they are tech)
- Build traps if they have Trapper
- Change capital to a cropepr
- Claim daily and tutorial quests
- Manage farmlists
- Attack oases if they seem profitable (with hero only or hero with troops, or troops only)
- Attack empty oases with low troop numbers to farm them
- Get defenses if a village is attacked (also ask for defense from the alliance)
- Heal troops in the hospital / asclepeion
- Buy and sell and items in auctions
- Use hero gear
- Capture animals with cages
- Research and upgrade units
- Run celebrations
- Send hero on adventures
- Spy around to look for farms
- Revive hero if its dead

## Cheats

Automatically cheats are enabled.
The console can be accessed by pressing F2.
There are a number of cheat commands the player can use that will affect the currently controlled player, or just paste information to the console.
Unfortunately, I don't want to discuss what cheats do and how, so I will leave them to you to experiment. :)

## Future updates
- Treasury
- Artifacts
- Artifact spawns
- Default natar villages
- Wonder of the World
- Win condition
- Bugfixes
- Quality of life changes

