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
    [SerializeField] public GameObject shitOnFloor1;
    [SerializeField] public GameObject shitOnFloor2;
    [SerializeField] public GameObject shitOnFloor3;
    [SerializeField] public GameObject shitOnFloor4;
    [SerializeField] public GameObject shitOnFloor5;
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
        shitOnFloor1.SetActive(true);
        shitOnFloor2.SetActive(true);
        shitOnFloor3.SetActive(true);
        shitOnFloor4.SetActive(true);
        shitOnFloor5.SetActive(true);
        shitCounter = 0;
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

        shitOnFloor1.SetActive(true);
        shitOnFloor2.SetActive(true);
        shitOnFloor3.SetActive(true);
        shitOnFloor4.SetActive(true);
        shitOnFloor5.SetActive(true);
        shitOnBucket1.SetActive(false);
        shitOnBucket2.SetActive(false);
        shitOnBucket3.SetActive(false);
        shitOnBucket4.SetActive(false);
        shitOnBucket5.SetActive(false);
        shitOnShovel.SetActive(false);
    }
}
