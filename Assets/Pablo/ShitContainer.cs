using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitContainer : MonoBehaviour
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
        //if (other.gameObject.tag == "Shovel" && shitGameManager.Instance.shitOnShovel.activeSelf)
        //{
        //    shitGameManager.Instance.shitCounter++;
        //    shitGameManager.Instance.shitOnShovel.SetActive(false);

        //}

        if (other.gameObject.tag == "Shit")
        {
            Debug.Log("HOLAAAA");
            shitGameManager.Instance.shitCounter+=1;
            //shitGameManager.Instance.shitOnShovel.SetActive(false);
            Destroy(other.gameObject);

        }
    }
}
