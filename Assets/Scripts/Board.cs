using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
	[SerializeField]
	private List<Player> players;

	[SerializeField]
	private CardTable cardTable;

	private void Start()
	{
		players = new List<Player>();
		foreach(Player player in FindObjectsOfType<Player>())
		{
			players.Add(player);
		}

		cardTable = FindObjectOfType<CardTable>();
	}

	public Player GetNextPlayer()
	{
		Player player = players[0];
		players.Remove(player);
		players.Add(player);
		return player;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Player player = GetNextPlayer();
			player.DrawCard();
			List<Card> hand = player.GetHand();
			Card card = hand[Random.Range(0, hand.Count)];
			cardTable.HandleOnPlay(this, player, card);
			player.Discard(card);
		}
	}
}
