using FlashCardsPc.DbConfiguration;
using FlashCardsPc.Models;
using Microsoft.EntityFrameworkCore;

namespace FlashCardsPc.Repository;
public class CardsRepository : ICardsRepository
{
    private readonly FlashcardContext _context;
    public CardsRepository(FlashcardContext context)
    {
        _context = context;
    }

    public async Task<List<Card>> GetAllCardsAsync()
    {
        return await _context.Cards.ToListAsync();
    }

    public async Task<Card> AddCardAsync(Card card)
    {
        await _context.Cards.AddAsync(card);
        await _context.SaveChangesAsync();

        return card;
    }

    public async Task<bool> DeleteCardAsync(Guid id)
    {
        var cardToRemove = await _context.Cards.FirstOrDefaultAsync(x => x.Id == id);
        if(cardToRemove is null)
        {
            return false;
        }

        _context.Cards.Remove(cardToRemove);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Card>> GetAllTodaysCardsAsync()
    {
        return await _context.Cards.Where(x => x.NextAppareance.Date <= DateTime.UtcNow.Date).ToListAsync();
    }

    public async Task<bool> UpdateCardAsync(Card card)
    {
        var cardToUpdate = await _context.Cards.FirstOrDefaultAsync(x => x.Id == card.Id);
        if (cardToUpdate is null)
        {
            return false;
        }

        cardToUpdate.NextAppareance = card.NextAppareance;
        cardToUpdate.IsRectoSide = card.IsRectoSide;
        cardToUpdate.Recto = card.Recto;
        cardToUpdate.Verso = card.Verso;
        cardToUpdate.Strike = card.Strike;

        _context.Cards.Update(cardToUpdate);
        await _context.SaveChangesAsync();
        return true;
    }
}
