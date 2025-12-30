using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ok let's figure this out.
//I want to be able to spawn holes, these holes need visuals
//To do that, I want the holemodel to run the interaction with the holes
//the holecontroller will run the interaction with the holes
//the view makes sure the hole show up for the player

//All of this needs to be done without coupling the classes

//I'm going to break down the distinction between the model and the controller
//The controller should handle all interaction the player has with the game, which means: Which hole they clicked
//The model handles everything else having to do with the holes, hitting the moles(?), spawning the holes etc
//The holeview only needs to spawn in the sprites

//The biggest problem I'm facing is them getting all the information they need, but not getting it from each other
//I could do this via the GameManager. Add an Initialize function to all three, spawn the holes and pass their locations
//but this does seem like an incorrect and inefficient way to do things. I don't think the GameManager should handle the 
//spawning of the holes at all. And locations are fine for now, but what if I want to pass more information?

//Solution: A Hole should be a class with multiple variables, this way it's possible for me to also make different holes in the future
//The reference will be to a hole interface
//But this doesn't solve the problem of how I need to give these references to the scripts
public class HoleView : MonoBehaviour, IHoleView
{
    public void ResetVisuals()
    {
    }
}
