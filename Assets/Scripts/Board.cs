using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	[SerializeField]
	private List<Player> players;

	public Player GetNextPlayer()
	{
		Player player = players[0];
		players.Remove(player);
		players.Add(player);
		return player;
	}
}
