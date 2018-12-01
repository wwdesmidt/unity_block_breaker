using UnityEngine;


public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomness=0.2f;

    Vector2 paddleToBallVector;
    bool launched = false;

    //cached component references

    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2d;

	// Use this for initialization
	void Start ()
    {
        myAudioSource = GetComponent<AudioSource>();
        paddleToBallVector = transform.position - paddle1.transform.position;

        myRigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!launched)
        {
            lockBallToPaddle();
            launchOnMouseClick();
        }
        
        

    }

    private void launchOnMouseClick()
    {
        if(Input.GetMouseButton(0))
        {
            myRigidbody2d.velocity = new Vector2(xVelocity, yVelocity);
            launched = true;
        }
    }

    private void lockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        paddlePos += paddleToBallVector;
        this.transform.position = paddlePos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityRandomness = new Vector2(Random.Range(0f, randomness), Random.Range(0f, randomness));
        if(launched)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2d.velocity += velocityRandomness;
        }
        
    }
}
