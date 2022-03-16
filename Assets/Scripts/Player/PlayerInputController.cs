using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

public class PlayerInputController : MonoBehaviour
{

    [SerializeField]
    Player player;

    [SerializeField, FoldoutGroup("Movement")]
    KeyCode jump;

    [SerializeField, FoldoutGroup("Movement")]
    KeyCode right;

    [SerializeField, FoldoutGroup("Movement")]
    KeyCode left;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(right))
        {
            player.MoveRight();
        }
        if (Input.GetKey(left))
        {
            player.MoveLeft();
        }
        if(!Input.GetKey(right) && !Input.GetKey(left))
        {
            player.Idle();
        }
        if(Input.GetKeyDown(jump))
        {
            player.Jump();
        }
    }
}
