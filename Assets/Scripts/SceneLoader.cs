using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public bool load_a_Scene;
    public string theScene;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (load_a_Scene == true)
        {
            LoadScene();
            load_a_Scene = false;
        }
        
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(theScene);
    }
}
