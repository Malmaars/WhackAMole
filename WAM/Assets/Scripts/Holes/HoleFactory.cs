using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoleFactory : MonoBehaviour
{
    public HoleView holePrefab;
    public Transform parent;

    int amountOfHoles;

    public void DefineAmountOfHoles(int _amount)
    {
        amountOfHoles = _amount;
    }


    public HoleView Create(int _ID, IHole hole)
    {
        //for now the only number of holes is 6. I won't add more since this won't be released, and making highscores for each amount of holes seems unnecessary
        if(amountOfHoles != 6)
        {
            Debug.LogError("Holes other than 6 are not supported");
            return null;
        }
        HoleView view = Instantiate(holePrefab, parent);
        view.Bind(_ID, hole);

        //new problem: How do I decide where the holes go depending on the amount of holes?
        //for now this will do, it's not good, but I'll improve it later
        Vector2 spawnLocation = Vector2.zero;
        switch (_ID)
        {
            case 0:
                spawnLocation = new Vector2(-600, 100);
                break;
            case 1:
                spawnLocation = new Vector2(0, 100);
                break;
            case 2:
                spawnLocation = new Vector2(600, 100);
                break;
            case 3:
                spawnLocation = new Vector2(-600, -300);
                break;
            case 4:
                spawnLocation = new Vector2(0, -300);
                break;
            case 5:
                spawnLocation = new Vector2(600, -300);
                break;
        }

        view.GetComponent<RectTransform>().anchoredPosition = spawnLocation;

        return view;
    }
}
