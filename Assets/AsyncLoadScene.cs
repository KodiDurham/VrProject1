using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncLoadScene : MonoBehaviour
{
    public Button m_Button;
    public int sceneIndex;
    //public bool loadOnStart = true;

    AsyncOperation asyncOperation;

    void Start()
    {
        m_Button.interactable = false;
        //if(loadOnStart)
        //    StartCoroutine(LoadScene());


    }



    private void OnEnable()
    {
        m_Button.interactable = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player" && asyncOperation ==null)
            StartCoroutine(LoadScene());

    }

    IEnumerator LoadScene()
    {
        yield return null;

        asyncOperation = SceneManager.LoadSceneAsync(sceneIndex);
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);
        while (!asyncOperation.isDone || ! (SceneManager.GetActiveScene()== SceneManager.GetSceneAt(sceneIndex)))
        {
            //Output the current progress
            // Check if the load has finished

            if (asyncOperation.progress >= 0.9f)
            {
                m_Button.interactable = true;

            }

            yield return null;
        }
    }

    public void goToscene()
    {
        asyncOperation.allowSceneActivation = true;
    }

}
