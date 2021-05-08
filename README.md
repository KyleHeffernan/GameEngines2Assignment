# Space Battle Assignment - Kyle Heffernan

# Youtube Video

[![Video](http://i3.ytimg.com/vi/z8uOI9DQrOA/maxresdefault.jpg)](https://youtu.be/z8uOI9DQrOA)

# Project Description
This project simulates the scene in Guardians of the Galaxy Vol. 2 in which the guardians have to flee from the sovereign fleet
after rocket steals batteries from them.

The scene is fully autonomous, including the cutscenes.

# Instructions for use
Run the exe file.

# How it works
The Unity scene starts off by playing the beginning cutscene with a video player. Once this cutscene ends, the song starts playing and the milano begins moving.
The ai in this scene is made with finite state machines, so for the milano to start moving its state is switched.

Some camera movement is done, and once the milano reaches a certain point, a coroutine is started which spawns in the sovereign fleet and some dialogue is played.

After some time, the drones are activated, and once the milano is shot, it switches to the flee state and begins fleeing the drones.

The drones follow the milano throughout the scene with their offset pursue behaviour, constantly shooting at the milano when it is in front of them.

Some more dialogue is played as the milano traverses through the asteroids. It is following a set path, but is also using its obstacle avoidance behaviour to avoid crashing into any asteroids.

During this chase, if the milano takes damage, a small explosion happens on the ship. The milano also fires back at the fleet when it gets the chance. If any of the drones crash or get shot, they explode.

Once the milano gets to the end of the asteroid field, dialogue is played pointing out that some drones went around the field. These drones all fire simultaneously at the milano.

The milano slows down drastically as it is taking massive damage, but a mysterious ship shoots out a ray that obliterates every single drone, saving the guardians.

The scene then transitions to the end cutscene.

# STORYBOARD FOR THE SCENE

![Screenshot](/images/Storyboard1.png)
The scene starts off with the guardians on sovereign. Some dialogue is exchanged, after which we learn that rocket has stolen batteries.

![Screenshot](/images/Storyboard2.png)![Screenshot](/images/Storyboard3.png)
The guardians leave sovereign in the milano.

![Screenshot](/images/Storyboard4.png)
As they are flying through space, a fleet of sovereign ships appears behind the guardians. Some dialogue occurs suggesting that they realised that rocket stole their valuable batteries.

![Screenshot](/images/Storyboard5.png)
The sovereign fleet begins firing at the milano and the guardians begin to flee. Some dialogue occurs noting that they will need to traverse through an asteroid field in order to jump to the nearest planet.

![Screenshot](/images/Storyboard6.png)
The milano keeps traversing through the asteroid field, dodging lasers and asteroids as the guardians continue to flee from the fleet.

![Screenshot](/images/Storyboard7.png)
The guardians reach the end of the asteroid field but quickly realise that some of the fleet went around. The fleet all simultaneously fire at the milano, causing a great amount of damage.

![Screenshot](/images/Storyboard8.png)
A mysterious ship appears and blows up the entire fleet, saving the Guardians.

![Screenshot](/images/Storyboard9.png)
The guardians have escaped from the fleet and reached the jump point after being saved by the mysterious man.

# What am I most proud of
I would say I am most proud of the transitions between the cutscenes and the unity scenes. While they aren't perfect, I am proud of how well they transition together.

# References
- Unity Documentation
- Games Engines 2 2021 Examples Github
- [Asteroids](https://assetstore.unity.com/packages/3d/environments/asteroids-pack-84988)
- [Particle Effects](https://assetstore.unity.com/packages/essentials/asset-packs/unity-particle-pack-5-x-73777)
- [Sound Effects](https://assetstore.unity.com/packages/audio/sound-fx/weapons/ultra-sci-fi-game-audio-weapons-pack-vol-1-113047)
- [Models](https://sketchfab.com/3d-models/guardians-of-the-galaxy-milano-spaceship-d41dfa4b160e403db99f1c3bbe06dcfc)



