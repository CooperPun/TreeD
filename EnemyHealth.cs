using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > 30)
        {
            Destroy(gameObject);
        }

    }

}