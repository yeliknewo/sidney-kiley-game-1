using System.Collections.Generic;
using UnityEngine;

public class Board
{
	private List<Player> players;
	private CardTable cardTable;

	public Board()
	{
		cardTable = new CardTable();

		players = new List<Player>();
		for (int i = 0; i < 2; i++)
		{
			players.Add(new Player(10, 3, cardTable, this));
		}
	}

	public Player GetNextPlayer()
	{
		Player player = players[0];
		players.Remove(player);
		players.Add(player);
		return player;
	}

	public Player GetCurrentPlayer()
	{
		return players[0];
	}

	public Player GetOtherPlayer()
	{
		return players[1];
	}

	public void Turn()
	{
		Player player = GetNextPlayer();
		player.DrawCard(this);
		List<Card> hand = player.GetHand();
		Card card = hand[Random.Range(0, hand.Count)];
		cardTable.HandleOnPlay(this, player, card);
		player.Discard(card);
	}
}