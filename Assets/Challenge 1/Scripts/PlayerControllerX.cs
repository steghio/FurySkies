using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    private float turbo;
    private int score;
    private bool isSwappedControls;
    private Vector3 deltaScorePosition = new Vector3(0,2,-7);

    [SerializeField] private AudioClip _balloon;
    [SerializeField] private AudioClip _end;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] TextMesh _score;

    private void Awake()
    {
        score = 0;
        isSwappedControls = false;
    }

    private void Update()
    {
        _score.transform.position = transform.position + deltaScorePosition;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Challenge 1");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            isSwappedControls = !isSwappedControls;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space)){
            turbo = 3;
        }
        else
        {
            turbo = 1;
        }
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed * turbo);

        // tilt the plane up/down based on up/down arrow keys
        Vector3 direction;
        if (isSwappedControls)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.right;
        }
        transform.Rotate(direction * rotationSpeed * Time.deltaTime * verticalInput);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("balloon"))
        {
            GetComponent<AudioSource>().PlayOneShot(_balloon);
            Instantiate(_explosion, transform.position, Quaternion.identity).Play();
            Destroy(collision.gameObject);
            score++;
            _score.text = score.ToString();
        }

        if (collision.gameObject.CompareTag("end"))
        {
            GetComponent<AudioSource>().PlayOneShot(_end);
            Time.timeScale = 0;
        }
    }
}
