using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private float posX;
    private float posY;
    public float speed = 0.05f;
    private bool left = false;
    public bool grounded = false;
    public Transform groundedEnd;
    private bool paused = false;

    public bool isPlayerOne;
    private int m_playerNo;
    private KeyCode[] m_movingLeft = new KeyCode[2] { KeyCode.A, KeyCode.LeftArrow };
    private KeyCode[] m_movingRight = new KeyCode[2] { KeyCode.D, KeyCode.RightArrow };
    private KeyCode[] m_jumping = new KeyCode[2] { KeyCode.W, KeyCode.UpArrow };
    private KeyCode[] m_shooting = new KeyCode[2] { KeyCode.X, KeyCode.N };
    private KeyCode[] m_stealing = new KeyCode[2] { KeyCode.C, KeyCode.M };

    private Vector2 m_startingPosition;

    private SpriteRenderer m_spriteRenderer;
    public Vector3[] baseColours;
    private SpriteRenderer m_ballSprite;
    void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        if (isPlayerOne)
            m_playerNo = 0;
        else
            m_playerNo = 1;

        m_startingPosition = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (!paused)
        {
            if (Input.GetKey(m_movingRight[m_playerNo]))
            {
                posX = transform.position.x + speed;
                posY = transform.position.y;
                transform.position = new Vector2(posX, posY);
                left = false;
                transform.localScale = new Vector2(1, 1);
            }
            if (Input.GetKey(m_movingLeft[m_playerNo]))
            {
                posX = transform.position.x - speed;
                posY = transform.position.y;
                transform.position = new Vector2(posX, posY);
                left = true;
                transform.localScale = new Vector2(-1, 1);
            }

            if (Input.GetKeyDown(m_jumping[m_playerNo]) && grounded)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
            }
        }
        Raycasting();
    }

    void Raycasting()
    {
        Debug.DrawLine(this.transform.position, groundedEnd.position, Color.green);

        grounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));

        Physics2D.IgnoreLayerCollision(9, 10);
    }

    float m_posXProj;
    Vector3 m_dirProj;
}