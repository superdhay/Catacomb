using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_LoadScene : MonoBehaviour
{
    public int SceneID;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneID);
    }
}
