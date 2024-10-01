using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject blockPrefab;

    GameObject firstblock;

    // Start is called before the first frame update
    void Start()
    {
          Vector3 startPosition = transform.position;
        for (int i = 0; i < 40; i++) 
        {
        Vector3 position = startPosition + transform.forward * i;
        float amplitude = 1.5f;
        float frequency = 0.5f;
        position += transform.right * amplitude * Mathf.Sin(i * frequency);

        GameObject block = Instantiate(blockPrefab, position, Quaternion.identity);
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
