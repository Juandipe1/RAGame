using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour

{
    public GameObject winPanel;
    public GameObject startPanel;

    public string newScene;

    private void Start()
    {
        StartCoroutine(StartGame());
    }


    void OnTriggerEnter(Collider other)
    {

        Destroy(other.gameObject);
        StartCoroutine(Win());
    }

    IEnumerator Win()
    {

        winPanel.SetActive(true);

        yield return new WaitForSeconds(5f);

        winPanel.SetActive(false);
        SceneManager.LoadScene(newScene);

    }

    IEnumerator StartGame()
    {
        startPanel.SetActive(true);

        yield return new WaitForSeconds(5f);

        startPanel.SetActive(false);
    }

}