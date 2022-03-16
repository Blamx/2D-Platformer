using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

public class ConnectedTiles : MonoBehaviour
{
    [SerializeField]
    public GameObject TileAbove;

    [SerializeField]
    public GameObject TileBelow;

    [SerializeField]
    public GameObject TileRight;

    [SerializeField]
    public GameObject TileLeft;

    public List<GameObject> CurrentBranch;

    public List<GameObject> ExistingBranch;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FindBranches(GameObject obj, ConnectedTiles OG)
    {
        ConnectedTiles tile = obj.GetComponent<ConnectedTiles>();

        if (OG.ExistingBranch.Contains(obj))
            return;

        OG.CurrentBranch.Add(obj);
        OG.ExistingBranch.Add(obj);

        if (tile.TileAbove != null)
        {
            FindBranches(tile.TileAbove, OG);
        }
        if (tile.TileBelow != null)
        {
            FindBranches(tile.TileBelow, OG);
        }
        if (tile.TileLeft != null)
        {
            FindBranches(tile.TileLeft, OG);
        }
        if (tile.TileRight != null)
        {
            FindBranches(tile.TileRight, OG);
        }
    }

    private void OnDestroy()
    {
        if (TileAbove != null)
        {
            TileAbove.GetComponent<ConnectedTiles>().TileBelow = null;


            if (!ExistingBranch.Contains(TileAbove))
            {
                FindBranches(TileAbove, this);

                if (CurrentBranch.Count != 0)
                    TileMapUtility.instance.createBranch(CurrentBranch);
                CurrentBranch = new List<GameObject>();
            }

        }
        if (TileBelow != null)
        {
            TileBelow.GetComponent<ConnectedTiles>().TileAbove = null;

            if (!ExistingBranch.Contains(TileBelow))
            {
                FindBranches(TileBelow, this);

                if (CurrentBranch.Count != 0)
                    TileMapUtility.instance.createBranch(CurrentBranch);
                CurrentBranch = new List<GameObject>();
            }
        }
        if (TileLeft != null)
        {
            TileLeft.GetComponent<ConnectedTiles>().TileRight = null;

            if (!ExistingBranch.Contains(TileLeft))
            {
                FindBranches(TileLeft, this);

                if (CurrentBranch.Count != 0)
                    TileMapUtility.instance.createBranch(CurrentBranch);
                CurrentBranch = new List<GameObject>();
            }
        }
        if (TileRight != null)
        {

            TileRight.GetComponent<ConnectedTiles>().TileLeft = null;
            if (!ExistingBranch.Contains(TileRight))
            {
                FindBranches(TileRight, this);

                if (CurrentBranch.Count != 0)
                    TileMapUtility.instance.createBranch(CurrentBranch);
                CurrentBranch = new List<GameObject>();
            }
        }
    }
}
