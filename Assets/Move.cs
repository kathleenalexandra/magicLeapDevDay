using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Move : MonoBehaviour
{

    [SerializeField]
    public GameObject myObject; 

    [SerializeField]
    public ParticleSystem myParticles; 

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool particleSystemRunning = false;
    public void ReceivePosition(Vector3 position) {
     
        Debug.Log(position.ToString()); 
        Debug.Log("This is position we are using" + position); 
       
        myObject.transform.position = position;


      /* if(MLHandKeyPose.Fist) {
          Debug.Log("Fist gesture"); 
          myParticles.Stop(); 
       } else {
         myParticles.ParticleSystem.Play(); 
       } */ 

      if ( MLHands.Left.KeyPose   == MLHandKeyPose.Fist) {
        Debug.Log("user made fist"); 
        if(particleSystemRunning){
          myParticles.Stop(); 
          particleSystemRunning = false;
        }
    } else if (MLHands.Left.KeyPose == MLHandKeyPose.OpenHandBack) {
       Debug.Log("user opened hands"); 
       if(!particleSystemRunning){
          myParticles.Play();
          particleSystemRunning = true;
       } 
    } else {
      Debug.Log("User hand = " + MLHands.Left.KeyPose.ToString());
    }


/* 
    void IEnumerator PlayParticleSystem() {

      yield new return WaitForSeconds(0); 
      particleSystemPlaying = true; 
      myParticles.Play(); 


    } */ 

     
}
}
