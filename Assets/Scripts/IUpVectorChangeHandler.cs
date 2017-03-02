using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

/*
 * Interface for altering an objects 'up' vector
 */ 
public interface IUpVectorChangeHandler : IEventSystemHandler {
	void SetUpVector(Vector3 data);
}
