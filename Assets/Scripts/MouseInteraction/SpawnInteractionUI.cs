using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpawnInteractionUI : MonoBehaviour
{
    public GameObject DoorInteractUI;
    public GameObject FolderInteractUI;
    public GameObject TableInteractUI;
    public GameObject ChairInteractUI;
    public GameObject SceneInteractUI;
    public GameObject AvatarInteractUI;
 //   public GameObject UICanvas;
    public GameObject CurrentInteractionUI;
    //  public GameObject CurrentSelectObject;
    public GameObject InteractionManager;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UISelect(int ObjectIndex, Vector3 spawnPos)
    {

        if(CurrentInteractionUI != null)
        {
            CurrentInteractionUI.SetActive(false);
            CurrentInteractionUI = null;
          //  CurrentInteractionUI.SetActive(true);
        }

        if (ObjectIndex == 0) //door
        {
            Debug.Log("Door Interaction");
            DoorInteractUI.SetActive(true);
            CurrentInteractionUI = DoorInteractUI;
          /*  Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CurrentInteractionUI = Instantiate(DoorInteractUI, pos, Quaternion.identity);
            CurrentInteractionUI.transform.SetParent(UICanvas.transform);
            CurrentInteractionUI.transform.position = pos;
            */
        }
        else if (ObjectIndex == 1) //folder
        {
            Debug.Log("Folder Interaction");
            FolderInteractUI.SetActive(true);
            CurrentInteractionUI = FolderInteractUI;
        } 
        else if (ObjectIndex == 2) //table
        {
            Debug.Log("Table Interaction");
            TableInteractUI.SetActive(true);
            CurrentInteractionUI = TableInteractUI;
        } 
        else if (ObjectIndex == 3) //chair
        {
            Debug.Log("Chair Interaction");
            ChairInteractUI.SetActive(true);
            CurrentInteractionUI = ChairInteractUI;
        } 
        else if (ObjectIndex == 4) //screen
        {
            Debug.Log("Screen Interaction");
            SceneInteractUI.SetActive(true);
            CurrentInteractionUI = SceneInteractUI;
        }
        else if(ObjectIndex == 5) //avatar
        {
            AvatarInteractUI.SetActive(true);
            CurrentInteractionUI = AvatarInteractUI;
        }

       // CurrentInteractionUI.transform.SetParent(UICanvas.transform);
        var newPos = Camera.main.WorldToScreenPoint(spawnPos);
        CurrentInteractionUI.transform.position = newPos;
    }

    public void DeletCurrentUI()
    {
        if (IsPointerOverUIElement() == false && CurrentInteractionUI != null)
        {
            Debug.Log("DeletCurrentUI!");
            CurrentInteractionUI.SetActive(false);
            CurrentInteractionUI = null;
            //CurrentInteractionUI.SetActive(true);
        }
    }
    public void FinishCurrentUI()
    {
        if (CurrentInteractionUI != null) {
            CurrentInteractionUI.SetActive(false);
            CurrentInteractionUI = null;
            //d CurrentInteractionUI.SetActive(true);
            InteractionManager.GetComponent<InteractionManager>().FinishCurrentSelect();
        }
    }

    public void UpdateUIPos(Transform newPos)
    {
        var updatedPos = Camera.main.WorldToScreenPoint(newPos.transform.position);
        CurrentInteractionUI.transform.position = updatedPos;
    }

    /////////////////////////////////////////////////////////////////////////////UI Detecter see if is cicking on an UI Element
    ///Returns 'true' if we touched or hovering on Unity UI element.
    public static bool IsPointerOverUIElement()
    {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }

    
    ///Returns 'true' if we touched or hovering on Unity UI element.
    public static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];
            if (curRaysastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
                return true;
        }
        return false;
    }
    ///Gets all event systen raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
    
}
