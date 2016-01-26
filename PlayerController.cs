using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public string sonprofe;
    public float speed = 10f;
    Vector2 _dest = Vector2.zero;
    Vector2 _dir = Vector2.zero;
    Vector2 _nextDir = Vector2.zero;
    private AudioSource sourceprofe;

    [Serializable]
    public class PointSprites
    {
        public GameObject[] pointSprites;
    }

    public PointSprites points;

    public static int killstreak = 0;
    private GameManagerPac GM;
    private Vector2 inicio = new Vector2(69.14f, -58.79f);
    

    private bool _deadPlaying = false;

    void Start()
    {
        GM = GameObject.Find("Game ManagerPac").GetComponent<GameManagerPac>();
        _dest = transform.position;
        sourceprofe = gameObject.AddComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        switch (GameManagerPac.gameState)
        {
            case GameManagerPac.GameState.Game:
                ReadInputAndMove();
                Animate();
                break;

            case GameManagerPac.GameState.Dead:
                if (!_deadPlaying)
                    StartCoroutine("PlayDeadAnimation");
                break;
        }


    }

    IEnumerator PlayDeadAnimation()
    {
        _deadPlaying = true;
        GetComponent<Animator>().SetBool("Die", true);
        yield return new WaitForSeconds(1);
        GetComponent<Animator>().SetBool("Die", false);
        _deadPlaying = false;

        if (GameManagerPac.lives <= 0)
        {
              //poner escena
        }

        else
            GM.ResetScene();
    }

    void Animate()
    {
        Vector2 dir = _dest - (Vector2)transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }

    bool Valid(Vector2 direction)
    {
        Vector2 pos = transform.position;
        direction += new Vector2(direction.x * 0.9f, direction.y * 0.9f);
        RaycastHit2D hit = Physics2D.Linecast(pos + direction, pos);
        return hit.collider.name == "pacdot" || (hit.collider == GetComponent<Collider2D>());
    }

    public void ResetDestination()
    {
        _dest = new Vector2(69.14f, -58.79f);
        GetComponent<Animator>().SetFloat("DirX", 0);
        GetComponent<Animator>().SetFloat("DirY", 0);
    }

    void ReadInputAndMove()
    {
        Vector2 p = Vector2.MoveTowards(transform.position, _dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        if (Boton.right) _nextDir = Vector2.right;
        if (Boton.left) _nextDir = -Vector2.right;
        if (Boton.up) _nextDir = Vector2.up;
        if (Boton.down) _nextDir = -Vector2.up;

        if (Vector2.Distance(_dest, transform.position) < 0.00001f)
        {
            if (Valid(_nextDir))
            {
                _dest = (Vector2)transform.position + _nextDir;
                _dir = _nextDir;
            }
            else   
            {
                if (Valid(_dir)) 
                    _dest = (Vector2)transform.position + _dir; 
            }
        }
    }

    public Vector2 getDir()
    {
        return _dir;
    }


    void OnTriggerEnter2D(Collider2D co)
    {
                   
        if (co.name == "doorI")
        {
            transform.position = new Vector2(113.26f, -43.83f);
            _dest = new Vector2(113.26f, -43.83f);
            GetComponent<Animator>().SetFloat("DirX", 0);
            GetComponent<Animator>().SetFloat("DirY", 0);
            _nextDir = Vector2.zero;
            
        }
        else if(co.name == "doorD")
        {
            transform.position = new Vector2(70.81f, -43.7f);
            _dest = new Vector2(70.81f, -43.7f);
            GetComponent<Animator>().SetFloat("DirX", 0);
            GetComponent<Animator>().SetFloat("DirY", 0);
            _nextDir = Vector2.zero;
        }

        if (co.name == "Malo01" || co.name == "Malo02" || co.name == "Malo03")
        {
            sonarprofe();
            transform.position = inicio;
            ResetDestination();
            perro.ready = false;
            //StartCoroutine("PlayDeadAnimation");            
            _nextDir = Vector2.zero;        
            GameManagerPac.lives--;
            ProfeMove2.speedprofe -= 0.05f;
        }
            
    }

    void sonarprofe()
    {
        sourceprofe.clip = Resources.Load(sonprofe) as AudioClip;
        sourceprofe.Play();
    }


}
