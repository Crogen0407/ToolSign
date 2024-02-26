using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEventSender : MonoBehaviour
{
    public InteractionEvent interactionEvent;
    
    public virtual void OnInteraction()
    {
        interactionEvent.OnEvent(this);
    }
}
