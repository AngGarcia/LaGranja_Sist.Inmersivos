using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouch : MonoBehaviour
{
    [SerializeField]
    private Transform Trough;

    private int fillAmount = 0;
    [SerializeField]
    private int maxFillAmount;

    [SerializeField]
    private GameObject[] cornInTrough;

    [SerializeField]
    private float timePerFill;
    private float troughTime;
    [SerializeField]
    private float timerPerFillEaten;
    private float eatenTime;
    private bool isGrabed;

    private void Start()
    {
        for(int i = 0; i < cornInTrough.Length; i++)
            cornInTrough[i].SetActive(false);
        isGrabed = false;
        troughTime = timePerFill;
        eatenTime = timerPerFillEaten;
    }

    public void setRotation()
    {
        transform.rotation = new Quaternion(-0.7f, 0, 0, 0.7f);
    }

    private void Update()
    {
        Debug.Log(Vector3.Dot(transform.up, Vector3.down) > 0);
        Debug.Log("condicion 1 " + (Mathf.Abs(Trough.position.x - transform.position.x) <= 2f));
        Debug.Log("condicion 2 " + (Mathf.Abs(Trough.position.z - transform.position.z) <= 1f));
        Debug.Log("Trough time " + troughTime);

        if (Mathf.Abs(Trough.position.x - transform.position.x) <= 2f &&
            Mathf.Abs(Trough.position.z - transform.position.z) <= 1f &&
            Vector3.Dot(transform.up, Vector3.down) > 0 && isGrabed)
        {
            troughTime -= Time.deltaTime;
        } 
        if (troughTime < 0 && isGrabed)
        {
            troughTime = timePerFill;
            if (fillAmount < maxFillAmount)
            {
                cornInTrough[fillAmount].SetActive(true);
                fillAmount++;
            }
        }

        if(fillAmount > 0)
        {
            eatenTime -= Time.deltaTime;
        }
        if(eatenTime < 0)
        {
            fillAmount--;
            cornInTrough[fillAmount].SetActive(false);
            eatenTime = timerPerFillEaten;
        }
    }
    public void setGrabed(bool grabed)
    {
        isGrabed = grabed;
    }
}
