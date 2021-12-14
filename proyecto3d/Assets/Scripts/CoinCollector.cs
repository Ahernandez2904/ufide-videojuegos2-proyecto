using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    [SerializeField]
    public GameObject Secretos;
    public int Coins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

        public GameObject PickUp;

        void OnTriggerEnter(Collider col)
        {
            PickUp = GameObject.FindGameObjectWithTag("Key");

            if (gameObject != null)
            {
                Coins += 1;
                Secretos.GetComponent<Text>().text = "Secretos: " + Coins + " de 17";
                Destroy(gameObject);
                
            }
        }
    

    // Update is called once per frame
    void Update()
    {
        
    }

}
