using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;
public class BurnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject BurnEffect;

    public static BurnManager Instance;


    [SerializeField]
    public List<GameObject> BurnList = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
