using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class shitGameManager : MonoBehaviour
{
    private static shitGameManager instance;
    //[SerializeField] public GameObject shitOnShovel;
    [SerializeField] private GameObject shitOnBucket1;
    [SerializeField] private GameObject shitOnBucket2;
    [SerializeField] private GameObject shitOnBucket3;
    [SerializeField] private GameObject shitOnBucket4;
    [SerializeField] private GameObject shitOnBucket5;
    [SerializeField] public int shitCounter;
    [SerializeField] private GameObject shitSpawner1;
    [SerializeField] private GameObject shitSpawner2;
    [SerializeField] private GameObject shitSpawner3;
    [SerializeField] private GameObject shitSpawner4;
    [SerializeField] private GameObject shitSpawner5;
    [SerializeField] private GameObject Shit;
    [SerializeField] private float timeToWaitForShitToRespawn;
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
        
        shitCounter = 0;
        //shitOnShovel.SetActive(false);
        shitOnBucket1.SetActive(false);
        shitOnBucket2.SetActive(false);
        shitOnBucket3.SetActive(false);
        shitOnBucket4.SetActive(false);
        shitOnBucket5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (shitCounter == 2)
        {
            shitOnBucket1.SetActive(true);
        }
        if (shitCounter == 4)
        {
            shitOnBucket2.SetActive(true);
        }
        if (shitCounter == 6)
        {
            shitOnBucket3.SetActive(true);
        }
        if (shitCounter == 8)
        {
            shitOnBucket4.SetActive(true);
            
        }
        if (shitCounter == 10)
        {
            shitOnBucket5.SetActive(true);   
            shitCounter = 0;
            //StartCoroutine(respawnShit());
            StartCoroutine(respawnShit());    
        }
    }

    //private IEnumerator respawnShit() 
    //{
    //    //Debug.Log("ENTRA");
    //    yield return new WaitForSeconds(60.0f);

    //    Instantiate(Shit, shitSpawner1.transform.position, quaternion.identity);
    //    Instantiate(Shit, shitSpawner2.transform.position, quaternion.identity);
    //    Instantiate(Shit, shitSpawner3.transform.position, quaternion.identity);
    //    Instantiate(Shit, shitSpawner4.transform.position, quaternion.identity);
    //    Instantiate(Shit, shitSpawner5.transform.position, quaternion.identity);
    //    shitOnBucket1.SetActive(false);
    //    shitOnBucket2.SetActive(false);
    //    shitOnBucket3.SetActive(false);
    //    shitOnBucket4.SetActive(false);
    //    shitOnBucket5.SetActive(false);
    //    //shitOnShovel.SetActive(false);
    //}

    private IEnumerator respawnShit()
    {
        yield return new WaitForSeconds(timeToWaitForShitToRespawn);
        StartCoroutine(shitSpawner1.GetComponent<respawnShit>().respawnShitt());
        StartCoroutine(shitSpawner2.GetComponent<respawnShit>().respawnShitt());
        StartCoroutine(shitSpawner3.GetComponent<respawnShit>().respawnShitt());
        StartCoroutine(shitSpawner4.GetComponent<respawnShit>().respawnShitt());
        StartCoroutine(shitSpawner5.GetComponent<respawnShit>().respawnShitt());
    }
}
