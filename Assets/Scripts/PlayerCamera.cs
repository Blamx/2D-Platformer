using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    float zoom = 15;

    [SerializeField]
    float Maxzoom = 30;

    [SerializeField]
    float Minzoom = 5;

    [SerializeField]
    bool CanZoom = false;

    [SerializeField]
    float ScrollSens = 0.5f;

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        cam.orthographicSize = zoom;



        if (CanZoom && Input.mouseScrollDelta.y != 0)
        {
            zoom -= Input.mouseScrollDelta.y * ScrollSens;
            zoom = Mathf.Clamp(zoom, Minzoom, Maxzoom);
        }

    }
}
