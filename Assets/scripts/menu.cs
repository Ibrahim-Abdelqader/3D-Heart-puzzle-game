using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class menu : MonoBehaviour
{
    public GameObject menupanel;
    public GameObject infopanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void InfoButton() 
    {
        menupanel.SetActive(false);
        infopanel.SetActive(true);
    }

    public void BackButton()
    {
        menupanel.SetActive(true);
        infopanel.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("The exit button has been pressed.");
    }
}
