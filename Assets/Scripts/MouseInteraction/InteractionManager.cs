using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DTInventory;

public class InteractionManager : MonoBehaviour
{
    public GameObject UIInstantiator;
    GameObject CurrentSelectingItem;
    public GameObject ItemPicker;
    GameObject CurrentSelectingAvatar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentSelectingItem != null)
        {
            UIInstantiator.GetComponent<SpawnInteractionUI>().UpdateUIPos(CurrentSelectingItem.transform);
        }
    }

    public void InteractTargetDetect(GameObject targetItem)
    {
      
            CurrentSelectingItem = targetItem;

            if (targetItem.tag == "Door")
            {
                UIInstantiator.GetComponent<SpawnInteractionUI>().UISelect(0, targetItem.transform.position);
            }
            else if (targetItem.tag == "Folder")
            {
                UIInstantiator.GetComponent<SpawnInteractionUI>().UISelect(1, targetItem.transform.position);
            }
            else if (targetItem.tag == "Table")
            {
                UIInstantiator.GetComponent<SpawnInteractionUI>().UISelect(2, targetItem.transform.position);
            }
            else if (targetItem.tag == "Chair")
            {
                UIInstantiator.GetComponent<SpawnInteractionUI>().UISelect(3, targetItem.transform.position);
            }
            else if (targetItem.tag == "Screen")
            {
                UIInstantiator.GetComponent<SpawnInteractionUI>().UISelect(4, targetItem.transform.position);
            }    
       
    }

    public void InteractAvatarDetect(GameObject targetAvatar)
    {
        Debug.Log("avatar detect");
        CurrentSelectingAvatar = targetAvatar;
        UIInstantiator.GetComponent<SpawnInteractionUI>().UISelect(5, targetAvatar.transform.position);

    }

    public void OnClickExit(GameObject ExitItem)
    {
        if (ExitItem == CurrentSelectingItem || ExitItem == CurrentSelectingAvatar)
        {
            UIInstantiator.GetComponent<SpawnInteractionUI>().DeletCurrentUI();
           // CurrentSelectingItem = null;
          //  CurrentSelectingAvatar = null;
        }
    }

    public void FinishCurrentSelect()
    {
        CurrentSelectingItem = null;
    }

    public void FolderInteraction()
    {
        if (CurrentSelectingItem.tag == "Folder")
        {
            //pickup
            ItemPicker.GetComponent<PickUpManager>().OnItemPickUp(CurrentSelectingItem);
            UIInstantiator.GetComponent<SpawnInteractionUI>().FinishCurrentUI();
        }
    }
}
