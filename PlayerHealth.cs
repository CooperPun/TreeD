using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int health;
    public bool hasDied;

	// Use this for initialization
	void Start () {
        hasDied = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < -7)
        {
            hasDied = true;
        }
        if (hasDied == true)
        {
            StartCoroutine("Die");
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "")
        {
            hasDied = true;
        }
    }

    IEnumerator Die ()
    {
        SceneManager.LoadScene ("Prototype1");
        yield return null;
    }
}
