using FlashCardsPc.Models;

namespace FlashCardsPc.Repository;
public interface ICardsRepository
{
    Task<List<Card>> GetAllCardsAsync();
    Task<List<Card>> GetAllTodaysCardsAsync();
    Task<Card> AddCardAsync(Card card);
    Task<bool> DeleteCardAsync(Guid id);
    Task<bool> UpdateCardAsync(Card card);
}
