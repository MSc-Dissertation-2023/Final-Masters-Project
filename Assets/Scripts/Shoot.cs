using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * A class which creates shooting behaviour
 */
public class Shoot : MonoBehaviour
{
    private Camera cam;

    [SerializeField] GameObject bloodParticle;
    [SerializeField] GameObject bulletHole;
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioClip gunshot;
    //Ditance for bullet holes
    public float distance = 100f;

    private PlayerCharacter playerChar;

    void Start()
    {
        cam = GetComponent<Camera>();
        playerChar = GameObject.Find("Player").GetComponent<PlayerCharacter>();
    }

    void OnGUI()
    {
        int size = 12;
        //Find the centre of the screen
        float xPos = cam.pixelWidth / 2 - size / 4;
        float yPos = cam.pixelHeight / 2 - size / 2;

        //Place a star in the centre of he screen to represent crosshair
        GUI.Label(new Rect(xPos, yPos, size, size), "+");
    }

    // Update is called once per frame
    void Update()
    {
        //When the left mouse button is clicked && not hovering over game object (popup) && enough ammo

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && Managers.Player.ammo > 0)
        {
            Managers.Player.ConsumeAmmo();
            //Play gunshot sound
            soundSource.PlayOneShot(gunshot);
            //Find what the middle of the screen is pointing at
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            //Ray created from camer to point in the middle of the screen
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            //Fill reference variable with information
            if (Physics.Raycast(ray, out hit))
            {
                //Attain the hit object
                GameObject hitObject = hit.transform.gameObject;
                //Determine if hit is an enemy
                Enemy target = hitObject.GetComponent<Enemy>();
                // Old implementation - to be removed
                //  TargetEnemy target = hitObject.GetComponent<TargetEnemy>();
                if (target != null)
                {
                    //Create blood effect on impact
                    Managers.Player.OnSuccessfulShot();
                    StartCoroutine(BloodSplat(hit.point));
                    target.TakeDamage(Managers.Player.damage);
                    // Old implemetnation - to be removed
                    // target.ReactToHit(playerChar.damage);
                }
                else
                {
                    //Create bullet hole on game object
                    StartCoroutine(BulletHole(hit));
                }

            }
        }
    }

    //Represents bullet holes for missed shots
    private IEnumerator BulletHole(RaycastHit hit)
    {
        //If Ray hits a game object
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance))
        {
            //Create a bullet hole in that positiion and adjust angle so its flush with object
            GameObject bH = Instantiate(bulletHole, hit.point, Quaternion.LookRotation(-hit.normal));

            //Destroy bullet hole after one second
            yield return new WaitForSeconds(1);
            Destroy(bH);
        }
    }

    //Create a blood splatter particle system
    private IEnumerator BloodSplat(Vector3 pos)
    {
        GameObject bS = Instantiate(bloodParticle);
        bS.transform.position = pos;

        //Destroy game object after one second
        yield return new WaitForSeconds(1);
        Destroy(bS);
    }
}
