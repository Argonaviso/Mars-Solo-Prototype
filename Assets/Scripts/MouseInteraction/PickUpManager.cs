using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DTInventory
{

    public class PickUpManager : MonoBehaviour
    {
        public DTInventory inventory;

        // Start is called before the first frame update
        void Start()
        {
            if(inventory == null)
            {
                inventory = FindObjectOfType<DTInventory>();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnItemPickUp(GameObject selectItem)
        {
          //  var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("pickup Item");
            // selectFolder.transform.position = mousePos;
            inventory.AddItem(selectItem.GetComponent<Item>());
        }
    }
}
