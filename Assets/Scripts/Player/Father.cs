using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Father : MonoBehaviour
{
    public GameObject[] spawnLocations;
    void Start()
    {
        int randomLoc = Random.Range(0, spawnLocations.Length);
        this.transform.position = spawnLocations[randomLoc].transform.position;
        if (spawnLocations[randomLoc].GetComponent<FatherSpawns>().flipSprite)
        {
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Winner");
        }
    }
}
