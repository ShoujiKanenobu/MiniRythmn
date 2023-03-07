# MiniRythmn
A small rhythm game made to understand beat detection

## Thoughts on the project

I originally started this project to try and make a simple game, then focus on VFX and shaders. After 2 days of working on the Shaders, I realized that I was out of my wheelhouse, so I pivoted to implementing beat detection. 

Allanpichardo's beat detection from what I can gather, tries to calculate the average BPM through comparing the current channel/spectrum levels from past ones and calls an event based on that information. There are a number of parameters that you can play around with to try and fit your needs, but the threshold parameter is the important one. 

While the beat detection does work to a certain extent, for procedrual level generation, it simply is not complex enough for fun gameplay. What truly has been created here is an endless runner that plays for the duration of a chosen song. 

All that being said, it was a great learning project.

## Credits
I used a number of external resources to complete this project that arent in the repo. The following were also included
+ [Beat Detection Algorithm](https://github.com/allanpichardo/Unity-Beat-Detection)
+ [Simple File Browser](https://github.com/yasirkula/UnitySimpleFileBrowser)
+ DoTween
