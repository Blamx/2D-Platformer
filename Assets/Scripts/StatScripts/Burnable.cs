using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using Sirenix.OdinInspector;

public class Burnable : MonoBehaviour
{

    
    [SerializeField]
    Vector2 Burntime = new Vector2(30f, 90f);

    [SerializeField, ReadOnly]
    float burntimer;

    [SerializeField, ReadOnly]
    bool burning = false;

    [SerializeField]
    Vector2 SpreadInterval = new Vector2(0.5f, 1.5f);

    float SpreadTimer;

    [SerializeField]
    public float IgniteChance = 0.25f;

    [SerializeField]
    float SpreadRange = 10f;

    private void Start()
    {
        BurnManager.Instance.BurnList.Add(this.gameObject);
        burntimer = Random.Range(Burntime.x, Burntime.y);
    }

    // Update is called once per frame
    void Update()
    {
        FixedJoint2D joint = GetComponent<FixedJoint2D>();

        if(joint != null)
        {
            if (joint.connectedBody == null)
                Destroy(joint);
        }

        if (burning)
        {
            burntimer -= Time.deltaTime;
            SpreadTimer -= Time.deltaTime;

            if (SpreadTimer <= 0)
            {
                SpreadTimer += Random.Range(SpreadInterval.x, SpreadInterval.y);
                TryToSpread();

            }

            if (burntimer <= 0)
            {
                EndBurn();
            }
        }
    }

    [Button]
    public void StartBurn()
    {
        if (burning)
            return;

        burning = true;
        GameObject.Instantiate<GameObject>(BurnManager.Instance.BurnEffect, this.transform);

        SpreadTimer = Random.Range(SpreadInterval.x, SpreadInterval.y);
    }

    [Button]
    public virtual void EndBurn()
    {
        BurnManager.Instance.BurnList.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    public void TryToSpread()
    {
        foreach (var item in BurnManager.Instance.BurnList)
        {
            Burnable burn = item.GetComponent<Burnable>();

            if (burn.burning)
                continue;

            if (Vector3.Distance(transform.position, item.transform.position) < SpreadRange)
            {
                float roll = Random.Range(0.0f, 1.0f);

                if (roll < burn.IgniteChance)
                {
                    burn.StartBurn();
                }
            }
        }



    }

}
