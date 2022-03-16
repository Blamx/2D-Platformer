using System.Collections;
using System.Collections.Generic;

using UnityEngine;


using Sirenix.OdinInspector;
public class WallCheck : MonoBehaviour
{
    [SerializeField]
    public bool IsWall = false;

    [SerializeField]
    Collider2D col;

    public bool IsLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<Collider2D> cols = new List<Collider2D>();
        ContactFilter2D cont = new ContactFilter2D();
        cont.NoFilter();

        col.OverlapCollider(cont, cols);

        bool hasPlat = false;

        foreach (var item in cols)
        {
            if (item.gameObject.tag == "Platform")
            {
                Vector2 point = item.ClosestPoint(transform.position);

                if (point.x > transform.position.x)
                    IsLeft = true;
                else
                    IsLeft = false;

                hasPlat = true;
                break;
            }
        }

        if (hasPlat)
            IsWall = true;
        else
            IsWall = false;

    }

}
