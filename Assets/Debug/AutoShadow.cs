using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Experimental.Rendering.Universal;

using Sirenix.OdinInspector;

public class AutoShadow : MonoBehaviour
{
    [SerializeField]
    Tilemap tilemap;

    [SerializeField]
    ShadowCaster2D shadowCaster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Button]
    void GenerateShadowMap()
    {
       BoundsInt bounds =  tilemap.cellBounds;

      
    }
}
