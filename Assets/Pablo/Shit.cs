using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shit : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Shovel" && !shitGameManager.Instance.shitOnShovel.activeSelf)
        {
            //shitGameManager.Instance.shitCounter++;
            this.gameObject.SetActive(false);
            shitGameManager.Instance.shitOnShovel.SetActive(true);
            //if(shitGameManager.Instance.shitCounter==4)
            //{
            //    shitGameManager.Instance.hugeShit.SetActive(false);

            //}

        }
    }
}
