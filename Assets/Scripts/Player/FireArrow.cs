using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

public class FireArrow : Arrow
{
    override public void StickArrow(GameObject Parent)
    {

        base.StickArrow(Parent);
     
        if(Parent.GetComponent<Burnable>())
        {
            Parent.GetComponent<Burnable>().StartBurn();
        }
    }
}
