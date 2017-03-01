using System.Collections.Generic;

public class CardTable
{
	private delegate void OnPlay(Board board, Player player, Card card);
	private delegate void OnDraw(Board board, Player player, Card card);

	private Dictionary<CardType, OnPlay> onPlay;
	private Dictionary<CardType, OnDraw> onDraw;

	public void HandleOnPlay(Board board, Player player, Card card)
	{
		if (onPlay.ContainsKey(card.GetCardType()))
		{
			onPlay[card.GetCardType()](board, player, card);
		}
	}

	public void HandleOnDraw(Board board, Player player, Card card)
	{
		if (onDraw.ContainsKey(card.GetCardType()))
		{
			onDraw[card.GetCardType()](board, player, card);
		}
	}

	public CardTable()
	{
		onPlay = new Dictionary<CardType, OnPlay>();
		onDraw = new Dictionary<CardType, OnDraw>();

		onPlay.Add(CardType.Archmage, (board, player, card) =>
		{
			player.DrawCard(board);
		}
		);

		onDraw.Add(CardType.Archmage, (board, player, card) =>
		{
			Card copyCard = new Card(CardType.Bahamut);
			player.AddCardToHand(copyCard);
			player.Discard(copyCard);
		}
		);

		onPlay.Add(CardType.Bahamut, (board, player, card) =>
		{
			player.AddCardToHand(new Card(CardType.Archmage));
		}
		);
	}
}