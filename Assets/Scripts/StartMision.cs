using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMision : MonoBehaviour
{
    public GameObject startPanel;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Message());
    }

    IEnumerator Message()
    {
        startPanel.SetActive(true);

        yield return new WaitForSeconds(5f);

        startPanel.SetActive(false);
    }
}
