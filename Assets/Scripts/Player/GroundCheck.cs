using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    public bool IsGrounded = false;

    [SerializeField]
    Collider2D col;

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
                hasPlat = true;
                break;
            }
        }

        if (hasPlat)
            IsGrounded = true;
        else
            IsGrounded = false;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "Platform")
    //    {
    //        IsGrounded = true;
    //    }
    //}
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Platform")
    //    {
    //        IsGrounded = true;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Platform")
    //    {

    //        IsGrounded = false;

    //        List<Collider2D> cols = new List<Collider2D>();
    //        ContactFilter2D cont = new ContactFilter2D();
    //        cont.NoFilter();

    //        collision.OverlapCollider(cont, cols);

    //        foreach (var item in cols)
    //        {
    //            if(item.gameObject.tag == "Platform")
    //            {
    //                IsGrounded = true;
    //                break;
    //            }
    //        }

    //    }
    //}
}
