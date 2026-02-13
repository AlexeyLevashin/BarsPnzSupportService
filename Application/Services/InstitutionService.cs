using Application.Dto.Institutions.Requests;
using Application.Dto.Institutions.Responses;
using Application.Interfaces;
using Domain.DbModels;
using Domain.Interfaces;
using Mapster;

namespace Application.Services;

public class InstitutionService : IInstitutionService
{
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InstitutionService(IInstitutionRepository institutionRepository, IUnitOfWork unitOfWork)
    {
        _institutionRepository = institutionRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<CreateInstitutionResponse> AddAsync(CreateInstitutionRequest request)
    {
        var institution = await _institutionRepository.GetByInnAsync(request.INN);

        if (institution is not null)
        {
            throw new Exception("Учреждение с данным ИНН уже существует в системе");
        }

        var newInstitution = request.Adapt<DbInstitution>();
        await _institutionRepository.AddAsync(newInstitution);
        await _unitOfWork.SaveChangesAsync();

        return newInstitution.Adapt<CreateInstitutionResponse>();
    }
}