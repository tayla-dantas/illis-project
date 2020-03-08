using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    //public AudioClip beep; 
    // Start is called before the first frame update
    public IEnumerator OpenLevel(string level)
    {
        //GetComponent<AudioSource>().PlayOneShot(beep);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene(level);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void btnplay(){
        StartCoroutine(OpenLevel("Prototipo"));
    }
     public void btnquit(){
        Application.Quit();
    }
}
