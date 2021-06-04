using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PalyerHealth : MonoBehaviour
{
    public int playerHealth = 20;
    public Text healthText;
    public AudioClip playerSFX;

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = playerHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        playerHealth = playerHealth - 1;
        GetComponent<AudioSource>().PlayOneShot(playerSFX);
        healthText.text = playerHealth.ToString();
        if (playerHealth == 0)
        {
            print("Playerbase Finished");
            SceneManager.LoadScene(2);
        }
    }
}
