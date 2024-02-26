using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    protected InteractionEventSender _interactionEventSender;
    
    public virtual void OnEvent(InteractionEventSender interactionEventSender)
    {
        _interactionEventSender = interactionEventSender;
    }
}