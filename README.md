# Plantopia



# To Do 






# 05 03


The Goal right now is to:

- sync data to DataBaseManager

- model a landscape in Blender, along with a builder character

- move the character around through animation by point and clicking

- have the character tend to the farms

- create a good enough menu for now

- add FPS HUD for optimization

- pick a color scheme even just for testing

- create a "Loading Screen" just for show - name the Scene - "Loading Screen" (include a base time to show loading, also will be space for later on asset loading, and any other stuff

- make the loading screen interesting

- add functionality for menu settings (ex. turn off score, adjust the volume)

- add basic sound effects right away, like game startup chime (gives a sense of passage), selection clicking, building start

- add random score right away off YouTube as temp music...

- if the player selects "Continue Game" we can pick up where we left by saving the data into the DataBaseManager.cs

- there is also a place where the player can go through previous different saves and their saved game titles given out by the player

- add a "Quit game? Yes or Cancel" functional enough for now, check how others do this

- load straight in without the user having to select the resolution, leave that up to them in the settings of the game (can we do this?) -- or detect the users specs and pick a good generic starting one, and they can up the settings on their own in the game's graphics settings (like basic, good, very good)

- fix the starting screen flicker

- have the theme score going at the menu titles screen (analyze progressions with UChord to get the chord sheets)

- as far as the appeal of gameplay -- these elements will fill out the appeal for now (before we expand on strategy after core platform is done)

  - nice graphics: background, everything, characters
  
  - nice music
  
  - nice sound fx (mouse actions, and notifications)
  
  - game feel (game juice / sugar) MOAR SUGAR
  
  - having a large inventory of items to build / interact with
  
  - moving the characters around
  
  - hiring of workers mechanics in the game - economy
  
  - selling back of crops for profit to keep expanding
  
  - "base upgrades" -- eventual automation and mechanization of farm (still need people but in different job roles, now need an engineer, or an "operator", plus will need now "circuit boards", this is the unit of what we use to build automation on the farm in terms of where the CPUs are.
  
  - as the basic mechanisms of the game are finished we can create an optimization pipeline mechanism like in Factorio, especially when we get to the automation stage of the game
  
  - a very nice menu (HUD)
  
  - modeling the island or ground, along with character, and menu will be the most important that will be first judged by people
  
  



///////////////////////////////////////////////////////





- create terrain like in the island tutorial and Train Valley 2

- create a satisfying planting mechanism:

  - tap on device to plant with a plopping sound (can pop lips)
  
  - begin timer to grow
  
  - "pop" out plant (game juice / sugar) when done growing
  
  - harvest plant by tapping for money (each individually)
  
- allow to buy land parcel box

- allow to buy seeds

- show tokens on screen






# May 1

- okay, so some of the basics are established

- not sure whether this will be a mobile or steam early access game yet

- we have the workers going, raycasts to guide them, token count, menu for choosing planting, a data and a settings file, so the basics are here

- we would like to do something similar to Rimworld, where we can to the nerdy nitty gritty aspect of a simulation

- so as we plant more fields we will need to hire more workers, workers subtract costs out of our tokens on a cyclical basis

- need a separate menu for generating workers like in RTS games, check out their menus how to group

- don't be overly concerned about the menu layout since that will change menu times

- when a workers is doing an action like tilling the earth, before we can get animations going, we can simply display an overhead icon of what the worker is doing, so a shovel for tilling the earth for example

- modeling the island in blender will help with visuals

- a nice menu will also help with the game appearance

- island + nice menu = presentable game

- at first we will just be planting box gardens

- tractor and then solar for power and the water tanks like in RimWorld

- so at first we want a few box gardens with different seeds 

- and we want to set up the growing mechanism

- RESEARCH: watch videos of people on farms / industrial farms to check what we can model in 3D, and what sort of mechanisms we can implement

- we will eventually automate the farm, so stuff like watering, solar power energy, we will have auto yields like in Factorio

- so what is next on the todo:


  - model the island (blender tutorial)
  - model workers (sebastian lague tutorial)
  - choose a sexy menu (maybe Train Valley 2 for now)
  - this will begin to look like a game
  - maybe even have a score
  - add sound effects
  - create growth mechanism for plants
  - create mechanism to set down new box gardens
  - create graphic for when the earth is first tilled
  - create action mechanism for workers to go near tilling earth spots and show tilling earth icon until the animation is ready
  - create different plants that will grow after the time cycle, although vary their height so they don't look so mechanical
  - allow to sell harvest for more money
  - more money can pay for increased workers, getting rid of the labor bottleneck for advancing gameplay
  - offer upgrades like solar power, automatic watering, tractor, etc
  - create info panels for the different plants that show how easy certain plants are to grow, their yield, their sell potential etc
  - potatoes are easy, because we only show the top of the plant, while the potatoes are buried underground, check reference sources
  - garlic
  - also have shifting supply / demand cycles where prices change for what we can get
  - can set up wind power
  - we need enough actions to fill up gameplay, so the players are not just waiting around for their farms to grow
  - check games like Sid Meiers Golf, and others, how do they fill out gameplay, since those games were old and short on graphics
  - if the pay is low perhaps certain workers will quit
  - perhaps can even build worker's cabins, so you get a bonus when they stay near their field
  
  
  
  













Low Poly Island Blender Tutorial (just like Train Valley 2)

https://www.youtube.com/watch?v=0lj643VmTsg





Corn

https://sketchfab.com/3d-models/corn-d7f4f93c3a0e433888cbffe41ac1d2bd


Cabbage

https://sketchfab.com/3d-models/cabbage-7f4bd2c5b974453d9d82b0db02b02c6d

Tomatoe

https://sketchfab.com/3d-models/tomato-c13de9d85f6a4ab2baa15ebc138db0ee

Farm

https://sketchfab.com/3d-models/low-poly-farm-4ee929f6f461470f9e97f8f0e5c004e1

https://sketchfab.com/3d-models/low-poly-farm-v2-0e91a96ca6ee44569cf94972e30b5be4


