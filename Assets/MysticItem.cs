using UnityEngine;

public class MysticItem : MonoBehaviour
{
    private UnityEventOnTrigger trigger;
    private MysticCounter mysticCounter;
    void Start()
    {
        mysticCounter = GameObject.Find("MysticItemCounter").GetComponent<MysticCounter>();
        trigger = GetComponent<UnityEventOnTrigger>();
        trigger.onTriggerEnter.AddListener(mysticCounter.UpdateMysticItemText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
