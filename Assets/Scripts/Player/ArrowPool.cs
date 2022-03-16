using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

public class ArrowPool : MonoBehaviour
{
    List<Arrow> arrows = new List<Arrow>();

    [SerializeField]
    float Limit;

    [SerializeField]
    int index = 0;

   
    public Arrow SpawnArrow(GameObject Arrow, GameObject point)
    {
        if (arrows.Count < Limit)
        {
            Arrow arrow =  GameObject.Instantiate<GameObject>(Arrow, point.transform.position, point.transform.rotation, transform).GetComponent<Arrow>();
            arrows.Add(arrow);
            arrow.Init();
            return arrow;
        }
        else
        {
            Arrow arrow = arrows[index];
            arrow.transform.parent = transform;
            arrow.Reset();
            arrow.transform.position = point.transform.position;
            arrow.transform.rotation = point.transform.rotation;

            arrow.Init();
            if (++index >= Limit)
                index = 0;

            return arrow;
        }
    }

}
