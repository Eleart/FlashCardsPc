using FlashCardsPc.Models;

namespace FlashCardsPc.Services;
public interface ICardsService
{
    Task<List<Card>> GetAllCardsAsync();
    Task<List<Card>> GetAllTodaysCardsAsync();
    Task<Card> AddCardAsync(Card card);
    Task<bool> UpdateRightAnswer(Card card);
    Task<bool> UpdateWrongAnswer(Card card);
    Task<bool> DeleteCardAsync(Guid id);
}
