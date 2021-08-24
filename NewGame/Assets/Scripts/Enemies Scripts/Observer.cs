using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    // public GameEnding gameEnding;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;
    //public float obstacleRange;
    private bool _alive;

    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                //if (hit.distance < obstacleRange)
                //{
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
                //}
            }

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    if (Physics.SphereCast(ray, 0.75f, out hit))
                    {
                        GameObject hitObject = hit.transform.gameObject;
                        if (hitObject.GetComponent<PlayerCharacter>())
                        {
                            if (_fireball == null)
                            {
                                _fireball = Instantiate(fireballPrefab) as GameObject;
                                _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                                _fireball.transform.rotation = transform.rotation;
                               
                            }
                           new WaitForSeconds(2);
                            Destroy(_fireball);


                            //    }
                            //    else if (hit.distance < obstacleRange)
                            //    {
                            //        float angle = Random.Range(-110, 110);
                            //        transform.Rotate(0, angle, 0);
                            //    }
                            //}
                            // gameEnding.CaughtPlayer ();
                        }
                    }
                }
            }
        }
    }
}