using AutoMapper;
using BLL.Abstractions;
using BLL.Abstractions.DTO;
using BLL.Abstractions.DTO.Page;
using BLL.Abstractions.Exceptions;
using BLL.Abstractions.Infrastructure;
using BLL.Abstractions.Services;
using BLL.Infrastructure;
using DAL.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TourService : ServiceBase, ITourService
    {
        private readonly IUnit _unit;
        private readonly IMapper _mapper;

        public TourService(IUnit unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<TourDTO> GetTourAsync(int id)
        {
            var tour = await _unit.TourRepository.GetAsync(id);

            ValidateEntity(tour);

            return _mapper.Map<TourDTO>(tour);
        }

        public async Task<IEnumerable<TourDTO>> GetToursAsync(PageDTO page)
        {
            var tours = await _unit.TourRepository.GetAllAsync(_mapper.Map<Page>(page));
            return _mapper.Map<IEnumerable<TourDTO>>(tours);
        }

        public async Task<int> CreateTourAsync(TourDTO tour)
        {
            var tourToAdd = _mapper.Map<Tour>(tour);
            var resId = await _unit.TourRepository.CreateAsync(tourToAdd);

            if ((resId ?? 0) == 0)
                throw new OperationCanceledException();

            return resId.Value;
        }

        public async Task UpdateTourAsync(TourDTO tour)
        {
            var tourToUpdate = _mapper.Map<Tour>(tour);
            await _unit.TourRepository.UpdateAsync(tourToUpdate);
        }

        public async Task DeleteTourAsync(int id)
        {
            var tourToDel = await _unit.TourRepository.GetAsync(id);

            ValidateEntity(tourToDel);

            await _unit.TourRepository.DeleteAsync(tourToDel);
        }
    }
}
