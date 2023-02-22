using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int BuildIndexInGame;
    public void LoadInGame()
    {
        SceneManager.LoadScene(BuildIndexInGame);
    }
}
