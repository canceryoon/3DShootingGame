using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    CharacterController charCtrl = null;
    float yaw = 181.0f;
    float pitch = 0.0f;

    public GameObject[] bullets;
    public GameObject bullet;
    public GameObject reloadAlert;
    public GameObject[] targets;
    public GameObject scope;
    public GameObject gun;
    public Text stages;
    public Text score;
    public string name;

    Animator ani = null;

    private int remainBullets;
    bool gunScope = true;

	void Awake()
	{
		name = Variables.playerName;
	}

    void Start()
	{
        charCtrl = GetComponent<CharacterController>();
        remainBullets = 6;
        initTargetFalse();
        initStart();
        ani = gun.GetComponent<Animator>();
    }
    
    void initStart()
    {
        reloadAlert.SetActive(false);
        printStage(Variables.stage);
        initStage(Variables.stage);
    }
       
    void printStage(int _stage)
    {
        scope.SetActive(false);
        stages.text = "Stage " + _stage;
    }

    void initTargetFalse()
    {
        for (int i = 0; i < targets.Length; i++)
            targets[i].SetActive(false);
    }

    void initStage(int _stage)
    {
        for (int i = (_stage-1)<<2; i < (_stage<<2); i++)
            targets[i].SetActive(true);
        scope.SetActive(true);
    }

    Quaternion getBulletRotation()
    {
        GameObject _bullet = GameObject.Find("emptyBullet");
        return _bullet.transform.rotation;
    }

    Vector3 getBulletPostioin()
    {
        GameObject _bullet = GameObject.Find("emptyBullet");
        return _bullet.transform.position;
    }

    Vector3 getBulletdirection()
    {
        GameObject _bullet1 = GameObject.Find("emptyBullet");
        GameObject _bullet2 = GameObject.Find("emptyBullet2");
        return _bullet1.transform.position - _bullet2.transform.position;
    }

    void reloadBullet()
    {
        if (remainBullets == 6)
            return; 
        Variables.scores -= 5;
        reloadAlert.SetActive(false);
        remainBullets = 6;

        for (int i = 0; i < 6; i++)
            bullets[i].SetActive(true);
    }

    void printRemainBullets(int remains)
    {
        bool able = true;
        for (int i = 0; i < 6; i++)
        {
            able = (i >= remains) ? false : true;
            bullets[i].SetActive(able);
        }
    }

    
	void checkStage(int _stage)
	{
		if (Variables.targets == (_stage << 2)) 
		{
            if (_stage == 3)
            {
                Variables.success = true;
                SceneManager.LoadScene("GameEndView");
            }
            else
            {
                Variables.stage += 1;
                printStage(Variables.stage);
                initStage(Variables.stage);
            }
		}
		
        if(Variables.scores <= 0)
            SceneManager.LoadScene("GameEndView");
	}
    
    void rePrintScore()
    {
        score.text = "Score: " + Variables.scores;
    }

    IEnumerator reboundGun()
    {
        ani.Play("rebound");
        yield return new WaitForSeconds(0.3f);
        ani.Play("hold");
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse right click
        if (Input.GetMouseButtonDown(1))
        {
            scope.SetActive(!gunScope);
            gun.transform.localPosition =(gunScope)? 
                (gun.transform.localPosition - new Vector3(1.18f, -0.37f, 1.0f)) : 
                (gun.transform.localPosition + new Vector3(1.18f, -0.37f, 1.0f)) ;
            gunScope = !gunScope;
        }


        //Move Left / Right
        if (transform.position.x < 6 && Input.GetKey(KeyCode.Z))
            transform.position += new Vector3(0.2f, 0.0f, 0.0f);
        if (transform.position.x > -6 && Input.GetKey(KeyCode.X))
            transform.position += new Vector3(-0.2f, 0.0f, 0.0f);


        //Rotation 
        yaw += Input.GetAxis("Mouse X") * 5.0f;
        pitch += Input.GetAxis("Mouse Y") * 5.0f;

        if (yaw > 225.0f)
            yaw = 225.0f;
        else if (yaw < 120.0f)
            yaw = 120.0f;
   
        if (pitch > 45.0f)
            pitch = 45.0f;
        else if (pitch < -45.0f)
            pitch = -45.0f;

        transform.eulerAngles = new Vector3(pitch * -1, yaw, 0.0f);


        //Reload Bullet
        if (Input.GetKeyDown(KeyCode.Space))
            reloadBullet();


        //Shoot
        if (Input.GetMouseButtonDown(0) == true)
        {
            if(remainBullets > 0)
            {
                GameObject obj = Instantiate(bullet);
                obj.transform.position = getBulletPostioin(); // new Vector3(-1.295f, 1.99f, 12.06f);
                obj.transform.rotation = getBulletRotation();
                Rigidbody rig = obj.GetComponent<Rigidbody>();
                rig.velocity = getBulletdirection() * 500; // - Vector3.forward * 100;

				Variables.scores -= 1;
                remainBullets--;
                printRemainBullets(remainBullets);
            }

            if (remainBullets == 0)
                reloadAlert.SetActive(true);
            
            StartCoroutine(reboundGun());
        }

        rePrintScore();
        checkStage (Variables.stage);
    }
    
}
