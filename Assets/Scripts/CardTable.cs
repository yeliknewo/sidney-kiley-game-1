using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTable : MonoBehaviour
{
	private delegate void OnPlay(Board board, Player player);

	private Dictionary<CardType, OnPlay> onPlay;

	private void Awake()
	{
		onPlay = new Dictionary<CardType, OnPlay>();

		onPlay.Add(CardType.Archmage, (board, player) =>
		{
			player.DrawCard();
		}
		);

		onPlay.Add(CardType.Bahamut, (board, player) =>
		{
			player.DrawCard();
			player.DrawCard();
		}
		);
	}

	public void HandleOnPlay(Board board, Player player, Card card)
	{
		onPlay[card.GetCardType()](board, player);
	}
}
