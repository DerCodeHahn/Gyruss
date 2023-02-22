using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveManager : MonoBehaviour
{
    [SerializeField] GameObject LivesPrefab;
    List<GameObject> lives;

    private void Awake()
    {
        lives = new List<GameObject>();
    }

    public void SetLives(int count)
    {
        foreach (GameObject live in lives)
            Destroy(live);

        for (int i = 0; i < count; i++)
        {
            lives.Add(Instantiate(LivesPrefab, transform));
        }
    }

    public void RemoveOne()
    {
        if (lives.Count >= 1)
        {
            Destroy(lives[0]);
            lives.RemoveAt(0);
        }
            
    }
}
