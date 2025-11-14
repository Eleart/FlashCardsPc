using FlashCardsPc.Extensions;
using FlashCardsPc.Models;
using FlashCardsPc.Repository;

namespace FlashCardsPc.Services;
public class CardsService : ICardsService
{
    private readonly ICardsRepository _cardsRepository;

    public CardsService(ICardsRepository cardsRepository)
    {
        _cardsRepository = cardsRepository;
    }

    public async Task<Card> AddCardAsync(Card card)
    {
        card.NextAppareance = DateTime.UtcNow;
        return await _cardsRepository.AddCardAsync(card);
    }

    public async  Task<bool> DeleteCardAsync(Guid id)
    {
        return await _cardsRepository.DeleteCardAsync(id);
    }

    public async Task<List<Card>> GetAllCardsAsync()
    {
        return await _cardsRepository.GetAllCardsAsync();
    }

    public async Task<List<Card>> GetAllTodaysCardsAsync()
    {
        var todaysCards =  await _cardsRepository.GetAllTodaysCardsAsync();
        todaysCards.Shuffle();
        return todaysCards;
    }

    public async Task<bool> UpdateRightAnswer(Card card)
    {
        if(card.Strike < 90)
        {
            card.Strike++;
        }
        UpdateCardToNextAppareance(card);

        return await _cardsRepository.UpdateCardAsync(card);
    }

    public async Task<bool> UpdateWrongAnswer(Card card)
    {
        card.Strike = 1;
        UpdateCardToNextAppareance(card);

        return await _cardsRepository.UpdateCardAsync(card);
    }

    private static void UpdateCardToNextAppareance(Card card)
    {
        card.IsRectoSide = !card.IsRectoSide;
        var newAppareance = DateTime.UtcNow.AddDays(card.Strike);
        card.NextAppareance = newAppareance;
    }
}
