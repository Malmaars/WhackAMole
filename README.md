# WhackAMole

# Design Pattern Choices
To make this game, I've chosen to go with the MVC design pattern. This means I have a view, controller, and model.
The view only manages the visuals, the model implements any functionality, and the controller acts as a bridge between the two. The controller also handles all interactions with the player, and takes the correct corresponding actions.

I have multiple different View+Controller+Model groups, which are responsible for their own category of actions. The groups are:
- score
- time(r)
- highscores
- save data
- holes (where the moles come from)
- level generation

The only classes within the MVC groups that inherit from Monobehaviours are the view and controller classes. The view needs a connection to the UI in the Unity Editor. The controller could theoretically do without a monobehaviour if I linked it to the view, but I would like the view to have absolutely no dependency on other classes, it will only receive commands and data.

To make sure I comply to the SOLID design principles, I made everything as abstract as possible, and made classes for smaller tasks. Any reference to other classes is done via interfaces, even when there is only one class inheriting from an interface. This is to allow for future expansion if wanted.

To connect all the different subsystems (MVC groups) I use the GameManager. This class is solely responsible for connecting the groups and passing along data. All subsystems are unaware of each other, only the GameManager handles the communication between them.

#The Mole/Hole paradox
During the making of this game I've wondered: what is the distinction between a hole and a mole? Are they seperate entities or should they function as the same thing. One could argue that essentially clicking a hole would be clicking a mole, but if I want to do interesting things like having moles outside of holes, or holes that interact with the player when you tap and there isn't a mole, I'm inclined to believe a hole is seperate from a mole.

#Click Manager
I considered to manage all clicking. Essentially making Unity buttons redundant, and managing all clicks via script. This would mean there would need to be less monobehaviours, and I wouldn't have to link the controllers and views of my systems to the UI elements inside Unity. This included giving clickable one of a few shapes, and assigning colliders through code.
In theory I think this works fine, but it would require classes that use the IClickable interface to inherit from a class defining its shape (like a circle or a rectangle). I would like to avoid this, and use interface as much as possible.
I also think that doing it like this would make it needlessly complicated for future developers wanting to expand on the game 