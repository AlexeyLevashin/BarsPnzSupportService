using Application.Dto.Institutions.Requests;
using Application.Dto.Institutions.Responses;
using Domain.DbModels;

namespace Application.Interfaces;

public interface IInstitutionService
{
    public Task<CreateInstitutionResponse> AddAsync(CreateInstitutionRequest createInstitutionDto);
    // public Task<DbInstitution> UpdateAsync(UpdateInstitutionDto updateInstitutionDto);
    // public Task<DbInstitution> DeleteAsync(CreateInstitutionDto createInstitutionDto);
}