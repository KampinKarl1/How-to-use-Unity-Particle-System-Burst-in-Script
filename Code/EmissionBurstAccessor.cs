using UnityEngine;

public class EmissionBurstAccessor : MonoBehaviour
{

    [SerializeField] private ParticleSystem ps = null;

    // Start is called before the first frame update
    void Start()
    {
        //if the ps is null, notify the user
        if (ps == null && !TryGetComponent(out ps))
            Debug.LogWarning("The particle system field 'ps' on " + gameObject
                + " is null. Remember to place a particle system component into said field.", this);
    }

    // Update is called once per frame
    void Update()
    {
        //access burst in emission module
            //first get emission mod
                var em = ps.emission;

        //If you're exclusively using Bursts (rate/time and rate/distance are 0) then the burst will fire at 
        //  TIME in the Particle System's duration. If I have a looping PS whose duration is 1.00 and my burst fires 
        //  at .5, then the first burst will fire .5 seconds after pressing play and every second thereafter (at Time.time = 1.5, 2.5, 3.5...)


            //Use ParticleSystem.Burst struct to see the modifications available to bursts
             var burst = new ParticleSystem.Burst(.5f //The time at which the burst fires relative to the PS's duration
                                                 , 30 //The min number of particles to fire (this can be a min/max)
                                                 , 60 //max num particles to fire
                                                 , 4  //number of cycles
                                                 , .25f); //repeat frequency (all 4 cycles would be fired in 1 second)

            //Make sure to actually set the bursts you create to the emission module - they can also directly be created in SetBurst/SetBursts
             em.SetBurst(0 //First burst index
                        , burst); //the burst just created.
    }
}
