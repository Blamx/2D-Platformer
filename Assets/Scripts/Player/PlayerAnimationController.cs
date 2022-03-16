using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField]
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerArrow()
    {
        player.FireArrow();
    }

    public void TriggerAttackBox(int combo)
    {
        player.EnableAttackBox(combo);
    }

    public void DisableAttackBox()
    {
        player.DisableAttackBox();
    }

    public void BowDrawn()
    {
        player.DrawBow();
    }
}
