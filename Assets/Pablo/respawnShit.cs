using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class respawnShit : MonoBehaviour
{
    [SerializeField] private GameObject shitOnBucket;
    [SerializeField] private GameObject Shit;
    [SerializeField] private float shitRespawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator respawnShitt() 
    {
        shitOnBucket.SetActive(false);
        yield return new WaitForSeconds(shitRespawnTimer);
        Instantiate(Shit, this.transform.position, quaternion.identity);       
    }
}
