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