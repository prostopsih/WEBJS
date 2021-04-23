using BLL.Abstractions.DTO;
using BLL.Abstractions.DTO.Page;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions.Services
{
    public interface ITourService
    {
        Task<TourDTO> GetTourAsync(int id);
        Task<IEnumerable<TourDTO>> GetToursAsync(PageDTO page);
        Task<int> CreateTourAsync(TourDTO tour);
        Task UpdateTourAsync(TourDTO tour);
        Task DeleteTourAsync(int id);
    }
}
