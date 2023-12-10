using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shitGameManager : MonoBehaviour
{
    private static shitGameManager instance;
    [SerializeField] public GameObject shitOnShovel;
    [SerializeField] private GameObject shitOnBucket1;
    [SerializeField] private GameObject shitOnBucket2;
    [SerializeField] private GameObject shitOnBucket3;
    [SerializeField] private GameObject shitOnBucket4;
    [SerializeField] private GameObject shitOnBucket5;
    [SerializeField] public int shitCounter;
    [SerializeField] public GameObject hugeShit;
    // Start is called before the first frame update

    public static shitGameManager Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("NO GAME MANAGER");


            return instance;

        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        hugeShit.SetActive(true);
        shitCounter= 0;
        shitOnShovel.SetActive(false);
        shitOnBucket1.SetActive(false);
        shitOnBucket2.SetActive(false);
        shitOnBucket3.SetActive(false);
        shitOnBucket4.SetActive(false);
        shitOnBucket5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (shitCounter == 1)
        {
            shitOnBucket1.SetActive(true);
        }
        if (shitCounter == 2)
        {
            shitOnBucket2.SetActive(true);
        }
        if (shitCounter == 3)
        {
            shitOnBucket3.SetActive(true);
        }
        if (shitCounter == 4)
        {
            shitOnBucket4.SetActive(true);
            
        }
        if (shitCounter == 5)
        {
            shitOnBucket5.SetActive(true);   
            shitCounter = 0;
            StartCoroutine(respawnShit());
        }
    }

    private IEnumerator respawnShit() 
    {
        yield return new WaitForSeconds(60.0f);
        
        hugeShit.SetActive(true);
        shitOnBucket1.SetActive(false);
        shitOnBucket2.SetActive(false);
        shitOnBucket3.SetActive(false);
        shitOnBucket4.SetActive(false);
        shitOnBucket5.SetActive(false);
        shitOnShovel.SetActive(false);
    }
}
