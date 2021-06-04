using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    public AudioClip sceneStartAudio;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(sceneStartAudio);
    }

    // Update is called once per frame
    void Update()
    {
        RetryGame();
    }

    void RetryGame()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }

        else if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
