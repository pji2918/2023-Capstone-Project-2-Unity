using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerController : MonoBehaviour
{
    uint triggerCount = 0;
    [SerializeField]
    private SteamVR_Action_Boolean trigger = new SteamVR_Action_Boolean();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetStateDown(SteamVR_Input_Sources.Any))
        {
            Debug.Log("트리거 누름");
            ++triggerCount;
            if (triggerCount >= 2)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }
}
