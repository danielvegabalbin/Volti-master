using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public int CoinValue;
    private bool triggered_;
 //   private AudioSource audio_;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered_ )
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter()
    {
        triggered_ = true;
        // audio_.enabled = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        GameManager.PickUpCount += CoinValue;
    }
}
