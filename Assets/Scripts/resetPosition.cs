using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetPosition : MonoBehaviour
{
    public Vector3 limit;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < limit.y)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}