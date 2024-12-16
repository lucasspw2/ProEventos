using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos;

    public interface IPalestrantePersist
    {
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool IncludeEventos = false);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool IncludeEventos = false);
        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool IncludeEventos = false);

    }
