using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject Pause;
    [SerializeField]
    private GameObject Tip;
    [SerializeField]
    private GameObject start;
    [SerializeField]
    private GameObject death;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject spawn;
    [SerializeField]
    private bool paus;

    public Animator anim;

    public void Start()
    {
        // Dismiss menu
        Pause.SetActive(false);
        // Dismiss menu
        death.SetActive(false);
        // Dismiss menu
        Tip.SetActive(false);
        // Pause game
        Time.timeScale = 0;
        // Pause animation
        anim.SetBool("Running", false);
    }

    public void LOAD()
    {
        // Dismiss menu
        start.SetActive(false);
        // Unpause game
        Time.timeScale = 1;
        // Move player to spawn
        player.transform.position = spawn.transform.position;
        // Make grounded true
        player.GetComponent<ButtonMouse>().grounded = true;
        // Play animation
        anim.SetBool("Running", true);
    }
    public void TRY()
    {
        // Dismiss menu
        death.SetActive(false);
        // Open menu
        start.SetActive(true);
    }
    public void RETURN()
    {
        // Dismiss menu
        Pause.SetActive(false);
        // Unpause game
        Time.timeScale = 1;
        // Reveal Tip
        Tip.SetActive(true);
        // Play animation
        anim.SetBool("Running", true);
    }

    // Update is called once per frame
    void Update()
    {
        // If you hit the key "p"
        if (Input.GetKeyDown("p"))
        {
            // If paus is true
            if (paus == true)
            {
                // Pause game
                Time.timeScale = 0;
                // Open menu
                Pause.SetActive(true);
                // Hide Tip
                Tip.SetActive(false);
                // Play Coroutine
                StartCoroutine(Delay(0.1f));
                // Play Coroutine
                anim.SetBool("Running", false);
            }
            
            // If paus is false
            if (paus == false)
            {
                // Unpause game
                Time.timeScale = 1;
                // Dismiss menu
                Pause.SetActive(false);
                // Reveal Tip
                Tip.SetActive(true);
                // Play Coroutine
                StartCoroutine(Delay2(0.1f));
                // Play Animation
                anim.SetBool("Running", true);
            }
        }
    }

    public IEnumerator Delay(float _Delay)
    {
        // return value and wait for real seconds
        yield return new WaitForSecondsRealtime(_Delay);
        // Make paus false
        paus = false;
    }
    
    public IEnumerator Delay2(float _Delay)
    {
        // return value and wait for real seconds
        yield return new WaitForSecondsRealtime(_Delay);
        // Make paus true
        paus = true;
    }

    // Quit application and unity
    public void EXIT()
    {
#if     UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
