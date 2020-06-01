using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UMA.CharacterSystem;
using UMA.PoseTools;

public class SavePlayer : MonoBehaviour
{

    public GameObject playerSlot;
    GameObject CustomizedAvatar;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        CustomizedAvatar = GameObject.FindGameObjectWithTag("Avatar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSavePlayer()
    {
        CustomizedAvatar.GetComponent<DynamicCharacterAvatar>().enabled = false;
        CustomizedAvatar.GetComponent<UMAExpressionPlayer>().enabled = false;
        CustomizedAvatar.transform.parent = this.transform;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }



}
