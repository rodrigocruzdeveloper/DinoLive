using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject[] cactus;
    [SerializeField] private float timeMin;
    [SerializeField] private float timeMax;

    public bool inGame;

    public void Create()
    {
        StartCoroutine(CreateCactus(timeMin, timeMax));
    }

    IEnumerator CreateCactus(float a, float b)
    {
        yield return new WaitForSeconds(Random.Range(a, b));
        GameObject currentCacuts = Instantiate(cactus[Random.Range(0, cactus.Length)]);
        currentCacuts.transform.position = transform.position;
        StartCoroutine(CreateCactus(a, b));        
    }


}
