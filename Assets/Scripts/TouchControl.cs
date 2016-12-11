using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour {

    private PlayerControler player;
    public LevelLoader lvlExit;
    private PauzeMenu thePauzeMenu;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerControler>();
        lvlExit = FindObjectOfType<LevelLoader>();
        thePauzeMenu = FindObjectOfType<PauzeMenu>();
	}
	
	public void LeftArrow()
    {
        player.Move(-1);
    }

    public void RightArrow()
    {
        player.Move(1);
    }

    public void UnpressedArrow()
    {
        player.Move(0);
    }

    public void Sword()
    {
        player.SwordAttack();
    }

    public void ResetSword()
    {
        player.ResetSword();
    }

    public void Star()
    {
        player.FireStar();
    }

    public void Jump()
    {
        player.Jump();
        if (lvlExit.playerInZone)
        {
            lvlExit.LoadScene();
        }
    }

    public void Pauze()
    {
        thePauzeMenu.PauzeOnPauze();
    }
}
