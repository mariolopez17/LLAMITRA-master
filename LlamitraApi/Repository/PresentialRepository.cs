using LlamitraApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LlamitraApi.Repository.IRepository;

public class PresentialRepository: IPresentialRepository
{
    private readonly ProyectoIContext _context;

    public PresentialRepository(ProyectoIContext context)
    {
        _context = context;
    }

    public async Task AddPresential(Presential presential)
    {
        await _context.Presentials.AddAsync(presential);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Presential>> GetAllPresential()
    {
        return await _context.Presentials.ToListAsync();
    }

    public async Task<Presential> GetPresentialById(int id)
    {
        return await _context.Presentials.FirstOrDefaultAsync(p => p.IdPresential == id);
    }

    public Task UpdatePresential(Presential presential)
    {
        throw new NotImplementedException();
    }

    public async Task DeletePresential(Presential presential)
    {
        _context.Presentials.Remove(presential);
        await _context.SaveChangesAsync();
    }

}
