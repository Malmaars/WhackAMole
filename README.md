# WhackAMole
Runs on Android.
The apk is located in the "WAMbuild" folder


# Design Choices
To make this game, I've chosen to go with the MVC design pattern. This means I have a view, controller, and model.
The view only manages the visuals, the model implements any functionality, and the controller acts as a bridge between the two. The controller also handles all interactions with the player, and takes the correct corresponding actions.

I have multiple different View+Controller+Model groups, which are responsible for their own category of actions.

The only classes within the MVC groups that inherit from Monobehaviours are the view and controller classes. The view needs a connection to the UI in the Unity Editor. The controller could theoretically do without a monobehaviour if I linked it to the view, but I would like the view to have absolutely no dependency on other classes, it will only receive commands and data.

To make sure I comply to the SOLID design principles, I made everything as abstract as possible, and made classes for smaller tasks. Any reference to other classes is done via interfaces, even when there is only one class inheriting from an interface. This is to allow for future expansion if wanted.

To connect all the different subsystems (MVC groups) I use the GameManager. This class is solely responsible for connecting the groups and passing along data. All subsystems are unaware of each other, only the GameManager handles the communication between them.

I ended up using a mix of MVC and MVP structure where it felt appropriate. The Hole system was done with a presenter system.

To keep the classes from knowing too much about one another, I decided to implement an eventbus, where classes could subscribe to, and publish events. This way A class can call an event, effectively starting other functions in other classes, but both classes being unaware of each other.

The gamemanager acts to setup the classes in the game, and connect them where necessary. This is the only function the gamemanager has. It is a connector

I have used interfaces where I can, for some classes it could feel as a little overkill, but it's nice to have the option for different implementations open.

I added three different moles to show the ease of implementation. I can create a new mole, define what points they give (or theoretically more functionality) and it would work instantly. The only thing I'd need to change is to add it in the spawn pool for the holes.
The black mole awards one point when hit, the red mole awards a negative point, and the blue awards one point when hit, but won't go away when hit (spam that mole!)
Whenever you hit a hole with no mole in it, you get a negative point

There is currently only the option to play with 6 holes and a timer of 30 seconds, but I implemented it so it's easy to add other modes as well.

I considered to manage all clicking. Essentially making Unity buttons redundant, and managing all clicks via script. This would mean there would need to be less monobehaviours, and I wouldn't have to link the controllers and views of my systems to the UI elements inside Unity. This included giving clickable one of a few shapes, and assigning colliders through code.
In theory I think this works fine, but it would require classes that use the IClickable interface to inherit from a class defining its shape (like a circle or a rectangle). I would like to avoid this, and use interface as much as possible.
I also think that doing it like this would make it needlessly complicated for future developers wanting to expand on the game 

On a final note, I had a lot of struggles with the android support for Unity 2022.31.1f, which didn't create the proper android build folders (SDK, OPENJDK and NDK straight up didn't exist). I'm guessing it's an issue that doesn't appear at your side, the internet sure didn't have a good answer, but after struggling with getting unity to read any SDK folder, I got it working by referencing a folder from another unity editor I had installed. Surely not the best solution, but I'm happy it gets the job done.